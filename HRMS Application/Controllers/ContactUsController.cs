using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUs _contact;
        private readonly ILogger<ContactUsController> _logger;

        public ContactUsController(IContactUs contact, ILogger<ContactUsController> logger)
        {
            _contact = contact;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> SendMessageAsync([FromForm] ContactUsDTO contact)
        {
            _logger.LogInformation("Send message method started");

            await _contact.SendMessageAsync(contact);

            _logger.LogInformation("Message sent successfully.");
            return Ok("Message sent successfully.");
        }


    }
}
