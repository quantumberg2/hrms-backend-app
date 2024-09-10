using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HRMS_Application.DTO;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpLeaveAllocationController : ControllerBase
    {
        private readonly IEmpLeaveAllocation _employeeLeaveService;
        private readonly ILogger<EmpLeaveAllocationController> _logger;
        private readonly HRMSContext _context;

        public EmpLeaveAllocationController(IEmpLeaveAllocation employeeLeaveService, ILogger<EmpLeaveAllocationController> logger, HRMSContext context)
        {
            _employeeLeaveService = employeeLeaveService;
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Authorize(new[] { "Admin", "Developer" })]
        public IActionResult GetAllEmpleaves()
        {
            _logger.LogInformation("Get all employee leave method started");
            var dept = _employeeLeaveService.GetAllEmpLeave();
            return Ok(dept);
        }

        [HttpGet("CalculateLeaves/{empCredentialId}")]
        public IActionResult CalculateLeaves(int empCredentialId)
        {
            var leaveAllocations = _context.EmployeeLeaveAllocations
                .Where(e => e.EmpCredentialId == empCredentialId)
                .ToList();

            if (leaveAllocations == null || !leaveAllocations.Any())
            {
                return NotFound("Leave allocation not found for the specified employee and year.");
            }

            var leaveTypes = _context.LeaveTypes.ToList();
            var leaveTrackings = _context.LeaveTrackings
                .Where(l => l.EmpCredentialId == empCredentialId )
                .ToList();

            var result = leaveAllocations.Select(leaveAllocation =>
            {
                var totalLeaves = leaveTypes.FirstOrDefault(lt => lt.Id == leaveAllocation.LeaveType)?.Days ?? 0;
                var usedLeaves = leaveTrackings
                    .Where(lt => lt.LeaveTypeId == leaveAllocation.LeaveType)
                    .Sum(lt => EF.Functions.DateDiffDay(lt.Startdate.Value, lt.Enddate.Value) + 1);

                leaveAllocation.NumberOfLeaves = totalLeaves;
                leaveAllocation.RemainingLeave = totalLeaves - usedLeaves;

                return new
                {
                    LeaveType = leaveAllocation.LeaveTypeNavigation.Type,  // Corrected to use 'Type'
                    TotalLeaves = totalLeaves,
                    UsedLeaves = usedLeaves,
                    RemainingLeaves = leaveAllocation.RemainingLeave
                };
            }).ToList();

            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            _logger.LogInformation("Get employee leave by ID method started");
            var status = _employeeLeaveService.GetByEmpLeavebyId(id);
            if (status == null)
            {
                return NotFound("Employee leave not found");
            }
            return Ok(status);
        }

        [HttpPost("InsertEmployeeLeave")]
        [Authorize(new[] { "Admin" })]
        public async Task<IActionResult> InsertEmpLeaves([FromBody] EmployeeLeaveAllocation employeeLeave)
        {
            _logger.LogInformation("Insert employee leave method started");

            var status = await _employeeLeaveService.InsertEmployeeLeave(employeeLeave);
            if (status == "new Employeeleave inserted successfully")
            {
                return CreatedAtAction(nameof(GetById), new { id = employeeLeave.Id }, employeeLeave);
            }
            return BadRequest(status);
        }

        [HttpDelete("{id}")]
        [Authorize(new[] { "Admin" })]
        public async Task<IActionResult> DeleteEmpDetails(int id)
        {
            _logger.LogInformation("Delete method started");
            var result = await _employeeLeaveService.DeleteEmployeeLeave(id);
            if (!result)
            {
                return NotFound("Employee leave not found");
            }
            return NoContent();
        }

        [HttpPut("SoftDelete")]
        [Authorize(new[] { "Admin" })]
        public bool SoftDelete(int id, short isActive)
        {
            _logger.LogInformation("Soft update Employee leave method started");
            var res = _employeeLeaveService.SoftDelete(id, isActive);
            return res;

        }
        [HttpPost("GrantLeave")]
        public IActionResult SaveEmployeeLeaveAllocation([FromBody] EmployeeLeaveAllocationRequest request)
        {
            if (request == null || (request.EmpCredentialIds == null && request.EmpCredentialId == null))
            {
                return BadRequest("Invalid input data.");
            }

            try
            {
                // Check if it's a single credential ID request
                if (request.EmpCredentialId.HasValue)
                {
                    SaveLeaveAllocation(request.EmpCredentialId.Value, request);
                }
                // Handle multiple credential IDs
                else if (request.EmpCredentialIds != null && request.EmpCredentialIds.Any())
                {
                    foreach (var credentialId in request.EmpCredentialIds)
                    {
                        SaveLeaveAllocation(credentialId, request);
                    }
                }

                return Ok("Leave allocation saved successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private void SaveLeaveAllocation(int empCredentialId, EmployeeLeaveAllocationRequest request)
        {
            var leaveAllocation = new EmployeeLeaveAllocation
            {
                Year = request.Year,
                EmpCredentialId = empCredentialId,
                NumberOfLeaves = request.NumberOfLeaves,
                RemainingLeave = request.NumberOfLeaves, // Default to NumberOfLeaves if not specified
                LeaveType = request.LeaveType, // Default to 1 or any default LeaveType ID you have
                IsActive = 1 // Default to 1
            };

            _context.EmployeeLeaveAllocations.Add(leaveAllocation);
            _context.SaveChanges();
        }

    }
}