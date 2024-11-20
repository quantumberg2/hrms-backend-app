namespace HRMS_Unit_Test.Controllers
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.Controllers;
    using HRMS_Application.DTO;
    using HRMS_Application.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class NewsPreviewControllerTests
    {
        private readonly NewsPreviewController _testClass;
        private readonly Mock<ILogger<NewsPreviewController>> _logger;
        private readonly Mock<INewsPreview> _news;

        public NewsPreviewControllerTests()
        {
            _logger = new Mock<ILogger<NewsPreviewController>>();
            _news = new Mock<INewsPreview>();
            _testClass = new NewsPreviewController(_logger.Object, _news.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new NewsPreviewController(_logger.Object, _news.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllNews()
        {
            // Arrange
            _news.Setup(mock => mock.GetAllNews()).Returns(new List<NewsPreview>());

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
            var news = new NewsDTO
            {
                DisplayDate = DateTime.UtcNow,
                InsertedDate = DateTime.UtcNow,
                Heading = "TestValue1569924970",
                Desciption = "TestValue424981777",
                ImgUrl = new Mock<IFormFile>().Object,
                IsActive = (short)19934
            };

            _news.Setup(mock => mock.InsertNews(It.IsAny<NewsDTO>())).Returns("TestValue1375883673");

            // Act
            var result = _testClass.InsertNews(news);

            // Assert
            _news.Verify(mock => mock.InsertNews(It.IsAny<NewsDTO>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallUpdateNews()
        {
            // Arrange
            var id = 2099542340;
            var news = new NewsDTO
            {
                DisplayDate = DateTime.UtcNow,
                InsertedDate = DateTime.UtcNow,
                Heading = "TestValue719690823",
                Desciption = "TestValue806344800",
                ImgUrl = new Mock<IFormFile>().Object,
                IsActive = (short)15759
            };

            _news.Setup(mock => mock.UpdateNews(It.IsAny<int>(), It.IsAny<NewsDTO>())).Returns("TestValue675839625");

            // Act
            var result = _testClass.UpdateNews(id, news);

            // Assert
            _news.Verify(mock => mock.UpdateNews(It.IsAny<int>(), It.IsAny<NewsDTO>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 1482708210;
            var isActive = (short)16987;

            _news.Setup(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>())).Returns(false);

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            _news.Verify(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}