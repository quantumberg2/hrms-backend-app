﻿using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HRMS_Application.BusinessLogic.Implements
{

    public class EmployeeSalaryImp : IEmployeeSalary
    {
        private HRMSContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtUtils _jwtUtils;
        private List<string>? dToken;
        private int? _decodedToken;
        public EmployeeSalaryImp(HRMSContext context, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _jwtUtils = jwtUtils;
        }
        private void DecodeToken()
        {
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (string.IsNullOrEmpty(token))
            {
                dToken = null;
            }
            else
            {
                var userId = _jwtUtils.ValidateJwtToken(token);
                if (userId.HasValue)
                {
                    var userDetails = _context.EmployeeCredentials.FirstOrDefault(e => e.Id == userId.Value);
                    if (userDetails != null)
                    {
                        _decodedToken = userDetails.Id;
                        dToken = userDetails.UserRolesJs.Select(ur => ur.Roles.Name).ToList(); // Assuming you want role names
                    }
                    else
                    {
                        // Handle the case where the user is not found in the database
                        dToken = null;
                    }
                }
            }
        }
        public async Task<bool> deleteEmpsalary(int id)
        {
            DecodeToken();
            var result = (from row in _context.EmpSalaries
                          where row.Id == id
                          select row).SingleOrDefault();
            _context.EmpSalaries.Remove(result);
            await _context.SaveChangesAsync(_decodedToken);
            return true;
        }

        public List<EmpSalary> GetAllEmpSalary()
        {
            var result = (from row in _context.EmpSalaries
                          where row.IsActive == 1
                          select row).ToList();
            return result;
        }

        public EmpSalary GetEmpSalaryById(int id)
        {
            var result = (from row in _context.EmpSalaries
                          where row.Id == id && row.IsActive == 1
                          select row).FirstOrDefault();

            return result;
        }

        public async Task<string> InsertEmpSalary(EmpSalary empSalary)
        {
            _context.EmpSalaries.Add(empSalary);
            var result = await _context.SaveChangesAsync();
            if (result != 0)
            {
                return "new Department inserted successfully";

            }
            else
            {
                return "failed to insert new data";
            }
        }

        public bool SoftDelete(int id, short isActive)
        {
            var res = (from row in _context.EmpSalaries
                       where row.Id == id
                       select row).FirstOrDefault();
            if (res != null)
            {
                res.IsActive = isActive;
                _context.EmpSalaries.Update(res);
                _context.SaveChanges();
                return true;

            }
            return false;
        }
    }
}
