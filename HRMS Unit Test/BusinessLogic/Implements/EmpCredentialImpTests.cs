namespace HRMS_Unit_Test.BusinessLogic.Implements
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HRMS_Application.Authorization;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.DTO;
    using HRMS_Application.Models;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class EmpCredentialImpTests
    {
        private readonly EmpCredentialImp _testClass;
        private HRMSContext _context;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;
        private readonly Mock<IJwtUtils> _jwtUtils;
        private readonly Mock<IEmailPassword> _emailService;
        private readonly Mock<IEmailService> _emailotpService;

        public EmpCredentialImpTests()
        {
            _context = new HRMSContext();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _jwtUtils = new Mock<IJwtUtils>();
            _emailService = new Mock<IEmailPassword>();
            _emailotpService = new Mock<IEmailService>();
            _testClass = new EmpCredentialImp(_context, _httpContextAccessor.Object, _jwtUtils.Object, _emailService.Object, _emailotpService.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new EmpCredentialImp(_context, _httpContextAccessor.Object, _jwtUtils.Object, _emailService.Object, _emailotpService.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallDeleteEmployeeCredential()
        {
            // Arrange
            var id = 1684472371;

            // Act
            var result = await _testClass.DeleteEmployeeCredential(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAllEmpCredential()
        {
            // Act
            var result = _testClass.GetAllEmpCredential();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetById()
        {
            // Arrange
            var id = 868046247;

            // Act
            var result = _testClass.GetById(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertEmployeeCredential()
        {
            // Arrange
            var employeeCredential = new EmployeeCredential
            {
                Id = 1129486634,
                UserName = "TestValue1550542389",
                Password = "TestValue814600400",
                Status = (short)23029,
                RequestedCompanyId = 1886835246,
                Email = "TestValue641874056",
                DefaultPassword = false,
                GenerateOtp = "TestValue1906617177",
                OtpExpiration = DateTime.UtcNow,
                IsActive = (short)31064,
                EmployeeLoginName = "TestValue1562275818",
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1989430312,
                    Name = "TestValue443118464",
                    PhoneNumber = "TestValue1515190582",
                    DomainName = "TestValue1973377063",
                    Status = "TestValue218046616",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue298323075",
                    IsActive = (short)25019,
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

            _emailService.Setup(mock => mock.SendOtpEmailAsync(It.IsAny<Generatepassword>())).Verifiable();

            // Act
            var result = await _testClass.InsertEmployeeCredential(employeeCredential);

            // Assert
            _emailService.Verify(mock => mock.SendOtpEmailAsync(It.IsAny<Generatepassword>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmployeeCredentials()
        {
            // Arrange
            var id = 740823336;
            var username = "TestValue757776800";
            var password = "TestValue1065170947";
            var status = (short)1067;
            var requestedCompanyId = 2076088424;

            // Act
            var result = await _testClass.UpdateEmployeeCredentials(id, username, password, status, requestedCompanyId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmployeePassword()
        {
            // Arrange
            var email = "TestValue2090530506";
            var oldPassword = "TestValue1718022159";
            var newPassword = "TestValue812116163";

            // Act
            var result = await _testClass.UpdateEmployeePassword(email, oldPassword, newPassword);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallGenerateAndSendOtp()
        {
            // Arrange
            var email = "TestValue1449819345";

            _emailotpService.Setup(mock => mock.SendOtpEmailAsync(It.IsAny<OtpEmail>())).Verifiable();

            // Act
            var result = await _testClass.GenerateAndSendOtp(email);

            // Assert
            _emailotpService.Verify(mock => mock.SendOtpEmailAsync(It.IsAny<OtpEmail>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallSendOtpEmailAsync()
        {
            // Arrange
            var email = "TestValue1159653721";
            var otp = "TestValue1762423474";

            _emailotpService.Setup(mock => mock.SendOtpEmailAsync(It.IsAny<OtpEmail>())).Verifiable();

            // Act
            await _testClass.SendOtpEmailAsync(email, otp);

            // Assert
            _emailotpService.Verify(mock => mock.SendOtpEmailAsync(It.IsAny<OtpEmail>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdatePassword()
        {
            // Arrange
            var email = "TestValue1511629120";
            var otp = "TestValue2066659905";
            var newPassword = "TestValue175832616";
            var confirmPassword = "TestValue892076829";

            // Act
            var result = await _testClass.UpdatePassword(email, otp, newPassword, confirmPassword);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 1355109676;
            var isActive = (short)3148;

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}