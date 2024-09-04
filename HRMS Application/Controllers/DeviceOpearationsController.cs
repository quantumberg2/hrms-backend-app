using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceOpearationsController : ControllerBase
    {
        private readonly ILogger<DeviceOpearationsController> _logger;
        private readonly IDeviceOperations _deviceOperations;

        public DeviceOpearationsController(ILogger<DeviceOpearationsController> logger,IDeviceOperations deviceOperations)
        {
            _deviceOperations = deviceOperations;
            _logger = logger;
        }

        [HttpGet]
        public List<DeviceTable> GetAllInfo()
        {
            _logger.LogInformation("Get all login info method started");
            var res = _deviceOperations.GetAllInfo();
            return res;
        }

        [HttpGet("GetByEmpCredId")]
        public List<DeviceTable> GetByEmpCreId(int empCredId)
        {
            _logger.LogInformation("Get info by Employee credential id");
            var res = _deviceOperations.GetByEmpCreId(empCredId);
            return res;
        }

        [HttpPost]
        public string InsertInfo(DeviceTable deviceInfo)
        {
            _logger.LogInformation("Post login info method started");
            var res = _deviceOperations.InsertInfo(deviceInfo);
            return res;
        }

        [HttpPut]
        public string UpdateInfo(DeviceTable deviceInfo)
        {
            _logger.LogInformation("Update login info method started");
            var res = _deviceOperations.UpdateInfo(deviceInfo);
            return res;
        }

        [HttpDelete]
        public bool DeleteInfo(int id)
        {
            _logger.LogInformation("Delete login info method started");
            var res = _deviceOperations.DeleteInfo(id);
            return res;
        }
    }
}
