namespace HRMS_Unit_Test.DTO
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.DTO;
    using Xunit;

    public class MonthlyAttendanceStatisticsTests
    {
        private readonly MonthlyAttendanceStatistics _testClass;

        public MonthlyAttendanceStatisticsTests()
        {
            _testClass = new MonthlyAttendanceStatistics();
        }

        [Fact]
        public void CanSetAndGetEmployeecredntialId()
        {
            // Arrange
            var testValue = 1801022154;

            // Act
            _testClass.EmployeecredntialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeecredntialId);
        }

        [Fact]
        public void CanSetAndGetTotalWorkingDays()
        {
            // Arrange
            var testValue = 1174509455;

            // Act
            _testClass.TotalWorkingDays = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TotalWorkingDays);
        }

        [Fact]
        public void CanSetAndGetTotalHoursWorked()
        {
            // Arrange
            var testValue = 1829930264.91;

            // Act
            _testClass.TotalHoursWorked = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TotalHoursWorked);
        }

        [Fact]
        public void CanSetAndGetAverageWorkHours()
        {
            // Arrange
            var testValue = "TestValue2043829495";

            // Act
            _testClass.AverageWorkHours = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AverageWorkHours);
        }

        [Fact]
        public void CanSetAndGetAverageOvertime()
        {
            // Arrange
            var testValue = "TestValue915592710";

            // Act
            _testClass.AverageOvertime = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AverageOvertime);
        }

        [Fact]
        public void CanSetAndGetTotalWorkplusOT()
        {
            // Arrange
            var testValue = "TestValue1570363458";

            // Act
            _testClass.TotalWorkplusOT = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TotalWorkplusOT);
        }

        [Fact]
        public void CanSetAndGetTotalOverTime()
        {
            // Arrange
            var testValue = "TestValue549232777";

            // Act
            _testClass.TotalOverTime = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TotalOverTime);
        }

        [Fact]
        public void CanSetAndGetLessHoursTime()
        {
            // Arrange
            var testValue = "TestValue1055926367";

            // Act
            _testClass.LessHoursTime = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LessHoursTime);
        }

        [Fact]
        public void CanSetAndGetAvgTimein()
        {
            // Arrange
            var testValue = "TestValue1059333036";

            // Act
            _testClass.AvgTimein = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AvgTimein);
        }

        [Fact]
        public void CanSetAndGetAvgTimeouT()
        {
            // Arrange
            var testValue = "TestValue875002627";

            // Act
            _testClass.AvgTimeouT = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AvgTimeouT);
        }

        [Fact]
        public void CanSetAndGetLateInCount()
        {
            // Arrange
            var testValue = 771821790;

            // Act
            _testClass.LateInCount = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LateInCount);
        }

        [Fact]
        public void CanSetAndGetEarlyOutCount()
        {
            // Arrange
            var testValue = 386755877;

            // Act
            _testClass.EarlyOutCount = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EarlyOutCount);
        }

        [Fact]
        public void CanSetAndGetAbsentCount()
        {
            // Arrange
            var testValue = 706058628;

            // Act
            _testClass.AbsentCount = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AbsentCount);
        }

        [Fact]
        public void CanSetAndGetLeaveTakenCount()
        {
            // Arrange
            var testValue = 1732751813;

            // Act
            _testClass.LeaveTakenCount = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LeaveTakenCount);
        }

        [Fact]
        public void CanSetAndGetPenaltyCount()
        {
            // Arrange
            var testValue = 455311446;

            // Act
            _testClass.PenaltyCount = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PenaltyCount);
        }

        [Fact]
        public void CanSetAndGetPresentPercentage()
        {
            // Arrange
            var testValue = 488963811.6;

            // Act
            _testClass.PresentPercentage = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PresentPercentage);
        }

        [Fact]
        public void CanSetAndGetAbsentPercentage()
        {
            // Arrange
            var testValue = 1809943078.68;

            // Act
            _testClass.AbsentPercentage = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AbsentPercentage);
        }

        [Fact]
        public void CanSetAndGetLeaveTakenPercentage()
        {
            // Arrange
            var testValue = 134010474.84;

            // Act
            _testClass.LeaveTakenPercentage = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LeaveTakenPercentage);
        }

        [Fact]
        public void CanSetAndGetHolidayPercentage()
        {
            // Arrange
            var testValue = 1118294753.4;

            // Act
            _testClass.HolidayPercentage = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.HolidayPercentage);
        }

        [Fact]
        public void CanSetAndGetRestDaysPercentage()
        {
            // Arrange
            var testValue = 1706185907.91;

            // Act
            _testClass.RestDaysPercentage = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RestDaysPercentage);
        }

        [Fact]
        public void CanSetAndGetSpecificDayAttendance()
        {
            // Arrange
            var testValue = new DateWiseAttendance
            {
                Date = DateTime.UtcNow,
                TimeIn = "TestValue1911708379",
                TimeOut = "TestValue1415001624",
                WorkTime = "TestValue1687408333",
                Overtime = "TestValue1310768058",
                Status = "TestValue1099468133"
            };

            // Act
            _testClass.SpecificDayAttendance = testValue;

            // Assert
            Assert.Same(testValue, _testClass.SpecificDayAttendance);
        }

        [Fact]
        public void CanSetAndGetDateWiseAttendance()
        {
            // Arrange
            var testValue = new List<DateWiseAttendance>();

            // Act
            _testClass.DateWiseAttendance = testValue;

            // Assert
            Assert.Same(testValue, _testClass.DateWiseAttendance);
        }
    }

    public class DateWiseAttendanceTests
    {
        private readonly DateWiseAttendance _testClass;

        public DateWiseAttendanceTests()
        {
            _testClass = new DateWiseAttendance();
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
        public void CanSetAndGetTimeIn()
        {
            // Arrange
            var testValue = "TestValue879906968";

            // Act
            _testClass.TimeIn = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TimeIn);
        }

        [Fact]
        public void CanSetAndGetTimeOut()
        {
            // Arrange
            var testValue = "TestValue1169239072";

            // Act
            _testClass.TimeOut = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TimeOut);
        }

        [Fact]
        public void CanSetAndGetWorkTime()
        {
            // Arrange
            var testValue = "TestValue1588472033";

            // Act
            _testClass.WorkTime = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.WorkTime);
        }

        [Fact]
        public void CanSetAndGetOvertime()
        {
            // Arrange
            var testValue = "TestValue824199445";

            // Act
            _testClass.Overtime = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Overtime);
        }

        [Fact]
        public void CanSetAndGetStatus()
        {
            // Arrange
            var testValue = "TestValue983021029";

            // Act
            _testClass.Status = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Status);
        }
    }
}