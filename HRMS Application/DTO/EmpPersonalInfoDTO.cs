namespace HRMS_Application.DTO
{
    public class EmpPersonalInfoDTO
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }  
        public string LastName { get; set; }
        public int? EmployeeCredentialId { get; set; }
        public DateTime? Dob { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public string EmpStatus { get; set; }
        public string EmailId { get; set; }
        public string PersonalEmail { get; set; }
        public string MaritalStatus { get; set; }   
        public string BloodGroup { get; set; }
        public string SpouseName { get; set; }
        public bool? PhysicallyChallenged { get; set; }
        public string EmergencyContact { get; set; }
        public string PAN {  get; set; }
        public string Gender { get; set; }
        public string Contact { get; set; }
    }
}
