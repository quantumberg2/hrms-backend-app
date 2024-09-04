using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Models;
using Org.BouncyCastle.Crypto.Digests;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class EmpPersonalInfoImp : IEmpPersonalInfo
    {
        private readonly HRMSContext _context;
        public EmpPersonalInfoImp(HRMSContext context)
        {
            _context = context;
        }
        public List<EmpPersonalInfo> GetAll()
        {
            throw new NotImplementedException();
        }

        public string InsertEmpPersonalInfo(EmpPersonalInfoDTO empPersonalInfo, int empCredentialId)
        {
            /* var existingEntry = _context.EmpPersonalInfos
                                        .FirstOrDefault(row => row.EmployeeCredentialId == empCredentialId);

             if (existingEntry == null)
             {
                 _context.EmpPersonalInfos.Add(empPersonalInfo);
             }
             else
             {
                 existingEntry.BloodGroup = empPersonalInfo.BloodGroup;
                 existingEntry.SpouseName = empPersonalInfo.SpouseName;
                 existingEntry.DateOfJoining = empPersonalInfo.DateOfJoining;
                 existingEntry.EmailId = empPersonalInfo.EmailId;
                 existingEntry.ConfirmDate = empPersonalInfo.ConfirmDate;
                 existingEntry.Dob = empPersonalInfo.Dob;
                 existingEntry.EmergencyContact = empPersonalInfo.EmergencyContact;
                 existingEntry.EmpStatus = empPersonalInfo.EmpStatus;
                 existingEntry.MaritalStatus = empPersonalInfo.MaritalStatus;
                 existingEntry.PersonalEmail = empPersonalInfo.PersonalEmail;
                 existingEntry.PhysicallyChallenged = empPersonalInfo.PhysicallyChallenged;
             }

             // Save changes to the database
             _context.SaveChanges();
             return "Operation completed successfully.";*/

            var existingEmpDetails = _context.EmployeeDetails.FirstOrDefault(e=> e.EmployeeCredentialId == empPersonalInfo.EmployeeCredentialId);

            if(existingEmpDetails!=null)
            {

                existingEmpDetails.FirstName = empPersonalInfo.FirstName;
                existingEmpDetails.LastName = empPersonalInfo.LastName;
                existingEmpDetails.MiddleName = empPersonalInfo.MiddleName;
            }
            else
            {
                existingEmpDetails = new EmployeeDetail
                {
                    FirstName = empPersonalInfo.FirstName,
                    LastName = empPersonalInfo.LastName,
                    MiddleName = empPersonalInfo.MiddleName
                };
                _context.EmployeeDetails.Add(existingEmpDetails);
            }

            var existingEmpPersonalInfo = _context.EmpPersonalInfos.FirstOrDefault(e=> e.EmployeeCredentialId == empPersonalInfo.EmployeeCredentialId);

            if(existingEmpPersonalInfo!=null)
            {
                existingEmpPersonalInfo.DateOfJoining = empPersonalInfo.DateOfJoining;
                existingEmpPersonalInfo.ConfirmDate = empPersonalInfo.ConfirmDate;
                existingEmpPersonalInfo.EmailId = empPersonalInfo.EmailId;
                existingEmpPersonalInfo.BloodGroup = empPersonalInfo.BloodGroup;
                existingEmpPersonalInfo.Dob = empPersonalInfo.Dob;
                existingEmpPersonalInfo.EmergencyContact = empPersonalInfo.EmergencyContact;
                existingEmpPersonalInfo.PhysicallyChallenged = empPersonalInfo.PhysicallyChallenged;
                existingEmpPersonalInfo.EmpStatus =existingEmpPersonalInfo.EmpStatus;
                existingEmpPersonalInfo.PersonalEmail = existingEmpPersonalInfo.PersonalEmail;
                existingEmpPersonalInfo.MaritalStatus = existingEmpPersonalInfo.MaritalStatus;
                existingEmpPersonalInfo.SpouseName = existingEmpPersonalInfo.SpouseName;

            }

            existingEmpPersonalInfo = new EmpPersonalInfo
            {
                EmployeeCredentialId = empPersonalInfo.EmployeeCredentialId,
                Dob = empPersonalInfo.Dob,
                DateOfJoining = empPersonalInfo.DateOfJoining,
                ConfirmDate = empPersonalInfo.ConfirmDate,
                EmpStatus = empPersonalInfo.EmpStatus,
                EmailId = empPersonalInfo.EmailId,
                PersonalEmail = empPersonalInfo.PersonalEmail,
                MaritalStatus = empPersonalInfo.MaritalStatus,
                BloodGroup = empPersonalInfo.BloodGroup,
                SpouseName = empPersonalInfo.SpouseName,
                PhysicallyChallenged = empPersonalInfo.PhysicallyChallenged,
                EmergencyContact = empPersonalInfo.EmergencyContact
            };
             _context.EmpPersonalInfos.AddAsync(existingEmpPersonalInfo);
            try
            {
                _context.SaveChanges();
                return "Successfully added new data";
            }
            catch(Exception)
            {
                return "Failed to add new data";
            }
           
            

        }


        public string UpdateEmpPersonalInfo(EmpPersonalInfo empPersonalInfo, EmpPersonalInfoDTO name)
        {
            throw new NotImplementedException();

        }
        public string DeleteEmpPersonalInfo(int Id)
        {
            throw new NotImplementedException();
        }

    }
}
