namespace HRMSunitTestCase.BusinessLogic.Implements
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public class AddressImpTests
    {
        private AddressImp _testClass;
        private HRMSContext _context;

        public AddressImpTests()
        {
            _context = new HRMSContext();
            _testClass = new AddressImp(_context);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new AddressImp(_context);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCalldeleteAddressInfo()
        {
            // Arrange
            var id = 802745725;

            // Act
            var result = _testClass.deleteAddressInfo(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAddressInfoById()
        {
            // Arrange
            var id = 792279175;

            // Act
            var result = _testClass.GetAddressInfoById(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAllAddressInfo()
        {
            // Act
            var result = _testClass.GetAllAddressInfo();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallInsertAddressInfot()
        {
            // Arrange
            var address = new AddressInfo
            {
                Id = 2102185334,
                EmployeeCredentialId = 247661448,
                AddressLine1 = "TestValue1969316805",
                AddressLine2 = "TestValue1434762887",
                City = "TestValue547199881",
                State = "TestValue932232119",
                Country = "TestValue2072319944",
                PinCode = "TestValue792108796",
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1540316959,
                    UserName = "TestValue544360648",
                    Password = "TestValue382918323",
                    Status = (short)20508,
                    RequestedCompanyId = 1600323604,
                    Email = "TestValue731144705",
                    DefaultPassword = false,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1109642723,
                        Name = "TestValue328422397",
                        PhoneNumber = "TestValue570184235",
                        DomainName = "TestValue628046617",
                        Status = "TestValue736628317",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue2001560613",
                        Department = new Department
                        {
                            Id = 1386218620,
                            Name = "TestValue758249070",
                            RequestedCompanyId = 626548208,
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
                }
            };

            // Act
            var result = _testClass.InsertAddressInfot(address);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}