using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResignationController : ControllerBase
    {
       private readonly ILogger<ResignationController> _logger;
       private readonly IResignation _resignation;

        public ResignationController(ILogger<ResignationController> logger, IResignation resignation)
        {
            _logger = logger;
            _resignation = resignation;
        }

        [HttpGet]
        public List<Resignation> GetData()
        {
            _logger.LogInformation("Get resignation data method started");
            var res = _resignation.GetData();
            return res;
        }

        [HttpPost]
        public string InsertResignation(Resignation resignation)
        {
            _logger.LogInformation("Insert resignation data method started");
            var res = _resignation.InsertResignation(resignation);
            return res;
        }

        [HttpPut]
        public string UpdateResignation(Resignation resignation)
        {
            _logger.LogInformation("Update resignation method started");
            var res = _resignation.UpdateResignation(resignation);
            return res;
        }

        [HttpPut("SoftDelete")]
        public bool SoftDeleteResignation(int id, short isActive)
        {
            _logger.LogInformation("Soft delete method started");
            var res = _resignation.SoftDeleteResignation(id, isActive);
            return res;
        }

    }
}
