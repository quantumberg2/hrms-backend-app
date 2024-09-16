namespace HRMS_Application.DTO
{
    public class AddressInfoDTO
    {
        public int? EmployeeCredentialId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }
        public short? IsActive { get; set; }
    }
}
