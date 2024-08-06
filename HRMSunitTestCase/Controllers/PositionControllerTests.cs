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

    public class PositionControllerTests
    {
        private PositionController _testClass;
        private Mock<IPosition> _position;
        private Mock<ILogger<PositionController>> _logger;

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
                Id = 1527574174,
                Name = "TestValue1281013463",
                RequestedCompanyId = 1666868329,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 767336399,
                    Name = "TestValue1688672935",
                    PhoneNumber = "TestValue705333130",
                    DomainName = "TestValue889086888",
                    Status = "TestValue797822324",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue954740128",
                    Department = new Department
                    {
                        Id = 1138822697,
                        Name = "TestValue247270635",
                        RequestedCompanyId = 1961186601,
                        RequestedCompany = default(RequestedCompanyForm),
                        EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                    },
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
            };

            _position.Setup(mock => mock.InsertPositions(It.IsAny<Position>())).ReturnsAsync("TestValue1167825913");

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
            var id = 1660257705;
            var name = "TestValue1523897164";
            var requestedcompanyId = 886248116;

            _position.Setup(mock => mock.updateposition(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int?>())).ReturnsAsync(new Position
            {
                Id = 672260399,
                Name = "TestValue1264516475",
                RequestedCompanyId = 1424022894,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1757582591,
                    Name = "TestValue714999818",
                    PhoneNumber = "TestValue1030463078",
                    DomainName = "TestValue1319059958",
                    Status = "TestValue470435107",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue860374720",
                    Department = new Department
                    {
                        Id = 582425334,
                        Name = "TestValue911728031",
                        RequestedCompanyId = 1083833725,
                        RequestedCompany = default(RequestedCompanyForm),
                        EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                    },
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
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
            var id = 792631118;

            _position.Setup(mock => mock.deletePosition(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _testClass.DeletePosition(id);

            // Assert
            _position.Verify(mock => mock.deletePosition(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}