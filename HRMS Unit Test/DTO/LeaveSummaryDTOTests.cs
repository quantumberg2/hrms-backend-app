namespace HRMS_Unit_Test.DTO
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.DTO;
    using Xunit;

    public class LeaveSummaryDTOTests
    {
        private readonly LeaveSummaryDTO _testClass;

        public LeaveSummaryDTOTests()
        {
            _testClass = new LeaveSummaryDTO();
        }

        [Fact]
        public void CanSetAndGetTotalAllocatedLeaves()
        {
            // Arrange
            var testValue = 904605409;

            // Act
            _testClass.TotalAllocatedLeaves = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TotalAllocatedLeaves);
        }

        [Fact]
        public void CanSetAndGetApprovedLeaves()
        {
            // Arrange
            var testValue = 484458779;

            // Act
            _testClass.ApprovedLeaves = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ApprovedLeaves);
        }

        [Fact]
        public void CanSetAndGetPendingLeaves()
        {
            // Arrange
            var testValue = 337802626;

            // Act
            _testClass.PendingLeaves = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PendingLeaves);
        }

        [Fact]
        public void CanSetAndGetRejectedLeaves()
        {
            // Arrange
            var testValue = 893287016;

            // Act
            _testClass.RejectedLeaves = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RejectedLeaves);
        }

        [Fact]
        public void CanSetAndGetRemainingLeaves()
        {
            // Arrange
            var testValue = 485871167;

            // Act
            _testClass.RemainingLeaves = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RemainingLeaves);
        }

        /*[Fact]
        public void CanSetAndGetLeaveType()
        {
            // Arrange
            var testValue = "TestValue962795293";

            // Act
            _testClass.LeaveType = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LeaveType);
        }*/

      /*  [Fact]
        public void CanSetAndGetApprovedCount()
        {
            // Arrange
            var testValue = 1324241054;

            // Act
            _testClass.ApprovedCount = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ApprovedCount);
        }
*/
       /* [Fact]
        public void CanSetAndGetPendingCount()
        {
            // Arrange
            var testValue = 247685496;

            // Act
            _testClass.PendingCount = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PendingCount);
        }
*/
      /*  [Fact]
        public void CanSetAndGetRejectedCount()
        {
            // Arrange
            var testValue = 741119222;

            // Act
            _testClass.RejectedCount = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RejectedCount);
        }*/

        [Fact]
        public void CanSetAndGetLeaveSummaries()
        {
            // Arrange
            var testValue = new List<LeaveSummaryDTO>();

            // Act
            _testClass.LeaveSummaries = testValue;

            // Assert
            Assert.Same(testValue, _testClass.LeaveSummaries);
        }
    }
}