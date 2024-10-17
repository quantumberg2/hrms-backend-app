using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyDetailsController : ControllerBase
    {
        private readonly ICompanyDetails _companyDetails;
        private ILogger<CompanyDetailsController> _logger;

        public CompanyDetailsController(ICompanyDetails companyDetails, ILogger<CompanyDetailsController> logger)
        {
            _companyDetails = companyDetails;
            _logger = logger;
        }

        [HttpGet]
        public List<CompanyDetail> GetAllCompanyDetails()
        {
            _logger.LogInformation("get all company details started");
            var result = _companyDetails.GetAllCompanyDetails();
            return result;
        }
        [HttpGet("GetById")]
        public List<CompanyDetail> GetCompanyDetail(int id)
        {
            _logger.LogInformation("getbyid company details started");
            var result = _companyDetails.GetCompanyDetailstById(id);
            return result;
        }

        [HttpGet("GetDetailsByCompanyID")]
        [AllowAnonymous]
        public IActionResult GetCompanyDetailsByCompanyID()
        {
            // Get JWT token from the Authorization header
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Authorization token is missing or invalid.");
            }

            // Parse the JWT token
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            // Extract CompanyId from token claims
            var companyIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "CompanyId");

            if (companyIdClaim == null)
            {
                return Unauthorized("Company ID not found in token.");
            }

            if (!int.TryParse(companyIdClaim.Value, out int companyId))
            {
                return BadRequest("Invalid Company ID in token.");
            }

            // Fetch company details using the companyId from the token
            var companyDetails = _companyDetails.GetCompanyDetailstByCompanyId(companyId);

            if (companyDetails != null && companyDetails.Count > 0)
            {
                return Ok(companyDetails);
            }

            return NotFound("No active company details found for the specified company.");
        }

       
        [HttpPost]
        [Authorize(new[] { "Admin"})]
        public IActionResult InsertCompanyDetails([FromForm] CompanyDetailsDTO companyDetail)
        {
            try
            {
                _logger.LogInformation("InsertCompanyDetails method started");

                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Authorization token is missing or invalid.");
                }

                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                var companyIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "CompanyId");
                if (companyIdClaim == null)
                {
                    return Unauthorized("Company ID not found in token.");
                }

                if (!int.TryParse(companyIdClaim.Value, out int companyId))
                {
                      return BadRequest("Invalid Company ID in token.");
                }

                companyDetail.RequestedCompanyId = companyId;

                var result = _companyDetails.InsertCompanyDetails(companyDetail);

                if (result !=null)
                {
                    return Ok(new { Message = "Company details inserted successfully.", CompanyId = result });
                }
                else
                {
                    return StatusCode(500, "An error occurred while inserting company details.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while inserting company details.");
                return StatusCode(500, "An error occurred while inserting company details.");
            }
        }
        [HttpPut]
        [Authorize(new[] { "Admin" })]
        public IActionResult UpdateComanyLogo([FromForm] CompanyDetailsDTO companyDetail)
        {
            try
            {
                _logger.LogInformation("Update comapnyLogo method started");

                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Authorization token is missing or invalid.");
                }

                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                var companyIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "CompanyId");
                if (companyIdClaim == null)
                {
                    return Unauthorized("Company ID not found in token.");
                }

                if (!int.TryParse(companyIdClaim.Value, out int companyId))
                {
                    return BadRequest("Invalid Company ID in token.");
                }

                companyDetail.RequestedCompanyId = companyId;

                var result = _companyDetails.updateComapanyLogo(companyDetail, companyId);

                if (result != null)
                {
                    return Ok(new { Message = "CompanyLogo Updated successfully.", CompanyId = result });
                }
                else
                {
                    return StatusCode(500, "An error occurred while inserting company details.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while inserting company details.");
                return StatusCode(500, "An error occurred while inserting company details.");
            }
        }

        [HttpDelete]
        public bool DeletecompanyDetails(int id)
        {
            _logger.LogInformation("company details delete method started");
            var result = _companyDetails.deleteCompanyDetails(id);
            return result;
        }

        [HttpPut("SoftDelete")]
/*        [Authorize(new[] { "Admin" })]
*/
        public bool SoftDelete(int id, short isActive)
        {
            _logger.LogInformation("Soft update Company details method started");
            var res = _companyDetails.SoftDelete(id, isActive);
            return res;

        }

    }
}
