using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.BusinessLogics.Interface;
using HRMS_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class DepartmentsImp : IDepartment
    {
        private readonly HRMSContext _hrmsContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtUtils _jwtUtils;
        private List<string>? dToken;
        private int? _decodedToken;
        public DepartmentsImp(HRMSContext hrmsContext, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils)
        {
            _hrmsContext = hrmsContext;
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
                    var userDetails = _hrmsContext.EmployeeCredentials.FirstOrDefault(e => e.Id == userId.Value);
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
        public async Task<bool> deleteDepartment(int id)
        {
            DecodeToken();
            var result = (from row in _hrmsContext.Departments
                          where row.Id == id
                          select row).SingleOrDefault();
            _hrmsContext.Departments.Remove(result);
            await _hrmsContext.SaveChangesAsync(_decodedToken);
            return true;
        }

        public List<Department> GetAllDepartment()
        {
            var result = (from row in _hrmsContext.Departments
                          where  row.IsActive == 1
                          select row).ToList();
            return result;
        }

        public Department GetDepartmentById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetDepartmentsByName(string name)
        {
            var dept = (from row in _hrmsContext.Departments
                        where row.Name == name && row.IsActive == 1
                        select row).ToList();
            return dept;
        }

        public async Task<string> InsertDepartment(Department department)
        {
            DecodeToken();
            _hrmsContext.Departments.Add(department);
            var result = await _hrmsContext.SaveChangesAsync(_decodedToken);
            if (result != 0)
            {
                return "new Department inserted successfully";

            }
            else
            {
                return "failed to insert new data";
            }
        }

        public async Task<Department> UpdateDepartment(int id, string? name, int? requestedcompanyId)
        {
            var result = _hrmsContext.Departments.SingleOrDefault(p => p.Id == id);
            if (result == null)
            {
                // Handle the case where the user with the specified id doesn't exist
                return null;
            }
            result.Name = name;
            result.RequestedCompanyId = requestedcompanyId;
            _hrmsContext.Departments.Update(result);
            await _hrmsContext.SaveChangesAsync(_decodedToken);
            return result;
        }

        public bool SoftDelete(int id, short isActive)
        {
            var res = (from row in _hrmsContext.Departments
                       where row.Id == id
                       select row).FirstOrDefault();
            if (res != null)
            {
                res.IsActive = isActive;
                _hrmsContext.Departments.Update(res);
                _hrmsContext.SaveChanges();
                return true;

            }
            return false;
        }
    }
}
