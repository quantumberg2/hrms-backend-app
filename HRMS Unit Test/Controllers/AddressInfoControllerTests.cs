namespace HRMS_Unit_Test.Controllers
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.Controllers;
    using HRMS_Application.Models;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class AddressInfoControllerTests
    {
        private readonly AddressInfoController _testClass;
        private readonly Mock<IAddressInfo> _addressInfo;
        private readonly Mock<ILogger<AddressInfoController>> _logger;

        public AddressInfoControllerTests()
        {
            _addressInfo = new Mock<IAddressInfo>();
            _logger = new Mock<ILogger<AddressInfoController>>();
            _testClass = new AddressInfoController(_addressInfo.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new AddressInfoController(_addressInfo.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllAddressInfo()
        {
            // Arrange
            _addressInfo.Setup(mock => mock.GetAllAddressInfo()).Returns(new List<AddressInfo>());

            // Act
            var result = _testClass.GetAllAddressInfo();

            // Assert
            _addressInfo.Verify(mock => mock.GetAllAddressInfo());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallInsertAddressInfo()
        {
            // Arrange
            var addresinfo = new AddressInfo
            {
                Id = 1073674243,
                EmployeeCredentialId = 1796328223,
                AddressLine1 = "TestValue231301317",
                AddressLine2 = "TestValue1861585602",
                City = "TestValue1497544206",
                State = "TestValue988460627",
                Country = "TestValue1753537618",
                PinCode = "TestValue1990654590",
                IsActive = (short)31236,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 127347221,
                    UserName = "TestValue794235563",
                    Password = "TestValue633525628",
                    Status = (short)10732,
                    RequestedCompanyId = 476283762,
                    Email = "TestValue297925581",
                    DefaultPassword = false,
                    GenerateOtp = "TestValue1596081949",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)30168,
                    EmployeeLoginName = "TestValue218029018",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1830423797,
                        Name = "TestValue559405852",
                        PhoneNumber = "TestValue1066244917",
                        DomainName = "TestValue424037101",
                        Status = "TestValue1925596144",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue39919076",
                        IsActive = (short)32563,
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
                }
            };
            var empCredentialId = 616814158;

            _addressInfo.Setup(mock => mock.InsertAddressInfot(It.IsAny<AddressInfo>(), It.IsAny<int>())).Returns("TestValue721351425");

            // Act
            var result = _testClass.InsertAddressInfo(addresinfo, empCredentialId);

            // Assert
            _addressInfo.Verify(mock => mock.InsertAddressInfot(It.IsAny<AddressInfo>(), It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallDeleteAddressInfo()
        {
            // Arrange
            var id = 1231556047;

            _addressInfo.Setup(mock => mock.deleteAddressInfo(It.IsAny<int>())).Returns(true);

            // Act
            var result = _testClass.DeleteAddressInfo(id);

            // Assert
            _addressInfo.Verify(mock => mock.deleteAddressInfo(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 1882173265;
            var isActive = (short)5262;

            _addressInfo.Setup(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>())).Returns(true);

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            _addressInfo.Verify(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}