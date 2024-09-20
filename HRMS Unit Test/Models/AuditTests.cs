namespace HRMS_Unit_Test.Models
{
    using System;
    using HRMS_Application.Models;
    using Xunit;

    public partial class AuditTests
    {
        private readonly Audit _testClass;

        public AuditTests()
        {
            _testClass = new Audit();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 32362464;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetUserId()
        {
            // Arrange
            var testValue = 1602631693;

            // Act
            _testClass.UserId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.UserId);
        }

        [Fact]
        public void CanSetAndGetType()
        {
            // Arrange
            var testValue = "TestValue196580993";

            // Act
            _testClass.Type = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Type);
        }

        [Fact]
        public void CanSetAndGetTableName()
        {
            // Arrange
            var testValue = "TestValue242507860";

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
            var testValue = "TestValue1251900823";

            // Act
            _testClass.OldValues = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.OldValues);
        }

        [Fact]
        public void CanSetAndGetNewValues()
        {
            // Arrange
            var testValue = "TestValue1220678739";

            // Act
            _testClass.NewValues = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.NewValues);
        }

        [Fact]
        public void CanSetAndGetAffectedColumns()
        {
            // Arrange
            var testValue = "TestValue1147650141";

            // Act
            _testClass.AffectedColumns = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AffectedColumns);
        }

        [Fact]
        public void CanSetAndGetPrimaryKey()
        {
            // Arrange
            var testValue = "TestValue91281186";

            // Act
            _testClass.PrimaryKey = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PrimaryKey);
        }

        [Fact]
        public void CanSetAndGetIsActive()
        {
            // Arrange
            var testValue = (short)10036;

            // Act
            _testClass.IsActive = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.IsActive);
        }
    }
}