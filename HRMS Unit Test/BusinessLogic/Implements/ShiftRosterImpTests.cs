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

    public class ShiftRosterImpTests
    {
        private readonly ShiftRosterImp _testClass;
        private HRMSContext _context;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;
        private readonly Mock<IJwtUtils> _jwtUtils;

        public ShiftRosterImpTests()
        {
            _context = new HRMSContext();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _jwtUtils = new Mock<IJwtUtils>();
            _testClass = new ShiftRosterImp(_context, _httpContextAccessor.Object, _jwtUtils.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new ShiftRosterImp(_context, _httpContextAccessor.Object, _jwtUtils.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCalldeleteShiftRoster()
        {
            // Arrange
            var id = 845574464;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(2064906638);

            // Act
            var result = await _testClass.deleteShiftRoster(id);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAllShiftRoster()
        {
            // Act
            var result = _testClass.GetAllShiftRoster();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetShiftRosterId()
        {
            // Arrange
            var id = 319891783;

            // Act
            var result = _testClass.GetShiftRosterId(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertShiftRoster()
        {
            // Arrange
            var shiftRoster = new ShiftRoster
            {
                Id = 1945774675,
                EmpCredentialId = 552766395,
                ShiftRosterTypeId = 1695571812,
                Startdate = DateTime.UtcNow,
                Enddate = DateTime.UtcNow,
                ShiftRosterType = new ShiftRosterType
                {
                    Id = 38735928,
                    Type = "TestValue183766751",
                    TimeRange = "TestValue307555530",
                    ShiftRosters = new Mock<ICollection<ShiftRoster>>().Object
                }
            };

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(1648179795);

            // Act
            var result = await _testClass.InsertShiftRoster(shiftRoster);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}