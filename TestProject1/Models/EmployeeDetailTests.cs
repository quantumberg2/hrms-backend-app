namespace TestProject1.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class EmployeeDetailTests
    {
        private EmployeeDetail _testClass;

        public EmployeeDetailTests()
        {
            _testClass = new EmployeeDetail();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 1831267060;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetDeptId()
        {
            // Arrange
            var testValue = 559152122;

            // Act
            _testClass.DeptId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.DeptId);
        }

        [Fact]
        public void CanSetAndGetMobileNumber()
        {
            // Arrange
            var testValue = "TestValue1481255777";

            // Act
            _testClass.MobileNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.MobileNumber);
        }

        [Fact]
        public void CanSetAndGetFirstName()
        {
            // Arrange
            var testValue = "TestValue742928588";

            // Act
            _testClass.FirstName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.FirstName);
        }

        [Fact]
        public void CanSetAndGetMiddleName()
        {
            // Arrange
            var testValue = "TestValue2139512715";

            // Act
            _testClass.MiddleName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.MiddleName);
        }

        [Fact]
        public void CanSetAndGetLastName()
        {
            // Arrange
            var testValue = "TestValue405691551";

            // Act
            _testClass.LastName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LastName);
        }

        [Fact]
        public void CanSetAndGetPositionId()
        {
            // Arrange
            var testValue = 1598982913;

            // Act
            _testClass.PositionId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PositionId);
        }

        [Fact]
        public void CanSetAndGetNickName()
        {
            // Arrange
            var testValue = "TestValue1707749702";

            // Act
            _testClass.NickName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.NickName);
        }

        [Fact]
        public void CanSetAndGetGender()
        {
            // Arrange
            var testValue = "TestValue1563414992";

            // Act
            _testClass.Gender = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Gender);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 1540922382;

            // Act
            _testClass.EmployeeCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeCredentialId);
        }

        [Fact]
        public void CanSetAndGetDept()
        {
            // Arrange
            var testValue = new Department
            {
                Id = 1072432812,
                Name = "TestValue1783234992",
                RequestedCompanyId = 641651873,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 544586384,
                    Name = "TestValue667238299",
                    PhoneNumber = "TestValue1835611030",
                    DomainName = "TestValue964838484",
                    Status = "TestValue1509540941",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = default(Department),
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
            };

            // Act
            _testClass.Dept = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Dept);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredential()
        {
            // Arrange
            var testValue = new EmployeeCredential
            {
                Id = 1533607659,
                UserName = "TestValue379471160",
                Password = "TestValue1012009247",
                Status = (short)5462,
                RequestedCompanyId = 1035455402,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1159600239,
                    Name = "TestValue1957953439",
                    PhoneNumber = "TestValue265158144",
                    DomainName = "TestValue1273399487",
                    Status = "TestValue98186327",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = new Department
                    {
                        Id = 1194324212,
                        Name = "TestValue947006936",
                        RequestedCompanyId = 1733845940,
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
        public void CanSetAndGetPosition()
        {
            // Arrange
            var testValue = new Position
            {
                Id = 425593410,
                Name = "TestValue1244632381",
                RequestedCompanyId = 1218014619,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1904650888,
                    Name = "TestValue1708947358",
                    PhoneNumber = "TestValue800907796",
                    DomainName = "TestValue460159531",
                    Status = "TestValue1172828912",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = new Department
                    {
                        Id = 878287495,
                        Name = "TestValue1815685526",
                        RequestedCompanyId = 2008943140,
                        RequestedCompany = default(RequestedCompanyForm),
                        EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                    },
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
            };

            // Act
            _testClass.Position = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Position);
        }
    }
}