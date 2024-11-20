namespace HRMS_Unit_Test.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.Controllers;
    using HRMS_Application.DTO;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class RegularizationControllerTests
    {
        private readonly RegularizationController _testClass;
        private readonly Mock<IRegularization> _regularization;
        private readonly Mock<ILogger<RegularizationController>> _logger;

        public RegularizationControllerTests()
        {
            _regularization = new Mock<IRegularization>();
            _logger = new Mock<ILogger<RegularizationController>>();
            _testClass = new RegularizationController(_regularization.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new RegularizationController(_regularization.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetPendingRegularization()
        {
            // Arrange
            var status = "TestValue1237225957";

            _regularization.Setup(mock => mock.GetPendingRegularization(It.IsAny<int>(), It.IsAny<string>())).Returns(new List<LeavePendingDTO>());

            // Act
            var result = _testClass.GetPendingRegularization(status);

            // Assert
            _regularization.Verify(mock => mock.GetPendingRegularization(It.IsAny<int>(), It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallGetLeavesByStatus()
        {
            // Arrange
            var status = "TestValue1788450002";

            _regularization.Setup(mock => mock.GetRegularizationByStatusAsync(It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new List<LeaveApprovalDTO>());

            // Act
            var result = await _testClass.GetLeavesByStatus(status);

            // Assert
            _regularization.Verify(mock => mock.GetRegularizationByStatusAsync(It.IsAny<string>(), It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}