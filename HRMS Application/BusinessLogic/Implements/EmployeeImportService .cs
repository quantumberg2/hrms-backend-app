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

        public async Task<(int Inserted, int Rejected, List<string> Errors)> ImportEmployeesFromExcelAsync(IFormFile excelFile, int companyId)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

           /* var fileUrl = _azureOperations.StoreFilesInAzure(excelFile, "hrms-files");

            // If storing was unsuccessful, throw an exception
            if (string.IsNullOrWhiteSpace(fileUrl))
            {
                throw new Exception("Failed to store the file in Azure");
            }*/

            // Use OpenReadStream to create a stream for reading the Excel file
            using var excelStream = excelFile.OpenReadStream();

            using var package = new ExcelPackage(excelStream);
            var worksheet = package.Workbook.Worksheets.First();
            var rowCount = worksheet.Dimension.Rows;

            var employees = new List<EmployeeDto>();
            var errors = new List<string>();
            int insertedCount = 0;
            int rejectedCount = 0;
            for (int row = 2; row <= rowCount; row++)
            {
                var employeeNumber = worksheet.Cells[row, 1].Text;
                var firstName = worksheet.Cells[row, 2].Text;
                var middleName = worksheet.Cells[row, 3].Text;
                var lastName = worksheet.Cells[row, 4].Text;
                var designation = worksheet.Cells[row, 5].Text;
                var email = worksheet.Cells[row, 6].Text;
                var yearofexperience = worksheet.Cells[row, 7].Text;
                var managerId = worksheet.Cells[row, 8].Text;
                var missingFields = new List<string>();
                if (string.IsNullOrWhiteSpace(employeeNumber))
                    missingFields.Add("Employee Number");
                if (string.IsNullOrWhiteSpace(firstName))
                    missingFields.Add("First Name");
                if (string.IsNullOrWhiteSpace(lastName))
                    missingFields.Add("Last Name");
                if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
                    missingFields.Add("Email");
                if (string.IsNullOrWhiteSpace(designation))
                    missingFields.Add("Designation");
                if (string.IsNullOrWhiteSpace(yearofexperience))
                    missingFields.Add("Years of Experience");
                if (string.IsNullOrWhiteSpace(yearofexperience))
                    missingFields.Add("Manager ID");
                if (missingFields.Count > 0)
                {
                    errors.Add($"Row {row}: Missing or invalid data for fields: {string.Join(", ", missingFields)}.");
                    rejectedCount++;
                    continue;
                }
                int? deptId = null;
              //  int positionId = Convert.ToInt32(designation);
                var yearofexperiences = yearofexperience;

                var position = await _context.Positions
                 .FirstOrDefaultAsync(p => p.Name == designation && p.RequestedCompanyId == companyId && p.IsActive == 1);

                var Manager = await _context.EmployeeDetails
                    .FirstOrDefaultAsync(m => m.EmployeeNumber == managerId && m.RequestCompanyId == companyId && m.IsActive == 1);

                var employee = new EmployeeDto
                {
                    EmployeeNumber = employeeNumber,
                    FirstName = firstName,
                    MiddleName = middleName,
                    LastName = lastName,
                    Email = email,
                    DeptId = deptId,
                    PositionId = position.Id,
                    YearsExperience = yearofexperiences,
                    MangerId = Manager.EmployeeCredentialId,
                    isActive = 1,
                };
                employees.Add(employee);
            }
            foreach (var employeeDto in employees)
            {
                var existingEmail = await _context.EmployeeCredentials
                    .SingleOrDefaultAsync(e => e.Email == employeeDto.Email && e.RequestedCompanyId == companyId);
                var existingEmployeeNumber = await _context.EmployeeDetails
                    .SingleOrDefaultAsync(emp =>  emp.RequestCompanyId == companyId && emp.EmployeeNumber == employeeDto.EmployeeNumber);

                if (existingEmail != null || existingEmployeeNumber != null)
                {
                    var errorMessage = $"Record for '{employeeDto.FirstName} {employeeDto.LastName}' ";
                    if (existingEmail != null)
                    {
                        errorMessage += $"has an existing email '{employeeDto.Email}'. ";
                    }
                    if (existingEmployeeNumber != null)
                    {
                        errorMessage += $"Employee Number '{employeeDto.EmployeeNumber}' already exists. ";
                    }

                    errors.Add(errorMessage.Trim());
                    rejectedCount++;
                    continue; 
                }
                var employeeCredential = new EmployeeCredential
                {
                    UserName = employeeDto.Email,
                    Email = employeeDto.Email,
                    Password = GeneratePassword(),
                    DefaultPassword = true,
                    RequestedCompanyId = companyId,
                    IsActive = 1
                    
                };

                await _context.EmployeeCredentials.AddAsync(employeeCredential);
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
                    RequestCompanyId = companyId ,
                    NumberOfYearsExperience = employeeDto.YearsExperience,
                    ManagerId = employeeDto.MangerId,
                    IsActive = 1,
                };

               await _context.EmployeeDetails.AddAsync(employeeDetail);
                await _context.SaveChangesAsync();

                var userRole = new UserRolesJ
                {
                    EmployeeCredentialId = employeeCredential.Id,
                    RolesId = 2,
                    IsActive = 1
                };

                await _context.UserRolesJs.AddAsync(userRole);
                await _context.SaveChangesAsync();
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
