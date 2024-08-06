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

    public class LeaveTypeControllerTests
    {
        private LeaveTypeController _testClass;
        private Mock<ILeaveTypes> _leavetype;
        private Mock<ILogger<LeaveTypeController>> _logger;

        public LeaveTypeControllerTests()
        {
            _leavetype = new Mock<ILeaveTypes>();
            _logger = new Mock<ILogger<LeaveTypeController>>();
            _testClass = new LeaveTypeController(_leavetype.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new LeaveTypeController(_leavetype.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllLeavetype()
        {
            // Arrange
            _leavetype.Setup(mock => mock.GetAllLeaveType()).Returns(new List<LeaveType>());

            // Act
            var result = _testClass.GetAllLeavetype();

            // Assert
            _leavetype.Verify(mock => mock.GetAllLeaveType());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetleavetypeById()
        {
            // Arrange
            var id = 1386187120;

            _leavetype.Setup(mock => mock.GetLeaveTypeById(It.IsAny<int>())).Returns(new LeaveType
            {
                Id = 1157899939,
                LeaveType1 = "TestValue1529321427",
                Days = 105680036,
                CompanyId = 1231114963,
                EmployeecredentialId = 1061962326,
                Company = new CompanyDetail
                {
                    Id = 1022169185,
                    Name = "TestValue2000369654",
                    Address = "TestValue347724160",
                    Country = "TestValue1046440521",
                    States = "TestValue2088241596",
                    Industry = "TestValue1894760890",
                    TimeZone = "TestValue1239293616",
                    Currency = "TestValue837278671",
                    PfNo = "TestValue801806959",
                    TanNo = "TestValue1180081419",
                    EsiNo = "TestValue175769829",
                    PanNo = "TestValue331718652",
                    GstNo = "TestValue1906101837",
                    RegistrationNo = "TestValue568500372",
                    Twitter = "TestValue137744375",
                    Facebook = "TestValue234947764",
                    LinkedIn = "TestValue995848169",
                    CompanyLogo = "TestValue295735138",
                    RequestedCompanyId = 1826875546,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 731106782,
                        Name = "TestValue940542193",
                        PhoneNumber = "TestValue1367381844",
                        DomainName = "TestValue638951288",
                        Status = "TestValue1247083491",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue938305990",
                        Department = new Department
                        {
                            Id = 714089728,
                            Name = "TestValue441753827",
                            RequestedCompanyId = 1804024359,
                            RequestedCompany = default(RequestedCompanyForm),
                            EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                        },
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object
                },
                Employeecredential = new EmployeeCredential
                {
                    Id = 896644539,
                    UserName = "TestValue660502147",
                    Password = "TestValue2020986562",
                    Status = (short)1413,
                    RequestedCompanyId = 1135613762,
                    Email = "TestValue667034663",
                    DefaultPassword = false,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 21551480,
                        Name = "TestValue1806928572",
                        PhoneNumber = "TestValue1518543822",
                        DomainName = "TestValue1324772370",
                        Status = "TestValue1949896041",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1590164935",
                        Department = new Department
                        {
                            Id = 1754637645,
                            Name = "TestValue1444416952",
                            RequestedCompanyId = 1202170252,
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
                },
                EmployeeAttendances = new Mock<ICollection<EmployeeAttendance>>().Object,
                EmployeeLeaves = new Mock<ICollection<EmployeeLeave>>().Object
            });

            // Act
            var result = _testClass.GetleavetypeById(id);

            // Assert
            _leavetype.Verify(mock => mock.GetLeaveTypeById(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallInsertLeavetypes()
        {
            // Arrange
            var leaveType = new LeaveType
            {
                Id = 577667289,
                LeaveType1 = "TestValue1050694055",
                Days = 1464439102,
                CompanyId = 1686180195,
                EmployeecredentialId = 162051770,
                Company = new CompanyDetail
                {
                    Id = 1233586289,
                    Name = "TestValue426288137",
                    Address = "TestValue500008181",
                    Country = "TestValue121420133",
                    States = "TestValue1802270988",
                    Industry = "TestValue1361418366",
                    TimeZone = "TestValue1248124316",
                    Currency = "TestValue108134531",
                    PfNo = "TestValue1374151868",
                    TanNo = "TestValue1453007063",
                    EsiNo = "TestValue1582752904",
                    PanNo = "TestValue2088117779",
                    GstNo = "TestValue141304812",
                    RegistrationNo = "TestValue1306578504",
                    Twitter = "TestValue83140232",
                    Facebook = "TestValue1343588537",
                    LinkedIn = "TestValue1239067174",
                    CompanyLogo = "TestValue466890764",
                    RequestedCompanyId = 116192895,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 575502839,
                        Name = "TestValue1624787994",
                        PhoneNumber = "TestValue1118446415",
                        DomainName = "TestValue2024463152",
                        Status = "TestValue1288425494",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1333388195",
                        Department = new Department
                        {
                            Id = 2070448539,
                            Name = "TestValue1584264683",
                            RequestedCompanyId = 2008380018,
                            RequestedCompany = default(RequestedCompanyForm),
                            EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                        },
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object
                },
                Employeecredential = new EmployeeCredential
                {
                    Id = 1315643994,
                    UserName = "TestValue136422439",
                    Password = "TestValue1538543419",
                    Status = (short)5181,
                    RequestedCompanyId = 1357947991,
                    Email = "TestValue498450377",
                    DefaultPassword = true,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1813825107,
                        Name = "TestValue635605581",
                        PhoneNumber = "TestValue545614530",
                        DomainName = "TestValue446822267",
                        Status = "TestValue807616761",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue558804256",
                        Department = new Department
                        {
                            Id = 1410409291,
                            Name = "TestValue2098104149",
                            RequestedCompanyId = 496888978,
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
                },
                EmployeeAttendances = new Mock<ICollection<EmployeeAttendance>>().Object,
                EmployeeLeaves = new Mock<ICollection<EmployeeLeave>>().Object
            };

            _leavetype.Setup(mock => mock.InsertLeaveType(It.IsAny<LeaveType>())).Returns("TestValue1770145643");

            // Act
            var result = _testClass.InsertLeavetypes(leaveType);

            // Assert
            _leavetype.Verify(mock => mock.InsertLeaveType(It.IsAny<LeaveType>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallDeleteLeavetype()
        {
            // Arrange
            var id = 1814003513;

            _leavetype.Setup(mock => mock.deleteLeaveType(It.IsAny<int>())).Returns(true);

            // Act
            var result = _testClass.DeleteLeavetype(id);

            // Assert
            _leavetype.Verify(mock => mock.deleteLeaveType(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}