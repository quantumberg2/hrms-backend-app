namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Xunit;

    public class SelectCompanyRequestTests
    {
        private readonly SelectCompanyRequest _testClass;

        public SelectCompanyRequestTests()
        {
            _testClass = new SelectCompanyRequest();
        }

        [Fact]
        public void CanSetAndGetCompanyId()
        {
            // Arrange
            var testValue = 1637965526;

            // Act
            _testClass.CompanyId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.CompanyId);
        }
    }
}