namespace TestProject1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.Controllers;
    using HRMS_Application.Models;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class EmpDetailsControllerTests
    {
        private EmpDetailsController _testClass;
        private Mock<IEmpDetails> _empDetails;
        private Mock<ILogger<EmpDetailsController>> _logger;

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
            var id = 718822108;

            _empDetails.Setup(mock => mock.GetById(It.IsAny<int>())).Returns(new EmployeeDetail
            {
                Id = 489248335,
                DeptId = 417176182,
                MobileNumber = "TestValue1349552739",
                FirstName = "TestValue841591450",
                MiddleName = "TestValue1430882118",
                LastName = "TestValue1463884761",
                PositionId = 536857320,
                NickName = "TestValue1819332057",
                Gender = "TestValue1158565302",
                EmployeeCredentialId = 36700279,
                Dept = new Department
                {
                    Id = 223118042,
                    Name = "TestValue2092135120",
                    RequestedCompanyId = 772608315,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 855085565,
                        Name = "TestValue592519998",
                        PhoneNumber = "TestValue626902351",
                        DomainName = "TestValue995399284",
                        Status = "TestValue1692748056",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = default(Department),
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                },
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1909604070,
                    UserName = "TestValue174322938",
                    Password = "TestValue2059582571",
                    Status = (short)11513,
                    RequestedCompanyId = 950873557,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 245889404,
                        Name = "TestValue1196613686",
                        PhoneNumber = "TestValue1329456447",
                        DomainName = "TestValue1698353753",
                        Status = "TestValue836925778",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 1691853232,
                            Name = "TestValue1482016985",
                            RequestedCompanyId = 892180356,
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
                },
                Position = new Position
                {
                    Id = 2047562247,
                    Name = "TestValue409619380",
                    RequestedCompanyId = 1297150106,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 2069795323,
                        Name = "TestValue1531947465",
                        PhoneNumber = "TestValue1394156025",
                        DomainName = "TestValue1673552705",
                        Status = "TestValue1147743542",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 1692192621,
                            Name = "TestValue867999129",
                            RequestedCompanyId = 1158113578,
                            RequestedCompany = default(RequestedCompanyForm),
                            EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                        },
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
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
        public async Task CanCallInsertEmpDetails()
        {
            // Arrange
            var employeeDetail = new EmployeeDetail
            {
                Id = 199940483,
                DeptId = 214296962,
                MobileNumber = "TestValue887692965",
                FirstName = "TestValue597432974",
                MiddleName = "TestValue655462597",
                LastName = "TestValue1269744114",
                PositionId = 1865097284,
                NickName = "TestValue1128365220",
                Gender = "TestValue2069357264",
                EmployeeCredentialId = 2044644970,
                Dept = new Department
                {
                    Id = 600251331,
                    Name = "TestValue1882149232",
                    RequestedCompanyId = 1613786272,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1103663335,
                        Name = "TestValue1792461411",
                        PhoneNumber = "TestValue101425671",
                        DomainName = "TestValue1913014655",
                        Status = "TestValue1847415189",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = default(Department),
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                },
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 127478825,
                    UserName = "TestValue1824031964",
                    Password = "TestValue1292003570",
                    Status = (short)4929,
                    RequestedCompanyId = 1682515740,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1622941856,
                        Name = "TestValue932773889",
                        PhoneNumber = "TestValue1208056180",
                        DomainName = "TestValue1380229973",
                        Status = "TestValue1469330226",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 545004514,
                            Name = "TestValue217411449",
                            RequestedCompanyId = 1453807456,
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
                },
                Position = new Position
                {
                    Id = 901468993,
                    Name = "TestValue35760642",
                    RequestedCompanyId = 815613637,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 45948921,
                        Name = "TestValue982316724",
                        PhoneNumber = "TestValue441763482",
                        DomainName = "TestValue1100920779",
                        Status = "TestValue181463181",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 422109118,
                            Name = "TestValue1764403348",
                            RequestedCompanyId = 1911298783,
                            RequestedCompany = default(RequestedCompanyForm),
                            EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                        },
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                }
            };

            _empDetails.Setup(mock => mock.InsertEmployeeDetail(It.IsAny<EmployeeDetail>())).ReturnsAsync("TestValue135259920");

            // Act
            var result = await _testClass.InsertEmpDetails(employeeDetail);

            // Assert
            _empDetails.Verify(mock => mock.InsertEmployeeDetail(It.IsAny<EmployeeDetail>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmpDetails()
        {
            // Arrange
            var id = 438233483;
            var depId = 285739869;
            var mobilenumber = "TestValue2018317887";
            var fname = "TestValue1140970498";
            var mname = "TestValue1972357287";
            var lname = "TestValue169047880";
            var positionid = 303051855;
            var nickname = "TestValue1177012373";
            var gender = "TestValue1436261694";
            var employeecredentialId = 734056764;

            _empDetails.Setup(mock => mock.UpdateEmployeeDetail(It.IsAny<int>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int?>())).ReturnsAsync(new EmployeeDetail
            {
                Id = 2125688630,
                DeptId = 512458057,
                MobileNumber = "TestValue696898775",
                FirstName = "TestValue187646091",
                MiddleName = "TestValue2065644840",
                LastName = "TestValue290492690",
                PositionId = 2028574941,
                NickName = "TestValue1046317871",
                Gender = "TestValue1926661613",
                EmployeeCredentialId = 1168067587,
                Dept = new Department
                {
                    Id = 1030634753,
                    Name = "TestValue1042273791",
                    RequestedCompanyId = 990739997,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 2024384688,
                        Name = "TestValue679264869",
                        PhoneNumber = "TestValue1412234756",
                        DomainName = "TestValue1812142732",
                        Status = "TestValue1594890064",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = default(Department),
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                },
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 2036997788,
                    UserName = "TestValue395767058",
                    Password = "TestValue583360706",
                    Status = (short)28257,
                    RequestedCompanyId = 590837514,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1846265985,
                        Name = "TestValue1846388590",
                        PhoneNumber = "TestValue798172635",
                        DomainName = "TestValue1057714414",
                        Status = "TestValue810144687",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 1807145836,
                            Name = "TestValue812093876",
                            RequestedCompanyId = 1665952008,
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
                },
                Position = new Position
                {
                    Id = 1852853354,
                    Name = "TestValue59628615",
                    RequestedCompanyId = 1528188434,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 344834459,
                        Name = "TestValue1170057683",
                        PhoneNumber = "TestValue926043081",
                        DomainName = "TestValue745127798",
                        Status = "TestValue1289894987",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 1089737283,
                            Name = "TestValue1588238932",
                            RequestedCompanyId = 1646170290,
                            RequestedCompany = default(RequestedCompanyForm),
                            EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                        },
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                }
            });

            // Act
            var result = await _testClass.UpdateEmpDetails(id, depId, mobilenumber, fname, mname, lname, positionid, nickname, gender, employeecredentialId);

            // Assert
            _empDetails.Verify(mock => mock.UpdateEmployeeDetail(It.IsAny<int>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int?>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallDeleteEmpDetails()
        {
            // Arrange
            var id = 1368636290;

            _empDetails.Setup(mock => mock.DeleteEmployeeDetail(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _testClass.DeleteEmpDetails(id);

            // Assert
            _empDetails.Verify(mock => mock.DeleteEmployeeDetail(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}