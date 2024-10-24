//namespace HRMS_Unit_Test.Controllers
//{
//    using System;
//    using System.Collections.Generic;
//    using HRMS_Application.BusinessLogic.Interface;
//    using HRMS_Application.Controllers;
//    using HRMS_Application.Models;
//    using Microsoft.Extensions.Logging;
//    using Moq;
//    using Xunit;

//    public class DeviceOpearationsControllerTests
//    {
//        private readonly DeviceOpearationsController _testClass;
//        private readonly Mock<ILogger<DeviceOpearationsController>> _logger;
//        private readonly Mock<IDeviceOperations> _deviceOperations;

//        public DeviceOpearationsControllerTests()
//        {
//            _logger = new Mock<ILogger<DeviceOpearationsController>>();
//            _deviceOperations = new Mock<IDeviceOperations>();
//            _testClass = new DeviceOpearationsController(_logger.Object, _deviceOperations.Object);
//        }

//        [Fact]
//        public void CanConstruct()
//        {
//            // Act
//            var instance = new DeviceOpearationsController(_logger.Object, _deviceOperations.Object);

//            // Assert
//            Assert.NotNull(instance);
//        }

//        [Fact]
//        public void CanCallGetAllInfo()
//        {
//            // Arrange
//            _deviceOperations.Setup(mock => mock.GetAllInfo()).Returns(new List<DeviceTable>());

//            // Act
//            var result = _testClass.GetAllInfo();

//            // Assert
//            _deviceOperations.Verify(mock => mock.GetAllInfo());

//            throw new NotImplementedException("Create or modify test");
//        }

//        [Fact]
//        public void CanCallGetByEmpCreId()
//        {
//            // Arrange
//            var empCredId = 86219475;

//            _deviceOperations.Setup(mock => mock.GetByEmpCreId(It.IsAny<int>())).Returns(new List<DeviceTable>());

//            // Act
//            var result = _testClass.GetByEmpCreId(empCredId);

//            // Assert
//            _deviceOperations.Verify(mock => mock.GetByEmpCreId(It.IsAny<int>()));

//            throw new NotImplementedException("Create or modify test");
//        }

//        [Fact]
//        public void CanCallInsertInfo()
//        {
//            // Arrange
//            var deviceInfo = new DeviceTable
//            {
//                Id = 1250450503,
//                //EmpCredentialId = 1872659673,
//                TimeIn = DateTime.UtcNow,
//                TimeOut = DateTime.UtcNow,
//                InsertedDate = DateTime.UtcNow,
//                WorkTime = DateTime.UtcNow,
//                OverTime = DateTime.UtcNow,
//                Remark = "TestValue1509620676",
//                ErlOut = DateTime.UtcNow,
//                LateIn = DateTime.UtcNow,
//                Name = "TestValue1717074945",
//                Status = "TestValue694421890",
//                IsActive = (short)417,
//                //EmpCredential = new EmployeeCredential
//                //{
//                //    Id = 1779362275,
//                //    UserName = "TestValue1672539002",
//                //    Password = "TestValue1618683521",
//                 //   Status = (short)31858,
//                //    RequestedCompanyId = 862321360,
//                //    Email = "TestValue744695425",
//                //   DefaultPassword = true,
//                 //   GenerateOtp = "TestValue1118301292",
//                //    OtpExpiration = DateTime.UtcNow,
//               //     IsActive = (short)15794,
//                //    EmployeeLoginName = "TestValue953980191",
//                //    RequestedCompany = new RequestedCompanyForm
//            //        {
//            //            Id = 1429063492,
//            //            Name = "TestValue1328965957",
//            //            PhoneNumber = "TestValue104465974",
//            //            DomainName = "TestValue253383553",
//            //            Status = "TestValue390458676",
//            //            InsertedDate = DateTime.UtcNow,
//            //            UpdatedDate = DateTime.UtcNow,
//            //            Email = "TestValue1690064109",
//            //            IsActive = (short)22310,
//            //            CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
//            //            Departments = new Mock<ICollection<Department>>().Object,
//            //            EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
//            //            Holidays = new Mock<ICollection<Holiday>>().Object,
//            //            LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
//            //            Positions = new Mock<ICollection<Position>>().Object
//            //        },
//            //        AccountDetails = new Mock<ICollection<AccountDetail>>().Object,
//            //        AddressInfos = new Mock<ICollection<AddressInfo>>().Object,
//            //        Attendances = new Mock<ICollection<Attendance>>().Object,
//            //        //DeviceTables = new Mock<ICollection<DeviceTable>>().Object,
//            //        EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
//            //        EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
//            //        EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
//            //        EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
//            //        LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
//            //        UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
//            //    }
//            //};

