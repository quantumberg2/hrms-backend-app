namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class NewsDTOTests
    {
        private readonly NewsDTO _testClass;

        public NewsDTOTests()
        {
            _testClass = new NewsDTO();
        }

        [Fact]
        public void CanSetAndGetDisplayDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.DisplayDate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.DisplayDate);
        }

        [Fact]
        public void CanSetAndGetInsertedDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.InsertedDate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.InsertedDate);
        }

        [Fact]
        public void CanSetAndGetHeading()
        {
            // Arrange
            var testValue = "TestValue2110445186";

            // Act
            _testClass.Heading = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Heading);
        }

        [Fact]
        public void CanSetAndGetDesciption()
        {
            // Arrange
            var testValue = "TestValue1601287632";

            // Act
            _testClass.Desciption = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Desciption);
        }

        [Fact]
        public void CanSetAndGetImgUrl()
        {
            // Arrange
            var testValue = new Mock<IFormFile>().Object;

            // Act
            _testClass.ImgUrl = testValue;

            // Assert
            Assert.Same(testValue, _testClass.ImgUrl);
        }

        [Fact]
        public void CanSetAndGetIsActive()
        {
            // Arrange
            var testValue = (short)24659;

            // Act
            _testClass.IsActive = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.IsActive);
        }
    }
}