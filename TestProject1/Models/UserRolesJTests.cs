namespace TestProject1.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class UserRolesJTests
    {
        private UserRolesJ _testClass;

        public UserRolesJTests()
        {
            _testClass = new UserRolesJ();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 369629087;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetRoleId()
        {
            // Arrange
            var testValue = 1441221751;

            // Act
            _testClass.RoleId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RoleId);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 167908719;

            // Act
            _testClass.EmployeeCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeCredentialId);
        }

        [Fact]
        public void CanSetAndGetRolesId()
        {
            // Arrange
            var testValue = 322352503;

            // Act
            _testClass.RolesId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RolesId);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredential()
        {
            // Arrange
            var testValue = new EmployeeCredential
            {
                Id = 1180537401,
                UserName = "TestValue1349141435",
                Password = "TestValue477767228",
                Status = (short)23803,
                RequestedCompanyId = 1648505164,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1840145252,
                    Name = "TestValue847114641",
                    PhoneNumber = "TestValue2027683851",
                    DomainName = "TestValue87000597",
                    Status = "TestValue2057984273",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = new Department
                    {
                        Id = 1523901760,
                        Name = "TestValue1041698236",
                        RequestedCompanyId = 435301034,
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
        public void CanSetAndGetRoles()
        {
            // Arrange
            var testValue = new Role
            {
                Id = 539670892,
                Name = "TestValue431609796",
                UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
            };

            // Act
            _testClass.Roles = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Roles);
        }
    }
}