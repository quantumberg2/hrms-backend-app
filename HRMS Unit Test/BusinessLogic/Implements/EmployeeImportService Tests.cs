namespace HRMS_Unit_Test.BusinessLogic.Implements
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.DTO;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public class EmployeeImportServiceTests
    {
        private readonly EmployeeImportService _testClass;
        private HRMSContext _context;
        private readonly Mock<IEmailPassword> _emailPasswordService;

        public EmployeeImportServiceTests()
        {
            _context = new HRMSContext();
            _emailPasswordService = new Mock<IEmailPassword>();
            _testClass = new EmployeeImportService(_context, _emailPasswordService.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new EmployeeImportService(_context, _emailPasswordService.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallImportEmployeesFromExcelAsync()
        {
            // Arrange
            var excelStream = new MemoryStream();
            var companyId = 1985502974;

            _emailPasswordService.Setup(mock => mock.SendOtpEmailAsync(It.IsAny<Generatepassword>())).Verifiable();

            // Act
            var result = await _testClass.ImportEmployeesFromExcelAsync(excelStream, companyId);

            // Assert
            _emailPasswordService.Verify(mock => mock.SendOtpEmailAsync(It.IsAny<Generatepassword>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}