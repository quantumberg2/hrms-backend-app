namespace HRMS_Unit_Test.BusinessLogic.Implements
{
    using System;
    using HRMS_Application.BusinessLogic.Implements;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class LocalStorageOperationsImpTests
    {
        private readonly LocalStorageOperationsImp _testClass;

        public LocalStorageOperationsImpTests()
        {
            _testClass = new LocalStorageOperationsImp();
        }

        [Fact]
        public void CanCallStoreFiles()
        {
            // Arrange
            var @file = new Mock<IFormFile>().Object;
            var directory = "TestValue1774457603";

            // Act
            var result = _testClass.StoreFiles(file, directory);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}