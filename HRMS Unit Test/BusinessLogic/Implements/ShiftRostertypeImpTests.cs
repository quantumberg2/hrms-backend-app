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

    public class ShiftRostertypeImpTests
    {
        private readonly ShiftRostertypeImp _testClass;
        private HRMSContext _context;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;
        private readonly Mock<IJwtUtils> _jwtUtils;

        public ShiftRostertypeImpTests()
        {
            _context = new HRMSContext();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _jwtUtils = new Mock<IJwtUtils>();
            _testClass = new ShiftRostertypeImp(_context, _httpContextAccessor.Object, _jwtUtils.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new ShiftRostertypeImp(_context, _httpContextAccessor.Object, _jwtUtils.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCalldeleteShiftRosterType()
        {
            // Arrange
            var id = 232054075;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(1050883869);

            // Act
            var result = await _testClass.deleteShiftRosterType(id);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAllShiftRosterType()
        {
            // Act
            var result = _testClass.GetAllShiftRosterType();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetShiftRosterTypeId()
        {
            // Arrange
            var id = 473614537;

            // Act
            var result = _testClass.GetShiftRosterTypeId(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertShiftRosterType()
        {
            // Arrange
            var shiftRosterType = new ShiftRosterType
            {
                Id = 2129928359,
                Type = "TestValue1105516027",
                TimeRange = "TestValue38375188",
                ShiftRosters = new Mock<ICollection<ShiftRoster>>().Object
            };

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(4555692);

            // Act
            var result = await _testClass.InsertShiftRosterType(shiftRosterType);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallupdateShiftRosterType()
        {
            // Arrange
            var id = 1827068943;
            var Type = "TestValue927337169";
            var TimeRange = "TestValue902798576";

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(1738888599);

            // Act
            var result = await _testClass.updateShiftRosterType(id, Type, TimeRange);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}