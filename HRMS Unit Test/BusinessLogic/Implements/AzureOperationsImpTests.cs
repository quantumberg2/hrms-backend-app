namespace HRMS_Unit_Test.BusinessLogic.Implements
{
    using System;
    using Azure.Storage.Blobs;
    using HRMS_Application.BusinessLogic.Implements;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class AzureOperationsImpTests
    {
        private readonly AzureOperationsImp _testClass;
        private BlobServiceClient _blobServiceClient;

        public AzureOperationsImpTests()
        {
            _blobServiceClient = new BlobServiceClient("TestValue1962203869");
            _testClass = new AzureOperationsImp(_blobServiceClient);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new AzureOperationsImp(_blobServiceClient);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallStoreFilesInAzure()
        {
            // Arrange
            var fileObj = new Mock<IFormFile>().Object;
            var containerName = "TestValue1976160341";

            // Act
            var result = _testClass.StoreFilesInAzure(fileObj, containerName);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}