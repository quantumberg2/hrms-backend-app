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

    public class EmpCredentialControllerTests
    {
        private EmpCredentialController _testClass;
        private Mock<IEmpCredential> _empCredential;
        private Mock<ILogger<EmpCredentialController>> _logger;

        public EmpCredentialControllerTests()
        {
            _empCredential = new Mock<IEmpCredential>();
            _logger = new Mock<ILogger<EmpCredentialController>>();
            _testClass = new EmpCredentialController(_empCredential.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new EmpCredentialController(_empCredential.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetEmpCredential()
        {
            // Arrange
            _empCredential.Setup(mock => mock.GetAllEmpCredential()).Returns(new List<EmployeeCredential>());

            // Act
            var result = _testClass.GetEmpCredential();

            // Assert
            _empCredential.Verify(mock => mock.GetAllEmpCredential());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetEmployeeCredentialsById()
        {
            // Arrange
            var id = 55595292;

            _empCredential.Setup(mock => mock.GetById(It.IsAny<int>())).Returns(new EmployeeCredential
            {
                Id = 413683268,
                UserName = "TestValue1916524010",
                Password = "TestValue1122597688",
                Status = (short)23292,
                RequestedCompanyId = 835604668,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 889758654,
                    Name = "TestValue180838170",
                    PhoneNumber = "TestValue1326856666",
                    DomainName = "TestValue206938838",
                    Status = "TestValue1186232386",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = new Department
                    {
                        Id = 690656417,
                        Name = "TestValue2072867901",
                        RequestedCompanyId = 367295288,
                        RequestedCompany = default(RequestedCompanyForm),
                        EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                    },
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                AccountDetails = new Mock<ICollection<AccountDetail>>().Object,
                AddressInfos = new Mock<ICollection<AddressInfo>>().Object,
                EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                EmployeeAttendances = new Mock<ICollection<EmployeeAttendance>>().Object,
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                EmployeeLeaves = new Mock<ICollection<EmployeeLeave>>().Object,
                UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
            });

            // Act
            var result = _testClass.GetEmployeeCredentialsById(id);

            // Assert
            _empCredential.Verify(mock => mock.GetById(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallDeleteEmpCredential()
        {
            // Arrange
            var id = 1065158294;

            _empCredential.Setup(mock => mock.DeleteEmployeeCredential(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _testClass.DeleteEmpCredential(id);

            // Assert
            _empCredential.Verify(mock => mock.DeleteEmployeeCredential(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertemployeeCredential()
        {
            // Arrange
            var employeeCredential = new EmployeeCredential
            {
                Id = 1295518499,
                UserName = "TestValue1601668246",
                Password = "TestValue1041198233",
                Status = (short)21875,
                RequestedCompanyId = 1762869037,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1355764896,
                    Name = "TestValue1638033438",
                    PhoneNumber = "TestValue42543257",
                    DomainName = "TestValue1745632020",
                    Status = "TestValue629976275",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = new Department
                    {
                        Id = 856117960,
                        Name = "TestValue251097947",
                        RequestedCompanyId = 568918272,
                        RequestedCompany = default(RequestedCompanyForm),
                        EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                    },
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                AccountDetails = new Mock<ICollection<AccountDetail>>().Object,
                AddressInfos = new Mock<ICollection<AddressInfo>>().Object,
                EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                EmployeeAttendances = new Mock<ICollection<EmployeeAttendance>>().Object,
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                EmployeeLeaves = new Mock<ICollection<EmployeeLeave>>().Object,
                UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
            };

            _empCredential.Setup(mock => mock.InsertEmployeeCredential(It.IsAny<EmployeeCredential>())).ReturnsAsync("TestValue155308325");

            // Act
            var result = await _testClass.InsertemployeeCredential(employeeCredential);

            // Assert
            _empCredential.Verify(mock => mock.InsertEmployeeCredential(It.IsAny<EmployeeCredential>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallupdateemployeecredential()
        {
            // Arrange
            var id = 1711433663;
            var username = "TestValue1391280400";
            var password = "TestValue2047680041";
            var status = (short)14883;
            var requestedCompanyId = 787524328;

            _empCredential.Setup(mock => mock.UpdateEmployeeCredentials(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<short?>(), It.IsAny<int?>())).ReturnsAsync(new EmployeeCredential
            {
                Id = 12202436,
                UserName = "TestValue719877854",
                Password = "TestValue775008432",
                Status = (short)4441,
                RequestedCompanyId = 1208336634,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1911812024,
                    Name = "TestValue2136504685",
                    PhoneNumber = "TestValue1072323090",
                    DomainName = "TestValue780342254",
                    Status = "TestValue2040172603",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = new Department
                    {
                        Id = 2005424843,
                        Name = "TestValue1027372724",
                        RequestedCompanyId = 948854801,
                        RequestedCompany = default(RequestedCompanyForm),
                        EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                    },
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                AccountDetails = new Mock<ICollection<AccountDetail>>().Object,
                AddressInfos = new Mock<ICollection<AddressInfo>>().Object,
                EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                EmployeeAttendances = new Mock<ICollection<EmployeeAttendance>>().Object,
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                EmployeeLeaves = new Mock<ICollection<EmployeeLeave>>().Object,
                UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
            });

            // Act
            var result = await _testClass.updateemployeecredential(id, username, password, status, requestedCompanyId);

            // Assert
            _empCredential.Verify(mock => mock.UpdateEmployeeCredentials(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<short?>(), It.IsAny<int?>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}