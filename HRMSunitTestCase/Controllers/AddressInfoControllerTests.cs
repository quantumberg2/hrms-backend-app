namespace HRMSunitTestCase.Controllers
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
        private AddressInfoController _testClass;
        private Mock<IAddressInfo> _addressInfo;
        private Mock<ILogger<AddressInfoController>> _logger;

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
                Id = 744241382,
                EmployeeCredentialId = 610367684,
                AddressLine1 = "TestValue2123419013",
                AddressLine2 = "TestValue1161514708",
                City = "TestValue1236846703",
                State = "TestValue756233329",
                Country = "TestValue635753287",
                PinCode = "TestValue282742345",
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 409958266,
                    UserName = "TestValue1415857262",
                    Password = "TestValue1305610869",
                    Status = (short)10252,
                    RequestedCompanyId = 1701162570,
                    Email = "TestValue336203286",
                    DefaultPassword = false,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 2068371570,
                        Name = "TestValue1472003760",
                        PhoneNumber = "TestValue1212964884",
                        DomainName = "TestValue2031198132",
                        Status = "TestValue273809571",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue713678213",
                        Department = new Department
                        {
                            Id = 1836721459,
                            Name = "TestValue1431034461",
                            RequestedCompanyId = 1189723826,
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

            _addressInfo.Setup(mock => mock.InsertAddressInfot(It.IsAny<AddressInfo>())).Returns("TestValue394159202");

            // Act
            var result = _testClass.InsertAddressInfo(addresinfo);

            // Assert
            _addressInfo.Verify(mock => mock.InsertAddressInfot(It.IsAny<AddressInfo>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallDeleteAddressInfo()
        {
            // Arrange
            var id = 39499857;

            _addressInfo.Setup(mock => mock.deleteAddressInfo(It.IsAny<int>())).Returns(true);

            // Act
            var result = _testClass.DeleteAddressInfo(id);

            // Assert
            _addressInfo.Verify(mock => mock.deleteAddressInfo(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}