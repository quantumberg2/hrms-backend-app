using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;
using HRMS_Application.Middleware.Exceptions;
using System.IdentityModel.Tokens.Jwt;


namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPosition _position;
        private readonly ILogger<PositionController> _logger;


        public PositionController(IPosition position, ILogger<PositionController> logger)
        {
            _position = position;
            _logger = logger;
        }
        [HttpGet]
        [Authorize(new[] { "Admin" })]
        public IActionResult GetAllPositions()
        {
            try
            {
                _logger.LogInformation("GetAllPositions method started");

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

                // Get positions based on the companyId
                var positions = _position.GetPositions()
                                         .Where(p => p.RequestedCompanyId == companyId) 
                                         .ToList();

                return Ok(positions); // Return the list of positions as a successful response
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the positions.");
                return StatusCode(500, "An error occurred while fetching the positions.");
            }
        }

        [HttpPost("insertEmployees")]
        [Authorize(new[] { "Admin" })]
        public async Task<IActionResult> InsertPositions([FromBody] Position position)
        {
            _logger.LogInformation("Insert Positions method started");


            try
            {
                // Extract the JWT token from the Authorization header
                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Authorization token is missing or invalid.");
                }

                // Decode the JWT token to get the RequestedCompanyId
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                var companyIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "CompanyId");
                if (companyIdClaim == null)
                {
                    return Unauthorized("Company ID not found in token.");
                }

                // Parse the company ID from the claim
                if (!int.TryParse(companyIdClaim.Value, out int requestedCompanyId))
                {
                    return BadRequest("Invalid Company ID in token.");
                }

                // Set the RequestedCompanyId in the Position object
                position.RequestedCompanyId = requestedCompanyId;
                position.IsActive = 1;

                // Call the service method to insert the position
                var status = await _position.InsertPositions(position);
                return Ok(status);
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogError(ex, "Unauthorized access while inserting position");
                return Unauthorized(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, "Invalid operation while inserting position");
                return BadRequest(ex.Message);
            }
            catch (DatabaseOperationException ex)
            {
                _logger.LogError(ex, "Database operation failed while inserting position");
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error while inserting position");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("UpdateAll/{id}")]
        [Authorize(new[] { "Admin" })]
        // [Route("UpdateAll")]
        public async Task<Position> UpdatePosition(int id, string? name, int? requestedcompanyId)
        {
            _logger.LogInformation("Update Positions method started");
            var status = await _position.updateposition(id, name, requestedcompanyId);
            return status;
        }

        [HttpDelete("{id}")]
        [Authorize(new[] { "Admin" })]
        public async Task<bool> DeletePosition(int id)
        {
            _logger.LogInformation("Delete method started");
            var status = await  _position.deletePosition(id);
            return status;
        }

        [HttpPut("SoftDelete")]
        [Authorize(new[] { "Admin" })]

        public bool SoftDelete(int id, short isActive)
        {
            _logger.LogInformation("Soft update position method started");
            var res = _position.SoftDelete(id, isActive);
            return res;

        }
    }
}
