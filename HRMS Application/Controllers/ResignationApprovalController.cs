using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResignationApprovalController : ControllerBase
    {
        private readonly ILogger<ResignationApprovalController> _logger;
        private readonly IResignationApproval _resignationApproval;

        public ResignationApprovalController(ILogger<ResignationApprovalController> logger, IResignationApproval resignationApproval)
        {
            _logger = logger;
            _resignationApproval = resignationApproval;
        }

        [HttpGet]
        public List<ResignationApprovalStatus> GetData()
        {
            _logger.LogInformation("Get Resignation approval data method started");
            var res = _resignationApproval.GetData();
            return res;
        }

        [HttpPost]
        public string InsertResignation(ResignationApprovalStatus resignation)
        {
            _logger.LogInformation("Insert resignation approval data method started");
            var res = _resignationApproval.InsertResignation(resignation);
            return res;
        }

        [HttpPut]
        public string UpdateResignation(ResignationApprovalStatus resignation)
        {
            _logger.LogInformation("Update resignation approval method started");
            var res = _resignationApproval.UpdateResignation(resignation);
            return res;
        }

        [HttpPut("SoftDelete")]
        public bool SoftDeleteResignation(int id, short isActive)
        {
            _logger.LogInformation("Soft delete method started");
            var res = _resignationApproval.SoftDeleteResignation(id, isActive);
            return res;
        }

    }
}
