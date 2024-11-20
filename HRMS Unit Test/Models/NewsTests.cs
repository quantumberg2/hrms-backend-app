namespace HRMS_Unit_Test.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class NewsTests
    {
        private readonly News _testClass;

        public NewsTests()
        {
            _testClass = new News();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 46830919;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetNewsPreviewId()
        {
            // Arrange
            var testValue = 1693202676;

            // Act
            _testClass.NewsPreviewId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.NewsPreviewId);
        }

        [Fact]
        public void CanSetAndGetHeading()
        {
            // Arrange
            var testValue = "TestValue535036852";

            // Act
            _testClass.Heading = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Heading);
        }

        [Fact]
        public void CanSetAndGetDetails()
        {
            // Arrange
            var testValue = "TestValue538381380";

            // Act
            _testClass.Details = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Details);
        }

        [Fact]
        public void CanSetAndGetNewsPreview()
        {
            // Arrange
            var testValue = new NewsPreview
            {
                Id = 196170587,
                DisplayDate = DateTime.UtcNow,
                InsertedDate = DateTime.UtcNow,
                Heading = "TestValue1457483946",
                Description = "TestValue1464126995",
                ImgUrl = "TestValue1801849058",
                IsActive = (short)32480,
                News = new Mock<ICollection<News>>().Object
            };

            // Act
            _testClass.NewsPreview = testValue;

            // Assert
            Assert.Same(testValue, _testClass.NewsPreview);
        }
    }
}