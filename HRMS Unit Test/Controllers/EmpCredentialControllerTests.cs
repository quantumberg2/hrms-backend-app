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

    public class EmpCredentialControllerTests
    {
        private readonly EmpCredentialController _testClass;
        private readonly Mock<IEmpCredential> _empCredential;
        private readonly Mock<ILogger<EmpCredentialController>> _logger;

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
            var id = 357687066;

            _empCredential.Setup(mock => mock.GetById(It.IsAny<int>())).Returns(new EmployeeCredential
            {
                Id = 1840324485,
                UserName = "TestValue355437683",
                Password = "TestValue1164068499",
                Status = (short)9995,
                RequestedCompanyId = 763984124,
                Email = "TestValue18348393",
                DefaultPassword = true,
                GenerateOtp = "TestValue113115114",
                OtpExpiration = DateTime.UtcNow,
                IsActive = (short)22100,
                EmployeeLoginName = "TestValue2087312595",
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1262413998,
                    Name = "TestValue1809918626",
                    PhoneNumber = "TestValue500146345",
                    DomainName = "TestValue1011223710",
                    Status = "TestValue102703573",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue957133375",
                    IsActive = (short)898,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                AccountDetails = new Mock<ICollection<AccountDetail>>().Object,
                AddressInfos = new Mock<ICollection<AddressInfo>>().Object,
                Attendances = new Mock<ICollection<Attendance>>().Object,
                //DeviceTables = new Mock<ICollection<DeviceTable>>().Object,
                EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
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
            var id = 1152494136;

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
                Id = 1866709795,
                UserName = "TestValue1787286524",
                Password = "TestValue1477423651",
                Status = (short)26867,
                RequestedCompanyId = 820376154,
                Email = "TestValue777313499",
                DefaultPassword = true,
                GenerateOtp = "TestValue80217064",
                OtpExpiration = DateTime.UtcNow,
                IsActive = (short)2373,
                EmployeeLoginName = "TestValue962366196",
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 264995090,
                    Name = "TestValue1192736277",
                    PhoneNumber = "TestValue1264324923",
                    DomainName = "TestValue2050373872",
                    Status = "TestValue1408645427",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1776967118",
                    IsActive = (short)6062,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                AccountDetails = new Mock<ICollection<AccountDetail>>().Object,
                AddressInfos = new Mock<ICollection<AddressInfo>>().Object,
                Attendances = new Mock<ICollection<Attendance>>().Object,
                //DeviceTables = new Mock<ICollection<DeviceTable>>().Object,
                EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
                UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
            };

            _empCredential.Setup(mock => mock.InsertEmployeeCredential(It.IsAny<EmployeeCredential>())).ReturnsAsync("TestValue2088839263");

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
            var id = 2121098337;
            var username = "TestValue715634806";
            var password = "TestValue1834128495";
            var status = (short)15895;
            var requestedCompanyId = 2091091617;

            _empCredential.Setup(mock => mock.UpdateEmployeeCredentials(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<short?>(), It.IsAny<int?>())).ReturnsAsync(new EmployeeCredential
            {
                Id = 361730952,
                UserName = "TestValue335127683",
                Password = "TestValue426810964",
                Status = (short)17236,
                RequestedCompanyId = 1912348608,
                Email = "TestValue1628715345",
                DefaultPassword = false,
                GenerateOtp = "TestValue1669582454",
                OtpExpiration = DateTime.UtcNow,
                IsActive = (short)1810,
                EmployeeLoginName = "TestValue1876094305",
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1057668314,
                    Name = "TestValue1361586184",
                    PhoneNumber = "TestValue979180946",
                    DomainName = "TestValue1877027593",
                    Status = "TestValue1106418081",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1985989486",
                    IsActive = (short)27532,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                AccountDetails = new Mock<ICollection<AccountDetail>>().Object,
                AddressInfos = new Mock<ICollection<AddressInfo>>().Object,
                Attendances = new Mock<ICollection<Attendance>>().Object,
                //DeviceTables = new Mock<ICollection<DeviceTable>>().Object,
                EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
                UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
            });

            // Act
            var result = await _testClass.updateemployeecredential(id, username, password, status, requestedCompanyId);

            // Assert
            _empCredential.Verify(mock => mock.UpdateEmployeeCredentials(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<short?>(), It.IsAny<int?>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdatePasswordWithRequest()
        {
            // Arrange
            var request = new UpdatePasswordRequest
            {
                Email = "TestValue1192688215",
                OldPassword = "TestValue32898050",
                NewPassword = "TestValue1292908473"
            };

            _empCredential.Setup(mock => mock.UpdateEmployeePassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync("TestValue1388518541");

            // Act
            var result = await _testClass.UpdatePassword(request);

            // Assert
            _empCredential.Verify(mock => mock.UpdateEmployeePassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallGenerateAndSendOtp()
        {
            // Arrange
            var otpRequest = new OtpRequest { Email = "TestValue997418908" };

            _empCredential.Setup(mock => mock.GenerateAndSendOtp(It.IsAny<string>())).ReturnsAsync("TestValue1124946399");

            // Act
            var result = await _testClass.GenerateAndSendOtp(otpRequest);

            // Assert
            _empCredential.Verify(mock => mock.GenerateAndSendOtp(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdatePasswordWithUpdatePasswordRequest()
        {
            // Arrange
            var updatePasswordRequest = new ForgotpasswordRequest
            {
                Email = "TestValue1383305069",
                Otp = "TestValue1108333485",
                NewPassword = "TestValue841541793",
                ConfirmPassword = "TestValue1327649904"
            };

            _empCredential.Setup(mock => mock.UpdatePassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync("TestValue617182349");

            // Act
            var result = await _testClass.UpdatePassword(updatePasswordRequest);

            // Assert
            _empCredential.Verify(mock => mock.UpdatePassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 2143439761;
            var isActive = (short)24131;

            _empCredential.Setup(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>())).Returns(false);

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            _empCredential.Verify(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}