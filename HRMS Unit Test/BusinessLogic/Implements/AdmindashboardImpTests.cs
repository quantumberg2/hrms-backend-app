namespace HRMS_Unit_Test.BusinessLogic.Implements
{
    using System;
    using System.Threading.Tasks;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.Models;
    using Xunit;

    public class AdmindashboardImpTests
    {
        private readonly AdmindashboardImp _testClass;
        private HRMSContext _hrmsContext;

        public AdmindashboardImpTests()
        {
            _hrmsContext = new HRMSContext();
            _testClass = new AdmindashboardImp(_hrmsContext);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new AdmindashboardImp(_hrmsContext);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallGetAdminDashboardAsync()
        {
            // Arrange
            var companyId = 1571402776;

            // Act
            var result = await _testClass.GetAdminDashboardAsync(companyId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}