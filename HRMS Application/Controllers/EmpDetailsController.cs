using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Authorization;

using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.DTO;
using HRMS_Application.GlobalSearch;
using System.IdentityModel.Tokens.Jwt;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpDetailsController : ControllerBase
    {
        private readonly IEmpDetails _Empdetails;
        private readonly ILogger<EmpDetailsController> _logger;
/**/

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
                return BadRequest("Employee details are required.");
            }

            try
            {
                // Extract the JWT token from the Authorization header
                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Authorization token is missing or invalid.");
                }

                // Decode the JWT token to get the company ID
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                var companyIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "CompanyId");
                if (companyIdClaim == null)
                {
                    return Unauthorized("Company ID not found in token.");
                }

                // Parse the company ID from the claim
                if (!int.TryParse(companyIdClaim.Value, out int companyId))
                {
                    return BadRequest("Invalid Company ID in token.");
                }

                // Call the service to insert the employee
                string result = await _Empdetails.InsertEmployeeAsync(employeeDetail, companyId);

                if (result.Contains("already in use"))
                {
                    return Conflict(result); // Return 409 Conflict if email already exists
                }

                return Ok(result); // Return 200 OK if employee is inserted successfully
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPut("UpdateAll/{id}")]
        [Authorize(new[] { "Admin" })]
        // [Route("UpdateAll")]
        public async Task<EmployeeDetail> UpdateEmployeeDetails( int id, int? depId, string? fname, string? mname, string? lname, int? positionid, string? Designation, string? Email, int? employeecredentialId, string? EmployeeNumber, int? requsetCompanyId)
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

        [HttpPut("SoftDelete")]
        [Authorize(new[] { "Admin" })]

        public bool SoftDelete(int id, short isActive)
        {
            _logger.LogInformation("Soft update Employee details method started");
            var res = _Empdetails.SoftDelete(id, isActive);
            return res;

        }
        [HttpGet("EmployeeInfo")]
        [Authorize(new[] { "Admin" })]

        public ActionResult<IEnumerable<EmployeeView>> GetAllEmployees()
        {
            var employees = _Empdetails.GetAllEmployees();

            return Ok(employees);
        }
        [HttpGet("getdetails/{employeeCredentialId}")]
        [Authorize(new[] { "Admin" })]

        public async Task<IActionResult> GetEmployeeInfo(int employeeCredentialId)
        {
            var employeeInfo = await _Empdetails.GetEmployeeInfoAsync(employeeCredentialId);

            if (employeeInfo == null)
            {
                return NotFound("Employee with the given credential ID not found.");
            }

            return Ok(employeeInfo);
        }
        [HttpGet("personaldetails/{employeeCredentialId}")]
        [Authorize(new[] { "Admin" })]

        public async Task<IActionResult> GetEmployeePersonalInfo(int employeeCredentialId)
        {
            var employeePersonalInfo = await _Empdetails.GetEmployeePersonalInfoAsync(employeeCredentialId);

            if (employeePersonalInfo == null)
            {
                return NotFound("Employee personal information not found for the given credential ID.");
            }

            return Ok(employeePersonalInfo);
        }
        [HttpGet("addressdetails/{employeeCredentialId}")]
        [Authorize(new[] { "Admin" })]

        public async Task<IActionResult> GetEmployeeAddressInfo(int employeeCredentialId)
        {
            var employeeAddressInfo = await _Empdetails.GetEmployeeAddressInfoAsync(employeeCredentialId);

            if (employeeAddressInfo == null)
            {
                return NotFound("Employee address information not found for the given credential ID.");
            }

            return Ok(employeeAddressInfo);
        }
        [HttpGet("accountdetails/{employeeCredentialId}")]
        [Authorize(new[] { "Admin" })]

        public async Task<IActionResult> GetEmployeeAccountInfo(int employeeCredentialId)
        {
            var accountInfo = await _Empdetails.GetEmployeeAccountInfoAsync(employeeCredentialId);

            if (accountInfo == null)
            {
                return NotFound("Employee account information not found for the given credential ID.");
            }

            return Ok(accountInfo);
        }

        [HttpGet("EmployeeSearch/")]

        public IActionResult Get([FromQuery] GlobalsearchEmp globalsearch)
        {
            try
            {
                // Retrieve the Authorization token
                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Authorization token is missing or invalid.");
                }

                // Decode the JWT token to get the company ID
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                // Extract the CompanyId from the token
                var companyIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "CompanyId");
                if (companyIdClaim == null)
                {
                    return Unauthorized("Company ID not found in token.");
                }

                // Parse the company ID
                if (!int.TryParse(companyIdClaim.Value, out int companyId))
                {
                    return BadRequest("Invalid Company ID in token.");
                }

                var model = _Empdetails.GetFilters(globalsearch,companyId);

                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all employees.");
                return StatusCode(500, "An error occurred while fetching employee data.");
            }
        }

        [HttpPut("updatedetails")]
        [Authorize(new[] { "Admin" })]
        public async Task<IActionResult> UpdateEmployeeInfo([FromBody] UpdateEmployeeInfoDTO updateEmployeeInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _Empdetails.UpdateEmployeeInfoAsync(updateEmployeeInfo);

            if (!result)
            {
                return NotFound("Employee with given credential ID not found.");
            }

            return Ok("Employee information updated successfully.");
        }

        [HttpPut("PersonalDetails")]
        [Authorize(new[] { "Admin" })]

        public async Task<IActionResult> UpdateEmployeePersonalInfo([FromBody] EmpPersonalInfoDTO empPersonalInfoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _Empdetails.UpdateEmployeepersonalInfoAsync(empPersonalInfoDTO);

            if (!result)
            {
                return NotFound("Employee with given credential ID not found.");
            }

            return Ok("Employee information updated successfully.");
        }
        [HttpPut("AddressDetail")]
        [Authorize(new[] { "Admin" })]

        public async Task<IActionResult> UpdateEmployeeAddressInfo([FromBody] AddressInfoDTO addressInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _Empdetails.UpdateEmployeeAddresslInfoAsync(addressInfo);

            if (!result)
            {
                return NotFound("Employee with given credential ID not found.");
            }

            return Ok("Employee information updated successfully.");
        }
        [HttpPut("AccountDetail")]
        [Authorize(new[] { "Admin" })]

        public async Task<IActionResult> UpdateEmployeeAccountInfo([FromBody] AccountDetailDTO accountDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }/**/

            var result = await _Empdetails.UpdateEmployeeAccountInfoAsync(accountDetail);

            if (!result)
            {
                return NotFound("Employee with given credential ID not found.");
            }

            return Ok("Employee information updated successfully.");
        }

        [HttpGet("GetEmployeeShiftAndLeaveStats")]
        public IActionResult GetEmployeeShiftAndLeaveStats()
        {
            try
            {
                // Extract the JWT token from the Authorization header
                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "").Trim();
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Authorization token is missing or invalid.");
                }

                // Decode the JWT token to get the empCredentialId
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                // Extract the "UserId" claim from the token
                var empCredentialClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "UserId");
                if (empCredentialClaim == null)
                {
                    return Unauthorized("UserId not found in token.");
                }

                // Parse the empCredentialId from the claim
                if (!int.TryParse(empCredentialClaim.Value, out int empCredentialId))
                {
                    return BadRequest("Invalid UserId in token.");
                }

                var stats = _Empdetails.GetEmployeeShiftAndLeaveStats(empCredentialId);
                return Ok(stats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("monthly-statistics")]
        public IActionResult GetMonthlyStatistics(DateTime month)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "").Trim();
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Authorization token is missing or invalid.");
                }

              
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                
                var empCredentialClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "UserId");
                if (empCredentialClaim == null)
                {
                    return Unauthorized("UserId not found in token.");
                }

                if (!int.TryParse(empCredentialClaim.Value, out int empCredentialId))
                {
                    return BadRequest("Invalid UserId in token.");
                }
                var statistics = _Empdetails.GetMonthlyStatistics(empCredentialId, month);
                return Ok(statistics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut("UpdateProfileImageUrl")]
        [Authorize(new[] { "Admin", "User","HR" })]
        public async Task<IActionResult> UpdateImageUrl(IFormFile file)
        {
            _logger.LogInformation("Update employee imageUrl method started");

            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "").Trim();
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Authorization token is missing or invalid.");
            }

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            // Extract the "UserId" claim from the token
            var empCredentialClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "UserId");
            if (empCredentialClaim == null)
            {
                return Unauthorized("UserId not found in token.");
            }

            // Parse the empCredentialId from the claim
            if (!int.TryParse(empCredentialClaim.Value, out int empCredentialId))
            {
                return BadRequest("Invalid UserId in token.");
            }

            var result = await _Empdetails.UpdateImageUrl(empCredentialId, file); 
            return Ok(result); 
        }

        [HttpGet("GetUserDetails")]
        public IActionResult GetUserdetails()
        {
            try
            {
                // Extract the JWT token from the Authorization header
                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "").Trim();
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Authorization token is missing or invalid.");
                }

                // Decode the JWT token to get empCredentialId and companyId
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                // Extract the "UserId" claim from the token
                var empCredentialClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "UserId");
                var companyIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "CompanyId");

                if (empCredentialClaim == null || companyIdClaim == null)
                {
                    return Unauthorized("UserId or CompanyId not found in token.");
                }

                // Parse the empCredentialId and companyId from the claims
                if (!int.TryParse(empCredentialClaim.Value, out int empCredentialId))
                {
                    return BadRequest("Invalid UserId in token.");
                }

                if (!int.TryParse(companyIdClaim.Value, out int companyId))
                {
                    return BadRequest("Invalid CompanyId in token.");
                }

                // Fetch user details using empCredentialId and companyId
                var userDetails = _Empdetails.GetUserDetails(empCredentialId, companyId);

                return Ok(userDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
