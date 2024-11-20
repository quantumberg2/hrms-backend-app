namespace HRMS_Unit_Test.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class NewsPreviewTests
    {
        private readonly NewsPreview _testClass;

        public NewsPreviewTests()
        {
            _testClass = new NewsPreview();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new NewsPreview();

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 323337649;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
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
            var testValue = "TestValue617470708";

            // Act
            _testClass.Heading = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Heading);
        }

        [Fact]
        public void CanSetAndGetDescription()
        {
            // Arrange
            var testValue = "TestValue1372088432";

            // Act
            _testClass.Description = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Description);
        }

        [Fact]
        public void CanSetAndGetImgUrl()
        {
            // Arrange
            var testValue = "TestValue2017962572";

            // Act
            _testClass.ImgUrl = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ImgUrl);
        }

        [Fact]
        public void CanSetAndGetIsActive()
        {
            // Arrange
            var testValue = (short)21665;

            // Act
            _testClass.IsActive = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.IsActive);
        }

        [Fact]
        public void CanSetAndGetNews()
        {
            // Arrange
            var testValue = new Mock<ICollection<News>>().Object;

            // Act
            _testClass.News = testValue;

            // Assert
            Assert.Same(testValue, _testClass.News);
        }
    }
}