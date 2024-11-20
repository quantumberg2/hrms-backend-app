namespace HRMS_Unit_Test.DTO
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.DTO;
    using Xunit;

    public class MonthlyCountDTOTests
    {
        private readonly MonthlyCountDTO _testClass;

        public MonthlyCountDTOTests()
        {
            _testClass = new MonthlyCountDTO();
        }

        [Fact]
        public void CanSetAndGetYear()
        {
            // Arrange
            var testValue = 942421224;

            // Act
            _testClass.Year = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Year);
        }

        [Fact]
        public void CanSetAndGetMonth()
        {
            // Arrange
            var testValue = "TestValue1708125859";

            // Act
            _testClass.Month = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Month);
        }

        [Fact]
        public void CanSetAndGetJoinedCount()
        {
            // Arrange
            var testValue = 808980784;

            // Act
            _testClass.JoinedCount = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.JoinedCount);
        }

        [Fact]
        public void CanSetAndGetResignedCount()
        {
            // Arrange
            var testValue = 113853995;

            // Act
            _testClass.ResignedCount = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ResignedCount);
        }
    }

    public class ExperienceCountDTOTests
    {
        private readonly ExperienceCountDTO _testClass;

        public ExperienceCountDTOTests()
        {
            _testClass = new ExperienceCountDTO();
        }

        [Fact]
        public void CanSetAndGetYears()
        {
            // Arrange
            var testValue = "TestValue1674634773";

            // Act
            _testClass.Years = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Years);
        }

        [Fact]
        public void CanSetAndGetCount()
        {
            // Arrange
            var testValue = 295257589;

            // Act
            _testClass.Count = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Count);
        }
    }

    public class AdminDashboardDTOTests
    {
        private readonly AdminDashboardDTO _testClass;

        public AdminDashboardDTOTests()
        {
            _testClass = new AdminDashboardDTO();
        }

        [Fact]
        public void CanSetAndGetTotalEmployees()
        {
            // Arrange
            var testValue = 368377103;

            // Act
            _testClass.TotalEmployees = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TotalEmployees);
        }

        [Fact]
        public void CanSetAndGetNewEmployees()
        {
            // Arrange
            var testValue = 138521806;

            // Act
            _testClass.NewEmployees = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.NewEmployees);
        }

        [Fact]
        public void CanSetAndGetEmployeesJoinedMonthWise()
        {
            // Arrange
            var testValue = new List<MonthlyCountDTO>();

            // Act
            _testClass.EmployeesJoinedMonthWise = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmployeesJoinedMonthWise);
        }

        [Fact]
        public void CanSetAndGetEmployeesResignedMonthWise()
        {
            // Arrange
            var testValue = new List<MonthlyCountDTO>();

            // Act
            _testClass.EmployeesResignedMonthWise = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmployeesResignedMonthWise);
        }

        [Fact]
        public void CanSetAndGetExperienceCounts()
        {
            // Arrange
            var testValue = new List<ExperienceCountDTO>();

            // Act
            _testClass.ExperienceCounts = testValue;

            // Assert
            Assert.Same(testValue, _testClass.ExperienceCounts);
        }
    }
}