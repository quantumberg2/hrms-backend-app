using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class DeviceOperationsImp : IDeviceOperations
    {
        private readonly HRMSContext _context;
        public DeviceOperationsImp(HRMSContext context)
        {
            _context = context;
        }
        public List<DeviceTable> GetAllInfo()
        {
            var Info = (from row in _context.DeviceTables
                        select row).ToList();
            return Info;
        }

        public List<DeviceTable> GetByEmpCreId(int empCredId)
        {
            var Info = (from row in _context.DeviceTables
                        where row.EmpCredentialId == empCredId
                        select row).ToList();
            return Info;
        }

        public string InsertInfo(DeviceTable deviceInfo)
        {
           _context.DeviceTables.Add(deviceInfo);
            var res = _context.SaveChanges();
            if (res != null)
            {
                return "Successfully added new info";
            }
            else
            {
                return "failed to insert new info";
            }


        }

        public string UpdateInfo(DeviceTable deviceInfo)
        {
            var info = (from row in _context.DeviceTables
                        where row.Id == deviceInfo.Id
                        select row).FirstOrDefault();
            if(info == null)
            {
                return "Data not found";
            }

            info.EmpCredential = deviceInfo.EmpCredential;
            info.TimeOut = deviceInfo.TimeOut;
            info.TimeIn = deviceInfo.TimeIn;
            info.InsertedDate = deviceInfo.InsertedDate;
            info.WorkTime = deviceInfo.WorkTime;
            info.OverTime = deviceInfo.OverTime;
            info.ErlOut = deviceInfo.ErlOut;
            info.LateIn = deviceInfo.LateIn;
            info.Name = deviceInfo.Name;

            _context.DeviceTables.Update(info);
            var res = _context.SaveChanges();
            if (res != null)
            {
                return "Updated successfully";
            }
            else
            {
                return "Failed to update info";
            }

        }

        public bool DeleteInfo(int id)
        {
            var res = (from row in _context.DeviceTables
                       where row.Id ==  id
                       select row).FirstOrDefault();
            if(res != null)
            {
                _context.DeviceTables.Remove(res);
                _context.SaveChanges();
                return true;    
            }

            else
            {
                return false;   
            }
        }

    }
}
