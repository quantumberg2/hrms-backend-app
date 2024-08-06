namespace HRMSunitTestCase.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.Controllers;
    using HRMS_Application.Models;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class CompanyrequestedControllerTests
    {
        private CompanyrequestedController _testClass;
        private Mock<ICompanyRequestedform> _companyRequested;
        private Mock<ILogger<CompanyrequestedController>> _logger;

        public CompanyrequestedControllerTests()
        {
            _companyRequested = new Mock<ICompanyRequestedform>();
            _logger = new Mock<ILogger<CompanyrequestedController>>();
            _testClass = new CompanyrequestedController(_companyRequested.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new CompanyrequestedController(_companyRequested.Object, _logger.Object);

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
            var id = 2121640570;

            _companyRequested.Setup(mock => mock.GetById(It.IsAny<int>())).Returns(new RequestedCompanyForm
            {
                Id = 1649575328,
                Name = "TestValue734960779",
                PhoneNumber = "TestValue224174879",
                DomainName = "TestValue576933758",
                Status = "TestValue1065686362",
                InsertedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Email = "TestValue1053905063",
                Department = new Department
                {
                    Id = 947288815,
                    Name = "TestValue1443497091",
                    RequestedCompanyId = 598568190,
                    RequestedCompany = default(RequestedCompanyForm),
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                },
                CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
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
            var id = 1357152976;

            _companyRequested.Setup(mock => mock.DeleteRequestedCompanyForm(It.IsAny<int>())).ReturnsAsync(false);

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
                Id = 645563651,
                Name = "TestValue1968803087",
                PhoneNumber = "TestValue1690826123",
                DomainName = "TestValue2132800173",
                Status = "TestValue1975587208",
                InsertedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Email = "TestValue630920908",
                Department = new Department
                {
                    Id = 289057426,
                    Name = "TestValue420133310",
                    RequestedCompanyId = 1291260314,
                    RequestedCompany = default(RequestedCompanyForm),
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                },
                CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                Positions = new Mock<ICollection<Position>>().Object
            };

            _companyRequested.Setup(mock => mock.InsertRequestedCompanyForm(It.IsAny<RequestedCompanyForm>())).ReturnsAsync("TestValue1871875162");

            // Act
            var result = await _testClass.InsertRequestedCompanyForm(requestedCompanyForm);

            // Assert
            _companyRequested.Verify(mock => mock.InsertRequestedCompanyForm(It.IsAny<RequestedCompanyForm>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}