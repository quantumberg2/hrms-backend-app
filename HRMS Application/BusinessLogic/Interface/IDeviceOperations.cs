using HRMS_Application.Models;
using System.Diagnostics.Eventing.Reader;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IDeviceOperations
    {
        public List<DeviceTable> GetAllInfo();
        public List<DeviceTable> GetByEmpCreId(int empCredId);
        public string InsertInfo(DeviceTable deviceInfo);
        public string UpdateInfo(DeviceTable deviceInfo);
        public bool DeleteInfo(int id);

    }
}
