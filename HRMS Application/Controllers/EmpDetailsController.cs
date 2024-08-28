using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Authorization;

using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpDetailsController : ControllerBase
    {
        private readonly IEmpDetails _Empdetails;
        private readonly ILogger<EmpDetailsController> _logger;


        public EmpDetailsController(IEmpDetails EmpDetails, ILogger<EmpDetailsController> logger)
        {
            _Empdetails = EmpDetails;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(new[] { "Admin","Developer" })]
        public List<EmployeeDetail> GetAllEmpDetails()
        {
            _logger.LogInformation("Get all department method started");
            var dept = _Empdetails.GetAllUser();
            return dept;
        }
        [HttpGet("GetById")]
        [AllowAnonymous]
        public EmployeeDetail GetById(int id)
        {
           
            var status = _Empdetails.GetById(id);
            return status;
        }

        [HttpPost("insertEmployees")]
        [Authorize(new[] { "Admin" })]
        public async Task<IActionResult> InsertEmployee([FromBody] EmployeeDetail employeeDetail)
        {
            if (employeeDetail == null)
            {
                _logger.LogError("Employee detail is null.");
                return BadRequest("Employee detail is null.");
            }

            // Extract the companyId from the JWT token
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (string.IsNullOrWhiteSpace(token))
            {
                _logger.LogError("Authorization token is missing.");
                return Unauthorized("Authorization token is missing.");
            }

            int companyId;
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                companyId = int.Parse(jwtToken.Claims.First(claim => claim.Type == "CompanyId").Value);
            }
            catch
            {
                _logger.LogError("Invalid token or companyId claim.");
                return Unauthorized("Invalid token or companyId claim.");
            }

            _logger.LogInformation("Inserting employee...");
            var result = await _Empdetails.InsertEmployeeAsync(employeeDetail, companyId);

            if (result.Contains("successfully"))
            {
                return Ok(result);
            }

            _logger.LogError(result);
            return BadRequest(result);
        }
        [HttpPut("UpdateAll/{id}")]
        [Authorize(new[] { "Admin" })]
        // [Route("UpdateAll")]
        public async Task<EmployeeDetail> UpdateEmployeeDetails(int id, int? depId, string? fname, string? mname, string? lname, int? positionid, string? Designation, string? Email, int? employeecredentialId, string? EmployeeNumber, int? requsetCompanyId)
        {
            _logger.LogInformation("Update Employeedetails method started");
            var status = await _Empdetails.UpdateEmployeeDetail(id,depId,fname,mname,lname,positionid,Designation,Email,employeecredentialId,EmployeeNumber,requsetCompanyId);
            return status;
        }

        [HttpDelete("{id}")]
        [Authorize(new[] { "Admin" })]
        public async Task<bool> DeleteEmpDetails(int id)
        {
            _logger.LogInformation("Delete method started");
            var status = await _Empdetails.DeleteEmployeeDetail(id);
            return status;
        }
    }
}
/**/