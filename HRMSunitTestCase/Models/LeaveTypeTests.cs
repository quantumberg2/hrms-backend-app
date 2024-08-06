namespace HRMSunitTestCase.Models
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
            var testValue = 1308609951;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetLeaveType1()
        {
            // Arrange
            var testValue = "TestValue1786214372";

            // Act
            _testClass.LeaveType1 = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LeaveType1);
        }

        [Fact]
        public void CanSetAndGetDays()
        {
            // Arrange
            var testValue = 753918632;

            // Act
            _testClass.Days = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Days);
        }

        [Fact]
        public void CanSetAndGetCompanyId()
        {
            // Arrange
            var testValue = 1347616748;

            // Act
            _testClass.CompanyId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.CompanyId);
        }

        [Fact]
        public void CanSetAndGetEmployeecredentialId()
        {
            // Arrange
            var testValue = 639456996;

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
                Id = 1258316825,
                Name = "TestValue914144078",
                Address = "TestValue1026799273",
                Country = "TestValue176019303",
                States = "TestValue130747513",
                Industry = "TestValue73642899",
                TimeZone = "TestValue95670620",
                Currency = "TestValue1866216454",
                PfNo = "TestValue490875722",
                TanNo = "TestValue1833798815",
                EsiNo = "TestValue518966944",
                PanNo = "TestValue1275080265",
                GstNo = "TestValue812782347",
                RegistrationNo = "TestValue1671555977",
                Twitter = "TestValue2136742576",
                Facebook = "TestValue1209330946",
                LinkedIn = "TestValue1589796970",
                CompanyLogo = "TestValue553631935",
                RequestedCompanyId = 523414725,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 377776087,
                    Name = "TestValue586126574",
                    PhoneNumber = "TestValue123870799",
                    DomainName = "TestValue611880692",
                    Status = "TestValue426314288",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue248894975",
                    Department = new Department
                    {
                        Id = 357936968,
                        Name = "TestValue1381340521",
                        RequestedCompanyId = 916782766,
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
                Id = 1572191413,
                UserName = "TestValue1786067338",
                Password = "TestValue687191726",
                Status = (short)17209,
                RequestedCompanyId = 902989233,
                Email = "TestValue719768245",
                DefaultPassword = false,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 95496018,
                    Name = "TestValue1542441445",
                    PhoneNumber = "TestValue1817674197",
                    DomainName = "TestValue1402544099",
                    Status = "TestValue190701396",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue715852846",
                    Department = new Department
                    {
                        Id = 361138885,
                        Name = "TestValue69507735",
                        RequestedCompanyId = 1883694270,
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