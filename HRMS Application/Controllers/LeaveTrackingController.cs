using HRMS_Application.Models;
using HRMS_Application.BusinessLogic.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Create([FromBody] LeaveTracking leaveTracking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdLeaveTracking = await _leaveTracking.CreateAsync(leaveTracking);
            return CreatedAtAction(nameof(GetById), new { id = createdLeaveTracking.Id }, createdLeaveTracking);
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
