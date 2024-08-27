using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Enums;
using HRMS_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class AccountDetailsImp : IAccountDetails
    {
        private readonly HRMSContext _context;
        public AccountDetailsImp(HRMSContext context)
        {
            _context = context;
        }
        public List<AccountDetail> GetAllAccountdetails()
        {
            var result = (from row in _context.AccountDetails
                          select row).ToList();
            return result;
        }

        public AccountDetail GetAccountDetailsById(int id)
        {
            var result = (from row in _context.AccountDetails
                          where row.Id == id
                          select row).FirstOrDefault();
          
            return result;
        }


        public AccountDetail GetAccountDetailsByAccNumber(string accountNumber)
        {
            var details = (from row in _context.AccountDetails
                           where row.AccountNumber == accountNumber
                           select row).FirstOrDefault();
            return details;
        }

        public string InsertAccountDetails(AccountDetail accountDetail)
        {
            _context.AccountDetails.Add(accountDetail);
            var result = _context.SaveChanges();
            if (result != 0)
            {
                return "new Department inserted successfully";

            }
            else
            {
                return "failed to insert new data";
            }
        }

        public bool deleteAccountDetails(int id)
        {
            var result = (from row in _context.AccountDetails
                          where row.Id == id
                          select row).SingleOrDefault();
            _context.AccountDetails.Remove(result);
            _context.SaveChanges();
            return true;
        }

    }
}
