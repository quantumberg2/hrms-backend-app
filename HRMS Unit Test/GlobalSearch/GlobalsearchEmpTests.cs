namespace HRMS_Unit_Test.GlobalSearch
{
    using System;
    using HRMS_Application.GlobalSearch;
    using Xunit;

    public class GlobalsearchEmpTests
    {
        private readonly GlobalsearchEmp _testClass;

        public GlobalsearchEmpTests()
        {
            _testClass = new GlobalsearchEmp();
        }

        [Fact]
        public void CanSetAndGetFilterBy()
        {
            // Arrange
            var testValue = "TestValue342114643";

            // Act
            _testClass.FilterBy = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.FilterBy);
        }
    }
}