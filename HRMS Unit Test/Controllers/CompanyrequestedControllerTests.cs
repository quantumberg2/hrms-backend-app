namespace HRMS_Unit_Test.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.Controllers;
    using HRMS_Application.DTO;
    using HRMS_Application.Models;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class CompanyrequestedControllerTests
    {
        private readonly CompanyrequestedController _testClass;
        private readonly Mock<ICompanyRequestedform> _companyRequested;
        private readonly Mock<ILogger<CompanyrequestedController>> _logger;
        private HRMSContext _context;

        public CompanyrequestedControllerTests()
        {
            _companyRequested = new Mock<ICompanyRequestedform>();
            _logger = new Mock<ILogger<CompanyrequestedController>>();
            _context = new HRMSContext();
            _testClass = new CompanyrequestedController(_companyRequested.Object, _logger.Object, _context);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new CompanyrequestedController(_companyRequested.Object, _logger.Object, _context);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetEmpCredential()
        {
            // Arrange
            _companyRequested.Setup(mock => mock.GetAllRequestedCompanyForm()).Returns(new List<RequestedCompanyForm>());

            // Act
            var result = _testClass.GetEmpCredential();

            // Assert
            _companyRequested.Verify(mock => mock.GetAllRequestedCompanyForm());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetEmployeeCredentialsById()
        {
            // Arrange
            var id = 909928549;

            _companyRequested.Setup(mock => mock.GetById(It.IsAny<int>())).Returns(new RequestedCompanyForm
            {
                Id = 634140502,
                Name = "TestValue393044128",
                PhoneNumber = "TestValue1089705126",
                DomainName = "TestValue1602044217",
                Status = "TestValue448385171",
                InsertedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Email = "TestValue1638353311",
                IsActive = (short)8409,
                CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                Departments = new Mock<ICollection<Department>>().Object,
                EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                Holidays = new Mock<ICollection<Holiday>>().Object,
                LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                Positions = new Mock<ICollection<Position>>().Object
            });

            // Act
            var result = _testClass.GetEmployeeCredentialsById(id);

            // Assert
            _companyRequested.Verify(mock => mock.GetById(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallDeleteRequestedCompanyForm()
        {
            // Arrange
            var id = 1148091439;

            _companyRequested.Setup(mock => mock.DeleteRequestedCompanyForm(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _testClass.DeleteRequestedCompanyForm(id);

            // Assert
            _companyRequested.Verify(mock => mock.DeleteRequestedCompanyForm(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertRequestedCompanyForm()
        {
            // Arrange
            var requestedCompanyForm = new RequestedCompanyForm
            {
                Id = 2118866677,
                Name = "TestValue1211953008",
                PhoneNumber = "TestValue118736118",
                DomainName = "TestValue1707714847",
                Status = "TestValue816244637",
                InsertedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Email = "TestValue764649943",
                IsActive = (short)20247,
                CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                Departments = new Mock<ICollection<Department>>().Object,
                EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                Holidays = new Mock<ICollection<Holiday>>().Object,
                LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                Positions = new Mock<ICollection<Position>>().Object
            };

            _companyRequested.Setup(mock => mock.InsertRequestedCompanyForm(It.IsAny<RequestedCompanyForm>())).ReturnsAsync("TestValue2094523348");

            // Act
            var result = await _testClass.InsertRequestedCompanyForm(requestedCompanyForm);

            // Assert
            _companyRequested.Verify(mock => mock.InsertRequestedCompanyForm(It.IsAny<RequestedCompanyForm>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 139800988;
            var isActive = (short)2316;

            _companyRequested.Setup(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>())).Returns(true);

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            _companyRequested.Verify(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallVerifyOtp()
        {
            // Arrange
            var request = new OtpEmail
            {
                EmailAddress = "TestValue255230470",
                Otp = "TestValue2060189017"
            };

            // Act
            var result = await _testClass.VerifyOtp(request);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }

    public class OtpRequestTests
    {
        private readonly OtpRequest _testClass;

        public OtpRequestTests()
        {
            _testClass = new OtpRequest();
        }

        [Fact]
        public void CanSetAndGetEmail()
        {
            // Arrange
            var testValue = "TestValue1675935789";

            // Act
            _testClass.Email = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Email);
        }
    }
}