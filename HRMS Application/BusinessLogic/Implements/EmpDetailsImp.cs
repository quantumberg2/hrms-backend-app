using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.BusinessLogics.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class EmpDetailsImp : IEmpDetails
    {
        private readonly HRMSContext _hrmsContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtUtils _jwtUtils;
        public List<string>? dToken;
        private int? _decodedToken;
        private readonly IEmailPassword _emailPasswordService;

        public EmpDetailsImp(HRMSContext hrmsContext, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils,IEmailPassword emailPasswordService)
        {
            _hrmsContext = hrmsContext;
            _httpContextAccessor = httpContextAccessor;
            _jwtUtils = jwtUtils;
            _emailPasswordService = emailPasswordService;
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
        public async Task<bool> DeleteEmployeeDetail(int id)
        {
            DecodeToken();
            var result = (from row in _hrmsContext.EmployeeDetails
                          where row.Id == id
                          select row).SingleOrDefault();
            _hrmsContext.EmployeeDetails.Remove(result);
            await _hrmsContext.SaveChangesAsync(_decodedToken);
            return true;
        }

        public List<EmployeeDetail> GetAllUser()
        {
            var result = (from row in _hrmsContext.EmployeeDetails
                          where  row.IsActive == 1
                          select row).ToList();
            return result;
        }

        public EmployeeDetail GetById(int id)
        {
            var res = (from row in _hrmsContext.EmployeeDetails
                       where row.Id == id && row.IsActive == 1
                       select row).FirstOrDefault();
            return res;
        }

        public async Task<string> InsertEmployeeAsync(EmployeeDetail employeeDetail, int companyId)
        {
            DecodeToken();
            // Check if the email already exists for the same company
            var existingEmail = await _hrmsContext.EmployeeCredentials
                .SingleOrDefaultAsync(e => e.Email == employeeDetail.Email && e.RequestedCompanyId == companyId);

            if (existingEmail != null)
            {
                return $"Email '{employeeDetail.Email}' is already in use for company ID '{companyId}'.";
            }

            var employeeCredential = new EmployeeCredential
            {
                UserName = employeeDetail.Email, // Username is set to the email address
                Email = employeeDetail.Email,
                Password = GeneratePassword(),
                DefaultPassword = true,
                RequestedCompanyId = companyId
            };

            _hrmsContext.EmployeeCredentials.Add(employeeCredential);
            await _hrmsContext.SaveChangesAsync(_decodedToken);

            // Set the EmployeeCredentialId in EmployeeDetail
            employeeDetail.EmployeeCredentialId = employeeCredential.Id;
            employeeDetail.RequestCompanyId = companyId;
            employeeDetail.DeptId = null;
            employeeDetail.PositionId = null;

            _hrmsContext.EmployeeDetails.Add(employeeDetail);
            await _hrmsContext.SaveChangesAsync(_decodedToken);

            // Assign "User" role to the employee
            var userRole = new UserRolesJ
            {
                EmployeeCredentialId = employeeCredential.Id,
                RolesId = 2 // Assuming "2" is the ID for the "User" role
            };

            _hrmsContext.UserRolesJs.Add(userRole);
            await _hrmsContext.SaveChangesAsync(_decodedToken);

            // Send email with username and password
            await _emailPasswordService.SendOtpEmailAsync(new Generatepassword
            {
                EmailAddress = employeeCredential.Email,
                Password = employeeCredential.Password,
                UserName = employeeCredential.UserName
            });

            return "Employee inserted successfully and credentials sent via email.";
        }

        private string GeneratePassword()
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var res = new char[8];
            var rnd = new Random();
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = valid[rnd.Next(valid.Length)];
            }
            return new string(res);
        }



        public async Task<EmployeeDetail> UpdateEmployeeDetail(int id, int? depId, string? fname, string? mname, string? lname, int? positionid, string? Designation, string? Email, int? employeecredentialId, string? EmployeeNumber, int? requsetCompanyId)
        {
            DecodeToken();
            var result = _hrmsContext.EmployeeDetails.SingleOrDefault(p => p.Id == id);
            if (result == null)
            {
                // Handle the case where the user with the specified id doesn't exist
                return null;
            }

            // Update only the fields that have non-null values passed to the method
            result.DeptId = depId ?? result.DeptId;
            result.FirstName = fname ?? result.FirstName;
            result.MiddleName = mname ?? result.MiddleName;
            result.LastName = lname ?? result.LastName;
            result.PositionId = positionid ?? result.PositionId;
            result.EmployeeCredentialId = employeecredentialId ?? result.EmployeeCredentialId;
            result.Email = Email ?? result.Email;
            result.EmployeeNumber = EmployeeNumber ?? result.EmployeeNumber;
            result.RequestCompanyId = requsetCompanyId ?? result.RequestCompanyId;
             
            _hrmsContext.EmployeeDetails.Update(result);
            await _hrmsContext.SaveChangesAsync(_decodedToken);
            return result;
        }

        public bool SoftDelete(int id, short isActive)
        {
            var res = (from row in _hrmsContext.EmployeeDetails
                       where row.Id == id
                       select row).FirstOrDefault();
            if (res != null)
            {
                res.IsActive = isActive;
                _hrmsContext.EmployeeDetails.Update(res);
                _hrmsContext.SaveChanges();
                return true;

            }
            return false;
        }
        public IEnumerable<EmployeeView> GetAllEmployees()
        {
            var employees = _hrmsContext.EmployeeDetails
                .Include(e => e.EmployeeCredential)
                .Include(e => e.Position)
                .Include(e => e.Dept)
                .Include(e => e.EmployeeCredential.AddressInfos)
                .Include(e => e.EmployeeCredential.EmpPersonalInfos)
                .ToList();

            return employees.Select(employee => new EmployeeView
            {
                EmployeeId = employee.Id,
                EmployeeName = $"{employee.FirstName} {employee.MiddleName} {employee.LastName}",
                Address = employee.EmployeeCredential.AddressInfos.FirstOrDefault()?.AddressLine1,
                Gender = employee.EmployeeCredential.EmpPersonalInfos.FirstOrDefault()?.Gender,
                DOB = employee.EmployeeCredential.EmpPersonalInfos.FirstOrDefault()?.Dob.ToString(),
                Designation = employee.Position?.Name,
               // Manager = employee.ManagerId.HasValue ? _hrmsContext.EmployeeDetails.FirstOrDefault(m => m.Id == employee.ManagerId.Value)?.FirstName : "N/A"
               Manager = employee.ManagerId.HasValue ? _hrmsContext.EmployeeDetails.FirstOrDefault(m => m.EmployeeCredentialId == employee.ManagerId.Value)?.FirstName : "N/A"
            }).ToList();
        }
    }
}
