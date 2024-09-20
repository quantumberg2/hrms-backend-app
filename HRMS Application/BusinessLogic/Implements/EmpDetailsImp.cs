using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.BusinessLogics.Interface;
using HRMS_Application.DTO;
using HRMS_Application.GlobalSearch;
using HRMS_Application.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using OfficeOpenXml.FormulaParsing;
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
            var result =await (from row in _hrmsContext.EmployeeDetails
                          where row.Id == id
                          select row).FirstOrDefaultAsync();
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
                RequestedCompanyId = companyId,
                IsActive = 1
                
            };

            await _hrmsContext.EmployeeCredentials.AddAsync(employeeCredential);
            await _hrmsContext.SaveChangesAsync(_decodedToken);

            // Set the EmployeeCredentialId in EmployeeDetail
            employeeDetail.EmployeeCredentialId = employeeCredential.Id;
            employeeDetail.RequestCompanyId = companyId;
            employeeDetail.DeptId = null;
            employeeDetail.IsActive = 1;
            await _hrmsContext.EmployeeDetails.AddAsync(employeeDetail);
            await _hrmsContext.SaveChangesAsync(_decodedToken);

            // Assign "User" role to the employee
            var userRole = new UserRolesJ
            {
                EmployeeCredentialId = employeeCredential.Id,
                RolesId = 2 ,// Assuming "2" is the ID for the "User" role
                IsActive =1
                
            };

            await _hrmsContext.UserRolesJs.AddAsync(userRole);
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
            var result = await _hrmsContext.EmployeeDetails.SingleOrDefaultAsync(p => p.Id == id);

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
        public async Task<UpdateEmployeeInfoDTO> GetEmployeeInfoAsync(int employeeCredentialId)
        {
            // Fetch employee details by EmployeeCredentialId
            var employeeDetail = await _hrmsContext.EmployeeDetails
                .FirstOrDefaultAsync(e => e.EmployeeCredentialId == employeeCredentialId);

            var employeeCredential = await _hrmsContext.EmployeeCredentials
                .FirstOrDefaultAsync(ec => ec.Id == employeeCredentialId);

            var employeePersonalInfo = await _hrmsContext.EmpPersonalInfos
                .FirstOrDefaultAsync(ep => ep.EmployeeCredentialId == employeeCredentialId);

            // Check if all necessary data exists
            if (employeeDetail == null || employeeCredential == null || employeePersonalInfo == null)
            {
                return null; // No data found for the given EmployeeCredentialId
            }

            // Combine the data into the DTO and return
            return new UpdateEmployeeInfoDTO
            {
                EmployeeCredentialId = employeeCredentialId,
                EmployeeName = employeeDetail.FirstName,
                NickName = employeeDetail.NickName,
                EmailAddress = employeeDetail.Email,
                MobileNumber = employeeDetail.MobileNumber,
                Extension = employeeDetail.Extension,
                EmpLoginName = employeeCredential.EmployeeLoginName,
                gender = employeePersonalInfo.Gender
            };
        }
        public async Task<EmpPersonalInfoDTO> GetEmployeePersonalInfoAsync(int employeeCredentialId)
        {
            var employeePersonalInfo = await _hrmsContext.EmpPersonalInfos
                .FirstOrDefaultAsync(ep => ep.EmployeeCredentialId == employeeCredentialId);
            var employyedetail = await _hrmsContext.EmployeeDetails
                .FirstOrDefaultAsync(ed => ed.EmployeeCredentialId == employeeCredentialId);

            if (employeePersonalInfo == null)
            {
                return null; // Return null if no personal information found
            }

            // Map the entity data to the DTO
            return new EmpPersonalInfoDTO
            {
                FirstName = employyedetail.FirstName,
                MiddleName = employyedetail.MiddleName,
                LastName = employyedetail.LastName,
                Contact = employyedetail.MobileNumber,
                EmployeeCredentialId = employeePersonalInfo.EmployeeCredentialId,
                Gender = employeePersonalInfo.Gender,
                EmailId = employeePersonalInfo.EmailId,
                PersonalEmail = employeePersonalInfo.PersonalEmail,
                Dob = employeePersonalInfo.Dob,
                DateOfJoining = employeePersonalInfo.DateOfJoining,
                ConfirmDate = employeePersonalInfo.ConfirmDate,
                EmpStatus = employeePersonalInfo.EmpStatus,
                PAN = employeePersonalInfo.Pan,
                MaritalStatus = employeePersonalInfo.MaritalStatus,
                BloodGroup = employeePersonalInfo.BloodGroup,
                SpouseName = employeePersonalInfo.SpouseName,
                PhysicallyChallenged = employeePersonalInfo.PhysicallyChallenged,
                EmergencyContact = employeePersonalInfo.EmergencyContact
            };
        }
        public async Task<AddressInfoDTO> GetEmployeeAddressInfoAsync(int employeeCredentialId)
        {
            var employeeAddress = await _hrmsContext.AddressInfos
                .FirstOrDefaultAsync(e => e.EmployeeCredentialId == employeeCredentialId);

            if (employeeAddress == null)
            {
                return null; // Return null if no address info found
            }

            // Map the entity data to the DTO
            return new AddressInfoDTO
            {
                EmployeeCredentialId = employeeAddress.EmployeeCredentialId,
                AddressLine1 = employeeAddress.AddressLine1,
                AddressLine2 = employeeAddress.AddressLine2,
                City = employeeAddress.City,
                State = employeeAddress.State,
                Country = employeeAddress.Country,
                PinCode = employeeAddress.PinCode
            };
        }
        public async Task<AccountDetail> GetEmployeeAccountInfoAsync(int employeeCredentialId)
        {
            var accountDetail = await _hrmsContext.AccountDetails
                .FirstOrDefaultAsync(e => e.EmployeeCredentialId == employeeCredentialId);

            if (accountDetail == null)
            {
                return null; // Return null if no account info found
            }

            // Map the entity data to the DTO
            return new AccountDetail
            {
                EmployeeCredentialId = accountDetail.EmployeeCredentialId,
                AadharNumber = accountDetail.AadharNumber,
                AccountNumber = accountDetail.AccountNumber,
                PfNumber = accountDetail.PfNumber,
                UanNumber = accountDetail.UanNumber,
                BankName = accountDetail.BankName,
                AccountType = accountDetail.AccountType,
                BranchName = accountDetail.BranchName,
                City = accountDetail.City,
                Country = accountDetail.Country,
                State = accountDetail.State,
                PfJoiningDate = accountDetail.PfJoiningDate,
                Pin = accountDetail.Pin,
                EligibleForPf = accountDetail.EligibleForPf,
                IfscCode = accountDetail.IfscCode
            };
        }
        public List<EmployeeDetail> GetFilters(GlobalsearchEmp globalSearch)
        {
            List<EmployeeDetail> mm = new List<EmployeeDetail>();
            var filterby = globalSearch.FilterBy.Trim().ToLowerInvariant();
            if (!string.IsNullOrEmpty(filterby))
            {
                var query = _hrmsContext.EmployeeDetails.Where(f => f.FirstName.ToLower().Contains(filterby)
                || f.LastName.ToLower().Contains(filterby)
                || f.MiddleName.ToLower().Contains(filterby)
                || f.Email.ToLower().Contains(filterby)
                ||f.EmployeeNumber.ToLower().Contains(filterby)
                ||f.EmployeeCredentialId.ToString().Contains(filterby));
                mm = query.ToList();
            }
            return mm;
        }
        public async Task<bool> UpdateEmployeeInfoAsync(UpdateEmployeeInfoDTO updateEmployeeInfo)
        {
            // Check if the employee, credential, and personal info exist
            var employeeDetail = await _hrmsContext.EmployeeDetails
                .FirstOrDefaultAsync(e => e.EmployeeCredentialId == updateEmployeeInfo.EmployeeCredentialId);

            var employeeCredential = await _hrmsContext.EmployeeCredentials
                .FirstOrDefaultAsync(ec => ec.Id == updateEmployeeInfo.EmployeeCredentialId);

            var employeepersonalinfo = await _hrmsContext.EmpPersonalInfos
                .FirstOrDefaultAsync(ep => ep.EmployeeCredentialId == updateEmployeeInfo.EmployeeCredentialId);

            // If employee, credential, or personal info doesn't exist, create new ones
            if (employeeDetail == null)
            {
                employeeDetail = new EmployeeDetail
                {
                    EmployeeCredentialId = updateEmployeeInfo.EmployeeCredentialId,
                    FirstName = updateEmployeeInfo.EmployeeName,
                    NickName = updateEmployeeInfo.NickName,
                    Email = updateEmployeeInfo.EmailAddress,
                    MobileNumber = updateEmployeeInfo.MobileNumber,
                    Extension = updateEmployeeInfo.Extension,
                    IsActive =1,
                };
                await _hrmsContext.EmployeeDetails.AddAsync(employeeDetail);
            }
            else
            {
                // Update only the fields provided in the DTO, keeping other values unchanged
                employeeDetail.FirstName = updateEmployeeInfo.EmployeeName ?? employeeDetail.FirstName;
                employeeDetail.NickName = updateEmployeeInfo.NickName ?? employeeDetail.NickName;
                employeeDetail.Email = updateEmployeeInfo.EmailAddress ?? employeeDetail.Email;
                employeeDetail.MobileNumber = updateEmployeeInfo.MobileNumber ?? employeeDetail.MobileNumber;
                employeeDetail.Extension = updateEmployeeInfo.Extension ?? employeeDetail.Extension;

                _hrmsContext.EmployeeDetails.Update(employeeDetail);
            }

            if (employeeCredential == null)
            {
                return false;
            }
            else
            {
                employeeCredential.EmployeeLoginName = updateEmployeeInfo.EmpLoginName ?? employeeCredential.EmployeeLoginName;
                employeeCredential.Email = updateEmployeeInfo.EmailAddress ?? employeeCredential.Email;

                _hrmsContext.EmployeeCredentials.Update(employeeCredential);
            }

            if (employeepersonalinfo == null)
            {
                employeepersonalinfo = new EmpPersonalInfo
                {
                    EmployeeCredentialId = updateEmployeeInfo.EmployeeCredentialId,
                    Gender = updateEmployeeInfo.gender,
                    IsActive = 1
                };
                await _hrmsContext.EmpPersonalInfos.AddAsync(employeepersonalinfo);
            }
            else
            {
                employeepersonalinfo.Gender = updateEmployeeInfo.gender ?? employeepersonalinfo.Gender;
                _hrmsContext.EmpPersonalInfos.Update(employeepersonalinfo);
            }

            // Save changes to the database
            await _hrmsContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateEmployeepersonalInfoAsync(EmpPersonalInfoDTO empPersonalInfo)
        {
            // Check if EmployeeDetail exists
            var employeeDetail = await _hrmsContext.EmployeeDetails
                .FirstOrDefaultAsync(e => e.EmployeeCredentialId == empPersonalInfo.EmployeeCredentialId);

            // Check if EmployeeCredential exists
            var employeeCredential = await _hrmsContext.EmployeeCredentials
                .FirstOrDefaultAsync(ec => ec.Id == empPersonalInfo.EmployeeCredentialId);

            // Check if EmpPersonalInfo exists
            var employeepersonalinfo = await _hrmsContext.EmpPersonalInfos
                .FirstOrDefaultAsync(ep => ep.EmployeeCredentialId == empPersonalInfo.EmployeeCredentialId);

            // If none of the records exist, create new ones
            if (employeeDetail == null)
            {
                employeeDetail = new EmployeeDetail
                {
                    FirstName = empPersonalInfo.FirstName,
                    MiddleName = empPersonalInfo.MiddleName,
                    LastName = empPersonalInfo.LastName,
                    Email = empPersonalInfo.EmailId,
                    MobileNumber = empPersonalInfo.Contact,
                    EmployeeCredentialId = empPersonalInfo.EmployeeCredentialId,
                    IsActive =1
                    
                };
                await _hrmsContext.EmployeeDetails.AddAsync(employeeDetail);
            }
            else
            {
                // Update existing employee detail
                employeeDetail.FirstName = empPersonalInfo.FirstName ?? employeeDetail.FirstName;
                employeeDetail.MiddleName = empPersonalInfo.MiddleName ?? employeeDetail.MiddleName;
                employeeDetail.LastName = empPersonalInfo.LastName ?? employeeDetail.LastName;
                employeeDetail.Email = empPersonalInfo.EmailId ?? employeeDetail.Email;
                employeeDetail.MobileNumber = empPersonalInfo.Contact ?? employeeDetail.MobileNumber;

                _hrmsContext.EmployeeDetails.Update(employeeDetail);
            }

            if (employeeCredential == null)
            {
                return false;
            }
            else
            {
                // Update existing employee credential
                employeeCredential.Email = empPersonalInfo.EmailId ?? employeeCredential.Email;

                _hrmsContext.EmployeeCredentials.Update(employeeCredential);
            }

            if (employeepersonalinfo == null)
            {
                employeepersonalinfo = new EmpPersonalInfo
                {
                    EmployeeCredentialId = empPersonalInfo.EmployeeCredentialId,
                    Gender = empPersonalInfo.Gender,
                    EmailId = empPersonalInfo.EmailId,
                    PersonalEmail = empPersonalInfo.PersonalEmail,
                    Dob = empPersonalInfo.Dob,
                    DateOfJoining = empPersonalInfo.DateOfJoining,
                    ConfirmDate = empPersonalInfo.ConfirmDate,
                    EmpStatus = empPersonalInfo.EmpStatus,
                    Pan = empPersonalInfo.PAN,
                    MaritalStatus = empPersonalInfo.MaritalStatus,
                    BloodGroup = empPersonalInfo.BloodGroup,
                    SpouseName = empPersonalInfo.SpouseName,
                    PhysicallyChallenged = empPersonalInfo.PhysicallyChallenged,
                    EmergencyContact = empPersonalInfo.EmergencyContact,
                    IsActive =1
                };
                await _hrmsContext.EmpPersonalInfos.AddAsync(employeepersonalinfo);
            }
            else
            {
                // Update existing employee personal info
                employeepersonalinfo.Gender = empPersonalInfo.Gender ?? employeepersonalinfo.Gender;
                employeepersonalinfo.EmailId = empPersonalInfo.EmailId ?? employeepersonalinfo.EmailId;
                employeepersonalinfo.PersonalEmail = empPersonalInfo.PersonalEmail ?? employeepersonalinfo.PersonalEmail;
                employeepersonalinfo.Dob = empPersonalInfo.Dob ?? employeepersonalinfo.Dob;
                employeepersonalinfo.DateOfJoining = empPersonalInfo.DateOfJoining ?? employeepersonalinfo.DateOfJoining;
                employeepersonalinfo.ConfirmDate = empPersonalInfo.ConfirmDate ?? employeepersonalinfo.ConfirmDate;
                employeepersonalinfo.EmpStatus = empPersonalInfo.EmpStatus ?? employeepersonalinfo.EmpStatus;
                employeepersonalinfo.Pan = empPersonalInfo.PAN ?? employeepersonalinfo.Pan;
                employeepersonalinfo.MaritalStatus = empPersonalInfo.MaritalStatus ?? employeepersonalinfo.MaritalStatus;
                employeepersonalinfo.BloodGroup = empPersonalInfo.BloodGroup ?? employeepersonalinfo.BloodGroup;
                employeepersonalinfo.SpouseName = empPersonalInfo.SpouseName ?? employeepersonalinfo.SpouseName;
                employeepersonalinfo.PhysicallyChallenged = empPersonalInfo.PhysicallyChallenged ?? employeepersonalinfo.PhysicallyChallenged;
                employeepersonalinfo.EmergencyContact = empPersonalInfo.EmergencyContact ?? employeepersonalinfo.EmergencyContact;

                _hrmsContext.EmpPersonalInfos.Update(employeepersonalinfo);
            }

            // Save changes to the database
            await _hrmsContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateEmployeeAddresslInfoAsync(AddressInfoDTO addressInfo)
        {
            // Check if the AddressInfo record exists for the given EmployeeCredentialId
            var employeeAddress = await _hrmsContext.AddressInfos
                .FirstOrDefaultAsync(e => e.EmployeeCredentialId == addressInfo.EmployeeCredentialId);

            if (employeeAddress == null)
            {
                // If no record exists, create a new AddressInfo entry
                employeeAddress = new AddressInfo
                {
                    EmployeeCredentialId = addressInfo.EmployeeCredentialId,
                    AddressLine1 = addressInfo.AddressLine1,
                    AddressLine2 = addressInfo.AddressLine2,
                    City = addressInfo.City,
                    State = addressInfo.State,
                    Country = addressInfo.Country,
                    PinCode = addressInfo.PinCode,
                    IsActive =1
                };

                await _hrmsContext.AddressInfos.AddAsync(employeeAddress); // Insert new record
            }
            else
            {
                // If record exists, update the fields that are provided, keep existing values for others
                employeeAddress.AddressLine1 = addressInfo.AddressLine1 ?? employeeAddress.AddressLine1;
                employeeAddress.AddressLine2 = addressInfo.AddressLine2 ?? employeeAddress.AddressLine2;
                employeeAddress.City = addressInfo.City ?? employeeAddress.City;
                employeeAddress.State = addressInfo.State ?? employeeAddress.State;
                employeeAddress.Country = addressInfo.Country ?? employeeAddress.Country;
                employeeAddress.PinCode = addressInfo.PinCode ?? employeeAddress.PinCode;

                _hrmsContext.AddressInfos.Update(employeeAddress); // Update the existing record
            }

            await _hrmsContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateEmployeeAccountInfoAsync(AccountDetail accountDetail)
        {
            // Check if the account already exists
            var existingAccountDetail = await _hrmsContext.AccountDetails
                .FirstOrDefaultAsync(e => e.EmployeeCredentialId == accountDetail.EmployeeCredentialId);

            // If account exists, update the existing fields
            if (existingAccountDetail != null)
            {
                existingAccountDetail.AadharNumber = accountDetail.AadharNumber ?? existingAccountDetail.AadharNumber;
                existingAccountDetail.AccountNumber = accountDetail.AccountNumber ?? existingAccountDetail.AccountNumber;
                existingAccountDetail.PfNumber = accountDetail.PfNumber ?? existingAccountDetail.PfNumber;
                existingAccountDetail.UanNumber = accountDetail.UanNumber ?? existingAccountDetail.UanNumber;
                existingAccountDetail.BankName = accountDetail.BankName ?? existingAccountDetail.BankName;
                existingAccountDetail.AccountType = accountDetail.AccountType ?? existingAccountDetail.AccountType;
                existingAccountDetail.BranchName = accountDetail.BranchName ?? existingAccountDetail.BranchName;
                existingAccountDetail.City = accountDetail.City ?? existingAccountDetail.City;
                existingAccountDetail.Country = accountDetail.Country ?? existingAccountDetail.Country;
                existingAccountDetail.State = accountDetail.State ?? existingAccountDetail.State;
                existingAccountDetail.PfJoiningDate = accountDetail.PfJoiningDate ?? existingAccountDetail.PfJoiningDate;
                existingAccountDetail.Pin = accountDetail.Pin ?? existingAccountDetail.Pin;
                existingAccountDetail.EligibleForPf = accountDetail.EligibleForPf ?? existingAccountDetail.EligibleForPf;
                existingAccountDetail.IfscCode = accountDetail.IfscCode ?? existingAccountDetail.IfscCode;
                
                _hrmsContext.AccountDetails.Update(existingAccountDetail);
            }
            // If account does not exist, create a new one
            else
            {
                AccountDetail newAccountDetail = new AccountDetail
                {
                    EmployeeCredentialId = accountDetail.EmployeeCredentialId,
                    AadharNumber = accountDetail.AadharNumber,
                    AccountNumber = accountDetail.AccountNumber,
                    PfNumber = accountDetail.PfNumber,
                    UanNumber = accountDetail.UanNumber,
                    BankName = accountDetail.BankName,
                    AccountType = accountDetail.AccountType,
                    BranchName = accountDetail.BranchName,
                    City = accountDetail.City,
                    Country = accountDetail.Country,
                    State = accountDetail.State,
                    PfJoiningDate = accountDetail.PfJoiningDate,
                    Pin = accountDetail.Pin,
                    EligibleForPf = accountDetail.EligibleForPf,
                    IfscCode = accountDetail.IfscCode,
                    IsActive =1
                };

                await _hrmsContext.AccountDetails.AddAsync(newAccountDetail);
            }

            // Save changes to the database
            await _hrmsContext.SaveChangesAsync();

            return true;
        }
        public EmployeeShiftAndLeaveStatsDto GetEmployeeShiftAndLeaveStats(int empCredentialId)
        {
            var currentDate = DateTime.Now.Date;  

            var shiftRoster = _hrmsContext.ShiftRosters
                .Where(sr => sr.EmpCredentialId == empCredentialId
                             && sr.Startdate.HasValue && sr.Startdate.Value.Date <= currentDate
                             && sr.Enddate.HasValue && sr.Enddate.Value.Date >= currentDate)
                .Include(sr => sr.ShiftRosterType)
                .FirstOrDefault();

            if (shiftRoster == null)
            {
                throw new Exception("No shift roster found for the current date.");
            }


            var leaveAllocations = _hrmsContext.EmployeeLeaveAllocations
                .Where(la => la.EmpCredentialId == empCredentialId && la.IsActive == 1)
                .Include(la => la.LeaveTypeNavigation)
                .ToList();

            var totalLeaveCount = leaveAllocations.Sum(la => la.NumberOfLeaves ?? 0);
            var remainingLeaveCount = leaveAllocations.Sum(la => la.RemainingLeave ?? 0);

            var leavePercentage = totalLeaveCount > 0 ? (remainingLeaveCount * 100) / totalLeaveCount : 0;

            var result = new EmployeeShiftAndLeaveStatsDto
            {
                ShiftType = shiftRoster.ShiftRosterType?.Type,
                ShiftTimeRange = shiftRoster.ShiftRosterType?.TimeRange,
                TotalLeaveCount = totalLeaveCount,
                RemainingLeaveCount = remainingLeaveCount,
                LeavePercentage = leavePercentage
            };

            return result;
        }

    }
}
