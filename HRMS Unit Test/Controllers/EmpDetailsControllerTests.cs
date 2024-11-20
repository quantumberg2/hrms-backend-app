namespace HRMS_Unit_Test.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.Controllers;
    using HRMS_Application.DTO;
    using HRMS_Application.GlobalSearch;
    using HRMS_Application.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class EmpDetailsControllerTests
    {
        private readonly EmpDetailsController _testClass;
        private readonly Mock<IEmpDetails> _empDetails;
        private readonly Mock<ILogger<EmpDetailsController>> _logger;

        public EmpDetailsControllerTests()
        {
            _empDetails = new Mock<IEmpDetails>();
            _logger = new Mock<ILogger<EmpDetailsController>>();
            _testClass = new EmpDetailsController(_empDetails.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new EmpDetailsController(_empDetails.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllEmpDetails()
        {
            // Arrange
            _empDetails.Setup(mock => mock.GetAllUser()).Returns(new List<EmployeeDetail>());

            // Act
            var result = _testClass.GetAllEmpDetails();

            // Assert
            _empDetails.Verify(mock => mock.GetAllUser());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetById()
        {
            // Arrange
            var id = 219952252;

            _empDetails.Setup(mock => mock.GetById(It.IsAny<int>())).Returns(new EmployeeDetail
            {
                Id = 130258170,
                DeptId = 754034646,
                FirstName = "TestValue642495227",
                MiddleName = "TestValue55878964",
                LastName = "TestValue1217073969",
                PositionId = 1266307870,
                EmployeeCredentialId = 1403061727,
                EmployeeNumber = "TestValue1983760242",
                Email = "TestValue1960786929",
                RequestCompanyId = 596049487,
                IsActive = (short)31206,
                ManagerId = 1734052799,
                NickName = "TestValue1446251103",
                Extension = "TestValue1311064998",
                MobileNumber = "TestValue1872253432",
                NumberOfYearsExperience = "TestValue1954375850",
                ImageUrl = "TestValue876852541",
                Dept = new Department
                {
                    Id = 746585889,
                    Name = "TestValue1525055517",
                    RequestedCompanyId = 2050277719,
                    IsActive = (short)13132,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 755309492,
                        Name = "TestValue534082394",
                        PhoneNumber = "TestValue1486278651",
                        DomainName = "TestValue1022371519",
                        Status = "TestValue1674007689",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1035546661",
                        IsActive = (short)12723,
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        Departments = new Mock<ICollection<Department>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Holidays = new Mock<ICollection<Holiday>>().Object,
                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                },
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 123517060,
                    UserName = "TestValue81975052",
                    Password = "TestValue874649087",
                    Status = (short)27116,
                    RequestedCompanyId = 794151240,
                    Email = "TestValue1655857771",
                    DefaultPassword = true,
                    GenerateOtp = "TestValue181263939",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)27909,
                    EmployeeLoginName = "TestValue1923582498",
                    ResignedDate = DateTime.UtcNow,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1992841054,
                        Name = "TestValue122578385",
                        PhoneNumber = "TestValue264186359",
                        DomainName = "TestValue1569383233",
                        Status = "TestValue723594003",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1989932374",
                        IsActive = (short)23454,
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
                    EmpCredIdEmpCodeMappings = new Mock<ICollection<EmpCredIdEmpCodeMapping>>().Object,
                    EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                    EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
                    UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
                },
                Position = new Position
                {
                    Id = 723892659,
                    Name = "TestValue1917510491",
                    RequestedCompanyId = 1649484627,
                    IsActive = (short)2627,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 932393361,
                        Name = "TestValue475889957",
                        PhoneNumber = "TestValue1411869699",
                        DomainName = "TestValue824183337",
                        Status = "TestValue1061741396",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue770446266",
                        IsActive = (short)23229,
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        Departments = new Mock<ICollection<Department>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Holidays = new Mock<ICollection<Holiday>>().Object,
                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                }
            });

            // Act
            var result = _testClass.GetById(id);

            // Assert
            _empDetails.Verify(mock => mock.GetById(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertEmployee()
        {
            // Arrange
            var employeeDetail = new EmployeeDetail
            {
                Id = 1180991092,
                DeptId = 1690549927,
                FirstName = "TestValue230761209",
                MiddleName = "TestValue569170828",
                LastName = "TestValue1860243182",
                PositionId = 1878811877,
                EmployeeCredentialId = 1868884047,
                EmployeeNumber = "TestValue268036088",
                Email = "TestValue939901559",
                RequestCompanyId = 1937876979,
                IsActive = (short)23594,
                ManagerId = 1690989493,
                NickName = "TestValue125255053",
                Extension = "TestValue1100753690",
                MobileNumber = "TestValue901228482",
                NumberOfYearsExperience = "TestValue1402477132",
                ImageUrl = "TestValue1786091360",
                Dept = new Department
                {
                    Id = 1438803723,
                    Name = "TestValue31715489",
                    RequestedCompanyId = 691633667,
                    IsActive = (short)31990,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 298478860,
                        Name = "TestValue1903980845",
                        PhoneNumber = "TestValue1533545681",
                        DomainName = "TestValue661689598",
                        Status = "TestValue1338607346",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1753568742",
                        IsActive = (short)24569,
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        Departments = new Mock<ICollection<Department>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Holidays = new Mock<ICollection<Holiday>>().Object,
                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                },
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 952962515,
                    UserName = "TestValue1879893491",
                    Password = "TestValue885411505",
                    Status = (short)5947,
                    RequestedCompanyId = 2108795334,
                    Email = "TestValue525420574",
                    DefaultPassword = false,
                    GenerateOtp = "TestValue302291127",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)31116,
                    EmployeeLoginName = "TestValue1842499178",
                    ResignedDate = DateTime.UtcNow,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1856623698,
                        Name = "TestValue992265773",
                        PhoneNumber = "TestValue121048327",
                        DomainName = "TestValue1269108407",
                        Status = "TestValue1931474747",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue2127117159",
                        IsActive = (short)1573,
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
                    EmpCredIdEmpCodeMappings = new Mock<ICollection<EmpCredIdEmpCodeMapping>>().Object,
                    EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                    EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
                    UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
                },
                Position = new Position
                {
                    Id = 628695455,
                    Name = "TestValue807138308",
                    RequestedCompanyId = 1522619914,
                    IsActive = (short)7791,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1569189852,
                        Name = "TestValue1423133683",
                        PhoneNumber = "TestValue1479126190",
                        DomainName = "TestValue1490716836",
                        Status = "TestValue1675802232",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1354566067",
                        IsActive = (short)13465,
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        Departments = new Mock<ICollection<Department>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Holidays = new Mock<ICollection<Holiday>>().Object,
                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                }
            };

            _empDetails.Setup(mock => mock.InsertEmployeeAsync(It.IsAny<EmployeeDetail>(), It.IsAny<int>())).ReturnsAsync("TestValue1303700223");

            // Act
            var result = await _testClass.InsertEmployee(employeeDetail);

            // Assert
            _empDetails.Verify(mock => mock.InsertEmployeeAsync(It.IsAny<EmployeeDetail>(), It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmployeeDetails()
        {
            // Arrange
            var id = 1561776882;
            var depId = 2021970734;
            var fname = "TestValue2137650445";
            var mname = "TestValue2041777954";
            var lname = "TestValue1306482841";
            var positionid = 2078784557;
            var Designation = "TestValue750731907";
            var Email = "TestValue1646180159";
            var employeecredentialId = 110035207;
            var EmployeeNumber = "TestValue1296684704";
            var requsetCompanyId = 428979972;

            _empDetails.Setup(mock => mock.UpdateEmployeeDetail(It.IsAny<int>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<int?>())).ReturnsAsync(new EmployeeDetail
            {
                Id = 1934052729,
                DeptId = 844699175,
                FirstName = "TestValue2054964877",
                MiddleName = "TestValue521635836",
                LastName = "TestValue125243135",
                PositionId = 258621012,
                EmployeeCredentialId = 1462557220,
                EmployeeNumber = "TestValue1207491715",
                Email = "TestValue1052465474",
                RequestCompanyId = 1156573452,
                IsActive = (short)26391,
                ManagerId = 1747318126,
                NickName = "TestValue358162284",
                Extension = "TestValue598937355",
                MobileNumber = "TestValue1510659956",
                NumberOfYearsExperience = "TestValue2091075829",
                ImageUrl = "TestValue1729663672",
                Dept = new Department
                {
                    Id = 1186933363,
                    Name = "TestValue570585340",
                    RequestedCompanyId = 827509396,
                    IsActive = (short)7850,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1924347333,
                        Name = "TestValue1430405940",
                        PhoneNumber = "TestValue32994143",
                        DomainName = "TestValue531469038",
                        Status = "TestValue230948828",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1099621818",
                        IsActive = (short)23364,
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        Departments = new Mock<ICollection<Department>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Holidays = new Mock<ICollection<Holiday>>().Object,
                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                },
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 456759808,
                    UserName = "TestValue1553768962",
                    Password = "TestValue1046538245",
                    Status = (short)6606,
                    RequestedCompanyId = 1318338154,
                    Email = "TestValue2007562821",
                    DefaultPassword = true,
                    GenerateOtp = "TestValue1194601648",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)29525,
                    EmployeeLoginName = "TestValue1334987862",
                    ResignedDate = DateTime.UtcNow,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 867022638,
                        Name = "TestValue2009910962",
                        PhoneNumber = "TestValue1954034834",
                        DomainName = "TestValue723983032",
                        Status = "TestValue1074651685",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1094049936",
                        IsActive = (short)15967,
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
                    EmpCredIdEmpCodeMappings = new Mock<ICollection<EmpCredIdEmpCodeMapping>>().Object,
                    EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                    EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
                    UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
                },
                Position = new Position
                {
                    Id = 1207303829,
                    Name = "TestValue1164457630",
                    RequestedCompanyId = 2059187509,
                    IsActive = (short)893,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1479541501,
                        Name = "TestValue1896946165",
                        PhoneNumber = "TestValue303783473",
                        DomainName = "TestValue1105216892",
                        Status = "TestValue527056671",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue368024472",
                        IsActive = (short)148,
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        Departments = new Mock<ICollection<Department>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Holidays = new Mock<ICollection<Holiday>>().Object,
                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                }
            });

            // Act
            var result = await _testClass.UpdateEmployeeDetails(id, depId, fname, mname, lname, positionid, Designation, Email, employeecredentialId, EmployeeNumber, requsetCompanyId);

            // Assert
            _empDetails.Verify(mock => mock.UpdateEmployeeDetail(It.IsAny<int>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<int?>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallDeleteEmpDetails()
        {
            // Arrange
            var id = 83215310;

            _empDetails.Setup(mock => mock.DeleteEmployeeDetail(It.IsAny<int>())).ReturnsAsync(false);

            // Act
            var result = await _testClass.DeleteEmpDetails(id);

            // Assert
            _empDetails.Verify(mock => mock.DeleteEmployeeDetail(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 156057881;
            var isActive = (short)6022;

            _empDetails.Setup(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>())).Returns(false);

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            _empDetails.Verify(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAllEmployees()
        {
            // Arrange
            _empDetails.Setup(mock => mock.GetAllEmployees(It.IsAny<int>())).Returns(new[] {
                new EmployeeView
                {
                    EmployeeId = 319910725,
                    EmployeeName = "TestValue708158025",
                    Address = "TestValue1020958209",
                    Gender = "TestValue1937988375",
                    DOB = "TestValue849695648",
                    Designation = "TestValue336356004",
                    Manager = "TestValue1133976494"
                },
                new EmployeeView
                {
                    EmployeeId = 1471648856,
                    EmployeeName = "TestValue1213974845",
                    Address = "TestValue1187917956",
                    Gender = "TestValue1472726414",
                    DOB = "TestValue1124701954",
                    Designation = "TestValue1804306444",
                    Manager = "TestValue742754772"
                },
                new EmployeeView
                {
                    EmployeeId = 1475259857,
                    EmployeeName = "TestValue791281483",
                    Address = "TestValue1639538349",
                    Gender = "TestValue506016649",
                    DOB = "TestValue1780308413",
                    Designation = "TestValue2060530861",
                    Manager = "TestValue1344821064"
                }
            });

            // Act
            var result = _testClass.GetAllEmployees();

            // Assert
            _empDetails.Verify(mock => mock.GetAllEmployees(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallGetEmployeeInfo()
        {
            // Arrange
            var employeeCredentialId = 666374520;

            _empDetails.Setup(mock => mock.GetEmployeeInfoAsync(It.IsAny<int>())).ReturnsAsync(new UpdateEmployeeInfoDTO
            {
                EmployeeCredentialId = 972728331,
                EmployeeName = "TestValue703428121",
                NickName = "TestValue2022733924",
                EmailAddress = "TestValue2120734772",
                EmpLoginName = "TestValue1575955173",
                MobileNumber = "TestValue984014729",
                Extension = "TestValue1897300239",
                gender = "TestValue778323857"
            });

            // Act
            var result = await _testClass.GetEmployeeInfo(employeeCredentialId);

            // Assert
            _empDetails.Verify(mock => mock.GetEmployeeInfoAsync(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallGetEmployeePersonalInfo()
        {
            // Arrange
            var employeeCredentialId = 1773513600;

            _empDetails.Setup(mock => mock.GetEmployeePersonalInfoAsync(It.IsAny<int>())).ReturnsAsync(new EmpPersonalInfoDTO
            {
                FirstName = "TestValue1975972199",
                MiddleName = "TestValue1889955235",
                LastName = "TestValue1323483620",
                EmployeeCredentialId = 1502270355,
                Dob = DateTime.UtcNow,
                DateOfJoining = DateTime.UtcNow,
                ConfirmDate = DateTime.UtcNow,
                EmpStatus = "TestValue2131356395",
                EmailId = "TestValue397058867",
                PersonalEmail = "TestValue1653582109",
                MaritalStatus = "TestValue577519743",
                BloodGroup = "TestValue1307493395",
                SpouseName = "TestValue1225420878",
                PhysicallyChallenged = false,
                EmergencyContact = "TestValue666001589",
                PAN = "TestValue827803109",
                Gender = "TestValue118564885",
                Contact = "TestValue606058143"
            });

            // Act
            var result = await _testClass.GetEmployeePersonalInfo(employeeCredentialId);

            // Assert
            _empDetails.Verify(mock => mock.GetEmployeePersonalInfoAsync(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallGetEmployeeAddressInfo()
        {
            // Arrange
            var employeeCredentialId = 1197338393;

            _empDetails.Setup(mock => mock.GetEmployeeAddressInfoAsync(It.IsAny<int>())).ReturnsAsync(new AddressInfoDTO
            {
                EmployeeCredentialId = 1989357362,
                AddressLine1 = "TestValue1514764082",
                AddressLine2 = "TestValue1968908494",
                City = "TestValue1785182136",
                State = "TestValue1006028408",
                Country = "TestValue1724682308",
                PinCode = "TestValue683233542",
                IsActive = (short)3707
            });

            // Act
            var result = await _testClass.GetEmployeeAddressInfo(employeeCredentialId);

            // Assert
            _empDetails.Verify(mock => mock.GetEmployeeAddressInfoAsync(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallGetEmployeeAccountInfo()
        {
            // Arrange
            var employeeCredentialId = 304931962;

            _empDetails.Setup(mock => mock.GetEmployeeAccountInfoAsync(It.IsAny<int>())).ReturnsAsync(new AccountDetail
            {
                Id = 1494666041,
                EmployeeCredentialId = 4729904,
                AccountNumber = "TestValue1145707932",
                IfscCode = "TestValue1964737250",
                AccountType = "TestValue1421224122",
                BankName = "TestValue1499824922",
                BranchName = "TestValue1384159902",
                AadharNumber = "TestValue693324999",
                PfNumber = "TestValue547600325",
                UanNumber = "TestValue1359429404",
                PfJoiningDate = DateTime.UtcNow,
                EligibleForPf = false,
                IsActive = (short)29733,
                Country = "TestValue302036089",
                State = "TestValue758882024",
                City = "TestValue1078200990",
                Pin = 1285183021,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1062018605,
                    UserName = "TestValue1346006901",
                    Password = "TestValue554887535",
                    Status = (short)17890,
                    RequestedCompanyId = 678819475,
                    Email = "TestValue144925222",
                    DefaultPassword = false,
                    GenerateOtp = "TestValue1416675781",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)5298,
                    EmployeeLoginName = "TestValue1734081458",
                    ResignedDate = DateTime.UtcNow,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1616734294,
                        Name = "TestValue2075875392",
                        PhoneNumber = "TestValue1140625368",
                        DomainName = "TestValue1807829759",
                        Status = "TestValue251289891",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1206721693",
                        IsActive = (short)16486,
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
                    EmpCredIdEmpCodeMappings = new Mock<ICollection<EmpCredIdEmpCodeMapping>>().Object,
                    EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                    EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
                    UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
                }
            });

            // Act
            var result = await _testClass.GetEmployeeAccountInfo(employeeCredentialId);

            // Assert
            _empDetails.Verify(mock => mock.GetEmployeeAccountInfoAsync(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGet()
        {
            // Arrange
            var globalsearch = new GlobalsearchEmp { FilterBy = "TestValue636690354" };

            _empDetails.Setup(mock => mock.GetFilters(It.IsAny<GlobalsearchEmp>(), It.IsAny<int>())).Returns(new List<EmployeeDetail>());

            // Act
            var result = _testClass.Get(globalsearch);

            // Assert
            _empDetails.Verify(mock => mock.GetFilters(It.IsAny<GlobalsearchEmp>(), It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetfiltersbyManager()
        {
            // Arrange
            var globalsearch = new GlobalsearchEmp { FilterBy = "TestValue392328963" };

            _empDetails.Setup(mock => mock.GetFiltersbymanager(It.IsAny<GlobalsearchEmp>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<EmployeeDetail>());

            // Act
            var result = _testClass.GetfiltersbyManager(globalsearch);

            // Assert
            _empDetails.Verify(mock => mock.GetFiltersbymanager(It.IsAny<GlobalsearchEmp>(), It.IsAny<int>(), It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmployeeInfo()
        {
            // Arrange
            var updateEmployeeInfo = new UpdateEmployeeInfoDTO
            {
                EmployeeCredentialId = 760266141,
                EmployeeName = "TestValue2033752920",
                NickName = "TestValue1873079603",
                EmailAddress = "TestValue1651317985",
                EmpLoginName = "TestValue2120160237",
                MobileNumber = "TestValue280202784",
                Extension = "TestValue906619128",
                gender = "TestValue1023286964"
            };

            _empDetails.Setup(mock => mock.UpdateEmployeeInfoAsync(It.IsAny<UpdateEmployeeInfoDTO>())).ReturnsAsync(true);

            // Act
            var result = await _testClass.UpdateEmployeeInfo(updateEmployeeInfo);

            // Assert
            _empDetails.Verify(mock => mock.UpdateEmployeeInfoAsync(It.IsAny<UpdateEmployeeInfoDTO>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmployeePersonalInfo()
        {
            // Arrange
            var empPersonalInfoDTO = new EmpPersonalInfoDTO
            {
                FirstName = "TestValue1687321273",
                MiddleName = "TestValue755882058",
                LastName = "TestValue890707504",
                EmployeeCredentialId = 499999115,
                Dob = DateTime.UtcNow,
                DateOfJoining = DateTime.UtcNow,
                ConfirmDate = DateTime.UtcNow,
                EmpStatus = "TestValue2091493450",
                EmailId = "TestValue378675407",
                PersonalEmail = "TestValue128346007",
                MaritalStatus = "TestValue1217957693",
                BloodGroup = "TestValue518518918",
                SpouseName = "TestValue1349740819",
                PhysicallyChallenged = true,
                EmergencyContact = "TestValue1876515798",
                PAN = "TestValue1617516078",
                Gender = "TestValue1834626311",
                Contact = "TestValue2030574275"
            };

            _empDetails.Setup(mock => mock.UpdateEmployeepersonalInfoAsync(It.IsAny<EmpPersonalInfoDTO>())).ReturnsAsync(false);

            // Act
            var result = await _testClass.UpdateEmployeePersonalInfo(empPersonalInfoDTO);

            // Assert
            _empDetails.Verify(mock => mock.UpdateEmployeepersonalInfoAsync(It.IsAny<EmpPersonalInfoDTO>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmployeeAddressInfo()
        {
            // Arrange
            var addressInfo = new AddressInfoDTO
            {
                EmployeeCredentialId = 1700183278,
                AddressLine1 = "TestValue887254213",
                AddressLine2 = "TestValue1108139513",
                City = "TestValue523533133",
                State = "TestValue868229028",
                Country = "TestValue2144587774",
                PinCode = "TestValue122191670",
                IsActive = (short)10465
            };

            _empDetails.Setup(mock => mock.UpdateEmployeeAddresslInfoAsync(It.IsAny<AddressInfoDTO>())).ReturnsAsync(true);

            // Act
            var result = await _testClass.UpdateEmployeeAddressInfo(addressInfo);

            // Assert
            _empDetails.Verify(mock => mock.UpdateEmployeeAddresslInfoAsync(It.IsAny<AddressInfoDTO>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmployeeAccountInfo()
        {
            // Arrange
            var accountDetail = new AccountDetailDTO
            {
                EmployeeCredentialId = 301752464,
                AccountNumber = "TestValue1459737628",
                IfscCode = "TestValue829291579",
                AccountType = "TestValue1668702283",
                BankName = "TestValue706142885",
                BranchName = "TestValue2012206085",
                AadharNumber = "TestValue1825727755",
                PfNumber = "TestValue393388817",
                UanNumber = "TestValue522409553",
                PfJoiningDate = DateTime.UtcNow,
                EligibleForPf = true,
                IsActive = (short)13135,
                Country = "TestValue1185167888",
                State = "TestValue640626253",
                City = "TestValue1863819956",
                Pin = 2020098131
            };

            _empDetails.Setup(mock => mock.UpdateEmployeeAccountInfoAsync(It.IsAny<AccountDetailDTO>())).ReturnsAsync(false);

            // Act
            var result = await _testClass.UpdateEmployeeAccountInfo(accountDetail);

            // Assert
            _empDetails.Verify(mock => mock.UpdateEmployeeAccountInfoAsync(It.IsAny<AccountDetailDTO>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetEmployeeShiftAndLeaveStats()
        {
            // Arrange
            _empDetails.Setup(mock => mock.GetEmployeeShiftAndLeaveStats(It.IsAny<int>())).Returns(new EmployeeShiftAndLeaveStatsDto
            {
                ShiftType = "TestValue1078375686",
                ShiftTimeRange = "TestValue2009998907",
                TotalLeaveCount = 1933896691,
                RemainingLeaveCount = 1434433182,
                LeavePercentage = 962737672.05,
                Name = "TestValue778842026",
                Email = "TestValue1290233710",
                MonthlyPresentDays = 199126609,
                TotalWorkingDays = 1989988975,
                AttendancePercentage = 193594329.72
            });

            // Act
            var result = _testClass.GetEmployeeShiftAndLeaveStats();

            // Assert
            _empDetails.Verify(mock => mock.GetEmployeeShiftAndLeaveStats(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetMonthlyStatistics()
        {
            // Arrange
            var month = DateTime.UtcNow;

            _empDetails.Setup(mock => mock.GetMonthlyStatistics(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(new MonthlyAttendanceStatistics
            {
                EmployeecredntialId = 419976959,
                TotalWorkingDays = 1540432218,
                TotalHoursWorked = 1926503629.3799999,
                AverageWorkHours = "TestValue499753831",
                AverageOvertime = "TestValue1104066238",
                TotalWorkplusOT = "TestValue1690217146",
                TotalOverTime = "TestValue633690388",
                LessHoursTime = "TestValue204835477",
                AvgTimein = "TestValue1870173918",
                AvgTimeouT = "TestValue1789740986",
                LateInCount = 1066421426,
                EarlyOutCount = 1446538075,
                AbsentCount = 1696739057,
                LeaveTakenCount = 1959859680,
                PenaltyCount = 1485018381,
                PresentPercentage = 1870215144.93,
                AbsentPercentage = 1468295711.19,
                LeaveTakenPercentage = 1084155459.75,
                HolidayPercentage = 1769987464.74,
                RestDaysPercentage = 1158024818.61,
                SpecificDayAttendance = new DateWiseAttendance
                {
                    Date = DateTime.UtcNow,
                    TimeIn = "TestValue270600269",
                    TimeOut = "TestValue1059557025",
                    WorkTime = "TestValue1170917904",
                    Overtime = "TestValue1235525029",
                    Status = "TestValue1592641094"
                },
                DateWiseAttendance = new List<DateWiseAttendance>()
            });

            // Act
            var result = _testClass.GetMonthlyStatistics(month);

            // Assert
            _empDetails.Verify(mock => mock.GetMonthlyStatistics(It.IsAny<int>(), It.IsAny<DateTime>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetMonthlyStatisticsforManager()
        {
            // Arrange
            var empCredentialId = 1443198692;
            var month = DateTime.UtcNow;

            _empDetails.Setup(mock => mock.GetMonthlyStatistics(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(new MonthlyAttendanceStatistics
            {
                EmployeecredntialId = 1005713768,
                TotalWorkingDays = 210691083,
                TotalHoursWorked = 826889713.65,
                AverageWorkHours = "TestValue1860893379",
                AverageOvertime = "TestValue2145950465",
                TotalWorkplusOT = "TestValue1159002401",
                TotalOverTime = "TestValue1260611019",
                LessHoursTime = "TestValue986786251",
                AvgTimein = "TestValue1473152455",
                AvgTimeouT = "TestValue286165926",
                LateInCount = 471773867,
                EarlyOutCount = 2027248140,
                AbsentCount = 2041118633,
                LeaveTakenCount = 1565826962,
                PenaltyCount = 504026686,
                PresentPercentage = 224890229.52,
                AbsentPercentage = 970529086.89,
                LeaveTakenPercentage = 908756622.18,
                HolidayPercentage = 73338180.3,
                RestDaysPercentage = 944139937.95,
                SpecificDayAttendance = new DateWiseAttendance
                {
                    Date = DateTime.UtcNow,
                    TimeIn = "TestValue1779321258",
                    TimeOut = "TestValue313259850",
                    WorkTime = "TestValue2121520658",
                    Overtime = "TestValue2096898448",
                    Status = "TestValue1230839735"
                },
                DateWiseAttendance = new List<DateWiseAttendance>()
            });

            // Act
            var result = _testClass.GetMonthlyStatisticsforManager(empCredentialId, month);

            // Assert
            _empDetails.Verify(mock => mock.GetMonthlyStatistics(It.IsAny<int>(), It.IsAny<DateTime>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateImageUrl()
        {
            // Arrange
            var @file = new Mock<IFormFile>().Object;

            _empDetails.Setup(mock => mock.UpdateImageUrl(It.IsAny<int>(), It.IsAny<IFormFile>())).ReturnsAsync("TestValue195127185");

            // Act
            var result = await _testClass.UpdateImageUrl(file);

            // Assert
            _empDetails.Verify(mock => mock.UpdateImageUrl(It.IsAny<int>(), It.IsAny<IFormFile>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetUserdetails()
        {
            // Arrange
            _empDetails.Setup(mock => mock.GetUserDetails(It.IsAny<int>(), It.IsAny<int>())).Returns(new UserDetailsDTO
            {
                Name = "TestValue558744130",
                Email = "TestValue820266936",
                ImageUrl = "TestValue2072433206",
                CompanyLogo = "TestValue1507903581"
            });

            // Act
            var result = _testClass.GetUserdetails();

            // Assert
            _empDetails.Verify(mock => mock.GetUserDetails(It.IsAny<int>(), It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}
//namespace HRMS_Unit_Test.Controllers
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Threading.Tasks;
//    using HRMS_Application.BusinessLogic.Interface;
//    using HRMS_Application.Controllers;
//    using HRMS_Application.DTO;
//    using HRMS_Application.GlobalSearch;
//    using HRMS_Application.Models;
//    using Microsoft.Extensions.Logging;
//    using Moq;
//    using Xunit;

//    public class EmpDetailsControllerTests
//    {
//        private readonly EmpDetailsController _testClass;
//        private readonly Mock<IEmpDetails> _empDetails;
//        private readonly Mock<ILogger<EmpDetailsController>> _logger;

//        public EmpDetailsControllerTests()
//        {
//            _empDetails = new Mock<IEmpDetails>();
//            _logger = new Mock<ILogger<EmpDetailsController>>();
//            _testClass = new EmpDetailsController(_empDetails.Object, _logger.Object);
//        }

//        [Fact]
//        public void CanConstruct()
//        {
//            // Act
//            var instance = new EmpDetailsController(_empDetails.Object, _logger.Object);

//            // Assert
//            Assert.NotNull(instance);
//        }

//        [Fact]
//        public void CanCallGetAllEmpDetails()
//        {
//            // Arrange
//            _empDetails.Setup(mock => mock.GetAllUser()).Returns(new List<EmployeeDetail>());

//            // Act
//            var result = _testClass.GetAllEmpDetails();

//            // Assert
//            _empDetails.Verify(mock => mock.GetAllUser());

//            throw new NotImplementedException("Create or modify test");
//        }

//        [Fact]
//        public void CanCallGetById()
//        {
//            // Arrange
//            var id = 840355052;

//            _empDetails.Setup(mock => mock.GetById(It.IsAny<int>())).Returns(new EmployeeDetail
//            {
//                Id = 698396451,
//                DeptId = 799694469,
//                FirstName = "TestValue744780881",
//                MiddleName = "TestValue1065993012",
//                LastName = "TestValue1595538487",
//                PositionId = 937058197,
//                EmployeeCredentialId = 1904322270,
//                EmployeeNumber = "TestValue669233999",
//                Email = "TestValue922902054",
//                RequestCompanyId = 493462234,
//                IsActive = (short)7899,
//                ManagerId = 1772667389,
//                NickName = "TestValue1250929627",
//                Extension = "TestValue1111386684",
//                MobileNumber = "TestValue1996290296",
//                Dept = new Department
//                {
//                    Id = 865955273,
//                    Name = "TestValue2095281557",
//                    RequestedCompanyId = 1892190339,
//                    IsActive = (short)24330,
//                    RequestedCompany = new RequestedCompanyForm
//                    {
//                        Id = 952125732,
//                        Name = "TestValue1328731279",
//                        PhoneNumber = "TestValue1552839891",
//                        DomainName = "TestValue1190113159",
//                        Status = "TestValue1576816781",
//                        InsertedDate = DateTime.UtcNow,
//                        UpdatedDate = DateTime.UtcNow,
//                        Email = "TestValue828682620",
//                        IsActive = (short)7770,
//                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
//                        Departments = new Mock<ICollection<Department>>().Object,
//                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
//                        Holidays = new Mock<ICollection<Holiday>>().Object,
//                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
//                        Positions = new Mock<ICollection<Position>>().Object
//                    },
//                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
//                },
//                EmployeeCredential = new EmployeeCredential
//                {
//                    Id = 247760600,
//                    UserName = "TestValue793703643",
//                    Password = "TestValue1617232713",
//                    Status = (short)3302,
//                    RequestedCompanyId = 1793427922,
//                    Email = "TestValue670060106",
//                    DefaultPassword = false,
//                    GenerateOtp = "TestValue802780727",
//                    OtpExpiration = DateTime.UtcNow,
//                    IsActive = (short)29249,
//                    EmployeeLoginName = "TestValue248342192",
//                    RequestedCompany = new RequestedCompanyForm
//                    {
//                        Id = 1876205685,
//                        Name = "TestValue973437029",
//                        PhoneNumber = "TestValue1006396471",
//                        DomainName = "TestValue1652064443",
//                        Status = "TestValue1544310958",
//                        InsertedDate = DateTime.UtcNow,
//                        UpdatedDate = DateTime.UtcNow,
//                        Email = "TestValue742968050",
//                        IsActive = (short)17468,
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
//                },
//                Position = new Position
//                {
//                    Id = 220376415,
//                    Name = "TestValue1838987309",
//                    RequestedCompanyId = 1062696526,
//                    IsActive = (short)10679,
//                    RequestedCompany = new RequestedCompanyForm
//                    {
//                        Id = 1123089986,
//                        Name = "TestValue1250782577",
//                        PhoneNumber = "TestValue1694539235",
//                        DomainName = "TestValue856584630",
//                        Status = "TestValue2137908696",
//                        InsertedDate = DateTime.UtcNow,
//                        UpdatedDate = DateTime.UtcNow,
//                        Email = "TestValue947137146",
//                        IsActive = (short)16875,
//                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
//                        Departments = new Mock<ICollection<Department>>().Object,
//                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
//                        Holidays = new Mock<ICollection<Holiday>>().Object,
//                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
//                        Positions = new Mock<ICollection<Position>>().Object
//                    },
//                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
//                }
//            });

//            // Act
//            var result = _testClass.GetById(id);

//            // Assert
//            _empDetails.Verify(mock => mock.GetById(It.IsAny<int>()));

//            throw new NotImplementedException("Create or modify test");
//        }

//        [Fact]
//        public async Task CanCallInsertEmployee()
//        {
//            // Arrange
//            var employeeDetail = new EmployeeDetail
//            {
//                Id = 1757064957,
//                DeptId = 1315447747,
//                FirstName = "TestValue237310392",
//                MiddleName = "TestValue1086277829",
//                LastName = "TestValue689297597",
//                PositionId = 1110618627,
//                EmployeeCredentialId = 1199484933,
//                EmployeeNumber = "TestValue706489655",
//                Email = "TestValue847517959",
//                RequestCompanyId = 1995143637,
//                IsActive = (short)13285,
//                ManagerId = 448148900,
//                NickName = "TestValue1341940841",
//                Extension = "TestValue1747948104",
//                MobileNumber = "TestValue1137233235",
//                Dept = new Department
//                {
//                    Id = 1121844528,
//                    Name = "TestValue885793868",
//                    RequestedCompanyId = 2089982707,
//                    IsActive = (short)23731,
//                    RequestedCompany = new RequestedCompanyForm
//                    {
//                        Id = 585763229,
//                        Name = "TestValue407989105",
//                        PhoneNumber = "TestValue969736744",
//                        DomainName = "TestValue1885313119",
//                        Status = "TestValue1913469741",
//                        InsertedDate = DateTime.UtcNow,
//                        UpdatedDate = DateTime.UtcNow,
//                        Email = "TestValue1956814959",
//                        IsActive = (short)19410,
//                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
//                        Departments = new Mock<ICollection<Department>>().Object,
//                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
//                        Holidays = new Mock<ICollection<Holiday>>().Object,
//                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
//                        Positions = new Mock<ICollection<Position>>().Object
//                    },
//                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
//                },
//                EmployeeCredential = new EmployeeCredential
//                {
//                    Id = 1690404713,
//                    UserName = "TestValue2070177125",
//                    Password = "TestValue1507311416",
//                    Status = (short)27510,
//                    RequestedCompanyId = 1870406607,
//                    Email = "TestValue1943447430",
//                    DefaultPassword = false,
//                    GenerateOtp = "TestValue623889283",
//                    OtpExpiration = DateTime.UtcNow,
//                    IsActive = (short)9746,
//                    EmployeeLoginName = "TestValue560757938",
//                    RequestedCompany = new RequestedCompanyForm
//                    {
//                        Id = 736126637,
//                        Name = "TestValue2067602289",
//                        PhoneNumber = "TestValue962766846",
//                        DomainName = "TestValue433692331",
//                        Status = "TestValue1690966764",
//                        InsertedDate = DateTime.UtcNow,
//                        UpdatedDate = DateTime.UtcNow,
//                        Email = "TestValue438361131",
//                        IsActive = (short)23197,
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
//                },
//                Position = new Position
//                {
//                    Id = 1991327319,
//                    Name = "TestValue191989555",
//                    RequestedCompanyId = 251780446,
//                    IsActive = (short)29427,
//                    RequestedCompany = new RequestedCompanyForm
//                    {
//                        Id = 1650318120,
//                        Name = "TestValue557306000",
//                        PhoneNumber = "TestValue1882223749",
//                        DomainName = "TestValue1252114828",
//                        Status = "TestValue1004638086",
//                        InsertedDate = DateTime.UtcNow,
//                        UpdatedDate = DateTime.UtcNow,
//                        Email = "TestValue1698181861",
//                        IsActive = (short)3884,
//                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
//                        Departments = new Mock<ICollection<Department>>().Object,
//                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
//                        Holidays = new Mock<ICollection<Holiday>>().Object,
//                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
//                        Positions = new Mock<ICollection<Position>>().Object
//                    },
//                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
//                }
//            };

//     //       _empDetails.Setup(mock => mock.InsertEmployeeAsync(It.IsAny<EmployeeDetail>(), It.IsAny<int>())).ReturnsAsync("TestValue1293040207");

//            // Act
//      //      var result = await _testClass.InsertEmployee(employeeDetail);

//            // Assert
//       //     _empDetails.Verify(mock => mock.InsertEmployeeAsync(It.IsAny<EmployeeDetail>(), It.IsAny<int>()));

//            throw new NotImplementedException("Create or modify test");
//        }

//        [Fact]
//        public async Task CanCallUpdateEmployeeDetails()
//        {
//            // Arrange
//            var id = 1359795358;
//            var depId = 915423128;
//            var fname = "TestValue1337933572";
//            var mname = "TestValue1683632475";
//            var lname = "TestValue897327759";
//            var positionid = 1719395651;
//            var Designation = "TestValue73621867";
//            var Email = "TestValue1527610968";
//            var employeecredentialId = 1911403977;
//            var EmployeeNumber = "TestValue1721574219";
//            var requsetCompanyId = 641110688;

//      //      _empDetails.Setup(mock => mock.UpdateEmployeeDetail(It.IsAny<int>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<int?>())).ReturnsAsync(new EmployeeDetail
//            {
//                //Id = 885051102,
//                //DeptId = 787328213,
//                //FirstName = "TestValue1577618275",
//                //MiddleName = "TestValue471324298",
//                //LastName = "TestValue1276946517",
//                //PositionId = 1564626983,
//                //EmployeeCredentialId = 1567697561,
//                //EmployeeNumber = "TestValue1276791455",
//                //Email = "TestValue1346661886",
//                //RequestCompanyId = 1191998733,
//                //IsActive = (short)1903,
//                //ManagerId = 1074743188,
//                //NickName = "TestValue485723225",
//                //Extension = "TestValue718051558",
//                //MobileNumber = "TestValue1109187222",
//                //Dept = new Department
//                {
//                    //Id = 576475297,
//                    //Name = "TestValue385717891",
//                    //RequestedCompanyId = 965675226,
//                    //IsActive = (short)17199,
//                    //RequestedCompany = new RequestedCompanyForm
//                    //{
//                        Id = 1121606090,
//                        Name = "TestValue1042280112",
//                        PhoneNumber = "TestValue2117111621",
//                        DomainName = "TestValue1596878288",
//                        Status = "TestValue2041469447",
//                        InsertedDate = DateTime.UtcNow,
//                        UpdatedDate = DateTime.UtcNow,
//                        Email = "TestValue1721480186",
//                        IsActive = (short)26015,
//                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
//                        Departments = new Mock<ICollection<Department>>().Object,
//                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
//                        Holidays = new Mock<ICollection<Holiday>>().Object,
//                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
//                        Positions = new Mock<ICollection<Position>>().Object
//                    },
//                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
//                },
//                EmployeeCredential = new EmployeeCredential
//                {
//                    Id = 1491005116,
//                    UserName = "TestValue40086593",
//                    Password = "TestValue1512871125",
//                    Status = (short)27046,
//                    RequestedCompanyId = 550888045,
//                    Email = "TestValue865768521",
//                    DefaultPassword = true,
//                    GenerateOtp = "TestValue1855317499",
//                    OtpExpiration = DateTime.UtcNow,
//                    IsActive = (short)28782,
//                    EmployeeLoginName = "TestValue1998916316",
//                    RequestedCompany = new RequestedCompanyForm
//                    {
//                        Id = 1130623310,
//                        Name = "TestValue264802339",
//                        PhoneNumber = "TestValue790655772",
//                        DomainName = "TestValue1545623510",
//                        Status = "TestValue1013478417",
//                        InsertedDate = DateTime.UtcNow,
//                        UpdatedDate = DateTime.UtcNow,
//                        Email = "TestValue414175309",
//                        IsActive = (short)18907,
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
//                },
//          //      Position = new Position
//                {
//                    Id = 328343370,
//                    Name = "TestValue1866590289",
//                    RequestedCompanyId = 1264730014,
//                    IsActive = (short)29197,
//                    RequestedCompany = new RequestedCompanyForm
//                    {
//                        Id = 1210581234,
//                        Name = "TestValue541130898",
//                        PhoneNumber = "TestValue2128314350",
//                        DomainName = "TestValue1496505858",
//                        Status = "TestValue286439602",
//                        InsertedDate = DateTime.UtcNow,
//                        UpdatedDate = DateTime.UtcNow,
//                        Email = "TestValue2024905872",
//                        IsActive = (short)8797,
//                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
//                        Departments = new Mock<ICollection<Department>>().Object,
//                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
//                        Holidays = new Mock<ICollection<Holiday>>().Object,
//                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
//                        Positions = new Mock<ICollection<Position>>().Object
//                    },
//                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
//                }
//            });

//            // Act
//      //      var result = await _testClass.UpdateEmployeeDetails(id, depId, fname, mname, lname, positionid, Designation, Email, employeecredentialId, EmployeeNumber, requsetCompanyId);

//            // Assert
//      //      _empDetails.Verify(mock => mock.UpdateEmployeeDetail(It.IsAny<int>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<int?>()));

//            throw new NotImplementedException("Create or modify test");
//        }

//        [Fact]
//        public async Task CanCallDeleteEmpDetails()
//        {
//            // Arrange
//            var id = 829477619;

//            _empDetails.Setup(mock => mock.DeleteEmployeeDetail(It.IsAny<int>())).ReturnsAsync(false);

//            // Act
//            var result = await _testClass.DeleteEmpDetails(id);

//            // Assert
//            _empDetails.Verify(mock => mock.DeleteEmployeeDetail(It.IsAny<int>()));

//            throw new NotImplementedException("Create or modify test");
//        }

//        [Fact]
//        public void CanCallSoftDelete()
//        {
//            // Arrange
//            var id = 979213377;
//            var isActive = (short)19191;

//            _empDetails.Setup(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>())).Returns(true);

//            // Act
//            var result = _testClass.SoftDelete(id, isActive);

//            // Assert
//            _empDetails.Verify(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>()));

//            throw new NotImplementedException("Create or modify test");
//        }

//        [Fact]
//        public void CanCallGetAllEmployees()
//        {
//            // Arrange
//            _empDetails.Setup(mock => mock.GetAllEmployees()).Returns(new[] {
//                new EmployeeView
//                {
//                    EmployeeId = 1593335634,
//                    EmployeeName = "TestValue120915552",
//                    Address = "TestValue175019454",
//                    Gender = "TestValue1729075998",
//                    DOB = "TestValue108127673",
//                    Designation = "TestValue628104803",
//                    Manager = "TestValue877928729"
//                },
//                new EmployeeView
//                {
//                    EmployeeId = 1268534918,
//                    EmployeeName = "TestValue174879158",
//                    Address = "TestValue456750172",
//                    Gender = "TestValue1938977292",
//                    DOB = "TestValue280423882",
//                    Designation = "TestValue1646439342",
//                    Manager = "TestValue1532040422"
//                },
//                new EmployeeView
//                {
//                    EmployeeId = 276065456,
//                    EmployeeName = "TestValue264448443",
//                    Address = "TestValue988346296",
//                    Gender = "TestValue1816173445",
//                    DOB = "TestValue495522141",
//                    Designation = "TestValue970898700",
//                    Manager = "TestValue660982744"
//                }
//            });

//            // Act
//            var result = _testClass.GetAllEmployees();

//            // Assert
//            _empDetails.Verify(mock => mock.GetAllEmployees());

//            throw new NotImplementedException("Create or modify test");
//        }

//        [Fact]
//        public async Task CanCallGetEmployeeInfo()
//        {
//            // Arrange
//            var employeeCredentialId = 460138133;

//            _empDetails.Setup(mock => mock.GetEmployeeInfoAsync(It.IsAny<int>())).ReturnsAsync(new UpdateEmployeeInfoDTO
//            {
//                EmployeeCredentialId = 1594474482,
//                EmployeeName = "TestValue1514958227",
//                NickName = "TestValue1218743768",
//                EmailAddress = "TestValue1472001643",
//                EmpLoginName = "TestValue1633351096",
//                MobileNumber = "TestValue650254979",
//                Extension = "TestValue1665092320",
//                gender = "TestValue1834716329"
//            });

//            // Act
//            var result = await _testClass.GetEmployeeInfo(employeeCredentialId);

//            // Assert
//            _empDetails.Verify(mock => mock.GetEmployeeInfoAsync(It.IsAny<int>()));

//            throw new NotImplementedException("Create or modify test");
//        }

//        [Fact]
//        public async Task CanCallGetEmployeePersonalInfo()
//        {
//            // Arrange
//            var employeeCredentialId = 1940681632;

//            _empDetails.Setup(mock => mock.GetEmployeePersonalInfoAsync(It.IsAny<int>())).ReturnsAsync(new EmpPersonalInfoDTO
//            {
//                FirstName = "TestValue435252395",
//                MiddleName = "TestValue1135651495",
//                LastName = "TestValue231367857",
//                EmployeeCredentialId = 1430859992,
//                Dob = DateTime.UtcNow,
//                DateOfJoining = DateTime.UtcNow,
//                ConfirmDate = DateTime.UtcNow,
//                EmpStatus = "TestValue534978716",
//                EmailId = "TestValue1375590306",
//                PersonalEmail = "TestValue111420148",
//                MaritalStatus = "TestValue295829874",
//                BloodGroup = "TestValue468448098",
//                SpouseName = "TestValue731690555",
//                PhysicallyChallenged = true,
//                EmergencyContact = "TestValue69398654",
//                PAN = "TestValue1508753317",
//                Gender = "TestValue440577587",
//                Contact = "TestValue1927902006"
//            });

//            // Act
//            var result = await _testClass.GetEmployeePersonalInfo(employeeCredentialId);

//            // Assert
//            _empDetails.Verify(mock => mock.GetEmployeePersonalInfoAsync(It.IsAny<int>()));

//            throw new NotImplementedException("Create or modify test");
//        }

//        [Fact]
//        public async Task CanCallGetEmployeeAddressInfo()
//        {
//            // Arrange
//            var employeeCredentialId = 596771809;

//            _empDetails.Setup(mock => mock.GetEmployeeAddressInfoAsync(It.IsAny<int>())).ReturnsAsync(new AddressInfoDTO
//            {
//                EmployeeCredentialId = 2028655273,
//                AddressLine1 = "TestValue379363555",
//                AddressLine2 = "TestValue1445508763",
//                City = "TestValue376662245",
//                State = "TestValue418105860",
//                Country = "TestValue1160787821",
//                PinCode = "TestValue282367232",
//                IsActive = (short)126
//            });

//            // Act
//            var result = await _testClass.GetEmployeeAddressInfo(employeeCredentialId);

//            // Assert
//            _empDetails.Verify(mock => mock.GetEmployeeAddressInfoAsync(It.IsAny<int>()));

//            throw new NotImplementedException("Create or modify test");
//        }

//        [Fact]
//        public async Task CanCallGetEmployeeAccountInfo()
//        {
//            // Arrange
//            var employeeCredentialId = 834088183;

//            _empDetails.Setup(mock => mock.GetEmployeeAccountInfoAsync(It.IsAny<int>())).ReturnsAsync(new AccountDetail
//            {
//                Id = 2146344799,
//                EmployeeCredentialId = 753440972,
//                AccountNumber = "TestValue1103759333",
//                IfscCode = "TestValue257074355",
//                AccountType = "TestValue622260224",
//                BankName = "TestValue2125333471",
//                BranchName = "TestValue1360320056",
//                AadharNumber = "TestValue1581302236",
//                PfNumber = "TestValue1862224672",
//                UanNumber = "TestValue21497777",
//                PfJoiningDate = DateTime.UtcNow,
//                EligibleForPf = true,
//                IsActive = (short)748,
//                Country = "TestValue215579350",
//                State = "TestValue997061706",
//                City = "TestValue1047958797",
//                Pin = 153028295,
//                EmployeeCredential = new EmployeeCredential
//                {
//                    Id = 692516422,
//                    UserName = "TestValue1347725347",
//                    Password = "TestValue1911315233",
//                    Status = (short)14242,
//                    RequestedCompanyId = 591584090,
//                    Email = "TestValue85721165",
//                    DefaultPassword = false,
//                    GenerateOtp = "TestValue1438325409",
//                    OtpExpiration = DateTime.UtcNow,
//                    IsActive = (short)25615,
//                    EmployeeLoginName = "TestValue1752179470",
//                    RequestedCompany = new RequestedCompanyForm
//                    {
//                        Id = 270891424,
//                        Name = "TestValue219583557",
//                        PhoneNumber = "TestValue1458054084",
//                        DomainName = "TestValue42032273",
//                        Status = "TestValue1421948221",
//                        InsertedDate = DateTime.UtcNow,
//                        UpdatedDate = DateTime.UtcNow,
//                        Email = "TestValue853284263",
//                        IsActive = (short)3403,
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
//            });

//            // Act
//            var result = await _testClass.GetEmployeeAccountInfo(employeeCredentialId);

//            // Assert
//            _empDetails.Verify(mock => mock.GetEmployeeAccountInfoAsync(It.IsAny<int>()));

//            throw new NotImplementedException("Create or modify test");
//        }

//        [Fact]
//        public void CanCallGet()
//        {
//            // Arrange
//            var globalsearch = new GlobalsearchEmp { FilterBy = "TestValue536117564" };

//            _empDetails.Setup(mock => mock.GetFilters(It.IsAny<GlobalsearchEmp>())).Returns(new List<EmployeeDetail>());

//            // Act
//            var result = _testClass.Get(globalsearch);

//            // Assert
//            _empDetails.Verify(mock => mock.GetFilters(It.IsAny<GlobalsearchEmp>()));

//            throw new NotImplementedException("Create or modify test");
//        }

//        [Fact]
//        public async Task CanCallUpdateEmployeeInfo()
//        {
//            // Arrange
//            var updateEmployeeInfo = new UpdateEmployeeInfoDTO
//            {
//                EmployeeCredentialId = 1155144462,
//                EmployeeName = "TestValue38755519",
//                NickName = "TestValue1993671521",
//                EmailAddress = "TestValue753840731",
//                EmpLoginName = "TestValue824657990",
//                MobileNumber = "TestValue635580065",
//                Extension = "TestValue1794012292",
//                gender = "TestValue419079810"
//            };

//            _empDetails.Setup(mock => mock.UpdateEmployeeInfoAsync(It.IsAny<UpdateEmployeeInfoDTO>())).ReturnsAsync(false);

//            // Act
//            var result = await _testClass.UpdateEmployeeInfo(updateEmployeeInfo);

//            // Assert
//            _empDetails.Verify(mock => mock.UpdateEmployeeInfoAsync(It.IsAny<UpdateEmployeeInfoDTO>()));

//            throw new NotImplementedException("Create or modify test");
//        }

//        [Fact]
//        public async Task CanCallUpdateEmployeePersonalInfo()
//        {
//            // Arrange
//            var empPersonalInfoDTO = new EmpPersonalInfoDTO
//            {
//                FirstName = "TestValue1891625607",
//                MiddleName = "TestValue1813075923",
//                LastName = "TestValue1529785496",
//                EmployeeCredentialId = 397549966,
//                Dob = DateTime.UtcNow,
//                DateOfJoining = DateTime.UtcNow,
//                ConfirmDate = DateTime.UtcNow,
//                EmpStatus = "TestValue223633950",
//                EmailId = "TestValue1873073085",
//                PersonalEmail = "TestValue1960546121",
//                MaritalStatus = "TestValue518535646",
//                BloodGroup = "TestValue1222394023",
//                SpouseName = "TestValue5187719",
//                PhysicallyChallenged = false,
//                EmergencyContact = "TestValue1826543979",
//                PAN = "TestValue1812917571",
//                Gender = "TestValue725754344",
//                Contact = "TestValue1017564401"
//            };

//            _empDetails.Setup(mock => mock.UpdateEmployeepersonalInfoAsync(It.IsAny<EmpPersonalInfoDTO>())).ReturnsAsync(true);

//            // Act
//            var result = await _testClass.UpdateEmployeePersonalInfo(empPersonalInfoDTO);

//            // Assert
//            _empDetails.Verify(mock => mock.UpdateEmployeepersonalInfoAsync(It.IsAny<EmpPersonalInfoDTO>()));

//            throw new NotImplementedException("Create or modify test");
//        }

//        [Fact]
//        public async Task CanCallUpdateEmployeeAddressInfo()
//        {
//            // Arrange
//            var addressInfo = new AddressInfoDTO
//            {
//                EmployeeCredentialId = 1140736499,
//                AddressLine1 = "TestValue123248152",
//                AddressLine2 = "TestValue1820192399",
//                City = "TestValue747033203",
//                State = "TestValue2097525181",
//                Country = "TestValue1973486492",
//                PinCode = "TestValue1528974814",
//                IsActive = (short)7033
//            };

//            _empDetails.Setup(mock => mock.UpdateEmployeeAddresslInfoAsync(It.IsAny<AddressInfoDTO>())).ReturnsAsync(true);

//            // Act
//            var result = await _testClass.UpdateEmployeeAddressInfo(addressInfo);

//            // Assert
//            _empDetails.Verify(mock => mock.UpdateEmployeeAddresslInfoAsync(It.IsAny<AddressInfoDTO>()));

//            throw new NotImplementedException("Create or modify test");
//        }

//        [Fact]
//        public async Task CanCallUpdateEmployeeAccountInfo()
//        {
//            // Arrange
//            var accountDetail = new AccountDetail
//            {
//                Id = 1145367480,
//                EmployeeCredentialId = 653760903,
//                AccountNumber = "TestValue1501537473",
//                IfscCode = "TestValue1157474502",
//                AccountType = "TestValue108746311",
//                BankName = "TestValue2103487672",
//                BranchName = "TestValue439192520",
//                AadharNumber = "TestValue655300830",
//                PfNumber = "TestValue313749200",
//                UanNumber = "TestValue1934661698",
//                PfJoiningDate = DateTime.UtcNow,
//                EligibleForPf = false,
//                IsActive = (short)13558,
//                Country = "TestValue1969517238",
//                State = "TestValue1234420134",
//                City = "TestValue316442835",
//                Pin = 1608885747,
//                EmployeeCredential = new EmployeeCredential
//                {
//                    Id = 334748617,
//                    UserName = "TestValue1148142804",
//                    Password = "TestValue828900464",
//                    Status = (short)9505,
//                    RequestedCompanyId = 943089002,
//                    Email = "TestValue1489710538",
//                    DefaultPassword = false,
//                    GenerateOtp = "TestValue976107120",
//                    OtpExpiration = DateTime.UtcNow,
//                    IsActive = (short)15973,
//                    EmployeeLoginName = "TestValue1831405138",
//                    RequestedCompany = new RequestedCompanyForm
//                    {
//                        Id = 512331913,
//                        Name = "TestValue2121303540",
//                        PhoneNumber = "TestValue1819530254",
//                        DomainName = "TestValue1174534675",
//                        Status = "TestValue2065622762",
//                        InsertedDate = DateTime.UtcNow,
//                        UpdatedDate = DateTime.UtcNow,
//                        Email = "TestValue284101109",
//                        IsActive = (short)16308,
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

//            _empDetails.Setup(mock => mock.UpdateEmployeeAccountInfoAsync(It.IsAny<AccountDetail>())).ReturnsAsync(true);

//            // Act
//            var result = await _testClass.UpdateEmployeeAccountInfo(accountDetail);

//            // Assert
//            _empDetails.Verify(mock => mock.UpdateEmployeeAccountInfoAsync(It.IsAny<AccountDetail>()));

//            throw new NotImplementedException("Create or modify test");
//        }

//        [Fact]
//        public void CanCallGetEmployeeShiftAndLeaveStats()
//        {
//            // Arrange
//            _empDetails.Setup(mock => mock.GetEmployeeShiftAndLeaveStats(It.IsAny<int>())).Returns(new EmployeeShiftAndLeaveStatsDto
//            {
//                ShiftType = "TestValue2119224150",
//                ShiftTimeRange = "TestValue1225750117",
//                TotalLeaveCount = 1219312182,
//                RemainingLeaveCount = 459008648,
//                LeavePercentage = 1493459343.09
//            });

//            // Act
//            var result = _testClass.GetEmployeeShiftAndLeaveStats();

//            // Assert
//            _empDetails.Verify(mock => mock.GetEmployeeShiftAndLeaveStats(It.IsAny<int>()));

//            throw new NotImplementedException("Create or modify test");
//        }
//    }
//}