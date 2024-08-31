using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using UnlimitSoft.Message;
using HRMS_Application.Authorization;
using HRMS_Application.Middleware;
using HRMS_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpPersonalInfoController : ControllerBase
    {
        private readonly ILogger<EmpPersonalInfoController> _logger;
        private readonly IEmpPersonalInfo _empPersonalInfo;
        private readonly HRMSContext _context;
        public EmpPersonalInfoController(ILogger<EmpPersonalInfoController> logger, IEmpPersonalInfo empPersonalInfo, HRMSContext context)
        {
            _empPersonalInfo = empPersonalInfo;
            _logger = logger;
            _context = context;

        }

        [HttpPost]
        [Authorize(new[] {"Admin","User"})]
        public IActionResult InsertEmpPersonalInfo(EmpPersonalInfoDTO empPersonalInfo)
        {
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
            _logger.LogInformation("Insert Employee personal info method started");

            // Create EmpPersonalInfo object from DTO
            var employeepersonal = new EmpPersonalInfo
            {
                BloodGroup = empPersonalInfo.BloodGroup,
                EmployeeCredentialId = empCredentialId,
                SpouseName = empPersonalInfo.SpouseName,
                DateOfJoining = empPersonalInfo.DateOfJoining,
                EmailId = empPersonalInfo.EmailId,
                ConfirmDate = empPersonalInfo.ConfirmDate,
                Dob = empPersonalInfo.Dob,
                EmergencyContact = empPersonalInfo.EmergencyContact,
                EmpStatus = empPersonalInfo.EmpStatus,
                MaritalStatus = empPersonalInfo.MaritalStatus,
                PersonalEmail = empPersonalInfo.PersonalEmail,
                PhysicallyChallenged = empPersonalInfo.PhysicallyChallenged
            };

            // Insert or update EmpPersonalInfo
            var result = _empPersonalInfo.InsertEmpPersonalInfo(employeepersonal, empCredentialId);

            // Retrieve the EmployeeDetail record to check if it exists
           /* var employeeDetail = _context.EmployeeDetails
                                        .FirstOrDefault(detail => detail.EmployeeCredentialId == empCredentialId);*/
           var employeeDetail = ( from row in _context.EmployeeDetails
                                  where row.EmployeeCredentialId == empCredentialId
                                  select row).FirstOrDefault();

            if (employeeDetail != null)
            {
                var objEmpDetails = new EmployeeDetail
                {
                    FirstName = empPersonalInfo.FirstName,
                    LastName = empPersonalInfo.LastName,
                    MiddleName = empPersonalInfo.MiddleName,
                    Email = empPersonalInfo.EmailId
                };

                // Add EmployeeDetail record to the context
                _context.EmployeeDetails.Add(objEmpDetails);

                // Save changes to both tables
                _context.SaveChanges();

                _logger.LogInformation("Employee personal info and details successfully inserted.");
                return Ok("Employee personal info and details successfully inserted.");
            }

            _logger.LogError("Failed to insert employee details. EmployeeDetail record not found.");
            return BadRequest("Failed to insert employee details.");
        }


    }
}

