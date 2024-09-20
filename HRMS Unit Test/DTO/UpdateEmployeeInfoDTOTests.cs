namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Xunit;

    public class UpdateEmployeeInfoDTOTests
    {
        private readonly UpdateEmployeeInfoDTO _testClass;

        public UpdateEmployeeInfoDTOTests()
        {
            _testClass = new UpdateEmployeeInfoDTO();
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 1170551312;

            // Act
            _testClass.EmployeeCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeCredentialId);
        }

        [Fact]
        public void CanSetAndGetEmployeeName()
        {
            // Arrange
            var testValue = "TestValue1941181788";

            // Act
            _testClass.EmployeeName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeName);
        }

        [Fact]
        public void CanSetAndGetNickName()
        {
            // Arrange
            var testValue = "TestValue227407456";

            // Act
            _testClass.NickName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.NickName);
        }

        [Fact]
        public void CanSetAndGetEmailAddress()
        {
            // Arrange
            var testValue = "TestValue471441667";

            // Act
            _testClass.EmailAddress = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmailAddress);
        }

        [Fact]
        public void CanSetAndGetEmpLoginName()
        {
            // Arrange
            var testValue = "TestValue1623906090";

            // Act
            _testClass.EmpLoginName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmpLoginName);
        }

        [Fact]
        public void CanSetAndGetMobileNumber()
        {
            // Arrange
            var testValue = "TestValue1024839017";

            // Act
            _testClass.MobileNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.MobileNumber);
        }

        [Fact]
        public void CanSetAndGetExtension()
        {
            // Arrange
            var testValue = "TestValue1425935056";

            // Act
            _testClass.Extension = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Extension);
        }

        [Fact]
        public void CanSetAndGetgender()
        {
            // Arrange
            var testValue = "TestValue345937604";

            // Act
            _testClass.gender = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.gender);
        }
    }
}