namespace TestProject1.Models
{
    using System;
    using System.Threading.Tasks;
    using HRMS_Application.Models;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public partial class HRMSContextTests
    {
        private class TestHRMSContext : HRMSContext
        {
            public TestHRMSContext() : base()
            {
            }

            public TestHRMSContext(DbContextOptions<HRMSContext> options) : base(options)
            {
            }

            public void PublicOnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }
        }

        private TestHRMSContext _testClass;
        private DbContextOptions<HRMSContext> _options;

        public HRMSContextTests()
        {
            _options = new DbContextOptions<HRMSContext>();
            _testClass = new TestHRMSContext(_options);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new TestHRMSContext();

            // Assert
            Assert.NotNull(instance);

            // Act
            instance = new TestHRMSContext(_options);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallSaveChangesAsync()
        {
            // Arrange
            var userId = 402565387;

            // Act
            var result = await _testClass.SaveChangesAsync(userId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallOnModelCreating()
        {
            // Arrange
            var modelBuilder = new ModelBuilder();

            // Act
            _testClass.PublicOnModelCreating(modelBuilder);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanSetAndGetAccountDetails()
        {
            // Arrange
            var testValue = new DbSet<AccountDetail>();

            // Act
            _testClass.AccountDetails = testValue;

            // Assert
            Assert.Same(testValue, _testClass.AccountDetails);
        }

        [Fact]
        public void CanSetAndGetAddressInfos()
        {
            // Arrange
            var testValue = new DbSet<AddressInfo>();

            // Act
            _testClass.AddressInfos = testValue;

            // Assert
            Assert.Same(testValue, _testClass.AddressInfos);
        }

        [Fact]
        public void CanSetAndGetAduits()
        {
            // Arrange
            var testValue = new DbSet<Aduit>();

            // Act
            _testClass.Aduits = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Aduits);
        }

        [Fact]
        public void CanSetAndGetCompanyDetails()
        {
            // Arrange
            var testValue = new DbSet<CompanyDetail>();

            // Act
            _testClass.CompanyDetails = testValue;

            // Assert
            Assert.Same(testValue, _testClass.CompanyDetails);
        }

        [Fact]
        public void CanSetAndGetDepartments()
        {
            // Arrange
            var testValue = new DbSet<Department>();

            // Act
            _testClass.Departments = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Departments);
        }

        [Fact]
        public void CanSetAndGetEmpPersonalInfos()
        {
            // Arrange
            var testValue = new DbSet<EmpPersonalInfo>();

            // Act
            _testClass.EmpPersonalInfos = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmpPersonalInfos);
        }

        [Fact]
        public void CanSetAndGetEmpSalaries()
        {
            // Arrange
            var testValue = new DbSet<EmpSalary>();

            // Act
            _testClass.EmpSalaries = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmpSalaries);
        }

        [Fact]
        public void CanSetAndGetEmployeeAttendances()
        {
            // Arrange
            var testValue = new DbSet<EmployeeAttendance>();

            // Act
            _testClass.EmployeeAttendances = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmployeeAttendances);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentials()
        {
            // Arrange
            var testValue = new DbSet<EmployeeCredential>();

            // Act
            _testClass.EmployeeCredentials = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmployeeCredentials);
        }

        [Fact]
        public void CanSetAndGetEmployeeDetails()
        {
            // Arrange
            var testValue = new DbSet<EmployeeDetail>();

            // Act
            _testClass.EmployeeDetails = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmployeeDetails);
        }

        [Fact]
        public void CanSetAndGetEmployeeLeaves()
        {
            // Arrange
            var testValue = new DbSet<EmployeeLeave>();

            // Act
            _testClass.EmployeeLeaves = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmployeeLeaves);
        }

        [Fact]
        public void CanSetAndGetHolidays()
        {
            // Arrange
            var testValue = new DbSet<Holiday>();

            // Act
            _testClass.Holidays = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Holidays);
        }

        [Fact]
        public void CanSetAndGetLeaveTypes()
        {
            // Arrange
            var testValue = new DbSet<LeaveType>();

            // Act
            _testClass.LeaveTypes = testValue;

            // Assert
            Assert.Same(testValue, _testClass.LeaveTypes);
        }

        [Fact]
        public void CanSetAndGetPositions()
        {
            // Arrange
            var testValue = new DbSet<Position>();

            // Act
            _testClass.Positions = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Positions);
        }

        [Fact]
        public void CanSetAndGetRequestedCompanyForms()
        {
            // Arrange
            var testValue = new DbSet<RequestedCompanyForm>();

            // Act
            _testClass.RequestedCompanyForms = testValue;

            // Assert
            Assert.Same(testValue, _testClass.RequestedCompanyForms);
        }

        [Fact]
        public void CanSetAndGetRoles()
        {
            // Arrange
            var testValue = new DbSet<Role>();

            // Act
            _testClass.Roles = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Roles);
        }

        [Fact]
        public void CanSetAndGetUserRolesJs()
        {
            // Arrange
            var testValue = new DbSet<UserRolesJ>();

            // Act
            _testClass.UserRolesJs = testValue;

            // Assert
            Assert.Same(testValue, _testClass.UserRolesJs);
        }
    }
}