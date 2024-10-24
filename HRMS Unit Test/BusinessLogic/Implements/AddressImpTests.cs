namespace HRMS_Unit_Test.BusinessLogic.Implements
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public class AddressImpTests
    {
        private readonly AddressImp _testClass;
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
            var id = 1394012170;

            // Act
            var result = _testClass.deleteAddressInfo(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAddressInfoById()
        {
            // Arrange
            var id = 1037776991;

            // Act
            var result = _testClass.GetAddressInfoById(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAddressInfoByEmpCredId()
        {
            // Arrange
            var empCredId = 1603486236;

            // Act
            var result = _testClass.GetAddressInfoByEmpCredId(empCredId);

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
                Id = 93817432,
                EmployeeCredentialId = 1599711591,
                AddressLine1 = "TestValue1803993366",
                AddressLine2 = "TestValue963299217",
                City = "TestValue14754039",
                State = "TestValue1018885706",
                Country = "TestValue224639886",
                PinCode = "TestValue453236898",
                IsActive = (short)2483,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1949945657,
                    UserName = "TestValue1244133647",
                    Password = "TestValue647846752",
                    Status = (short)22918,
                    RequestedCompanyId = 115004150,
                    Email = "TestValue754347509",
                    DefaultPassword = false,
                    GenerateOtp = "TestValue931122408",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)9885,
                    EmployeeLoginName = "TestValue115098127",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1717249882,
                        Name = "TestValue1487358695",
                        PhoneNumber = "TestValue1285360215",
                        DomainName = "TestValue753526003",
                        Status = "TestValue421465373",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1726347170",
                        IsActive = (short)13814,
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
                    //DeviceTables = new Mock<ICollection<DeviceTable>>().Object,
                    EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                    EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
                    UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
                }
            };
            var empCredentialId = 45391479;

            // Act
            var result = _testClass.InsertAddressInfot(address, empCredentialId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 1703247345;
            var isActive = (short)1038;

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}