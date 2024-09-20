namespace HRMS_Unit_Test.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Enums;
    using HRMS_Application.Models;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Moq;
    using Xunit;

    public class AuditEntryTests
    {
        private readonly AuditEntry _testClass;
        private EntityEntry _entry;

        public AuditEntryTests()
        {
            _entry = new EntityEntry(new InternalEntityEntry(new Mock<IStateManager>().Object, new Mock<IEntityType>().Object, new object()));
            _testClass = new AuditEntry(_entry);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new AuditEntry(_entry);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallToAudit()
        {
            // Act
            var result = _testClass.ToAudit();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanSetAndGetUserId()
        {
            // Arrange
            var testValue = 1619268631;

            // Act
            _testClass.UserId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.UserId);
        }

        [Fact]
        public void CanSetAndGetTableName()
        {
            // Arrange
            var testValue = "TestValue288228692";

            // Act
            _testClass.TableName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TableName);
        }

        [Fact]
        public void CanGetKeyValues()
        {
            // Assert
            Assert.IsType<Dictionary<string, object>>(_testClass.KeyValues);

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanGetOldValues()
        {
            // Assert
            Assert.IsType<Dictionary<string, object>>(_testClass.OldValues);

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanGetNewValues()
        {
            // Assert
            Assert.IsType<Dictionary<string, object>>(_testClass.NewValues);

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanSetAndGetAuditType()
        {
            // Arrange
            var testValue = AuditType.None;

            // Act
            _testClass.AuditType = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AuditType);
        }

        [Fact]
        public void CanGetChangedColumns()
        {
            // Assert
            Assert.IsType<List<string>>(_testClass.ChangedColumns);

            throw new NotImplementedException("Create or modify test");
        }
    }
}