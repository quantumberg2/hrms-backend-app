namespace TestProject1.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class LeaveTypeTests
    {
        private LeaveType _testClass;

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
            var testValue = 1180466848;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetLeaveType1()
        {
            // Arrange
            var testValue = "TestValue282906679";

            // Act
            _testClass.LeaveType1 = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LeaveType1);
        }

        [Fact]
        public void CanSetAndGetDays()
        {
            // Arrange
            var testValue = 1091765114;

            // Act
            _testClass.Days = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Days);
        }

        [Fact]
        public void CanSetAndGetCompanyId()
        {
            // Arrange
            var testValue = 56742153;

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
                Id = 1159531225,
                Name = "TestValue1952266763",
                Address = "TestValue1427748476",
                Country = "TestValue1409558276",
                States = "TestValue504842379",
                Industry = "TestValue736576994",
                TimeZone = "TestValue231412807",
                Currency = "TestValue2040504338",
                PfNo = "TestValue1462273298",
                TanNo = "TestValue188951370",
                EsiNo = "TestValue117329503",
                PanNo = "TestValue632602742",
                GstNo = "TestValue2139216766",
                RegistrationNo = "TestValue1174954626",
                Twitter = "TestValue774540122",
                Facebook = "TestValue1983548933",
                LinkedIn = "TestValue258114198",
                CompanyLogo = "TestValue276467097",
                RequestedCompanyId = 1952295406,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 854428900,
                    Name = "TestValue1357956810",
                    PhoneNumber = "TestValue2061295697",
                    DomainName = "TestValue1351762405",
                    Status = "TestValue1919914386",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = new Department
                    {
                        Id = 1229296797,
                        Name = "TestValue34435387",
                        RequestedCompanyId = 116661220,
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

        [Fact]
        public void CanSetAndGetEmployeeLeaves()
        {
            // Arrange
            var testValue = new Mock<ICollection<EmployeeLeave>>().Object;

            // Act
            _testClass.EmployeeLeaves = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmployeeLeaves);
        }
    }
}