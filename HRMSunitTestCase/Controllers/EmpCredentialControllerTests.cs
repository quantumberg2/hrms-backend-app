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
            var id = 288012199;

            _empCredential.Setup(mock => mock.GetById(It.IsAny<int>())).Returns(new EmployeeCredential
            {
                Id = 2020867561,
                UserName = "TestValue1613505289",
                Password = "TestValue1760715472",
                Status = (short)25564,
                RequestedCompanyId = 287288135,
                Email = "TestValue313718687",
                DefaultPassword = false,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1603845315,
                    Name = "TestValue302264749",
                    PhoneNumber = "TestValue1803874456",
                    DomainName = "TestValue1789257769",
                    Status = "TestValue2033820088",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1375335692",
                    Department = new Department
                    {
                        Id = 1608526868,
                        Name = "TestValue1574465673",
                        RequestedCompanyId = 1890647356,
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
                Holidays = new Mock<ICollection<Holiday>>().Object,
                LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
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
            var id = 940375892;

            _empCredential.Setup(mock => mock.DeleteEmployeeCredential(It.IsAny<int>())).ReturnsAsync(false);

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
                Id = 300652480,
                UserName = "TestValue1198234530",
                Password = "TestValue1938104773",
                Status = (short)28865,
                RequestedCompanyId = 2124729518,
                Email = "TestValue1892234424",
                DefaultPassword = false,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 571590333,
                    Name = "TestValue1699537333",
                    PhoneNumber = "TestValue1489218501",
                    DomainName = "TestValue1592841654",
                    Status = "TestValue155118733",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue794194615",
                    Department = new Department
                    {
                        Id = 451731321,
                        Name = "TestValue511546267",
                        RequestedCompanyId = 1980740639,
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
                Holidays = new Mock<ICollection<Holiday>>().Object,
                LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
            };

            _empCredential.Setup(mock => mock.InsertEmployeeCredential(It.IsAny<EmployeeCredential>())).ReturnsAsync("TestValue1484661364");

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
            var id = 1462355039;
            var username = "TestValue1248996";
            var password = "TestValue2068856336";
            var status = (short)12552;
            var requestedCompanyId = 1822884163;

            _empCredential.Setup(mock => mock.UpdateEmployeeCredentials(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<short?>(), It.IsAny<int?>())).ReturnsAsync(new EmployeeCredential
            {
                Id = 2017391256,
                UserName = "TestValue994442795",
                Password = "TestValue933023035",
                Status = (short)32409,
                RequestedCompanyId = 1412681788,
                Email = "TestValue1036590381",
                DefaultPassword = true,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 914688516,
                    Name = "TestValue1452408505",
                    PhoneNumber = "TestValue1851552613",
                    DomainName = "TestValue2025596534",
                    Status = "TestValue270846404",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1654286441",
                    Department = new Department
                    {
                        Id = 1079034834,
                        Name = "TestValue344923178",
                        RequestedCompanyId = 82208539,
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
                Holidays = new Mock<ICollection<Holiday>>().Object,
                LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
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