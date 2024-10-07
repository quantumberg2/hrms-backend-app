namespace HRMS_Unit_Test.Controllers
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.Controllers;
    using HRMS_Application.DTO;
    using Moq;
    using Xunit;

    public class OrgChartControllerTests
    {
        private readonly OrgChartController _testClass;
        private readonly Mock<IOrgChartService> _orgChartService;

        public OrgChartControllerTests()
        {
            _orgChartService = new Mock<IOrgChartService>();
            _testClass = new OrgChartController(_orgChartService.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new OrgChartController(_orgChartService.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetManagersWithEmployees()
        {
            // Arrange
          //  _orgChartService.Setup(mock => mock.GetManagersWithEmployees()).Returns(new List<OrgChartNode>());

            // Act
          //  var result = _testClass.GetManagersWithEmployees();

            // Assert
          //  _orgChartService.Verify(mock => mock.GetManagersWithEmployees());

            throw new NotImplementedException("Create or modify test");
        }
    }
}