using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IAccountDetails
    {
        public List<AccountDetail> GetAllAccountdetails();
        public AccountDetail GetAccountDetailsById(int id);
        public AccountDetail GetAccountDetailsByAccNumber(string accountNumber);
        public string InsertAccountDetails(AccountDetail accountDetail);
       // public AccountDetail UpdateAccountDetails(int id, string? name, int? requestedcompanyId);
        public bool deleteAccountDetails(int id);
    }
}
