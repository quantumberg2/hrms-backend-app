namespace TestProject1.BusinessLogic.Implements
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HRMS_Application.Authorization;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.Models;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class CompanyRequestedformImpTests
    {
        private CompanyRequestedformImp _testClass;
        private HRMSContext _context;
        private Mock<IHttpContextAccessor> _httpContextAccessor;
        private Mock<IJwtUtils> _jwtUtils;

        public CompanyRequestedformImpTests()
        {
            _context = new HRMSContext();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _jwtUtils = new Mock<IJwtUtils>();
            _testClass = new CompanyRequestedformImp(_context, _httpContextAccessor.Object, _jwtUtils.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new CompanyRequestedformImp(_context, _httpContextAccessor.Object, _jwtUtils.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallDeleteRequestedCompanyForm()
        {
            // Arrange
            var id = 1469613729;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(1162449200);

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
            var id = 1600934511;

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
                Id = 1076440021,
                Name = "TestValue1134029831",
                PhoneNumber = "TestValue1558212922",
                DomainName = "TestValue538859121",
                Status = "TestValue1864008822",
                InsertedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Department = new Department
                {
                    Id = 287292375,
                    Name = "TestValue32728575",
                    RequestedCompanyId = 1330586123,
                    RequestedCompany = default(RequestedCompanyForm),
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                },
                CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                Positions = new Mock<ICollection<Position>>().Object
            };

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(1026529436);

            // Act
            var result = await _testClass.InsertRequestedCompanyForm(requestedcompanyform);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}