namespace TestProject1.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class EmployeeLeaveTests
    {
        private EmployeeLeave _testClass;

        public EmployeeLeaveTests()
        {
            _testClass = new EmployeeLeave();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 1745995431;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 314888940;

            // Act
            _testClass.EmployeeCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeCredentialId);
        }

        [Fact]
        public void CanSetAndGetLeaveId()
        {
            // Arrange
            var testValue = 1495517650;

            // Act
            _testClass.LeaveId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LeaveId);
        }

        [Fact]
        public void CanSetAndGetStartDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.StartDate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.StartDate);
        }

        [Fact]
        public void CanSetAndGetEndDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.EndDate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EndDate);
        }

        [Fact]
        public void CanSetAndGetSession()
        {
            // Arrange
            var testValue = "TestValue1609127684";

            // Act
            _testClass.Session = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Session);
        }

        [Fact]
        public void CanSetAndGetTotalDays()
        {
            // Arrange
            var testValue = 1918954857;

            // Act
            _testClass.TotalDays = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TotalDays);
        }

        [Fact]
        public void CanSetAndGetContact()
        {
            // Arrange
            var testValue = "TestValue107352411";

            // Act
            _testClass.Contact = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Contact);
        }

        [Fact]
        public void CanSetAndGetReasonForLeave()
        {
            // Arrange
            var testValue = "TestValue2147389256";

            // Act
            _testClass.ReasonForLeave = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ReasonForLeave);
        }

        [Fact]
        public void CanSetAndGetFiles()
        {
            // Arrange
            var testValue = "TestValue1341586179";

            // Act
            _testClass.Files = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Files);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredential()
        {
            // Arrange
            var testValue = new EmployeeCredential
            {
                Id = 849509884,
                UserName = "TestValue2040881073",
                Password = "TestValue596305159",
                Status = (short)14890,
                RequestedCompanyId = 2118769470,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 2064879836,
                    Name = "TestValue163993647",
                    PhoneNumber = "TestValue1389014085",
                    DomainName = "TestValue1193346715",
                    Status = "TestValue214272617",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = new Department
                    {
                        Id = 2063730759,
                        Name = "TestValue1660497224",
                        RequestedCompanyId = 226936213,
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
        public void CanSetAndGetLeave()
        {
            // Arrange
            var testValue = new LeaveType
            {
                Id = 1643305251,
                LeaveType1 = "TestValue254298626",
                Days = 950109671,
                CompanyId = 1149982939,
                Company = new CompanyDetail
                {
                    Id = 528712001,
                    Name = "TestValue793962345",
                    Address = "TestValue169233158",
                    Country = "TestValue745186474",
                    States = "TestValue356049096",
                    Industry = "TestValue1068007597",
                    TimeZone = "TestValue555450976",
                    Currency = "TestValue976978218",
                    PfNo = "TestValue1038237688",
                    TanNo = "TestValue1056808380",
                    EsiNo = "TestValue396380341",
                    PanNo = "TestValue1802515751",
                    GstNo = "TestValue818290089",
                    RegistrationNo = "TestValue1685436540",
                    Twitter = "TestValue298056015",
                    Facebook = "TestValue1419539610",
                    LinkedIn = "TestValue305832179",
                    CompanyLogo = "TestValue934444223",
                    RequestedCompanyId = 1353100534,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1114494307,
                        Name = "TestValue638005898",
                        PhoneNumber = "TestValue1454562265",
                        DomainName = "TestValue2082964515",
                        Status = "TestValue205375806",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 1584403989,
                            Name = "TestValue1385506979",
                            RequestedCompanyId = 1970978021,
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