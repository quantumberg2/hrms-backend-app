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

    public class CompanyRequestedformImpTests
    {
        private readonly CompanyRequestedformImp _testClass;
        private HRMSContext _context;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;
        private readonly Mock<IJwtUtils> _jwtUtils;
        private readonly Mock<IEmailService> _emailService;

        public CompanyRequestedformImpTests()
        {
            _context = new HRMSContext();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _jwtUtils = new Mock<IJwtUtils>();
            _emailService = new Mock<IEmailService>();
            _testClass = new CompanyRequestedformImp(_context, _httpContextAccessor.Object, _jwtUtils.Object, _emailService.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new CompanyRequestedformImp(_context, _httpContextAccessor.Object, _jwtUtils.Object, _emailService.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 1098804210;
            var isActive = (short)23568;

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallDeleteRequestedCompanyForm()
        {
            // Arrange
            var id = 198127423;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(506042392);

            // Act
            var result = await _testClass.DeleteRequestedCompanyForm(id);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAllRequestedCompanyForm()
        {
            // Act
            var result = _testClass.GetAllRequestedCompanyForm();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetById()
        {
            // Arrange
            var id = 202048920;

            // Act
            var result = _testClass.GetById(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertRequestedCompanyForm()
        {
            // Arrange
            var requestedcompanyform = new RequestedCompanyForm
            {
                Id = 1932566373,
                Name = "TestValue264856555",
                PhoneNumber = "TestValue1453913689",
                DomainName = "TestValue978561178",
                Status = "TestValue1187913651",
                InsertedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Email = "TestValue718210655",
                IsActive = (short)29815,
                CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                Departments = new Mock<ICollection<Department>>().Object,
                EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                Holidays = new Mock<ICollection<Holiday>>().Object,
                LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                Positions = new Mock<ICollection<Position>>().Object
            };

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(154679395);
            _emailService.Setup(mock => mock.SendOtpEmailAsync(It.IsAny<OtpEmail>())).Verifiable();

            // Act
            //    var result = await _testClass.InsertRequestedCompanyForm(requestedcompanyform);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));
            _emailService.Verify(mock => mock.SendOtpEmailAsync(It.IsAny<OtpEmail>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}