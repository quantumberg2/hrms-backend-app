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

        public string InsertEmpPersonalInfo(EmpPersonalInfo empPersonalInfo, int empCredentialId)
        {
            var existingEntry = _context.EmpPersonalInfos
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
            return "Operation completed successfully.";
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
