namespace HRMS_Unit_Test.Controllers
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

    public class PositionControllerTests
    {
        private readonly PositionController _testClass;
        private readonly Mock<IPosition> _position;
        private readonly Mock<ILogger<PositionController>> _logger;

        public PositionControllerTests()
        {
            _position = new Mock<IPosition>();
            _logger = new Mock<ILogger<PositionController>>();
            _testClass = new PositionController(_position.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new PositionController(_position.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllPositions()
        {
            // Arrange
            _position.Setup(mock => mock.GetPositions()).Returns(new List<Position>());

            // Act
            var result = _testClass.GetAllPositions();

            // Assert
            _position.Verify(mock => mock.GetPositions());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertPositions()
        {
            // Arrange
            var position = new Position
            {
                Id = 763905151,
                Name = "TestValue596006017",
                RequestedCompanyId = 2074893936,
                IsActive = (short)19120,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1199846903,
                    Name = "TestValue2079895826",
                    PhoneNumber = "TestValue237419867",
                    DomainName = "TestValue1882817839",
                    Status = "TestValue260819510",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue622653519",
                    IsActive = (short)29307,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
            };

            _position.Setup(mock => mock.InsertPositions(It.IsAny<Position>())).ReturnsAsync("TestValue1265880629");

            // Act
            var result = await _testClass.InsertPositions(position);

            // Assert
            _position.Verify(mock => mock.InsertPositions(It.IsAny<Position>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdatePosition()
        {
            // Arrange
            var id = 579698035;
            var name = "TestValue664055611";
            var requestedcompanyId = 2012081916;

            _position.Setup(mock => mock.updateposition(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int?>())).ReturnsAsync(new Position
            {
                Id = 1809009982,
                Name = "TestValue2062259015",
                RequestedCompanyId = 1688412915,
                IsActive = (short)9550,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 91260454,
                    Name = "TestValue526108476",
                    PhoneNumber = "TestValue1509343453",
                    DomainName = "TestValue1980989096",
                    Status = "TestValue1671600210",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1894862496",
                    IsActive = (short)9320,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
            });

            // Act
            var result = await _testClass.UpdatePosition(id, name, requestedcompanyId);

            // Assert
            _position.Verify(mock => mock.updateposition(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int?>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallDeletePosition()
        {
            // Arrange
            var id = 1445270625;

            _position.Setup(mock => mock.deletePosition(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _testClass.DeletePosition(id);

            // Assert
            _position.Verify(mock => mock.deletePosition(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 1080340979;
            var isActive = (short)18211;

            _position.Setup(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>())).Returns(true);

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            _position.Verify(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}