//            //_deviceOperations.Setup(mock => mock.InsertInfo(It.IsAny<DeviceTable>())).Returns("TestValue1997774997");

//            //// Act
//            //var result = _testClass.InsertInfo(deviceInfo);

//            //// Assert
//            //_deviceOperations.Verify(mock => mock.InsertInfo(It.IsAny<DeviceTable>()));

//            //throw new NotImplementedException("Create or modify test");
//        }

//       // [Fact]
//        public void CanCallUpdateInfo()
//        {
//            // Arrange
//            var deviceInfo = new DeviceTable
//            {
//                Id = 686369928,
//                //EmpCredentialId = 860324050,
//                TimeIn = DateTime.UtcNow,
//                TimeOut = DateTime.UtcNow,
//                InsertedDate = DateTime.UtcNow,
//                WorkTime = DateTime.UtcNow,
//                OverTime = DateTime.UtcNow,
//                Remark = "TestValue828063704",
//                ErlOut = DateTime.UtcNow,
//                LateIn = DateTime.UtcNow,
//                Name = "TestValue899687352",
//                Status = "TestValue1898101392",
//                IsActive = (short)24669,
//                EmpCredential = new EmployeeCredential
//                {
//                    Id = 517317868,
//                    UserName = "TestValue2011602558",
//                    Password = "TestValue1940749333",
//                    Status = (short)9825,
//                    RequestedCompanyId = 492923424,
//                    Email = "TestValue1618833972",
//                    DefaultPassword = false,
//                    GenerateOtp = "TestValue1976074095",
//                    OtpExpiration = DateTime.UtcNow,
//                    IsActive = (short)19428,
//                    EmployeeLoginName = "TestValue716453361",
//                    RequestedCompany = new RequestedCompanyForm
//                    {
//                        Id = 1375966906,
//                        Name = "TestValue25890586",
//                        PhoneNumber = "TestValue1195504950",
//                        DomainName = "TestValue472746715",
//                        Status = "TestValue2138769766",
//                        InsertedDate = DateTime.UtcNow,
//                        UpdatedDate = DateTime.UtcNow,
//                        Email = "TestValue987682344",
//                        IsActive = (short)25100,
//                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
//                        Departments = new Mock<ICollection<Department>>().Object,
//                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
//                        Holidays = new Mock<ICollection<Holiday>>().Object,
//                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
//                        Positions = new Mock<ICollection<Position>>().Object
//                    },
//                    AccountDetails = new Mock<ICollection<AccountDetail>>().Object,
//                    AddressInfos = new Mock<ICollection<AddressInfo>>().Object,
//                    Attendances = new Mock<ICollection<Attendance>>().Object,
//                    //DeviceTables = new Mock<ICollection<DeviceTable>>().Object,
//                    EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
//                    EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
//                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
//                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
//                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
//                    UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
//                }
//            };

//            _deviceOperations.Setup(mock => mock.UpdateInfo(It.IsAny<DeviceTable>())).Returns("TestValue246783787");

//            // Act
//            var result = _testClass.UpdateInfo(deviceInfo);

//            // Assert
//            _deviceOperations.Verify(mock => mock.UpdateInfo(It.IsAny<DeviceTable>()));

//            throw new NotImplementedException("Create or modify test");
//        }

//        [Fact]
//        public void CanCallDeleteInfo()
//        {
//            // Arrange
//            var id = 1180384316;

//            _deviceOperations.Setup(mock => mock.DeleteInfo(It.IsAny<int>())).Returns(true);

//            // Act
//            var result = _testClass.DeleteInfo(id);

//            // Assert
//            _deviceOperations.Verify(mock => mock.DeleteInfo(It.IsAny<int>()));

//            throw new NotImplementedException("Create or modify test");
//        }
//    }
//}