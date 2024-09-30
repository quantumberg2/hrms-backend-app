using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS_Application.BusinessLogic.Implements
{

    public class EmpLeaveAllocationImp : IEmpLeaveAllocation
    {
        private readonly HRMSContext _hrmsContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtUtils _jwtUtils;
        private List<string>? dToken;
        private int? _decodedToken;
        public EmpLeaveAllocationImp(HRMSContext hrmscontext, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils)
        {
            _hrmsContext = hrmscontext;
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
        public async Task<bool> DeleteEmployeeLeave(int id)
        {
            DecodeToken();
            var result = (from row in _hrmsContext.EmployeeLeaveAllocations
                          where row.Id == id
                          select row).SingleOrDefault();
            _hrmsContext.EmployeeLeaveAllocations.Remove(result);
            await _hrmsContext.SaveChangesAsync(_decodedToken);
            return true;
        }

        public List<EmployeeLeaveAllocation> GetAllEmpLeave()
        {
            var result = (from row in _hrmsContext.EmployeeLeaveAllocations
                          where row.IsActive == 1
                          select row).ToList();
            return result;
        }

        public EmployeeLeaveAllocation GetByEmpLeavebyId(int id)
        {
            var res = (from row in _hrmsContext.EmployeeLeaveAllocations
                       where row.Id == id && row.IsActive == 1
                       select row).FirstOrDefault();
            return res;
        }

        public async Task<string> InsertEmployeeLeave(EmployeeLeaveAllocation employeeLeave)
        {
            await _hrmsContext.EmployeeLeaveAllocations.AddAsync(employeeLeave);
            var result = await _hrmsContext.SaveChangesAsync(_decodedToken);
            if (result != 0)
            {
                return "new Employeeleave inserted successfully";

            }
            else
            {
                return "failed to insert new data";
            }
        }

        public bool SoftDelete(int id, short isActive)
        {
            var res = (from row in _hrmsContext.EmployeeLeaveAllocations
                       where row.Id == id
                       select row).FirstOrDefault();
            if (res != null)
            {
                res.IsActive = isActive;
                _hrmsContext.EmployeeLeaveAllocations.Update(res);
                _hrmsContext.SaveChanges();
                return true;

            }
            return false;
        }
        public async Task GrantLeaveAllocationAsync(EmployeeLeaveAllocationRequest request)
        {
            if (request.EmpCredentialId == null)
            {
                throw new ArgumentException("Employee credential ID is required.");
            }

            var empCredentialId = request.EmpCredentialId.Value;

            var existingAllocation = await _hrmsContext.EmployeeLeaveAllocations
                .FirstOrDefaultAsync(e => e.EmpCredentialId == empCredentialId && e.Year == request.Year && e.IsActive == 1);

            if (existingAllocation != null)
            {
                existingAllocation.NumberOfLeaves = request.NumberOfLeaves;
                existingAllocation.RemainingLeave = request.RemainingLeave ?? request.NumberOfLeaves;
                existingAllocation.LeaveType = request.LeaveType;

                _hrmsContext.EmployeeLeaveAllocations.Update(existingAllocation); 
            }
            else
            {
                var newLeaveAllocation = new EmployeeLeaveAllocation
                {
                    Year = request.Year,
                    EmpCredentialId = empCredentialId,
                    NumberOfLeaves = request.NumberOfLeaves,
                    RemainingLeave = request.RemainingLeave ?? request.NumberOfLeaves,
                    LeaveType = request.LeaveType,
                    IsActive = 1
                };

                await _hrmsContext.EmployeeLeaveAllocations.AddAsync(newLeaveAllocation);
            }

            await _hrmsContext.SaveChangesAsync();
        }
    }
}