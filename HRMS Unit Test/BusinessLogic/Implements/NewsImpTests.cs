namespace HRMS_Unit_Test.BusinessLogic.Implements
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public class NewsImpTests
    {
        private readonly NewsImp _testClass;
        private HRMSContext _context;

        public NewsImpTests()
        {
            _context = new HRMSContext();
            _testClass = new NewsImp(_context);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new NewsImp(_context);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllNews()
        {
            // Act
            var result = _testClass.GetAllNews();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallInsertNews()
        {
            // Arrange
            var newNews = new News
            {
                Id = 869203435,
                NewsPreviewId = 1968734553,
                Heading = "TestValue1978611560",
                Details = "TestValue469715013",
                NewsPreview = new NewsPreview
                {
                    Id = 1825559147,
                    DisplayDate = DateTime.UtcNow,
                    InsertedDate = DateTime.UtcNow,
                    Heading = "TestValue1379873262",
                    Description = "TestValue540936333",
                    ImgUrl = "TestValue397637340",
                    IsActive = (short)17516,
                    News = new Mock<ICollection<News>>().Object
                }
            };

            // Act
            var result = _testClass.InsertNews(newNews);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallUpdateNews()
        {
            // Arrange
            var newNews = new News
            {
                Id = 1152505952,
                NewsPreviewId = 1039748064,
                Heading = "TestValue1436165202",
                Details = "TestValue294345444",
                NewsPreview = new NewsPreview
                {
                    Id = 1767629418,
                    DisplayDate = DateTime.UtcNow,
                    InsertedDate = DateTime.UtcNow,
                    Heading = "TestValue1455073098",
                    Description = "TestValue116693865",
                    ImgUrl = "TestValue785197441",
                    IsActive = (short)18610,
                    News = new Mock<ICollection<News>>().Object
                }
            };

            // Act
            var result = _testClass.UpdateNews(newNews);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallDeleteNews()
        {
            // Arrange
            var id = 511185450;

            // Act
            var result = _testClass.DeleteNews(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}