using HRMS_Application.Models;
using HRMS_Application.BusinessLogic.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using HRMS_Application.Authorization;
using HRMS_Application.DTO;

namespace HRMS_Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveTrackingController : ControllerBase
    {
        private readonly ILeaveTracking _leaveTracking;
        private readonly ILogger<LeaveTrackingController> _logger;

        public LeaveTrackingController(ILeaveTracking leaveTracking, ILogger<LeaveTrackingController> logger)
        {
            _leaveTracking = leaveTracking;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Get all leaves method started");
            var leaveTrackings = await _leaveTracking.GetAllAsync();
            return Ok(leaveTrackings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("Get leaves by Id method started");

            var leaveTracking = await _leaveTracking.GetByIdAsync(id);
            if (leaveTracking == null)
            {
                return NotFound();
            }
            return Ok(leaveTracking);
        }

        [HttpPost]
        [Authorize(new[] { "Admin", "User" })]
        public async Task<IActionResult> CreateLeaveTracking([FromBody] LeaveTrackingDTO leaveTrackingDto)
        {
            _logger.LogInformation("Apply leave method started");

            try
            {
                // Extract the token from the Authorization header
                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "").Trim();

                // Check if the token is present
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Authorization header is missing or token is empty.");
                }

                // Decode the JWT token to extract claims
                var handler = new JwtSecurityTokenHandler();
                if (!handler.CanReadToken(token))
                {
                    return Unauthorized("Invalid token format.");
                }

                var jwtToken = handler.ReadJwtToken(token);
                var empCredentialIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "UserId");

                if (empCredentialIdClaim == null)
                {
                    return Unauthorized("Employee credential ID not found in token.");
                }

                // Parse the empCredentialId from the claim
                int empCredentialId = int.Parse(empCredentialIdClaim.Value);

                // Map the DTO to the entity model
                var leaveTracking = new LeaveTracking
                {
                    LeaveTypeId = leaveTrackingDto.LeaveTypeId,
                    Startdate = leaveTrackingDto.StartDate,
                    Enddate = leaveTrackingDto.EndDate,
                    ReasonForLeave = leaveTrackingDto.ReasonForLeave,
                    EmpCredentialId = empCredentialId,
                    AppliedDate = leaveTrackingDto.Applied,
                    Status = "Pending",
                    Files = leaveTrackingDto.Files,
                    Session = leaveTrackingDto.Session,
                    Contact = leaveTrackingDto.Contact,
                    IsActive = 1,
                    // Map other necessary fields here
                };

                // Call the service to create the leave tracking record
                var result = await _leaveTracking.CreateAsync(leaveTracking, empCredentialId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("Apply_Behalf")]
        [Authorize(new[] { "Admin" })]
        public async Task<IActionResult> ApllyLeaveBehalf([FromBody] LeaveTrackingDTO leaveTrackingDto, int empCredentialId)
        {
            _logger.LogInformation("Apply leave method started");

            try
            {
               

                // Map the DTO to the entity model
                var leaveTracking = new LeaveTracking
                {
                    LeaveTypeId = leaveTrackingDto.LeaveTypeId,
                    Startdate = leaveTrackingDto.StartDate,
                    Enddate = leaveTrackingDto.EndDate,
                    ReasonForLeave = leaveTrackingDto.ReasonForLeave,
                    EmpCredentialId = empCredentialId,
                    AppliedDate = leaveTrackingDto.Applied,
                    Status = "Approved",
                    Files = leaveTrackingDto.Files,
                    Session = leaveTrackingDto.Session,
                    Contact = leaveTrackingDto.Contact,
                    IsActive = 1,
                    // Map other necessary fields here
                };

                // Call the service to create the leave tracking record
                var result = await _leaveTracking.ApllyLeaveBehalf(leaveTracking, empCredentialId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LeaveTracking leaveTracking)
        {
            _logger.LogInformation("Update leaves method started");

            if (id != leaveTracking.Id)
            {
                return BadRequest("ID mismatch");
            }

            if (!ModelState.IsValid)  
            {
                return BadRequest(ModelState);
            }

            var updatedLeaveTracking = await _leaveTracking.UpdateAsync(leaveTracking);
            if (updatedLeaveTracking == null)
            {
                return NotFound();
            }

            return Ok(updatedLeaveTracking);
        }

        [HttpPut("statusUpdate")]
        [Authorize(new[] { "Admin" })]

        public async Task<IActionResult> UpdateLeaveAsync(int id, string newStatus)
        {
            _logger.LogInformation("update leave status method started");

            var status =await _leaveTracking.UpdateLeaveAsync(id,newStatus);
            return Ok(status);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("delete leaves method started");

            var result = await _leaveTracking.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpGet("leaves/{status}")]
        public async Task<ActionResult<List<LeaveApprovalDTO>>> GetLeavesByStatus(string status)
        {
            _logger.LogInformation("Get leaves by status method started");

            var leaves = await _leaveTracking.GetLeavesByStatusAsync(status);

            if (leaves == null || !leaves.Any())
            {
                return NotFound("No leave records found with the given status.");
            }

            return Ok(leaves);
        }

        [HttpGet("summary")]
        [Authorize(new[] { "Admin", "User" })]

        public async Task<IActionResult> GetLeaveSummary()
        {
            _logger.LogInformation("Get leave summary method started");

            try
            {
                // Extract employee credential ID from the JWT token
                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
                var employeeCredentialId = int.Parse(jwtToken.Claims.First(c => c.Type == "UserId").Value); // Replace 'employee_id' with the actual claim name


                var leaveSummary = await _leaveTracking.GetEmployeeLeaveSummaryAsync(employeeCredentialId);

                return Ok(leaveSummary);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("SoftDelete")]
        [Authorize(new[] { "Admin" })]

        public bool SoftDelete(int id, short isActive)
        {
            _logger.LogInformation("Soft update Leave tracking method started");
            var res = _leaveTracking.SoftDelete(id, isActive);
            return res;

        }
    }
}
