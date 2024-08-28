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

        public LeaveTrackingController(ILeaveTracking leaveTracking)
        {
            _leaveTracking = leaveTracking;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var leaveTrackings = await _leaveTracking.GetAllAsync();
            return Ok(leaveTrackings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
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
            try
            {
                // Extract the token from the Authorization header
                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                // Decode the JWT token to extract claims
                var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
                var empCredentialIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "UserId");

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
                    EmpCredentialId = leaveTrackingDto.EmpCredentialId,
                    Applied = leaveTrackingDto.Applied,
                    Status = "Pending",
                    Files= leaveTrackingDto.Files,
                    Session = leaveTrackingDto.Session,
                    Contact = leaveTrackingDto.Contact,
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LeaveTracking leaveTracking)
        {
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _leaveTracking.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
