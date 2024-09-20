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

    public class FileStorageControllerTests
    {
        private readonly FileStorageController _testClass;
        private readonly Mock<ILogger<FileStorageController>> _logger;
        private readonly Mock<IFileStorage> _fileStorage;

        public FileStorageControllerTests()
        {
            _logger = new Mock<ILogger<FileStorageController>>();
            _fileStorage = new Mock<IFileStorage>();
            _testClass = new FileStorageController(_logger.Object, _fileStorage.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new FileStorageController(_logger.Object, _fileStorage.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetFiles()
        {
            // Arrange
            _fileStorage.Setup(mock => mock.GetFiles()).Returns(new List<File>());

            // Act
            var result = _testClass.GetFiles();

            // Assert
            _fileStorage.Verify(mock => mock.GetFiles());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallUploadFile()
        {
            // Arrange
            var @file = new FileStorageDTO
            {
                ObjectId = 1923778001,
                ObjectName = "TestValue243559012",
                IsActive = true,
                Tags = "TestValue1046869106",
                FileContent = new Mock<IFormFile>().Object
            };

            _fileStorage.Setup(mock => mock.UploadFile(It.IsAny<FileStorageDTO>())).Returns("TestValue903485624");

            // Act
            var result = _testClass.UploadFile(file);

            // Assert
            _fileStorage.Verify(mock => mock.UploadFile(It.IsAny<FileStorageDTO>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallUpdateFile()
        {
            // Arrange
            var id = 1139559835;
            var files = new FileStorageDTO
            {
                ObjectId = 1653005629,
                ObjectName = "TestValue1821979766",
                IsActive = false,
                Tags = "TestValue1918379856",
                FileContent = new Mock<IFormFile>().Object
            };

            _fileStorage.Setup(mock => mock.UpdateFile(It.IsAny<int>(), It.IsAny<FileStorageDTO>())).Returns("TestValue1972594316");

            // Act
            var result = _testClass.UpdateFile(id, files);

            // Assert
            _fileStorage.Verify(mock => mock.UpdateFile(It.IsAny<int>(), It.IsAny<FileStorageDTO>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 653687585;
            var isActive = true;

            _fileStorage.Setup(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<bool>())).Returns(true);

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            _fileStorage.Verify(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<bool>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}