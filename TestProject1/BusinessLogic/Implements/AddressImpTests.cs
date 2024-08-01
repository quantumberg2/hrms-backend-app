namespace TestProject1.BusinessLogic.Implements
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
            var id = 603414235;

            // Act
            var result = _testClass.deleteAddressInfo(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAddressInfoById()
        {
            // Arrange
            var id = 1893177684;

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
                Id = 13103033,
                EmployeeCredentialId = 1434855299,
                AddressLine1 = "TestValue1140554981",
                AddressLine2 = "TestValue1040210894",
                City = "TestValue1783840277",
                State = "TestValue2073309884",
                Country = "TestValue919128197",
                PinCode = "TestValue1827600684",
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 476819325,
                    UserName = "TestValue460453272",
                    Password = "TestValue1840093422",
                    Status = (short)32119,
                    RequestedCompanyId = 1648309055,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1482554014,
                        Name = "TestValue1198527987",
                        PhoneNumber = "TestValue1458517926",
                        DomainName = "TestValue755217209",
                        Status = "TestValue457596375",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 1860514763,
                            Name = "TestValue1254542200",
                            RequestedCompanyId = 312275607,
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
                }
            };

            // Act
            var result = _testClass.InsertAddressInfot(address);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}