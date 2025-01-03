namespace HRMS_Unit_Test.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.Controllers;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class EmployeeImportControllerTests
    {
        private readonly EmployeeImportController _testClass;
        private readonly Mock<IEmployeeImportService> _employeeImportService;
        private readonly Mock<IAzureOperations> _azureOperations;

        public EmployeeImportControllerTests()
        {
            _azureOperations = new Mock<IAzureOperations>();
            _employeeImportService = new Mock<IEmployeeImportService>();
            //   _testClass = new EmployeeImportController(_employeeImportService.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            //  var instance = new EmployeeImportController(_employeeImportService.Object);

            // Assert
            //   Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallImportEmployees()
        {
            // Arrange
            var @file = new Mock<IFormFile>().Object;

            //  _employeeImportService.Setup(mock => mock.ImportEmployeesFromExcelAsync(It.IsAny<Stream>(), It.IsAny<int>()))
            //      .ReturnsAsync((Inserted: 0, Rejected: 0, Errors: new List<string>()));

            // Act
            var result = await _testClass.ImportEmployees(file);

            // Assert
            //   _employeeImportService.Verify(mock => mock.ImportEmployeesFromExcelAsync(It.IsAny<Stream>(), It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallDownloadEmployeeFile()
        {
            // Arrange
            _azureOperations.Setup(mock => mock.FetchBulkEmployeeDetailsFile(It.IsAny<string>())).ReturnsAsync(new MemoryStream());

            // Act
            var result = await _testClass.DownloadEmployeeFile();

            // Assert
            _azureOperations.Verify(mock => mock.FetchBulkEmployeeDetailsFile(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}