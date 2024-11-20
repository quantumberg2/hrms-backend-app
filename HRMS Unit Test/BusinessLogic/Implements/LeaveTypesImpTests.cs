namespace HRMS_Unit_Test.BusinessLogic.Implements
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

    public class LeaveTypesImpTests
    {
        private readonly LeaveTypesImp _testClass;
        private HRMSContext _context;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;
        private readonly Mock<IJwtUtils> _jwtUtils;

        public LeaveTypesImpTests()
        {
            _context = new HRMSContext();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _jwtUtils = new Mock<IJwtUtils>();
            _testClass = new LeaveTypesImp(_context, _httpContextAccessor.Object, _jwtUtils.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new LeaveTypesImp(_context, _httpContextAccessor.Object, _jwtUtils.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCalldeleteLeaveType()
        {
            // Arrange
            var id = 1741039139;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(658465131);

            // Act
            var result = _testClass.deleteLeaveType(id);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        /*  [Fact]
          public void CanCallGetAllLeaveType()
          {
              // Act
              var result = _testClass.GetAllLeaveType();

              // Assert
              throw new NotImplementedException("Create or modify test");
          }
  */
        [Fact]
        public void CanCallGetLeaveTypeById()
        {
            // Arrange
            var id = 1278849482;

            // Act
            var result = _testClass.GetLeaveTypeById(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetLeaveTypeByType()
        {
            // Arrange
            var Type = "TestValue1436985480";

            // Act
            var result = _testClass.GetLeaveTypeByType(Type);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertLeaveType()
        {
            // Arrange
            var leaveType = new LeaveType
            {
                Id = 1979603808,
                Type = "TestValue582015100",
                Days = 1373900299,
                CompanyId = 87845961,
                Year = 512156974,
                IsActive = (short)23582,
                Company = new RequestedCompanyForm
                {
                    Id = 681328442,
                    Name = "TestValue1529970913",
                    PhoneNumber = "TestValue1294794083",
                    DomainName = "TestValue1305725127",
                    Status = "TestValue735722390",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1996956317",
                    IsActive = (short)22473,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object
            };

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(1739165188);

            // Act
            var result = await _testClass.InsertLeaveType(leaveType);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallUpdateLeaveType()
        {
            // Arrange
            var id = 523789351;
            var name = "TestValue162787917";
            var requestedcompanyId = 933466615;

            // Act
            //    var result = _testClass.UpdateLeaveType(id, name, requestedcompanyId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 681287515;
            var isActive = (short)11539;

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAllLeaveType()
        {
            // Arrange
            var companyId = 509343262;

            // Act
            var result = _testClass.GetAllLeaveType(companyId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetRegularizationLeaveType()
        {
            // Act
            var result = _testClass.GetRegularizationLeaveType();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}