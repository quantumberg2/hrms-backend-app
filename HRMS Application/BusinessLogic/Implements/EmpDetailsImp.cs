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
        private readonly IAzureOperations _azureOperations;

        public EmpDetailsImp(HRMSContext hrmsContext, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils,IEmailPassword emailPasswordService, IAzureOperations azureOperations)
        {
            _hrmsContext = hrmsContext;
            _httpContextAccessor = httpContextAccessor;
            _jwtUtils = jwtUtils;
            _emailPasswordService = emailPasswordService;
            _azureOperations = azureOperations;
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
            if (res == null)
            {
                throw new KeyNotFoundException($"EmployeeDetail with Id {id} not found.");
            }
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

            // Check if the EmployeeNumber already exists
            var existingEmployeeNumber = await _hrmsContext.EmployeeDetails
                .SingleOrDefaultAsync(e => e.EmployeeNumber == employeeDetail.EmployeeNumber && e.RequestCompanyId == companyId);

            if (existingEmployeeNumber != null)
            {
                return $"EmployeeNumber '{employeeDetail.EmployeeNumber}' already exists for company ID '{companyId}'.";
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
                RolesId = 2, // Assuming "2" is the ID for the "User" role
                IsActive = 1
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
                return null;
            }
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
        public IEnumerable<EmployeeView> GetAllEmployees(int companyId)
        {
            var employees = _hrmsContext.EmployeeDetails
                
                .Include(e => e.EmployeeCredential)
                .Include(e => e.Position)
                .Include(e => e.Dept)
                .Include(e => e.EmployeeCredential.AddressInfos)
                .Include(e => e.EmployeeCredential.EmpPersonalInfos)
                .Where(e => e.RequestCompanyId == companyId)
                .ToList();

            return employees.Select(employee => new EmployeeView
            {
                EmployeeId = employee.Id,
                EmployeeName = $"{employee.FirstName} {employee.MiddleName} {employee.LastName}",
                Address = employee.EmployeeCredential.AddressInfos.FirstOrDefault()?.AddressLine1,
                Gender = employee.EmployeeCredential.EmpPersonalInfos.FirstOrDefault()?.Gender,
                DOB = employee.EmployeeCredential.EmpPersonalInfos.FirstOrDefault()?.Dob.ToString(),
                Designation = employee.Position?.Name,
               Manager = employee.ManagerId.HasValue ? _hrmsContext.EmployeeDetails.FirstOrDefault(m => m.EmployeeCredentialId == employee.ManagerId.Value)?.FirstName : "N/A"
            }).ToList();
        }
        public async Task<UpdateEmployeeInfoDTO> GetEmployeeInfoAsync(int employeeCredentialId)
        {
            var employeeDetail = await _hrmsContext.EmployeeDetails
                .FirstOrDefaultAsync(e => e.EmployeeCredentialId == employeeCredentialId);

            var employeeCredential = await _hrmsContext.EmployeeCredentials
                .FirstOrDefaultAsync(ec => ec.Id == employeeCredentialId);


            if (employeeDetail == null || employeeCredential == null)
            {
                return null; 
            }

            return new UpdateEmployeeInfoDTO
            {
                EmployeeCredentialId = employeeCredentialId,
                EmployeeName = employeeDetail.FirstName,
                NickName = employeeDetail.NickName,
                EmailAddress = employeeDetail.Email,
                MobileNumber = employeeDetail.MobileNumber,
                Extension = employeeDetail.Extension,
                EmpLoginName = employeeCredential.EmployeeLoginName,
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
                return null;
            }

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
                return null; 
            }

            return new AddressInfoDTO
            {
                EmployeeCredentialId = employeeAddress.EmployeeCredentialId,
                AddressLine1 = employeeAddress.AddressLine1,
                AddressLine2 = employeeAddress.AddressLine2,
                City = employeeAddress.City,
                State = employeeAddress.State,
                Country = employeeAddress.Country,
                PinCode = employeeAddress.PinCode,
                IsActive = employeeAddress.IsActive
            };
        }
        public async Task<AccountDetail> GetEmployeeAccountInfoAsync(int employeeCredentialId)
        {
            var accountDetail = await _hrmsContext.AccountDetails
                .FirstOrDefaultAsync(e => e.EmployeeCredentialId == employeeCredentialId);

            if (accountDetail == null)
            {
                return null; 
            }

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
        public List<EmployeeDetail> GetFilters(GlobalsearchEmp globalSearch, int companyId)
        {
            List<EmployeeDetail> filteredEmployees = new List<EmployeeDetail>();
            var filterby = globalSearch.FilterBy.Trim().ToLowerInvariant();
            if (!string.IsNullOrEmpty(filterby))
            {
                var query = (from ed in _hrmsContext.EmployeeDetails
                             join ec in _hrmsContext.EmployeeCredentials
                             on ed.EmployeeCredentialId equals ec.Id 
                             where ec.RequestedCompanyId == companyId 
                             && (ed.FirstName.ToLower().Contains(filterby)
                             || ed.LastName.ToLower().Contains(filterby)
                             || ed.MiddleName.ToLower().Contains(filterby)
                             || ed.Email.ToLower().Contains(filterby)
                             || ed.EmployeeNumber.ToLower().Contains(filterby)
                             || ed.EmployeeCredentialId.ToString().Contains(filterby))
                             select ed).ToList();

                filteredEmployees = query;
                
            }
            return filteredEmployees;
        }
        public List<EmployeeDetail> GetFiltersbymanager(GlobalsearchEmp globalSearch, int companyId, int managerId)
        {
            List<EmployeeDetail> filteredEmployees = new List<EmployeeDetail>();
            var filterby = globalSearch.FilterBy.Trim().ToLowerInvariant();
            if (!string.IsNullOrEmpty(filterby))
            {
                var query = (from ed in _hrmsContext.EmployeeDetails
                             join ec in _hrmsContext.EmployeeCredentials
                             on ed.EmployeeCredentialId equals ec.Id
                             where ec.RequestedCompanyId == companyId && ed.ManagerId == managerId
                             && (ed.FirstName.ToLower().Contains(filterby)
                             || ed.LastName.ToLower().Contains(filterby)
                             || ed.MiddleName.ToLower().Contains(filterby)
                             || ed.Email.ToLower().Contains(filterby)
                             || ed.EmployeeNumber.ToLower().Contains(filterby)
                             || ed.EmployeeCredentialId.ToString().Contains(filterby))
                             select ed).ToList();

                filteredEmployees = query;
                
            }
            return filteredEmployees;
        }
        public async Task<bool> UpdateEmployeeInfoAsync(UpdateEmployeeInfoDTO updateEmployeeInfo)
        {
            var employeeDetail = await _hrmsContext.EmployeeDetails
                .FirstOrDefaultAsync(e => e.EmployeeCredentialId == updateEmployeeInfo.EmployeeCredentialId);

            var employeeCredential = await _hrmsContext.EmployeeCredentials
                .FirstOrDefaultAsync(ec => ec.Id == updateEmployeeInfo.EmployeeCredentialId);

            var employeepersonalinfo = await _hrmsContext.EmpPersonalInfos
                .FirstOrDefaultAsync(ep => ep.EmployeeCredentialId == updateEmployeeInfo.EmployeeCredentialId);

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
                    IsActive = 1,
                };
                await _hrmsContext.EmployeeDetails.AddAsync(employeeDetail);
            }
            else
            {
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

            await _hrmsContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateEmployeepersonalInfoAsync(EmpPersonalInfoDTO empPersonalInfo)
        {
            var employeeDetail = await _hrmsContext.EmployeeDetails
                .FirstOrDefaultAsync(e => e.EmployeeCredentialId == empPersonalInfo.EmployeeCredentialId);

            var employeeCredential = await _hrmsContext.EmployeeCredentials
                .FirstOrDefaultAsync(ec => ec.Id == empPersonalInfo.EmployeeCredentialId);

            var employeepersonalinfo = await _hrmsContext.EmpPersonalInfos
                .FirstOrDefaultAsync(ep => ep.EmployeeCredentialId == empPersonalInfo.EmployeeCredentialId);

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
                employeeDetail.FirstName = empPersonalInfo.FirstName ?? employeeDetail.FirstName;
                employeeDetail.MiddleName = empPersonalInfo.MiddleName ?? employeeDetail.MiddleName;
                employeeDetail.LastName = empPersonalInfo.LastName ?? employeeDetail.LastName;
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
              /*  employeeCredential.Email = empPersonalInfo.EmailId ?? employeeCredential.Email;

                _hrmsContext.EmployeeCredentials.Update(employeeCredential);*/
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

            await _hrmsContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateEmployeeAddresslInfoAsync(AddressInfoDTO addressInfo)
        {
            var employeeAddress = await _hrmsContext.AddressInfos
                .FirstOrDefaultAsync(e => e.EmployeeCredentialId == addressInfo.EmployeeCredentialId);

            if (employeeAddress == null)
            {
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

                await _hrmsContext.AddressInfos.AddAsync(employeeAddress); 
            }
            else
            {
                employeeAddress.AddressLine1 = addressInfo.AddressLine1 ?? employeeAddress.AddressLine1;
                employeeAddress.AddressLine2 = addressInfo.AddressLine2 ?? employeeAddress.AddressLine2;
                employeeAddress.City = addressInfo.City ?? employeeAddress.City;
                employeeAddress.State = addressInfo.State ?? employeeAddress.State;
                employeeAddress.Country = addressInfo.Country ?? employeeAddress.Country;
                employeeAddress.PinCode = addressInfo.PinCode ?? employeeAddress.PinCode;

                _hrmsContext.AddressInfos.Update(employeeAddress); 
            }

            await _hrmsContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateEmployeeAccountInfoAsync(AccountDetailDTO accountDetail)
        {
            var existingAccountDetail = await _hrmsContext.AccountDetails
                .FirstOrDefaultAsync(e => e.EmployeeCredentialId == accountDetail.EmployeeCredentialId);

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

            await _hrmsContext.SaveChangesAsync();

            return true;
        }
        public EmployeeShiftAndLeaveStatsDto GetEmployeeShiftAndLeaveStats(int empCredentialId)
        {
            var currentDate = DateTime.Now.Date;
            var currentYear = DateTime.Now.Year;
            var currentMonth = DateTime.Now.Month;

            var startDate = new DateTime(currentYear, currentMonth, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);  
            var totalWorkingDays = CalculateTotalWorkingDays(startDate);

            var employeeDetail = _hrmsContext.EmployeeDetails
                .FirstOrDefault(e => e.EmployeeCredentialId == empCredentialId);

            if (employeeDetail == null)
            {
                throw new Exception("Employee not found.");
            }

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

            var holidays = _hrmsContext.Holidays
                .Where(h => h.CompanyId == employeeDetail.RequestCompanyId
                            && h.Date.HasValue
                            && h.Date.Value.Date >= startDate
                            && h.Date.Value.Date <= endDate
                            && h.IsActive == 1)
                .Select(h => h.Date.Value.Date)
                .ToList();

            var totalDaysInMonth = (endDate - startDate).Days + 1;
            var weekends = Enumerable.Range(0, totalDaysInMonth)
                .Select(d => startDate.AddDays(d))
                .Where(d => d.DayOfWeek == DayOfWeek.Sunday)
                .ToList();

            var holidaysCount = holidays.Count;
            var weekendsCount = weekends.Count;

            var presentDaysCount = _hrmsContext.Attendances
            .Where(a => a.EmpCredentialId == empCredentialId
                && a.Status == "Present" 
                && a.Date.HasValue
                && a.Date.Value.Date >= startDate
                && a.Date.Value.Date <= endDate)
             .Select(a => a.Date.Value.Date)  
             .Distinct()
             .Count();


            var attendancePercentage = totalWorkingDays > 0 ? (presentDaysCount / (double)totalWorkingDays) * 100 : 0;

            var result = new EmployeeShiftAndLeaveStatsDto
            {
                ShiftType = shiftRoster.ShiftRosterType?.Type,
                ShiftTimeRange = shiftRoster.ShiftRosterType?.TimeRange,
                TotalLeaveCount = totalLeaveCount,
                RemainingLeaveCount = remainingLeaveCount,
                LeavePercentage = leavePercentage,
                Name = $"{employeeDetail.FirstName} {employeeDetail.LastName}",
                Email = employeeDetail.Email,
                MonthlyPresentDays = presentDaysCount,
                TotalWorkingDays = totalWorkingDays,
                AttendancePercentage = attendancePercentage,
            
            };

            return result;
        }

        public MonthlyAttendanceStatistics GetMonthlyStatistics(int empCredentialId, DateTime month)
        {
            var attendances = _hrmsContext.Attendances
                .Where(a => a.EmpCredentialId == empCredentialId && a.Date.Value.Month == month.Month && a.Date.Value.Year == month.Year)
                .ToList();

            var shiftRoster = _hrmsContext.ShiftRosters
                .Include(sr => sr.ShiftRosterType)
                .FirstOrDefault(sr => sr.EmpCredentialId == empCredentialId);

            if (shiftRoster == null)
                throw new Exception("Shift Roster not found for employee");

            var timeRange = shiftRoster.ShiftRosterType.TimeRange.Split('-');
            if (timeRange.Length != 2)
                throw new Exception("Invalid shift time range format");

            var shiftStart = DateTime.Parse(timeRange[0].Trim()).TimeOfDay; 
            var shiftEnd = DateTime.Parse(timeRange[1].Trim()).TimeOfDay;   
            var standardWorkDayHours = (shiftEnd - shiftStart).TotalHours;

            var totalworkhrs = (standardWorkDayHours);

            var totalWorkingDays = CalculateTotalWorkingDays(month);

            var totalHoursWorked = totalworkhrs * totalWorkingDays;
            double totalPresentHours = 0; 
            double totalTimeIn = 0;
            double totalTimeOut = 0;
            double totalOvertimeHours = 0; 

            TimeSpan totalWorkTime = TimeSpan.Zero;
            TimeSpan totalOverTime = TimeSpan.Zero;
            TimeSpan LessHours = TimeSpan.Zero;

            var dateWiseAttendance = new List<DateWiseAttendance>();

            DateWiseAttendance? specificDayAttendance = null;

            foreach (var attendance in attendances)
            {
                if (attendance.TimeIn.HasValue && attendance.Timeout.HasValue)
                {
                    TimeSpan effectiveTimeIn = attendance.TimeIn.Value.TimeOfDay;
                    TimeSpan effectiveTimeOut = attendance.Timeout.Value.TimeOfDay;

                    TimeSpan workStart = effectiveTimeIn < shiftStart ? shiftStart : effectiveTimeIn; 
                    TimeSpan workEnd = effectiveTimeOut > shiftEnd ? shiftEnd : effectiveTimeOut;

                    TimeSpan workTime = effectiveTimeOut - effectiveTimeIn;
                    double workedHourstime = (workEnd - workStart).TotalHours;


                    TimeSpan overtime = TimeSpan.Zero;
                    if (workTime.TotalHours > workedHourstime)
                    {
                        overtime = workTime - TimeSpan.FromHours(workedHourstime);
                    }
                  
                    if (workStart < workEnd)
                    {
                        TimeSpan workTimes = effectiveTimeOut - effectiveTimeIn;
                        totalWorkTime += workTimes; 
                        totalOverTime += overtime;
                     
                        double workedHours = (workEnd - workStart).TotalHours;
                           if (workTimes.TotalHours < standardWorkDayHours)
                           {
                                double lessHours = standardWorkDayHours - workTimes.TotalHours;
                                LessHours += TimeSpan.FromHours(lessHours); 
                           }

                        if (attendance.Status == "Present")
                        {
                            totalPresentHours += workedHours;
                            totalTimeIn += attendance.TimeIn.Value.TimeOfDay.TotalHours;
                            totalTimeOut += attendance.Timeout.Value.TimeOfDay.TotalHours;
                            totalOvertimeHours += overtime.TotalHours; 

                            var attendanceEntry = new DateWiseAttendance
                            {
                                Date = attendance.Date.Value,
                                TimeIn = attendance.TimeIn.Value.ToString(@"hh\:mm\:ss"),
                                TimeOut = attendance.Timeout.Value.ToString(@"hh\:mm\:ss"),
                                WorkTime = workTime.ToString(@"hh\:mm"), 
                                Overtime = overtime.ToString(@"hh\:mm"),
                                Status = attendance.Status
                            };

                            dateWiseAttendance.Add(attendanceEntry);

                            if (attendance.Date.Value.Date == month.Date)
                            {
                                specificDayAttendance = attendanceEntry;
                            }
                        }

                    }
                }
            }
           
            var presentDaysCount = attendances.Count(a => a.Status == "Present");
            var avgworkhours = presentDaysCount > 0 ? totalPresentHours : 0;

            var averageWorkHours = TimeSpan.FromHours(avgworkhours); 
            
            var averageTimeInHours = presentDaysCount > 0 ? totalTimeIn / presentDaysCount : 0;
            var averageTimeOutHours = presentDaysCount > 0 ? totalTimeOut / presentDaysCount : 0;

            var averageTimeIn = TimeSpan.FromHours(averageTimeInHours);
            var averageTimeOut = TimeSpan.FromHours(averageTimeOutHours);
            
            double averageOvertimeHours = presentDaysCount > 0 ? totalOvertimeHours / presentDaysCount : 0;
            var averageOvertime = TimeSpan.FromHours(averageOvertimeHours);

            var presentCount = attendances.Count(a => a.Status == "Present");
            var absentCount = attendances.Count(a => a.Status == "Absent");
            var leaveTakenCount = attendances.Count(a => a.Status == "Leave");
            var PenaltyleaveTakenCount = attendances.Count(a => a.Status == "Penalty Leave");

            var holidayCount = GetHolidayCount(month);
            var lateInCount = attendances.Count(a => a.TimeIn.HasValue && a.TimeIn.Value.TimeOfDay > shiftStart);
            var earlyOutCount = attendances.Count(a => a.Timeout.HasValue && a.Timeout.Value.TimeOfDay < shiftEnd);
            var daysInMonth = DateTime.DaysInMonth(month.Year, month.Month);  

            var countedDays = presentCount + absentCount + leaveTakenCount;
            var restDays = daysInMonth - countedDays;
            var restDaysPercentage = restDays > 0 ? (double)restDays / daysInMonth * 100 : 0;

            var presentPercentage = daysInMonth > 0 ? (double)presentCount / daysInMonth * 100 : 0;
            var absentPercentage = daysInMonth > 0 ? (double)absentCount / daysInMonth * 100 : 0;
            var leaveTakenPercentage = daysInMonth > 0 ? (double)leaveTakenCount / daysInMonth * 100 : 0;

            var holidayPercentage = (double)holidayCount / daysInMonth * 100;

            
           var TotalWorkplusOTs = totalWorkTime.TotalHours >= 1
    ? string.Format("{0:00}:{1:00}", (int)totalWorkTime.TotalHours, totalWorkTime.Minutes)
    : string.Format("00:{0:00}", totalWorkTime.Minutes);

            return new MonthlyAttendanceStatistics
            {
                EmployeecredntialId = empCredentialId,
                TotalWorkingDays = totalWorkingDays,
                TotalHoursWorked = totalHoursWorked,
                AverageWorkHours = averageWorkHours.ToString(@"hh\:mm"),
                AverageOvertime = averageOvertime.ToString(@"hh\:mm"),
                TotalWorkplusOT = TotalWorkplusOTs,
                TotalOverTime = totalOverTime.ToString(@"hh\:mm"),
                LessHoursTime = LessHours.ToString(@"hh\:mm"),
                LateInCount = lateInCount,
                EarlyOutCount = earlyOutCount,
                AbsentCount = absentCount,
                LeaveTakenCount = leaveTakenCount,
                PresentPercentage = presentPercentage,
                AbsentPercentage = absentPercentage,
                LeaveTakenPercentage = leaveTakenPercentage,
                AvgTimein = averageTimeIn.ToString(@"hh\:mm\:ss"),
                AvgTimeouT = averageTimeOut.ToString(@"hh\:mm\:ss"),
                HolidayPercentage = holidayPercentage,
                RestDaysPercentage = restDaysPercentage,
                PenaltyCount = PenaltyleaveTakenCount,

                SpecificDayAttendance = specificDayAttendance,
                DateWiseAttendance = dateWiseAttendance

            };
        }
        private int GetHolidayCount(DateTime month)
        {
            return _hrmsContext.Holidays
                .Where(h => h.Date.HasValue && h.Date.Value.Month == month.Month && h.Date.Value.Year == month.Year && h.IsActive == 1)
                .Count();
        }

        private int CalculateTotalWorkingDays(DateTime month)
        {
            var daysInMonth = DateTime.DaysInMonth(month.Year, month.Month);

            var weekends = Enumerable.Range(1, daysInMonth)
                .Select(day => new DateTime(month.Year, month.Month, day))
                .Count(date => date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday);

            var holidays = _hrmsContext.Holidays
                .Where(h => h.Date.HasValue && h.Date.Value.Month == month.Month && h.Date.Value.Year == month.Year && h.IsActive == 1)
                .ToList();

            var holidayCount = holidays.Count(h => !(h.Date.Value.DayOfWeek == DayOfWeek.Sunday));

            return daysInMonth - weekends - holidayCount; 
        }

        public async Task<string> UpdateImageUrl(int empcredId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return "File is empty";

            var employee = await _hrmsContext.EmployeeDetails.FirstOrDefaultAsync(e => e.EmployeeCredentialId == empcredId);
            if (employee == null)
            {
                return "Employee not found";
            }

            var imageUrl = _azureOperations.StoreFilesInAzure(file, "hrms-profile-pics");

            employee.ImageUrl = imageUrl;
            _hrmsContext.EmployeeDetails.Update(employee);
            await _hrmsContext.SaveChangesAsync();

            return "File Updated successfully";
        }

        public UserDetailsDTO GetUserDetails(int empcredId, int companyId)
        {
            var employeeDetail = _hrmsContext.EmployeeDetails
               .FirstOrDefault(e => e.EmployeeCredentialId == empcredId);

            if (employeeDetail == null)
            {
                throw new Exception("Employee not found.");
            }
            var companyDetail = _hrmsContext.CompanyDetails
       .FirstOrDefault(c => c.RequestedCompanyId == companyId && c.IsActive == 1);

            
            var result = new UserDetailsDTO
            {
               
                Name = $"{employeeDetail.FirstName} {employeeDetail.LastName}",
                Email = employeeDetail.Email,
                ImageUrl = employeeDetail.ImageUrl,
                CompanyLogo = companyDetail?.CompanyLogo 
            };

            return result;
        }
    }

}
