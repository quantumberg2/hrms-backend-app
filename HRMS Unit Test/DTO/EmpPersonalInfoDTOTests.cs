namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Xunit;

    public class EmpPersonalInfoDTOTests
    {
        private readonly EmpPersonalInfoDTO _testClass;

        public EmpPersonalInfoDTOTests()
        {
            _testClass = new EmpPersonalInfoDTO();
        }

        [Fact]
        public void CanSetAndGetFirstName()
        {
            // Arrange
            var testValue = "TestValue1429993003";

            // Act
            _testClass.FirstName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.FirstName);
        }

        [Fact]
        public void CanSetAndGetMiddleName()
        {
            // Arrange
            var testValue = "TestValue2037031438";

            // Act
            _testClass.MiddleName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.MiddleName);
        }

        [Fact]
        public void CanSetAndGetLastName()
        {
            // Arrange
            var testValue = "TestValue327708041";

            // Act
            _testClass.LastName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LastName);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 196337166;

            // Act
            _testClass.EmployeeCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeCredentialId);
        }

        [Fact]
        public void CanSetAndGetDob()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.Dob = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Dob);
        }

        [Fact]
        public void CanSetAndGetDateOfJoining()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.DateOfJoining = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.DateOfJoining);
        }

        [Fact]
        public void CanSetAndGetConfirmDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.ConfirmDate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ConfirmDate);
        }

        [Fact]
        public void CanSetAndGetEmpStatus()
        {
            // Arrange
            var testValue = "TestValue2014384942";

            // Act
            _testClass.EmpStatus = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmpStatus);
        }

        [Fact]
        public void CanSetAndGetEmailId()
        {
            // Arrange
            var testValue = "TestValue1344984013";

            // Act
            _testClass.EmailId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmailId);
        }

        [Fact]
        public void CanSetAndGetPersonalEmail()
        {
            // Arrange
            var testValue = "TestValue1171737820";

            // Act
            _testClass.PersonalEmail = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PersonalEmail);
        }

        [Fact]
        public void CanSetAndGetMaritalStatus()
        {
            // Arrange
            var testValue = "TestValue1319302260";

            // Act
            _testClass.MaritalStatus = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.MaritalStatus);
        }

        [Fact]
        public void CanSetAndGetBloodGroup()
        {
            // Arrange
            var testValue = "TestValue1258110204";

            // Act
            _testClass.BloodGroup = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.BloodGroup);
        }

        [Fact]
        public void CanSetAndGetSpouseName()
        {
            // Arrange
            var testValue = "TestValue476373875";

            // Act
            _testClass.SpouseName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.SpouseName);
        }

        [Fact]
        public void CanSetAndGetPhysicallyChallenged()
        {
            // Arrange
            var testValue = true;

            // Act
            _testClass.PhysicallyChallenged = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PhysicallyChallenged);
        }

        [Fact]
        public void CanSetAndGetEmergencyContact()
        {
            // Arrange
            var testValue = "TestValue126550530";

            // Act
            _testClass.EmergencyContact = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmergencyContact);
        }

        [Fact]
        public void CanSetAndGetPAN()
        {
            // Arrange
            var testValue = "TestValue1674854342";

            // Act
            _testClass.PAN = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PAN);
        }

        [Fact]
        public void CanSetAndGetGender()
        {
            // Arrange
            var testValue = "TestValue1670330882";

            // Act
            _testClass.Gender = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Gender);
        }

        [Fact]
        public void CanSetAndGetContact()
        {
            // Arrange
            var testValue = "TestValue355943638";

            // Act
            _testClass.Contact = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Contact);
        }
    }
}