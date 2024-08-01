namespace TestProject1.Controllers
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
            var id = 1204957333;

            _companyRequested.Setup(mock => mock.GetById(It.IsAny<int>())).Returns(new RequestedCompanyForm
            {
                Id = 89610028,
                Name = "TestValue2070809739",
                PhoneNumber = "TestValue410585660",
                DomainName = "TestValue1563618675",
                Status = "TestValue309406618",
                InsertedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Department = new Department
                {
                    Id = 1934095214,
                    Name = "TestValue154757743",
                    RequestedCompanyId = 2061717964,
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
            var id = 110078551;

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
                Id = 1489974682,
                Name = "TestValue843897106",
                PhoneNumber = "TestValue1783828043",
                DomainName = "TestValue189530099",
                Status = "TestValue2004549090",
                InsertedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Department = new Department
                {
                    Id = 1688512748,
                    Name = "TestValue305247643",
                    RequestedCompanyId = 2008911241,
                    RequestedCompany = default(RequestedCompanyForm),
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                },
                CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                Positions = new Mock<ICollection<Position>>().Object
            };

            _companyRequested.Setup(mock => mock.InsertRequestedCompanyForm(It.IsAny<RequestedCompanyForm>())).ReturnsAsync("TestValue1761720390");

            // Act
            var result = await _testClass.InsertRequestedCompanyForm(requestedCompanyForm);

            // Assert
            _companyRequested.Verify(mock => mock.InsertRequestedCompanyForm(It.IsAny<RequestedCompanyForm>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}