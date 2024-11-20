namespace HRMS_Unit_Test.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class LeaveTypeTests
    {
        private readonly LeaveType _testClass;

        public LeaveTypeTests()
        {
            _testClass = new LeaveType();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new LeaveType();

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 13306488;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetType()
        {
            // Arrange
            var testValue = "TestValue1643615209";

            // Act
            _testClass.Type = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Type);
        }

        [Fact]
        public void CanSetAndGetDays()
        {
            // Arrange
            var testValue = 351073162;

            // Act
            _testClass.Days = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Days);
        }

        [Fact]
        public void CanSetAndGetCompanyId()
        {
            // Arrange
            var testValue = 1475615131;

            // Act
            _testClass.CompanyId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.CompanyId);
        }

        [Fact]
        public void CanSetAndGetYear()
        {
            // Arrange
            var testValue = 1345271077;

            // Act
            _testClass.Year = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Year);
        }

        [Fact]
        public void CanSetAndGetIsActive()
        {
            // Arrange
            var testValue = (short)16244;

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
                Id = 1426709044,
                Name = "TestValue1592673460",
                PhoneNumber = "TestValue1083408069",
                DomainName = "TestValue2134697176",
                Status = "TestValue1801243891",
                InsertedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Email = "TestValue1281734526",
                IsActive = (short)32604,
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

        [Fact]
        public void CanSetAndGetEmployeeLeaveAllocations()
        {
            // Arrange
            var testValue = new Mock<ICollection<EmployeeLeaveAllocation>>().Object;

            // Act
            _testClass.EmployeeLeaveAllocations = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmployeeLeaveAllocations);
        }

        [Fact]
        public void CanSetAndGetLeaveTrackings()
        {
            // Arrange
            var testValue = new Mock<ICollection<LeaveTracking>>().Object;

            // Act
            _testClass.LeaveTrackings = testValue;

            // Assert
            Assert.Same(testValue, _testClass.LeaveTrackings);
        }

        [Fact]
        public void CanSetAndGetCompanyConfiguredLeave()
        {
            // Arrange
            var testValue = false;

            // Act
            _testClass.CompanyConfiguredLeave = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.CompanyConfiguredLeave);
        }
    }
}