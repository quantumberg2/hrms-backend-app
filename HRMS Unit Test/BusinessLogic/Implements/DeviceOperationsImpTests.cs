namespace HRMS_Unit_Test.BusinessLogic.Implements
{
    using System;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.Models;
    using Xunit;

    public class DeviceOperationsImpTests
    {
        private readonly DeviceOperationsImp _testClass;
        private HRMSContext _context;

        public DeviceOperationsImpTests()
        {
            _context = new HRMSContext();
            _testClass = new DeviceOperationsImp(_context);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new DeviceOperationsImp(_context);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllInfo()
        {
            // Act
            var result = _testClass.GetAllInfo();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetByEmpCreId()
        {
            // Arrange
            var empCredId = 1432013585;

            // Act
            var result = _testClass.GetByEmpCreId(empCredId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallInsertInfo()
        {
            // Arrange
            var deviceInfo = new DeviceTable
            {
                Id = 1077205121,
                EmpCode = 183012333,
                TimeIn = DateTime.UtcNow,
                TimeOut = DateTime.UtcNow,
                InsertedDate = DateTime.UtcNow,
                WorkTime = DateTime.UtcNow,
                OverTime = DateTime.UtcNow,
                Remark = "TestValue1583753403",
                ErlOut = DateTime.UtcNow,
                LateIn = DateTime.UtcNow,
                Name = "TestValue443670877",
                Status = "TestValue1231103648",
                IsActive = (short)27978
            };

            // Act
            var result = _testClass.InsertInfo(deviceInfo);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallUpdateInfo()
        {
            // Arrange
            var deviceInfo = new DeviceTable
            {
                Id = 1927147359,
                EmpCode = 1349195724,
                TimeIn = DateTime.UtcNow,
                TimeOut = DateTime.UtcNow,
                InsertedDate = DateTime.UtcNow,
                WorkTime = DateTime.UtcNow,
                OverTime = DateTime.UtcNow,
                Remark = "TestValue26464771",
                ErlOut = DateTime.UtcNow,
                LateIn = DateTime.UtcNow,
                Name = "TestValue1927643278",
                Status = "TestValue1864485979",
                IsActive = (short)25841
            };

            // Act
            var result = _testClass.UpdateInfo(deviceInfo);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallDeleteInfo()
        {
            // Arrange
            var id = 1911179226;

            // Act
            var result = _testClass.DeleteInfo(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}
//namespace HRMS_Unit_Test.BusinessLogic.Implements
//{
//    using System;
//    using System.Collections.Generic;
//    using HRMS_Application.BusinessLogic.Implements;
//    using HRMS_Application.Models;
//    using Moq;
//    using Xunit;

//    public class DeviceOperationsImpTests
//    {
//        private readonly DeviceOperationsImp _testClass;
//        private HRMSContext _context;

//        public DeviceOperationsImpTests()
//        {
//            _context = new HRMSContext();
//            _testClass = new DeviceOperationsImp(_context);
//        }

//        [Fact]
//        public void CanConstruct()
//        {
//            // Act
//            var instance = new DeviceOperationsImp(_context);

//            // Assert
//            Assert.NotNull(instance);
//        }

//        [Fact]
//        public void CanCallGetAllInfo()
//        {
//            // Act
//            var result = _testClass.GetAllInfo();

//            // Assert
//            throw new NotImplementedException("Create or modify test");
//        }

//        [Fact]
//        public void CanCallGetByEmpCreId()
//        {
//            // Arrange
//            var empCredId = 430235671;

//            // Act
//            var result = _testClass.GetByEmpCreId(empCredId);

//            // Assert
//            throw new NotImplementedException("Create or modify test");
//        }

//        [Fact]
//        public void CanCallInsertInfo()
//        {
//            // Arrange
//            var deviceInfo = new DeviceTable
//            {
//                Id = 1945420976,
//                EmpCredentialId = 1875077102,
//                TimeIn = DateTime.UtcNow,
//                TimeOut = DateTime.UtcNow,
//                InsertedDate = DateTime.UtcNow,
//                WorkTime = DateTime.UtcNow,
//                OverTime = DateTime.UtcNow,
//                Remark = "TestValue1490448034",
//                ErlOut = DateTime.UtcNow,
//                LateIn = DateTime.UtcNow,
//                Name = "TestValue1029441425",
//                Status = "TestValue1822299095",
//                IsActive = (short)30086,
//                EmpCredential = new EmployeeCredential
//                {
//                    Id = 1422341184,
//                    UserName = "TestValue1109081004",
//                    Password = "TestValue2062249053",
//                    Status = (short)20039,
//                    RequestedCompanyId = 109316810,
//                    Email = "TestValue971491318",
//                    DefaultPassword = false,
//                    GenerateOtp = "TestValue1231228453",
//                    OtpExpiration = DateTime.UtcNow,
//                    IsActive = (short)27006,
//                    EmployeeLoginName = "TestValue1687673331",
//                    RequestedCompany = new RequestedCompanyForm
//                    {
//                        Id = 1602930073,
//                        Name = "TestValue1858465957",
//                        PhoneNumber = "TestValue1041971331",
//                        DomainName = "TestValue1284450229",
//                        Status = "TestValue910163358",
//                        InsertedDate = DateTime.UtcNow,
//                        UpdatedDate = DateTime.UtcNow,
//                        Email = "TestValue927305974",
//                        IsActive = (short)32707,
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
//                    DeviceTables = new Mock<ICollection<DeviceTable>>().Object,
//                    EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
//                    EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
//                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
//                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
//                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
//                    UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
//                }
//            };

//            // Act
//            var result = _testClass.InsertInfo(deviceInfo);

//            // Assert
//            throw new NotImplementedException("Create or modify test");
//        }

//        [Fact]
//        public void CanCallUpdateInfo()
//        {
//            // Arrange
//            var deviceInfo = new DeviceTable
//            {
//                Id = 523748736,
//                EmpCredentialId = 249494441,
//                TimeIn = DateTime.UtcNow,
//                TimeOut = DateTime.UtcNow,
//                InsertedDate = DateTime.UtcNow,
//                WorkTime = DateTime.UtcNow,
//                OverTime = DateTime.UtcNow,
//                Remark = "TestValue392920262",
//                ErlOut = DateTime.UtcNow,
//                LateIn = DateTime.UtcNow,
//                Name = "TestValue724818720",
//                Status = "TestValue106761516",
//                IsActive = (short)16043,
//                EmpCredential = new EmployeeCredential
//                {
//                    Id = 521851759,
//                    UserName = "TestValue918229057",
//                    Password = "TestValue1698279282",
//                    Status = (short)21148,
//                    RequestedCompanyId = 840515191,
//                    Email = "TestValue1442598991",
//                    DefaultPassword = false,
//                    GenerateOtp = "TestValue165528183",
//                    OtpExpiration = DateTime.UtcNow,
//                    IsActive = (short)11373,
//                    EmployeeLoginName = "TestValue966367557",
//                    RequestedCompany = new RequestedCompanyForm
//                    {
//                        Id = 2115068108,
//                        Name = "TestValue297582655",
//                        PhoneNumber = "TestValue1608137661",
//                        DomainName = "TestValue207514047",
//                        Status = "TestValue1904411350",
//                        InsertedDate = DateTime.UtcNow,
//                        UpdatedDate = DateTime.UtcNow,
//                        Email = "TestValue297872774",
//                        IsActive = (short)3468,
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
//                    DeviceTables = new Mock<ICollection<DeviceTable>>().Object,
//                    EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
//                    EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
//                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
//                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
//                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
//                    UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
//                }
//            };

//            // Act
//            var result = _testClass.UpdateInfo(deviceInfo);

//            // Assert
//            throw new NotImplementedException("Create or modify test");
//        }

//        [Fact]
//        public void CanCallDeleteInfo()
//        {
//            // Arrange
//            var id = 28712376;

//            // Act
//            var result = _testClass.DeleteInfo(id);

//            // Assert
//            throw new NotImplementedException("Create or modify test");
//        }
//    }
//}