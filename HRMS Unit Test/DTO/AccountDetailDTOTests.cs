namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Xunit;

    public class AccountDetailDTOTests
    {
        private readonly AccountDetailDTO _testClass;

        public AccountDetailDTOTests()
        {
            _testClass = new AccountDetailDTO();
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 650720670;

            // Act
            _testClass.EmployeeCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeCredentialId);
        }

        [Fact]
        public void CanSetAndGetAccountNumber()
        {
            // Arrange
            var testValue = "TestValue757934338";

            // Act
            _testClass.AccountNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AccountNumber);
        }

        [Fact]
        public void CanSetAndGetIfscCode()
        {
            // Arrange
            var testValue = "TestValue967698938";

            // Act
            _testClass.IfscCode = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.IfscCode);
        }

        [Fact]
        public void CanSetAndGetAccountType()
        {
            // Arrange
            var testValue = "TestValue1698136665";

            // Act
            _testClass.AccountType = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AccountType);
        }

        [Fact]
        public void CanSetAndGetBankName()
        {
            // Arrange
            var testValue = "TestValue53587256";

            // Act
            _testClass.BankName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.BankName);
        }

        [Fact]
        public void CanSetAndGetBranchName()
        {
            // Arrange
            var testValue = "TestValue1922136364";

            // Act
            _testClass.BranchName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.BranchName);
        }

        [Fact]
        public void CanSetAndGetAadharNumber()
        {
            // Arrange
            var testValue = "TestValue1590372950";

            // Act
            _testClass.AadharNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AadharNumber);
        }

        [Fact]
        public void CanSetAndGetPfNumber()
        {
            // Arrange
            var testValue = "TestValue1919980916";

            // Act
            _testClass.PfNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PfNumber);
        }

        [Fact]
        public void CanSetAndGetUanNumber()
        {
            // Arrange
            var testValue = "TestValue30188802";

            // Act
            _testClass.UanNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.UanNumber);
        }

        [Fact]
        public void CanSetAndGetPfJoiningDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.PfJoiningDate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PfJoiningDate);
        }

        [Fact]
        public void CanSetAndGetEligibleForPf()
        {
            // Arrange
            var testValue = false;

            // Act
            _testClass.EligibleForPf = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EligibleForPf);
        }

        [Fact]
        public void CanSetAndGetIsActive()
        {
            // Arrange
            var testValue = (short)7808;

            // Act
            _testClass.IsActive = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.IsActive);
        }

        [Fact]
        public void CanSetAndGetCountry()
        {
            // Arrange
            var testValue = "TestValue308275740";

            // Act
            _testClass.Country = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Country);
        }

        [Fact]
        public void CanSetAndGetState()
        {
            // Arrange
            var testValue = "TestValue366892417";

            // Act
            _testClass.State = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.State);
        }

        [Fact]
        public void CanSetAndGetCity()
        {
            // Arrange
            var testValue = "TestValue1964081059";

            // Act
            _testClass.City = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.City);
        }

        [Fact]
        public void CanSetAndGetPin()
        {
            // Arrange
            var testValue = 1622874930;

            // Act
            _testClass.Pin = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Pin);
        }
    }
}