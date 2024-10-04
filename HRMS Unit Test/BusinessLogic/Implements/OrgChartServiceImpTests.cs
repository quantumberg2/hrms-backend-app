namespace HRMS_Unit_Test.BusinessLogic.Implements
{
    using System;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.Models;
    using Xunit;

    public class OrgChartServiceImpTests
    {
        private readonly OrgChartServiceImp _testClass;
        private HRMSContext _hrmsContext;

        public OrgChartServiceImpTests()
        {
            _hrmsContext = new HRMSContext();
            _testClass = new OrgChartServiceImp(_hrmsContext);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new OrgChartServiceImp(_hrmsContext);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetManagersWithEmployees()
        {
            // Act
         //   var result = _testClass.GetManagersWithEmployees();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}