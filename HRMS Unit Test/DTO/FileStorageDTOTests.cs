namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class FileStorageDTOTests
    {
        private readonly FileStorageDTO _testClass;

        public FileStorageDTOTests()
        {
            _testClass = new FileStorageDTO();
        }

        [Fact]
        public void CanSetAndGetObjectId()
        {
            // Arrange
            var testValue = 1656932607;

            // Act
            _testClass.ObjectId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ObjectId);
        }

        [Fact]
        public void CanSetAndGetObjectName()
        {
            // Arrange
            var testValue = "TestValue249082256";

            // Act
            _testClass.ObjectName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ObjectName);
        }

        [Fact]
        public void CanSetAndGetIsActive()
        {
            // Arrange
            var testValue = false;

            // Act
            _testClass.IsActive = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.IsActive);
        }

        [Fact]
        public void CanSetAndGetTags()
        {
            // Arrange
            var testValue = "TestValue957001128";

            // Act
            _testClass.Tags = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Tags);
        }

        [Fact]
        public void CanSetAndGetFileContent()
        {
            // Arrange
            var testValue = new Mock<IFormFile>().Object;

            // Act
            _testClass.FileContent = testValue;

            // Assert
            Assert.Same(testValue, _testClass.FileContent);
        }
    }
}