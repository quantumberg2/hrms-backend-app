﻿using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;
using System.Xml.Linq;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpCredentialController : ControllerBase
    {
        private readonly IEmpCredential _empCredential;
        private readonly ILogger<EmpCredentialController> _logger;
        public EmpCredentialController(IEmpCredential empCredential, ILogger<EmpCredentialController> logger)
        {
            _empCredential = empCredential;
            _logger = logger;
        }
        [HttpGet]
        [Authorize(new[] { "Admin" })]
        public List<EmployeeCredential> GetEmpCredential()
        {
            _logger.LogInformation("Get All Employee Credential started");
            var result = _empCredential.GetAllEmpCredential();
            return result;

        }
        [HttpGet("GetById")]
        public EmployeeCredential GetEmployeeCredentialsById(int id)
        {
            _logger.LogInformation("Getby ID for Employee Credential method started");
            var result = _empCredential.GetById(id);
            return result;
        }

        [HttpDelete]
        [Authorize(new[] { "Admin" })]
        public async Task<bool> DeleteEmpCredential(int id)
        {
            _logger.LogInformation("Delete Employee Credential method was started");
            var result = await _empCredential.DeleteEmployeeCredential(id);
            return result;
        }
        [HttpPost]
        [Authorize(new[] { "Admin" })]
        public async Task<string> InsertemployeeCredential([FromBody] EmployeeCredential employeeCredential)
        {
            _logger.LogInformation("Insert Employee Credential method started");
            var result = await _empCredential.InsertEmployeeCredential(employeeCredential);
                return result;

        }
        [HttpPut]
        [Authorize(new[] { "Admin" })]
        public async Task<EmployeeCredential> updateemployeecredential(int id, string? username, string? password, short? status, int? requestedCompanyId)
        {
            _logger.LogInformation("Update method started");
            var result = await _empCredential.UpdateEmployeeCredentials(id, username,password,status,requestedCompanyId);
            return result;
        }
    }
}
