using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class UpdateEmployeeDetailsImp : IUpdateEmployeeDetails
    {
        private readonly HRMSContext _hrmsContext;
        private readonly IAzureOperations _azureOperations;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtUtils _jwtUtils;
        public List<string>? dToken;
        private int? _decodedToken;
        private readonly IEmailPassword _emailPasswordService;

        public UpdateEmployeeDetailsImp(HRMSContext hrmsContext, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils, IEmailPassword emailPasswordService, IAzureOperations azureOperations)
        {
            _hrmsContext = hrmsContext;
            _azureOperations = azureOperations;
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
        public async Task<AccountDetail> GetEmployeeAccountInfoAsync(int employeeCredentialId)
        {
            var accountDetail = await _hrmsContext.AccountDetails
                .FirstOrDefaultAsync(e => e.EmployeeCredentialId == employeeCredentialId && e.IsActive == 1);

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

        public async Task<AddressInfoDTO> GetEmployeeAddressInfoAsync(int employeeCredentialId)
        {
            var employeeAddress = await _hrmsContext.AddressInfos
                 .FirstOrDefaultAsync(e => e.EmployeeCredentialId == employeeCredentialId && e.IsActive == 1);

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

        public async Task<UpdateEmployeeInfoDTO> GetEmployeeInfoAsync(int employeeCredentialId)
        {
            var employeeDetail = await _hrmsContext.EmployeeDetails
        .FirstOrDefaultAsync(e => e.EmployeeCredentialId == employeeCredentialId && e.IsActive == 1);

            var employeeCredential = await _hrmsContext.EmployeeCredentials
                .FirstOrDefaultAsync(ec => ec.Id == employeeCredentialId && ec.IsActive == 1);

            var employeePersonalInfo = await _hrmsContext.EmpPersonalInfos
                .FirstOrDefaultAsync(ep => ep.EmployeeCredentialId == employeeCredentialId && ep.IsActive == 1);

            if (employeeDetail == null || employeeCredential == null || employeePersonalInfo == null)
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
                gender = employeePersonalInfo.Gender
            };
        }

        public async Task<EmpPersonalInfoDTO> GetEmployeePersonalInfoAsync(int employeeCredentialId)
        {
            var employeePersonalInfo = await _hrmsContext.EmpPersonalInfos
                .FirstOrDefaultAsync(ep => ep.EmployeeCredentialId == employeeCredentialId && ep.IsActive == 1);
            var employyedetail = await _hrmsContext.EmployeeDetails
                .FirstOrDefaultAsync(ed => ed.EmployeeCredentialId == employeeCredentialId && ed.IsActive == 1);

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

        public async Task<bool> UpdateEmployeeAccountInfoAsync(AccountDetail accountDetail)
        {
            var existingAccountDetail = await _hrmsContext.AccountDetails
               .FirstOrDefaultAsync(e => e.EmployeeCredentialId == accountDetail.EmployeeCredentialId && e.IsActive == 1);

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
                    IsActive = 1
                };

                await _hrmsContext.AccountDetails.AddAsync(newAccountDetail);
            }

            // Save changes to the database
            await _hrmsContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateEmployeeAddresslInfoAsync(AddressInfoDTO addressInfo)
        {
            var employeeAddress = await _hrmsContext.AddressInfos
                .FirstOrDefaultAsync(e => e.EmployeeCredentialId == addressInfo.EmployeeCredentialId && e.IsActive == 1);

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
                    IsActive = 1
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

        public async Task<bool> UpdateEmployeeInfoAsync(UpdateEmployeeInfoDTO updateEmployeeInfo)
        {
            var employeeDetail = await _hrmsContext.EmployeeDetails
                .FirstOrDefaultAsync(e => e.EmployeeCredentialId == updateEmployeeInfo.EmployeeCredentialId && e.IsActive == 1);

            var employeeCredential = await _hrmsContext.EmployeeCredentials
                .FirstOrDefaultAsync(ec => ec.Id == updateEmployeeInfo.EmployeeCredentialId && ec.IsActive == 1);

            var employeepersonalinfo = await _hrmsContext.EmpPersonalInfos
                .FirstOrDefaultAsync(ep => ep.EmployeeCredentialId == updateEmployeeInfo.EmployeeCredentialId && ep.IsActive == 1);

            string existingImageUrl = employeeDetail?.ImageUrl;

            string Url = null;
            if (updateEmployeeInfo.imageUrl != null)
            {
                Url = _azureOperations.StoreFilesInAzure(updateEmployeeInfo.imageUrl, "hrms-profile-pics");
            }

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
                    ImageUrl = Url
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

                if (Url != null)
                {
                    employeeDetail.ImageUrl = Url;
                }
                else
                {
                    employeeDetail.ImageUrl = existingImageUrl;
                }

                _hrmsContext.EmployeeDetails.Update(employeeDetail);
            }

           /* if (employeeCredential == null)
            {
                return false;
            }
            else
            {
                employeeCredential.EmployeeLoginName = updateEmployeeInfo.EmpLoginName ?? employeeCredential.EmployeeLoginName;
                employeeCredential.Email = updateEmployeeInfo.EmailAddress ?? employeeCredential.Email;

                _hrmsContext.EmployeeCredentials.Update(employeeCredential);
            }*/

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
                .FirstOrDefaultAsync(e => e.EmployeeCredentialId == empPersonalInfo.EmployeeCredentialId && e.IsActive == 1);

            // Check if EmployeeCredential exists
            var employeeCredential = await _hrmsContext.EmployeeCredentials
                .FirstOrDefaultAsync(ec => ec.Id == empPersonalInfo.EmployeeCredentialId && ec.IsActive == 1);

            // Check if EmpPersonalInfo exists
            var employeepersonalinfo = await _hrmsContext.EmpPersonalInfos
                .FirstOrDefaultAsync(ep => ep.EmployeeCredentialId == empPersonalInfo.EmployeeCredentialId && ep.IsActive == 1);

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
                    IsActive = 1

                };
                await _hrmsContext.EmployeeDetails.AddAsync(employeeDetail);
            }
            else
            {
                // Update existing employee detail
                employeeDetail.FirstName = empPersonalInfo.FirstName ?? employeeDetail.FirstName;
                employeeDetail.MiddleName = empPersonalInfo.MiddleName ?? employeeDetail.MiddleName;
                employeeDetail.LastName = empPersonalInfo.LastName ?? employeeDetail.LastName;
                //employeeDetail.Email = empPersonalInfo.EmailId ?? employeeDetail.Email;
                employeeDetail.MobileNumber = empPersonalInfo.Contact ?? employeeDetail.MobileNumber;

                _hrmsContext.EmployeeDetails.Update(employeeDetail);
            }

          /*  if (employeeCredential == null)
            {
                return false;
            }
            else
            {
                // Update existing employee credential
               *//* employeeCredential.Email = empPersonalInfo.EmailId ?? employeeCredential.Email;

                _hrmsContext.EmployeeCredentials.Update(employeeCredential);*//*
            }*/

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
                    IsActive = 1
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
    }
}
