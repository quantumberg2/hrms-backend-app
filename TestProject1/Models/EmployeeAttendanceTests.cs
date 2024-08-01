namespace TestProject1.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class EmployeeAttendanceTests
    {
        private EmployeeAttendance _testClass;

        public EmployeeAttendanceTests()
        {
            _testClass = new EmployeeAttendance();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 461248824;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 1306581593;

            // Act
            _testClass.EmployeeCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeCredentialId);
        }

        [Fact]
        public void CanSetAndGetLeaveId()
        {
            // Arrange
            var testValue = 1114495021;

            // Act
            _testClass.LeaveId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LeaveId);
        }

        [Fact]
        public void CanSetAndGetHolidayId()
        {
            // Arrange
            var testValue = 1310756104;

            // Act
            _testClass.HolidayId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.HolidayId);
        }

        [Fact]
        public void CanSetAndGetTimeIn()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.TimeIn = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TimeIn);
        }

        [Fact]
        public void CanSetAndGetTimeOut()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.TimeOut = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TimeOut);
        }

        [Fact]
        public void CanSetAndGetRemarks()
        {
            // Arrange
            var testValue = "TestValue563832505";

            // Act
            _testClass.Remarks = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Remarks);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredential()
        {
            // Arrange
            var testValue = new EmployeeCredential
            {
                Id = 238400901,
                UserName = "TestValue1944305532",
                Password = "TestValue1286032838",
                Status = (short)21391,
                RequestedCompanyId = 1557110971,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 308809617,
                    Name = "TestValue1705738465",
                    PhoneNumber = "TestValue632379446",
                    DomainName = "TestValue1685408189",
                    Status = "TestValue858710404",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = new Department
                    {
                        Id = 1014558233,
                        Name = "TestValue1694664964",
                        RequestedCompanyId = 1784487971,
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
                UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
            };

            // Act
            _testClass.EmployeeCredential = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmployeeCredential);
        }

        [Fact]
        public void CanSetAndGetHoliday()
        {
            // Arrange
            var testValue = new Holiday
            {
                Id = 666768473,
                Occasion = "TestValue1030571652",
                Date = DateTime.UtcNow,
                Day = "TestValue306971755",
                RestrictedHoliday = true,
                CompanyId = 98229468,
                Company = new CompanyDetail
                {
                    Id = 1742257409,
                    Name = "TestValue1475786748",
                    Address = "TestValue782129766",
                    Country = "TestValue231572869",
                    States = "TestValue20053888",
                    Industry = "TestValue1458767703",
                    TimeZone = "TestValue1255317114",
                    Currency = "TestValue1656897225",
                    PfNo = "TestValue1129293211",
                    TanNo = "TestValue1781844674",
                    EsiNo = "TestValue1271943667",
                    PanNo = "TestValue122084985",
                    GstNo = "TestValue1405322545",
                    RegistrationNo = "TestValue1181035",
                    Twitter = "TestValue588875749",
                    Facebook = "TestValue1619526973",
                    LinkedIn = "TestValue1690064749",
                    CompanyLogo = "TestValue343361908",
                    RequestedCompanyId = 2147262129,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 874281034,
                        Name = "TestValue1564276264",
                        PhoneNumber = "TestValue892639208",
                        DomainName = "TestValue1139989697",
                        Status = "TestValue1434161822",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 76714494,
                            Name = "TestValue250727680",
                            RequestedCompanyId = 322760138,
                            RequestedCompany = default(RequestedCompanyForm),
                            EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                        },
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object
                },
                EmployeeAttendances = new Mock<ICollection<EmployeeAttendance>>().Object
            };

            // Act
            _testClass.Holiday = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Holiday);
        }

        [Fact]
        public void CanSetAndGetLeave()
        {
            // Arrange
            var testValue = new LeaveType
            {
                Id = 1093423382,
                LeaveType1 = "TestValue1281233282",
                Days = 1109724409,
                CompanyId = 1475063876,
                Company = new CompanyDetail
                {
                    Id = 130000582,
                    Name = "TestValue1951189020",
                    Address = "TestValue1208352125",
                    Country = "TestValue1519721259",
                    States = "TestValue1982453003",
                    Industry = "TestValue1929186386",
                    TimeZone = "TestValue6828032",
                    Currency = "TestValue1924251644",
                    PfNo = "TestValue1974748782",
                    TanNo = "TestValue146623089",
                    EsiNo = "TestValue2047697393",
                    PanNo = "TestValue1327000053",
                    GstNo = "TestValue2071377438",
                    RegistrationNo = "TestValue1507919426",
                    Twitter = "TestValue1563323204",
                    Facebook = "TestValue1600871506",
                    LinkedIn = "TestValue1013377198",
                    CompanyLogo = "TestValue1105789215",
                    RequestedCompanyId = 164960998,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1124187371,
                        Name = "TestValue687209744",
                        PhoneNumber = "TestValue307193273",
                        DomainName = "TestValue1930746064",
                        Status = "TestValue681436851",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 849618201,
                            Name = "TestValue335797051",
                            RequestedCompanyId = 1495451591,
                            RequestedCompany = default(RequestedCompanyForm),
                            EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                        },
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object
                },
                EmployeeAttendances = new Mock<ICollection<EmployeeAttendance>>().Object,
                EmployeeLeaves = new Mock<ICollection<EmployeeLeave>>().Object
            };

            // Act
            _testClass.Leave = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Leave);
        }
    }
}