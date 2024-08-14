using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

            using (var stream = file.OpenReadStream())
            {
                var result = await _employeeImportService.ImportEmployeesFromExcelAsync(stream);
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
