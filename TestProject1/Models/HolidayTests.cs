namespace TestProject1.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class HolidayTests
    {
        private Holiday _testClass;

        public HolidayTests()
        {
            _testClass = new Holiday();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new Holiday();

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 154823273;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetOccasion()
        {
            // Arrange
            var testValue = "TestValue742182658";

            // Act
            _testClass.Occasion = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Occasion);
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
        public void CanSetAndGetDay()
        {
            // Arrange
            var testValue = "TestValue2116950045";

            // Act
            _testClass.Day = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Day);
        }

        [Fact]
        public void CanSetAndGetRestrictedHoliday()
        {
            // Arrange
            var testValue = true;

            // Act
            _testClass.RestrictedHoliday = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RestrictedHoliday);
        }

        [Fact]
        public void CanSetAndGetCompanyId()
        {
            // Arrange
            var testValue = 1009998412;

            // Act
            _testClass.CompanyId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.CompanyId);
        }

        [Fact]
        public void CanSetAndGetCompany()
        {
            // Arrange
            var testValue = new CompanyDetail
            {
                Id = 354294013,
                Name = "TestValue1569965210",
                Address = "TestValue1330061270",
                Country = "TestValue1413711562",
                States = "TestValue1596447838",
                Industry = "TestValue835265187",
                TimeZone = "TestValue1991157523",
                Currency = "TestValue1494330501",
                PfNo = "TestValue1699607678",
                TanNo = "TestValue1290710045",
                EsiNo = "TestValue2007255564",
                PanNo = "TestValue958523480",
                GstNo = "TestValue1067224075",
                RegistrationNo = "TestValue530340314",
                Twitter = "TestValue2064609178",
                Facebook = "TestValue492823931",
                LinkedIn = "TestValue2017398205",
                CompanyLogo = "TestValue524815888",
                RequestedCompanyId = 1266240002,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 170289027,
                    Name = "TestValue434145763",
                    PhoneNumber = "TestValue363231465",
                    DomainName = "TestValue358594246",
                    Status = "TestValue830874817",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = new Department
                    {
                        Id = 681365590,
                        Name = "TestValue1071975704",
                        RequestedCompanyId = 1802281986,
                        RequestedCompany = default(RequestedCompanyForm),
                        EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                    },
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                Holidays = new Mock<ICollection<Holiday>>().Object,
                LeaveTypes = new Mock<ICollection<LeaveType>>().Object
            };

            // Act
            _testClass.Company = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Company);
        }

        [Fact]
        public void CanSetAndGetEmployeeAttendances()
        {
            // Arrange
            var testValue = new Mock<ICollection<EmployeeAttendance>>().Object;

            // Act
            _testClass.EmployeeAttendances = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmployeeAttendances);
        }
    }
}