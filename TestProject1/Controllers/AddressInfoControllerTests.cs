namespace TestProject1.Controllers
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
                Id = 1995892124,
                EmployeeCredentialId = 254034581,
                AddressLine1 = "TestValue849122059",
                AddressLine2 = "TestValue1347651918",
                City = "TestValue83582146",
                State = "TestValue452170215",
                Country = "TestValue24317047",
                PinCode = "TestValue48320530",
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 298156090,
                    UserName = "TestValue1155933994",
                    Password = "TestValue1153388373",
                    Status = (short)6360,
                    RequestedCompanyId = 196086714,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1540484309,
                        Name = "TestValue139735519",
                        PhoneNumber = "TestValue1922926182",
                        DomainName = "TestValue161058351",
                        Status = "TestValue2049637980",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 987407616,
                            Name = "TestValue1343689320",
                            RequestedCompanyId = 1616076971,
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

            _addressInfo.Setup(mock => mock.InsertAddressInfot(It.IsAny<AddressInfo>())).Returns("TestValue1516390997");

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
            var id = 141698972;

            _addressInfo.Setup(mock => mock.deleteAddressInfo(It.IsAny<int>())).Returns(true);

            // Act
            var result = _testClass.DeleteAddressInfo(id);

            // Assert
            _addressInfo.Verify(mock => mock.deleteAddressInfo(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}