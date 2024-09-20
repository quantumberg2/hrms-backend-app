namespace HRMS_Unit_Test.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class HolidayTests
    {
        private readonly Holiday _testClass;

        public HolidayTests()
        {
            _testClass = new Holiday();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 200440649;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.Date = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Date);
        }

        [Fact]
        public void CanSetAndGetType()
        {
            // Arrange
            var testValue = "TestValue2121009354";

            // Act
            _testClass.Type = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Type);
        }

        [Fact]
        public void CanSetAndGetCompanyId()
        {
            // Arrange
            var testValue = 391962771;

            // Act
            _testClass.CompanyId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.CompanyId);
        }

        [Fact]
        public void CanSetAndGetOccasion()
        {
            // Arrange
            var testValue = "TestValue814776464";

            // Act
            _testClass.Occasion = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Occasion);
        }

        [Fact]
        public void CanSetAndGetIsActive()
        {
            // Arrange
            var testValue = (short)25064;

            // Act
            _testClass.IsActive = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.IsActive);
        }

        [Fact]
        public void CanSetAndGetCompany()
        {
            // Arrange
            var testValue = new RequestedCompanyForm
            {
                Id = 1874223695,
                Name = "TestValue765700642",
                PhoneNumber = "TestValue1333220231",
                DomainName = "TestValue1415987749",
                Status = "TestValue362922538",
                InsertedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Email = "TestValue1460718944",
                IsActive = (short)5837,
                CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                Departments = new Mock<ICollection<Department>>().Object,
                EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                Holidays = new Mock<ICollection<Holiday>>().Object,
                LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                Positions = new Mock<ICollection<Position>>().Object
            };

            // Act
            _testClass.Company = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Company);
        }
    }
}