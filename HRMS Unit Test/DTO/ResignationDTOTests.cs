namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Xunit;

    public class ResignationDTOTests
    {
        private readonly ResignationDTO _testClass;

        public ResignationDTOTests()
        {
            _testClass = new ResignationDTO();
        }

        [Fact]
        public void CanSetAndGetReason()
        {
            // Arrange
            var testValue = "TestValue1241608961";

            // Act
            _testClass.Reason = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Reason);
        }

        [Fact]
        public void CanSetAndGetStartDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.StartDate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.StartDate);
        }

        [Fact]
        public void CanSetAndGetCreatedDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.CreatedDate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.CreatedDate);
        }

        [Fact]
        public void CanSetAndGetComments()
        {
            // Arrange
            var testValue = "TestValue1469952096";

            // Act
            _testClass.Comments = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Comments);
        }
    }
}