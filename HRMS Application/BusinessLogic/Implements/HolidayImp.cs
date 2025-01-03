﻿using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.BusinessLogics.Interface;
using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class HolidayImp : IHoliday
    {
        private readonly HRMSContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtUtils _jwtUtils;
        private List<string>? dToken;
        private int? _decodedToken;
        public HolidayImp(HRMSContext context, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils)
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
        public async Task<bool> deleteHoliday(int id)
        {
            DecodeToken();
            var result = (from row in _context.Holidays
                          where row.Id == id
                          select row).SingleOrDefault();
            _context.Holidays.Remove(result);
            await _context.SaveChangesAsync(_decodedToken);
            return true;
        }



        public List<Holiday> GetHoliday(int companyId)
        {
            var result = (from row in _context.Holidays
                          where row.IsActive == 1 && row.CompanyId == companyId 
                          select row).ToList();
            return result;
        }

        public Holiday GetHolidayById(int id)
        {
            var result = (from row in _context.Holidays
                          where row.Id == id && row.IsActive == 1
                          select row).FirstOrDefault();
            return result;
        }

        public async Task<string> InsertHoliday(Holiday holiday)
        {
            DecodeToken();
            _context.Holidays.Add(holiday);
            var result = await _context.SaveChangesAsync(_decodedToken);
            if (result != 0)
            {
                return "new Holidays inserted successfully";

            }
            else
            {
                return "failed to insert new data";
            }
        }
        public bool SoftDelete(int id, short isActive)
        {
            var res = (from row in _context.Holidays
                       where row.Id == id
                       select row).FirstOrDefault();
            if (res != null)
            {
                res.IsActive = isActive;
                _context.Holidays.Update(res);
                _context.SaveChanges();
                return true;

            }
            return false;
        }

        public Holiday UpdateHolidayType(int id, string? name, DateOnly? date, string? occasion, int? requestedCompanyId)
        {
       
            var holiday = _context.Holidays.SingleOrDefault(row => row.Id == id);

            if (holiday == null)
            {
                return null; 
            }

           
            holiday.Type = name ?? holiday.Type; 
            holiday.CompanyId = requestedCompanyId ?? holiday.CompanyId; 
            holiday.Date = date?.ToDateTime(TimeOnly.MinValue) ?? holiday.Date; 
            holiday.Occasion = occasion ?? holiday.Occasion; 

            _context.SaveChanges();

            return holiday;
        }


    }
}
