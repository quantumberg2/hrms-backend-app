using HRMS_Application.BusinessLogic.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertEmailOperationsController : ControllerBase
    {
        private readonly IAlertEmailOperations _alertEmailOperations;
        private readonly ILogger<AlertEmailOperationsController> _logger;   
        public AlertEmailOperationsController(IAlertEmailOperations alertEmailOperations, ILogger<AlertEmailOperationsController> logger)
        {
            _alertEmailOperations = alertEmailOperations;
            _logger = logger;

        }

        [HttpPost("send-leave-notification")]
        public IActionResult SendLeaveNotification(string eventType, string toEmail, string? employeeName, string? startDate, string? endDate, string? absentDate)
        {
            _logger.LogInformation("Send leave Notifications method started");

            var parameters = new Dictionary<string, string>
            {
                { "To", toEmail },
                { "EmployeeName", employeeName },
                { "StartDate", startDate },
                { "EndDate", endDate },
                { "AbsentDate", absentDate }
            };

            string emailTemplate = "";
            switch (eventType.ToLower())
            {
                case "leave-approved":
                    parameters["Subject"] = "Your Leave Request has been Approved";
                    emailTemplate = "Hello {{EmployeeName}}, your leave request from {{StartDate}} to {{EndDate}} has been approved. Enjoy your time off!";
                    break;
                case "leave-rejected":
                    parameters["Subject"] = "Your Leave Request has been Rejected";
                    emailTemplate = "Hello {{EmployeeName}}, unfortunately, your leave request from {{StartDate}} to {{EndDate}} has been rejected. Please contact HR for more details.";
                    break;
                case "leave-applied":
                    parameters["Subject"] = "Leave Request Received";
                    emailTemplate = "Hello {{EmployeeName}}, your leave request from {{StartDate}} to {{EndDate}} has been successfully submitted and is pending approval.";
                    break;
                case "absent":
                    parameters["Subject"] = "Absent Notification";
                    emailTemplate = "Hello {{EmployeeName}}, we noticed you were absent on {{AbsentDate}}. If this was unintentional, please contact HR or your supervisor.";
                    break;
                default:
                    return BadRequest("Invalid event type");
            }

            _alertEmailOperations.SendEmail(emailTemplate, parameters);
            return Ok("Email sent successfully");
        }
    }
}
