using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.FormulaParsing;
using System.IdentityModel.Tokens.Jwt;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateEmployeeDetailController : ControllerBase
    {
        private readonly IUpdateEmployeeDetails _updateEmpdetails;
        private readonly ILogger<UpdateEmployeeDetailController> _logger;

        public UpdateEmployeeDetailController(IUpdateEmployeeDetails EmpDetails, ILogger<UpdateEmployeeDetailController> logger)
        {
            _updateEmpdetails = EmpDetails;
            _logger = logger;
        }
        [HttpGet("getEmpdetails")]
        public async Task<IActionResult> GetEmployeeInfo()
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
                if (!int.TryParse(empCredentialClaim.Value, out int employeeCredentialId))
                {
                    return BadRequest("Invalid UserId in token.");
                }

                var employeeInfo = await _updateEmpdetails.GetEmployeeInfoAsync(employeeCredentialId);

                if (employeeInfo == null)
                {
                    return NotFound("Employee with the given credential ID not found.");
                }

                return Ok(employeeInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
        [HttpGet("Emppersonaldetails")]
        public async Task<IActionResult> GetEmployeePersonalInfo()
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
                if (!int.TryParse(empCredentialClaim.Value, out int employeeCredentialId))
                {
                    return BadRequest("Invalid UserId in token.");
                }

                var employeePersonalInfo = await _updateEmpdetails.GetEmployeePersonalInfoAsync(employeeCredentialId);

                if (employeePersonalInfo == null)
                {
                    return NotFound("Employee with the given credential ID not found.");
                }

                return Ok(employeePersonalInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("Empaddressdetails")]
        public async Task<IActionResult> GetEmployeeAddressInfo()
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
                if (!int.TryParse(empCredentialClaim.Value, out int employeeCredentialId))
                {
                    return BadRequest("Invalid UserId in token.");
                }

                var employeeAddressInfo = await _updateEmpdetails.GetEmployeeAddressInfoAsync(employeeCredentialId);

                if (employeeAddressInfo == null)
                {
                    return NotFound("Employee with the given credential ID not found.");
                }

                return Ok(employeeAddressInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("Empaccountdetails")]
        public async Task<IActionResult> GetEmployeeAccountInfo()
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
                if (!int.TryParse(empCredentialClaim.Value, out int employeeCredentialId))
                {
                    return BadRequest("Invalid UserId in token.");
                }

                var accountInfo = await _updateEmpdetails.GetEmployeeAccountInfoAsync(employeeCredentialId);

                if (accountInfo == null)
                {
                    return NotFound("Employee with the given credential ID not found.");
                }

                return Ok(accountInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("updateemployeeinfo")]
        public async Task<IActionResult> UpdateEmployeeInfo([FromBody] UpdateEmployeeInfoDTO updateEmployeeInfo)
        {
            try
            {
                // Extract the JWT token from the Authorization header
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

                if (!int.TryParse(empCredentialClaim.Value, out int employeeCredentialId))
                {
                    return BadRequest("Invalid UserId in token.");
                }

                updateEmployeeInfo.EmployeeCredentialId = employeeCredentialId;

                var updateResult = await _updateEmpdetails.UpdateEmployeeInfoAsync(updateEmployeeInfo);

                if (!updateResult)
                {
                    return NotFound("Employee with the given credential ID not found or update failed.");
                }

                return Ok("Employee information updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("PersonalDetails")]
        public async Task<IActionResult> UpdateEmployeePersonalInfo([FromBody] EmpPersonalInfoDTO empPersonalInfoDTO)
        {
       
            try
            {
                // Extract the JWT token from the Authorization header
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

                if (!int.TryParse(empCredentialClaim.Value, out int employeeCredentialId))
                {
                    return BadRequest("Invalid UserId in token.");
                }

                empPersonalInfoDTO.EmployeeCredentialId = employeeCredentialId;

                var updateResult = await _updateEmpdetails.UpdateEmployeepersonalInfoAsync(empPersonalInfoDTO);

                if (!updateResult)
                {
                    return NotFound("Employee with the given credential ID not found or update failed.");
                }

                return Ok("Employee information updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("AddressDetail")]
        public async Task<IActionResult> UpdateEmployeeAddressInfo([FromBody] AddressInfoDTO addressInfo)
        {
            try
            {
                // Extract the JWT token from the Authorization header
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

                if (!int.TryParse(empCredentialClaim.Value, out int employeeCredentialId))
                {
                    return BadRequest("Invalid UserId in token.");
                }

                addressInfo.EmployeeCredentialId = employeeCredentialId;

                var updateResult = await _updateEmpdetails.UpdateEmployeeAddresslInfoAsync(addressInfo);

                if (!updateResult)
                {
                    return NotFound("Employee with the given credential ID not found or update failed.");
                }

                return Ok("Employee information updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("AccountDetail")]
        public async Task<IActionResult> UpdateEmployeeAccountInfo([FromBody] AccountDetail accountDetail)
        {
      
            try
            {
                // Extract the JWT token from the Authorization header
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

                if (!int.TryParse(empCredentialClaim.Value, out int employeeCredentialId))
                {
                    return BadRequest("Invalid UserId in token.");
                }

                accountDetail.EmployeeCredentialId = employeeCredentialId;

                var updateResult = await _updateEmpdetails.UpdateEmployeeAccountInfoAsync(accountDetail);

                if (!updateResult)
                {
                    return NotFound("Employee with the given credential ID not found or update failed.");
                }

                return Ok("Employee information updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
