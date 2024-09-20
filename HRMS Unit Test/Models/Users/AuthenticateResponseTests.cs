namespace HRMS_Unit_Test
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.DTOs;
    using Xunit;

    public class AuthenticateResponseTests
    {
        private readonly AuthenticateResponse _testClass;
        private UserDto _user;
        private string _token;
        private List<string> _roles;
        private List<int> _companyIds;

        public AuthenticateResponseTests()
        {
            _user = new UserDto
            {
                UserName = "TestValue1047106014",
                UserId = 993026341,
                Email = "TestValue1993995281",
                RequestedCompanyId = 157383919,
                CompanyIds = new List<int>(),
                Roles = new List<string>()
            };
            _token = "TestValue1885783355";
            _roles = new List<string>();
            _companyIds = new List<int>();
            _testClass = new AuthenticateResponse(_user, _token, _roles, _companyIds);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new AuthenticateResponse(_user, _token, _roles, _companyIds);

            // Assert
            Assert.NotNull(instance);

            // Act
            instance = new AuthenticateResponse(_companyIds);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 728317748;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue1714091075";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetUsername()
        {
            // Arrange
            var testValue = "TestValue1550288122";

            // Act
            _testClass.Username = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Username);
        }

        [Fact]
        public void CanSetAndGetPassword()
        {
            // Arrange
            var testValue = "TestValue157322586";

            // Act
            _testClass.Password = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Password);
        }

        [Fact]
        public void CanSetAndGetEmail()
        {
            // Arrange
            var testValue = "TestValue1726955169";

            // Act
            _testClass.Email = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Email);
        }

        [Fact]
        public void CanSetAndGetCompanyRequestId()
        {
            // Arrange
            var testValue = 1971002583;

            // Act
            _testClass.CompanyRequestId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.CompanyRequestId);
        }

        [Fact]
        public void CanSetAndGetCompanyIds()
        {
            // Arrange
            var testValue = new List<int>();

            // Act
            _testClass.CompanyIds = testValue;

            // Assert
            Assert.Same(testValue, _testClass.CompanyIds);
        }

        [Fact]
        public void CanSetAndGetRoles()
        {
            // Arrange
            var testValue = new List<string>();

            // Act
            _testClass.Roles = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Roles);
        }

        [Fact]
        public void CanSetAndGetToken()
        {
            // Arrange
            var testValue = "TestValue394606145";

            // Act
            _testClass.Token = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Token);
        }
    }
}