namespace HRMS_Unit_Test.Models
{
    using System;
    using HRMS_Application.Models;
    using Xunit;

    public partial class FileTests
    {
        private readonly File _testClass;

        public FileTests()
        {
            _testClass = new File();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 882227890;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetFileUrl()
        {
            // Arrange
            var testValue = "TestValue151943408";

            // Act
            _testClass.FileUrl = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.FileUrl);
        }

        [Fact]
        public void CanSetAndGetObjectId()
        {
            // Arrange
            var testValue = 484462898;

            // Act
            _testClass.ObjectId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ObjectId);
        }

        [Fact]
        public void CanSetAndGetObjectName()
        {
            // Arrange
            var testValue = "TestValue1022028819";

            // Act
            _testClass.ObjectName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ObjectName);
        }

        [Fact]
        public void CanSetAndGetIsActive()
        {
            // Arrange
            var testValue = true;

            // Act
            _testClass.IsActive = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.IsActive);
        }

        [Fact]
        public void CanSetAndGetTags()
        {
            // Arrange
            var testValue = "TestValue1137919858";

            // Act
            _testClass.Tags = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Tags);
        }
    }
}