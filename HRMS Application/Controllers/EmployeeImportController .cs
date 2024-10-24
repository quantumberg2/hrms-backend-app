
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Authorization;

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
        [Authorize(new[] { "Admin" })]

        public async Task<IActionResult> ImportEmployees(IFormFile file)
        {
            // Validate the uploaded file
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            // Extract the Authorization header and remove "Bearer " prefix
            var authorizationHeader = HttpContext.Request.Headers["Authorization"].ToString();

            if (string.IsNullOrWhiteSpace(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
            {
                return BadRequest("Authorization header is missing or improperly formatted.");
            }

            var token = authorizationHeader.Replace("Bearer ", "").Trim();

            try
            {
                // Read and validate the token
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                // Extract companyId from the token claims
                var companyIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "CompanyId");

                if (companyIdClaim == null)
                {
                    return BadRequest("CompanyId not found in token.");
                }

                var companyId = int.Parse(companyIdClaim.Value);

                // Directly pass the IFormFile to the service method
                var result = await _employeeImportService.ImportEmployeesFromExcelAsync(file, companyId);

                // Return the result
                return Ok(new
                {
                    Message = "File imported successfully.",
                    Inserted = result.Inserted,
                    Rejected = result.Rejected,
                    Errors = result.Errors
                });
            }
            catch (ArgumentException ex)
            {
                // Handle invalid JWT token format
                return BadRequest($"Invalid token format: {ex.Message}");
            }
            catch (Exception ex)
            {
                // General error handling
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
    }
}
