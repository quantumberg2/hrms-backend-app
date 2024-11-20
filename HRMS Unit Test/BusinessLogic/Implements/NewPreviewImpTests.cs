namespace HRMS_Unit_Test.BusinessLogic.Implements
{
    using System;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.DTO;
    using HRMS_Application.Models;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class NewPreviewImpTests
    {
        private readonly NewPreviewImp _testClass;
        private HRMSContext _hRMSContext;
        private readonly Mock<IAzureOperations> _azureOperations;

        public NewPreviewImpTests()
        {
            _hRMSContext = new HRMSContext();
            _azureOperations = new Mock<IAzureOperations>();
            _testClass = new NewPreviewImp(_hRMSContext, _azureOperations.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new NewPreviewImp(_hRMSContext, _azureOperations.Object);

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
            var news = new NewsDTO
            {
                DisplayDate = DateTime.UtcNow,
                InsertedDate = DateTime.UtcNow,
                Heading = "TestValue677895247",
                Desciption = "TestValue1515483065",
                ImgUrl = new Mock<IFormFile>().Object,
                IsActive = (short)28585
            };

            _azureOperations.Setup(mock => mock.StoreFilesInAzure(It.IsAny<IFormFile>(), It.IsAny<string>())).Returns("TestValue203401669");

            // Act
            var result = _testClass.InsertNews(news);

            // Assert
            _azureOperations.Verify(mock => mock.StoreFilesInAzure(It.IsAny<IFormFile>(), It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallUpdateNews()
        {
            // Arrange
            var id = 162004555;
            var news = new NewsDTO
            {
                DisplayDate = DateTime.UtcNow,
                InsertedDate = DateTime.UtcNow,
                Heading = "TestValue1591885274",
                Desciption = "TestValue940809003",
                ImgUrl = new Mock<IFormFile>().Object,
                IsActive = (short)16171
            };

            _azureOperations.Setup(mock => mock.StoreFilesInAzure(It.IsAny<IFormFile>(), It.IsAny<string>())).Returns("TestValue1937972778");

            // Act
            var result = _testClass.UpdateNews(id, news);

            // Assert
            _azureOperations.Verify(mock => mock.StoreFilesInAzure(It.IsAny<IFormFile>(), It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 1142325179;
            var isActive = (short)2776;

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}