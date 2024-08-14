using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using HRMS_Application.BusinessLogic.Interface;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeImportController : ControllerBase
    {
        private readonly IEmployeeImportService _employeeImportService;

        public EmployeeImportController(IEmployeeImportService employeeImportService)
        {
            _employeeImportService = employeeImportService;
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImportEmployees(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            // Extract companyId from the token
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var companyId = int.Parse(jwtToken.Claims.First(claim => claim.Type == "CompanyId").Value);

            using (var stream = file.OpenReadStream())
            {
                var result = await _employeeImportService.ImportEmployeesFromExcelAsync(stream, companyId);
                return Ok(new
                {
                    Message = "File imported successfully.",
                    Inserted = result.Inserted,
                    Rejected = result.Rejected,
                    Errors = result.Errors
                });
            }
        }
    }
}
