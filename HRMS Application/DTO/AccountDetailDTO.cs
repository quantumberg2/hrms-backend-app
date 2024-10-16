namespace HRMS_Application.DTO
{
    public class AccountDetailDTO
    {
      //  public int? Id { get; set; }
        public int? EmployeeCredentialId { get; set; }
        public string? AccountNumber { get; set; }
        public string? IfscCode { get; set; }
        public string? AccountType { get; set; }
        public string? BankName { get; set; }
        public string? BranchName { get; set; }
        public string? AadharNumber { get; set; }
        public string? PfNumber { get; set; }
        public string? UanNumber { get; set; }
        public DateTime? PfJoiningDate { get; set; }
        public bool? EligibleForPf { get; set; }
        public short? IsActive { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public int? Pin { get; set; }

    }
}
