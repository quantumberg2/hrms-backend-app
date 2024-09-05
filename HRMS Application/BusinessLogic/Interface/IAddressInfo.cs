using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IAddressInfo
    {
        public List<AddressInfo> GetAllAddressInfo();
        public AddressInfo GetAddressInfoById(int id);
        public string InsertAddressInfot(AddressInfo address, int empCredentialId);
        //public AddressInfo UpdateAddressInfo(int id, string? name, int? requestedcompanyId);
        public bool deleteAddressInfo(int id);
        public bool SoftDelete(int id, short isActive);

    }
}
