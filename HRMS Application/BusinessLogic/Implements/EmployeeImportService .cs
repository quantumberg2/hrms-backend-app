using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml;
using HRMS_Application.Models;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using Microsoft.EntityFrameworkCore;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class EmployeeImportService : IEmployeeImportService
    {
        private readonly HRMSContext _context;
        private readonly IEmailPassword _emailPasswordService;

        public EmployeeImportService(HRMSContext context, IEmailPassword emailPasswordService)
        {
            _context = context;
            _emailPasswordService = emailPasswordService;
        }

        public async Task ImportEmployeesFromExcelAsync(Stream excelStream)
        {
            // Set the license context
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using var package = new ExcelPackage(excelStream);
            var worksheet = package.Workbook.Worksheets.First();
            var rowCount = worksheet.Dimension.Rows;

            var employees = new List<EmployeeDto>();
            var existingUsernames = new HashSet<string>();
            var existingEmails = new HashSet<string>();

            // Read the data starting from row 2, assuming row 1 has headings
            for (int row = 2; row <= rowCount; row++)
            {
                // Extract data from cells
                var employeeNumber = worksheet.Cells[row, 1].Text;
                var email = worksheet.Cells[row, 6].Text;
                var firstName = worksheet.Cells[row, 2].Text;
                var middleName = worksheet.Cells[row, 3].Text;
                var lastName = worksheet.Cells[row, 4].Text;
                var designation = worksheet.Cells[row, 5].Text;

                // Handle departmentId and positionId as null
                int? deptId = null;
                int? positionId = null;

                // Create a new EmployeeDto
                var employee = new EmployeeDto
                {
                    EmployeeNumber = employeeNumber,
                    Email = email,
                    FirstName = firstName,
                    MiddleName = middleName,
                    LastName = lastName,
                    DeptId = deptId,
                    PositionId = positionId,
                    Designation = designation
                };
                employees.Add(employee);
            }

            foreach (var employeeDto in employees)
            {
                // Check if the username or email already exists
                var existingUserName = await _context.EmployeeCredentials
                    .SingleOrDefaultAsync(e => e.UserName == employeeDto.FirstName);
                var existingEmail = await _context.EmployeeCredentials
                    .SingleOrDefaultAsync(e => e.Email == employeeDto.Email);

                if (existingUserName != null)
                {
                    Console.WriteLine($"Username '{employeeDto.FirstName}' is already in use.");
                    continue; // Skip this record
                }

                if (existingEmail != null)
                {
                    Console.WriteLine($"Email '{employeeDto.Email}' is already in use.");
                    continue; // Skip this record
                }

                var employeeCredential = new EmployeeCredential
                {
                    UserName = employeeDto.FirstName,
                    Email = employeeDto.Email,
                    Password = GeneratePassword(),
                    DefaultPassword = true
                };

                _context.EmployeeCredentials.Add(employeeCredential);
                await _context.SaveChangesAsync();

                var employeeDetail = new EmployeeDetail
                {
                    EmployeeCredentialId = employeeCredential.Id,
                    DeptId = employeeDto.DeptId,
                    FirstName = employeeDto.FirstName,
                    MiddleName = employeeDto.MiddleName,
                    LastName = employeeDto.LastName,
                    Email = employeeDto.Email,
                    Designation = employeeDto.Designation,
                    EmployeeNumber = employeeDto.EmployeeNumber,
                    PositionId = employeeDto.PositionId
                };

                _context.EmployeeDetails.Add(employeeDetail);
                await _context.SaveChangesAsync();

                // Send email with username and password
                await _emailPasswordService.SendOtpEmailAsync(new Generatepassword
                {
                    EmailAddress = employeeCredential.Email,
                    Password = employeeCredential.Password,
                    UserName = employeeCredential.UserName
                });
            }
        }


        private string GeneratePassword()
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var res = new char[8];
            var rnd = new Random();
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = valid[rnd.Next(valid.Length)];
            }
            return new string(res);
        }
    }
}
