namespace HRMS_Unit_Test.Controllers
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.Controllers;
    using HRMS_Application.Models;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class NewsControllerTests
    {
        private readonly NewsController _testClass;
        private readonly Mock<ILogger<NewsController>> _logger;
        private readonly Mock<INews> _news;

        public NewsControllerTests()
        {
            _logger = new Mock<ILogger<NewsController>>();
            _news = new Mock<INews>();
            _testClass = new NewsController(_logger.Object, _news.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new NewsController(_logger.Object, _news.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllNews()
        {
            // Arrange
            _news.Setup(mock => mock.GetAllNews()).Returns(new List<News>());

            // Act
            var result = _testClass.GetAllNews();

            // Assert
            _news.Verify(mock => mock.GetAllNews());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallInsertNews()
        {
            // Arrange
            var newNews = new News
            {
                Id = 987036498,
                NewsPreviewId = 1442644635,
                Heading = "TestValue1490056436",
                Details = "TestValue850117467",
                NewsPreview = new NewsPreview
                {
                    Id = 1712624271,
                    DisplayDate = DateTime.UtcNow,
                    InsertedDate = DateTime.UtcNow,
                    Heading = "TestValue876545814",
                    Description = "TestValue173434888",
                    ImgUrl = "TestValue1461651138",
                    IsActive = (short)5302,
                    News = new Mock<ICollection<News>>().Object
                }
            };

            _news.Setup(mock => mock.InsertNews(It.IsAny<News>())).Returns("TestValue1940561556");

            // Act
            var result = _testClass.InsertNews(newNews);

            // Assert
            _news.Verify(mock => mock.InsertNews(It.IsAny<News>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallUpdateNews()
        {
            // Arrange
            var newNews = new News
            {
                Id = 1931242340,
                NewsPreviewId = 899326175,
                Heading = "TestValue2019858817",
                Details = "TestValue1295283974",
                NewsPreview = new NewsPreview
                {
                    Id = 1706325874,
                    DisplayDate = DateTime.UtcNow,
                    InsertedDate = DateTime.UtcNow,
                    Heading = "TestValue1604819641",
                    Description = "TestValue1016391881",
                    ImgUrl = "TestValue929546442",
                    IsActive = (short)15556,
                    News = new Mock<ICollection<News>>().Object
                }
            };

            _news.Setup(mock => mock.UpdateNews(It.IsAny<News>())).Returns("TestValue34782730");

            // Act
            var result = _testClass.UpdateNews(newNews);

            // Assert
            _news.Verify(mock => mock.UpdateNews(It.IsAny<News>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallDeleteNews()
        {
            // Arrange
            var id = 992844742;

            _news.Setup(mock => mock.DeleteNews(It.IsAny<int>())).Returns("TestValue338609896");

            // Act
            var result = _testClass.DeleteNews(id);

            // Assert
            _news.Verify(mock => mock.DeleteNews(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}