namespace HRMSunitTestCase.Models
{
    using System;
    using HRMS_Application.Models;
    using Xunit;

    public partial class AduitTests
    {
        private Aduit _testClass;

        public AduitTests()
        {
            _testClass = new Aduit();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 1757698572;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetUserId()
        {
            // Arrange
            var testValue = 1483392898;

            // Act
            _testClass.UserId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.UserId);
        }

        [Fact]
        public void CanSetAndGetType()
        {
            // Arrange
            var testValue = "TestValue1255030426";

            // Act
            _testClass.Type = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Type);
        }

        [Fact]
        public void CanSetAndGetTableName()
        {
            // Arrange
            var testValue = "TestValue1755025663";

            // Act
            _testClass.TableName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TableName);
        }

        [Fact]
        public void CanSetAndGetDateTime()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.DateTime = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.DateTime);
        }

        [Fact]
        public void CanSetAndGetOldValues()
        {
            // Arrange
            var testValue = "TestValue1502505817";

            // Act
            _testClass.OldValues = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.OldValues);
        }

        [Fact]
        public void CanSetAndGetNewValues()
        {
            // Arrange
            var testValue = "TestValue1728819794";

            // Act
            _testClass.NewValues = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.NewValues);
        }

        [Fact]
        public void CanSetAndGetAffectedColumns()
        {
            // Arrange
            var testValue = "TestValue1768134234";

            // Act
            _testClass.AffectedColumns = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AffectedColumns);
        }

        [Fact]
        public void CanSetAndGetPrimaryKey()
        {
            // Arrange
            var testValue = "TestValue899201781";

            // Act
            _testClass.PrimaryKey = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PrimaryKey);
        }
    }
}