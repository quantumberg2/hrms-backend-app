namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Xunit;

    public class AddressInfoDTOTests
    {
        private readonly AddressInfoDTO _testClass;

        public AddressInfoDTOTests()
        {
            _testClass = new AddressInfoDTO();
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 615200737;

            // Act
            _testClass.EmployeeCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeCredentialId);
        }

        [Fact]
        public void CanSetAndGetAddressLine1()
        {
            // Arrange
            var testValue = "TestValue1963389297";

            // Act
            _testClass.AddressLine1 = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AddressLine1);
        }

        [Fact]
        public void CanSetAndGetAddressLine2()
        {
            // Arrange
            var testValue = "TestValue452581858";

            // Act
            _testClass.AddressLine2 = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AddressLine2);
        }

        [Fact]
        public void CanSetAndGetCity()
        {
            // Arrange
            var testValue = "TestValue1264790561";

            // Act
            _testClass.City = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.City);
        }

        [Fact]
        public void CanSetAndGetState()
        {
            // Arrange
            var testValue = "TestValue707459423";

            // Act
            _testClass.State = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.State);
        }

        [Fact]
        public void CanSetAndGetCountry()
        {
            // Arrange
            var testValue = "TestValue1590810437";

            // Act
            _testClass.Country = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Country);
        }

        [Fact]
        public void CanSetAndGetPinCode()
        {
            // Arrange
            var testValue = "TestValue1360574249";

            // Act
            _testClass.PinCode = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PinCode);
        }

        [Fact]
        public void CanSetAndGetIsActive()
        {
            // Arrange
            var testValue = (short)23978;

            // Act
            _testClass.IsActive = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.IsActive);
        }
    }
}