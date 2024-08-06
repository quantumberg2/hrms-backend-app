namespace HRMSunitTestCase.Models
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
            var testValue = 923310799;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetOccasion()
        {
            // Arrange
            var testValue = "TestValue2114996258";

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
            var testValue = "TestValue1750756397";

            // Act
            _testClass.Day = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Day);
        }

        [Fact]
        public void CanSetAndGetRestrictedHoliday()
        {
            // Arrange
            var testValue = false;

            // Act
            _testClass.RestrictedHoliday = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RestrictedHoliday);
        }

        [Fact]
        public void CanSetAndGetCompanyId()
        {
            // Arrange
            var testValue = 834912486;

            // Act
            _testClass.CompanyId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.CompanyId);
        }

        [Fact]
        public void CanSetAndGetEmployeecredentialId()
        {
            // Arrange
            var testValue = 2063814342;

            // Act
            _testClass.EmployeecredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeecredentialId);
        }

        [Fact]
        public void CanSetAndGetCompany()
        {
            // Arrange
            var testValue = new CompanyDetail
            {
                Id = 1529278112,
                Name = "TestValue1870757587",
                Address = "TestValue541720797",
                Country = "TestValue1240297431",
                States = "TestValue809606035",
                Industry = "TestValue2097174501",
                TimeZone = "TestValue1463839407",
                Currency = "TestValue547148698",
                PfNo = "TestValue1031355296",
                TanNo = "TestValue1189161047",
                EsiNo = "TestValue1359074769",
                PanNo = "TestValue535223430",
                GstNo = "TestValue1616653540",
                RegistrationNo = "TestValue9513341",
                Twitter = "TestValue1140514480",
                Facebook = "TestValue1848893613",
                LinkedIn = "TestValue2135744277",
                CompanyLogo = "TestValue414934722",
                RequestedCompanyId = 1847840612,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1544326769,
                    Name = "TestValue2051576723",
                    PhoneNumber = "TestValue1275994410",
                    DomainName = "TestValue492554988",
                    Status = "TestValue517196856",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1829398091",
                    Department = new Department
                    {
                        Id = 1958190657,
                        Name = "TestValue466086484",
                        RequestedCompanyId = 27832584,
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
        public void CanSetAndGetEmployeecredential()
        {
            // Arrange
            var testValue = new EmployeeCredential
            {
                Id = 607708798,
                UserName = "TestValue243596276",
                Password = "TestValue2147345141",
                Status = (short)10575,
                RequestedCompanyId = 1998452821,
                Email = "TestValue1582247057",
                DefaultPassword = true,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1134911052,
                    Name = "TestValue757740293",
                    PhoneNumber = "TestValue82651548",
                    DomainName = "TestValue1322267314",
                    Status = "TestValue953368608",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue597133127",
                    Department = new Department
                    {
                        Id = 1725654271,
                        Name = "TestValue1541677652",
                        RequestedCompanyId = 389432654,
                        RequestedCompany = default(RequestedCompanyForm),
                        EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                    },
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                AccountDetails = new Mock<ICollection<AccountDetail>>().Object,
                AddressInfos = new Mock<ICollection<AddressInfo>>().Object,
                EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                EmployeeAttendances = new Mock<ICollection<EmployeeAttendance>>().Object,
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                EmployeeLeaves = new Mock<ICollection<EmployeeLeave>>().Object,
                Holidays = new Mock<ICollection<Holiday>>().Object,
                LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
            };

            // Act
            _testClass.Employeecredential = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Employeecredential);
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