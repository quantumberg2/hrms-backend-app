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

        public async Task<(int Inserted, int Rejected, List<string> Errors)> ImportEmployeesFromExcelAsync(Stream excelStream, int companyId)
        {
            // Set the license context
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using var package = new ExcelPackage(excelStream);
            var worksheet = package.Workbook.Worksheets.First();
            var rowCount = worksheet.Dimension.Rows;

            var employees = new List<EmployeeDto>();
            var errors = new List<string>();
            int insertedCount = 0;
            int rejectedCount = 0;

            // Read the data starting from row 2, assuming row 1 has headings
            for (int row = 2; row <= rowCount; row++)
            {
                // Extract data from cells
                var employeeNumber = worksheet.Cells[row, 1].Text;
                var firstName = worksheet.Cells[row, 2].Text;
                var middleName = worksheet.Cells[row, 3].Text;
                var lastName = worksheet.Cells[row, 4].Text;
                var designation = worksheet.Cells[row, 5].Text;
                var email = worksheet.Cells[row, 6].Text;

                // Validate fields
                if (string.IsNullOrWhiteSpace(employeeNumber) || string.IsNullOrWhiteSpace(firstName) ||
                    string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(email) ||
                    !IsValidEmail(email))
                {
                    errors.Add($"Row {row}: Invalid data. Ensure all required fields are filled correctly.");
                    rejectedCount++;
                    continue;
                }

                // Handle departmentId and positionId as null
                int? deptId = null;
                int? positionId = null;

                // Create a new EmployeeDto
                var employee = new EmployeeDto
                {
                    EmployeeNumber = employeeNumber,
                    FirstName = firstName,
                    MiddleName = middleName,
                    LastName = lastName,
                    Email = email,
                    DeptId = deptId,
                    PositionId = positionId,
                    Designation = designation
                };
                employees.Add(employee);
            }

            foreach (var employeeDto in employees)
            {
                // Check if the email already exists for the same company
                var existingEmail = await _context.EmployeeCredentials
                    .SingleOrDefaultAsync(e => e.Email == employeeDto.Email && e.RequestedCompanyId == companyId);

                if (existingEmail != null)
                {
                    errors.Add($"Email '{employeeDto.Email}' is already in use for company ID '{companyId}'.");
                    rejectedCount++;
                    continue; // Skip this record
                }

                var employeeCredential = new EmployeeCredential
                {
                    UserName = employeeDto.FirstName,
                    Email = employeeDto.Email,
                    Password = GeneratePassword(),
                    DefaultPassword = true,
                    RequestedCompanyId = companyId
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
                    EmployeeNumber = employeeDto.EmployeeNumber,
                    PositionId = employeeDto.PositionId,
                    RequestCompanyId = companyId 
                };

                _context.EmployeeDetails.Add(employeeDetail);
                await _context.SaveChangesAsync();

                // Assign "User" role to the employee
                var userRole = new UserRolesJ
                {
                    EmployeeCredentialId = employeeCredential.Id,
                    RolesId = 2 
                };

                _context.UserRolesJs.Add(userRole);
                await _context.SaveChangesAsync();

                // Send email with username and password
                await _emailPasswordService.SendOtpEmailAsync(new Generatepassword
                {
                    EmailAddress = employeeCredential.Email,
                    Password = employeeCredential.Password,
                    UserName = employeeCredential.UserName
                });

                insertedCount++;
            }

            return (Inserted: insertedCount, Rejected: rejectedCount, Errors: errors);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
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
