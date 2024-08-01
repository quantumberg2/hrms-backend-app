namespace TestProject1.Controllers
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
                Id = 80218295,
                Name = "TestValue1282451477",
                RequestedCompanyId = 241562261,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 341705203,
                    Name = "TestValue1637566060",
                    PhoneNumber = "TestValue415879069",
                    DomainName = "TestValue921508496",
                    Status = "TestValue1896015091",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = new Department
                    {
                        Id = 676455014,
                        Name = "TestValue1070211895",
                        RequestedCompanyId = 2074645904,
                        RequestedCompany = default(RequestedCompanyForm),
                        EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                    },
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
            };

            _position.Setup(mock => mock.InsertPositions(It.IsAny<Position>())).ReturnsAsync("TestValue1744310990");

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
            var id = 1739499184;
            var name = "TestValue862219385";
            var requestedcompanyId = 651948760;

            _position.Setup(mock => mock.updateposition(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int?>())).ReturnsAsync(new Position
            {
                Id = 199478670,
                Name = "TestValue1582389780",
                RequestedCompanyId = 1259342030,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 239592427,
                    Name = "TestValue881689515",
                    PhoneNumber = "TestValue832293420",
                    DomainName = "TestValue2037380370",
                    Status = "TestValue165240564",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = new Department
                    {
                        Id = 385476630,
                        Name = "TestValue1001669795",
                        RequestedCompanyId = 810022044,
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
            var id = 1188722827;

            _position.Setup(mock => mock.deletePosition(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _testClass.DeletePosition(id);

            // Assert
            _position.Verify(mock => mock.deletePosition(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}