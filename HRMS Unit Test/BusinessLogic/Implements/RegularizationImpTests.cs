namespace HRMS_Unit_Test.BusinessLogic.Implements
{
    using System;
    using System.Threading.Tasks;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.Models;
    using Xunit;

    public class RegularizationImpTests
    {
        private readonly RegularizationImp _testClass;
        private HRMSContext _hrmscontext;

        public RegularizationImpTests()
        {
            _hrmscontext = new HRMSContext();
            _testClass = new RegularizationImp(_hrmscontext);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new RegularizationImp(_hrmscontext);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetPendingRegularization()
        {
            // Arrange
            var employeeCredentialId = 1356694736;
            var status = "TestValue1758406281";

            // Act
            var result = _testClass.GetPendingRegularization(employeeCredentialId, status);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallGetRegularizationByStatusAsync()
        {
            // Arrange
            var status = "TestValue1088245753";
            var managerId = 1494507674;

            // Act
            var result = await _testClass.GetRegularizationByStatusAsync(status, managerId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}