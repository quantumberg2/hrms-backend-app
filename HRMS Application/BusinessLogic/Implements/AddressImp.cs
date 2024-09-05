using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class AddressImp : IAddressInfo
    {
        private HRMSContext _context;
        public AddressImp(HRMSContext context)
        {
            _context = context;
        }
        public bool deleteAddressInfo(int id)
        {
            var result = (from row in _context.AddressInfos
                          where row.Id == id
                          select row).SingleOrDefault();
            _context.AddressInfos.Remove(result);
            _context.SaveChanges();
            return true;
        }

        public AddressInfo GetAddressInfoById(int id)
        {
            var result = (from row in _context.AddressInfos
                          where row.Id == id && row.IsActive == 1
                          select row).FirstOrDefault();

            return result;
        }

        public AddressInfo GetAddressInfoByEmpCredId(int empCredId)
        {
            var Info = (from row in _context.AddressInfos
                        where row.EmployeeCredentialId == empCredId && row.IsActive == 1
                        select row).FirstOrDefault();
            return Info;
        }

        public List<AddressInfo> GetAllAddressInfo()
        {
            var result = (from row in _context.AddressInfos
                          where  row.IsActive == 1
                          select row).ToList();
            return result;
        }

        public string InsertAddressInfot(AddressInfo address, int empCredentialId)
        {
            address.EmployeeCredentialId = empCredentialId;

            _context.AddressInfos.Add(address);
            var result = _context.SaveChanges();
            if (result != 0)
            {
                return "new Address inserted successfully";

            }
            else
            {
                return "failed to insert new data";
            }
        }

        public bool SoftDelete(int id, short isActive)
        {
            var res = (from row in _context.AddressInfos
                       where row.Id == id
                       select row).FirstOrDefault();
            if(res != null)
            {
                res.IsActive = isActive;
                _context.AddressInfos.Update(res);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
