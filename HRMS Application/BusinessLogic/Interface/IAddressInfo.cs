using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IAddressInfo
    {
        public List<AddressInfo> GetAllAddressInfo();
        public AddressInfo GetAddressInfoById(int id);
        public AddressInfo GetAddressInfoByEmpCredId(int empCredId);
        public string InsertAddressInfot(AddressInfo address);
        //public AddressInfo UpdateAddressInfo(int id, string? name, int? requestedcompanyId);
        public bool deleteAddressInfo(int id);
    }
}
