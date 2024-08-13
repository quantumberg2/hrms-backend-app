namespace HRMSunitTestCase.Models
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
            var testValue = 813167858;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetDeptId()
        {
            // Arrange
            var testValue = 1112193440;

            // Act
            _testClass.DeptId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.DeptId);
        }

       /* [Fact]
        public void CanSetAndGetMobileNumber()
        {
            // Arrange
            var testValue = "TestValue758993212";

            // Act
            _testClass.MobileNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.MobileNumber);
        }*/

        [Fact]
        public void CanSetAndGetFirstName()
        {
            // Arrange
            var testValue = "TestValue2036380144";

            // Act
            _testClass.FirstName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.FirstName);
        }

        [Fact]
        public void CanSetAndGetMiddleName()
        {
            // Arrange
            var testValue = "TestValue1988117026";

            // Act
            _testClass.MiddleName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.MiddleName);
        }

        [Fact]
        public void CanSetAndGetLastName()
        {
            // Arrange
            var testValue = "TestValue1196812668";

            // Act
            _testClass.LastName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LastName);
        }

        [Fact]
        public void CanSetAndGetPositionId()
        {
            // Arrange
            var testValue = 451996322;

            // Act
            _testClass.PositionId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PositionId);
        }

       /* [Fact]
        public void CanSetAndGetNickName()
        {
            // Arrange
            var testValue = "TestValue1805759840";

            // Act
            _testClass.NickName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.NickName);
        }
*/
       /* [Fact]
        public void CanSetAndGetGender()
        {
            // Arrange
            var testValue = "TestValue11217894";

            // Act
            _testClass.Gender = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Gender);
        }*/

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 819486479;

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
                Id = 1788836679,
                Name = "TestValue674384543",
                RequestedCompanyId = 745658657,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 230663617,
                    Name = "TestValue687271822",
                    PhoneNumber = "TestValue55926890",
                    DomainName = "TestValue1591482368",
                    Status = "TestValue818652605",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue76833895",
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
                Id = 2015304318,
                UserName = "TestValue1528168880",
                Password = "TestValue861361055",
                Status = (short)29436,
                RequestedCompanyId = 241360090,
                Email = "TestValue304542567",
                DefaultPassword = false,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 93748302,
                    Name = "TestValue77768242",
                    PhoneNumber = "TestValue1976525560",
                    DomainName = "TestValue1549515918",
                    Status = "TestValue1804925220",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1450474255",
                    Department = new Department
                    {
                        Id = 131039055,
                        Name = "TestValue1337214750",
                        RequestedCompanyId = 1258525007,
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
                Id = 1322876702,
                Name = "TestValue532448037",
                RequestedCompanyId = 930906143,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1997034587,
                    Name = "TestValue644476535",
                    PhoneNumber = "TestValue1832676841",
                    DomainName = "TestValue541762459",
                    Status = "TestValue1580535725",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1510033342",
                    Department = new Department
                    {
                        Id = 1592008776,
                        Name = "TestValue1722992526",
                        RequestedCompanyId = 151430198,
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