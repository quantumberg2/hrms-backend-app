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