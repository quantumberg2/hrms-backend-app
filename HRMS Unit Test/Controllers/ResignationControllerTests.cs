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

    public class ResignationControllerTests
    {
        private readonly ResignationController _testClass;
        private readonly Mock<ILogger<ResignationController>> _logger;
        private readonly Mock<IResignation> _resignation;

        public ResignationControllerTests()
        {
            _logger = new Mock<ILogger<ResignationController>>();
            _resignation = new Mock<IResignation>();
            _testClass = new ResignationController(_logger.Object, _resignation.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new ResignationController(_logger.Object, _resignation.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetData()
        {
            // Arrange
            _resignation.Setup(mock => mock.GetData()).Returns(new List<Resignation>());

            // Act
            var result = _testClass.GetData();

            // Assert
            _resignation.Verify(mock => mock.GetData());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertResignation()
        {
            // Arrange
            var resignation = new ResignationDTO
            {
                Reason = "TestValue854211917",
                StartDate = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow,
                Comments = "TestValue1496173543"
            };

            _resignation.Setup(mock => mock.InsertResignation(It.IsAny<int>(), It.IsAny<ResignationDTO>())).Returns("TestValue478096589");

            // Act
            var result = await _testClass.InsertResignation(resignation);

            // Assert
            _resignation.Verify(mock => mock.InsertResignation(It.IsAny<int>(), It.IsAny<ResignationDTO>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallUpdateResignation()
        {
            // Arrange
            var resignation = new Resignation
            {
                Id = 1707840377,
                EmpCredentialId = 1561619251,
                Reason = "TestValue150873766",
                StartDate = DateTime.UtcNow,
                ExitDate = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Status = "TestValue243521183",
                FinalSettlementDate = DateTime.UtcNow,
                IsActive = (short)8708,
                Comments = "TestValue1100234804",
                ResignationApprovalStatuses = new Mock<ICollection<ResignationApprovalStatus>>().Object
            };

            _resignation.Setup(mock => mock.UpdateResignation(It.IsAny<Resignation>())).Returns("TestValue1581280916");

            // Act
            var result = _testClass.UpdateResignation(resignation);

            // Assert
            _resignation.Verify(mock => mock.UpdateResignation(It.IsAny<Resignation>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDeleteResignation()
        {
            // Arrange
            var id = 1945715587;
            var isActive = (short)20084;

            _resignation.Setup(mock => mock.SoftDeleteResignation(It.IsAny<int>(), It.IsAny<short>())).Returns(false);

            // Act
            var result = _testClass.SoftDeleteResignation(id, isActive);

            // Assert
            _resignation.Verify(mock => mock.SoftDeleteResignation(It.IsAny<int>(), It.IsAny<short>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}