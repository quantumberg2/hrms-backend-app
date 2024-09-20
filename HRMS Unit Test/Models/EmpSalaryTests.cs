namespace HRMS_Unit_Test.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class EmpSalaryTests
    {
        private readonly EmpSalary _testClass;

        public EmpSalaryTests()
        {
            _testClass = new EmpSalary();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 1375467494;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 897651715;

            // Act
            _testClass.EmployeeCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeCredentialId);
        }

        [Fact]
        public void CanSetAndGetSalaryRange()
        {
            // Arrange
            var testValue = "TestValue80124889";

            // Act
            _testClass.SalaryRange = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.SalaryRange);
        }

        [Fact]
        public void CanSetAndGetAnnualIncome()
        {
            // Arrange
            var testValue = 1820666072.61M;

            // Act
            _testClass.AnnualIncome = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AnnualIncome);
        }

        [Fact]
        public void CanSetAndGetLoan()
        {
            // Arrange
            var testValue = 927292386.24M;

            // Act
            _testClass.Loan = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Loan);
        }

        [Fact]
        public void CanSetAndGetInsurance()
        {
            // Arrange
            var testValue = 1330969789.71M;

            // Act
            _testClass.Insurance = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Insurance);
        }

        [Fact]
        public void CanSetAndGetIsActive()
        {
            // Arrange
            var testValue = (short)137;

            // Act
            _testClass.IsActive = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.IsActive);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredential()
        {
            // Arrange
            var testValue = new EmployeeCredential
            {
                Id = 1838180800,
                UserName = "TestValue816637058",
                Password = "TestValue1217993855",
                Status = (short)8138,
                RequestedCompanyId = 568553754,
                Email = "TestValue1517647956",
                DefaultPassword = true,
                GenerateOtp = "TestValue1525708603",
                OtpExpiration = DateTime.UtcNow,
                IsActive = (short)10341,
                EmployeeLoginName = "TestValue744826438",
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 2130352771,
                    Name = "TestValue566774540",
                    PhoneNumber = "TestValue665888824",
                    DomainName = "TestValue1878521386",
                    Status = "TestValue560691030",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1402436347",
                    IsActive = (short)5392,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                AccountDetails = new Mock<ICollection<AccountDetail>>().Object,
                AddressInfos = new Mock<ICollection<AddressInfo>>().Object,
                Attendances = new Mock<ICollection<Attendance>>().Object,
                DeviceTables = new Mock<ICollection<DeviceTable>>().Object,
                EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
                UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
            };

            // Act
            _testClass.EmployeeCredential = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmployeeCredential);
        }
    }
}