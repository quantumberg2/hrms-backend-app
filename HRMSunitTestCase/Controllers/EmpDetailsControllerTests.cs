namespace HRMSunitTestCase.Controllers
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
            var id = 1709017043;

            _empDetails.Setup(mock => mock.GetById(It.IsAny<int>())).Returns(new EmployeeDetail
            {
                Id = 1925705982,
                DeptId = 399729214,
                MobileNumber = "TestValue2032690273",
                FirstName = "TestValue1075317075",
                MiddleName = "TestValue1317450155",
                LastName = "TestValue146223936",
                PositionId = 997430103,
                NickName = "TestValue1947260812",
                Gender = "TestValue164049786",
                EmployeeCredentialId = 15719200,
                Dept = new Department
                {
                    Id = 1506647949,
                    Name = "TestValue120308911",
                    RequestedCompanyId = 1707870791,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1574849483,
                        Name = "TestValue279164019",
                        PhoneNumber = "TestValue1787866985",
                        DomainName = "TestValue684356932",
                        Status = "TestValue1597457449",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue371966522",
                        Department = default(Department),
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                },
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1114104468,
                    UserName = "TestValue1025196898",
                    Password = "TestValue1292142159",
                    Status = (short)18291,
                    RequestedCompanyId = 1832754278,
                    Email = "TestValue1723823487",
                    DefaultPassword = true,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1126284693,
                        Name = "TestValue1918898712",
                        PhoneNumber = "TestValue746358527",
                        DomainName = "TestValue1827106961",
                        Status = "TestValue274235892",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue877102270",
                        Department = new Department
                        {
                            Id = 1061242495,
                            Name = "TestValue14834223",
                            RequestedCompanyId = 1927501635,
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
                Position = new Position
                {
                    Id = 274771363,
                    Name = "TestValue343491754",
                    RequestedCompanyId = 111102663,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1046079799,
                        Name = "TestValue2081518367",
                        PhoneNumber = "TestValue1766436378",
                        DomainName = "TestValue1842707281",
                        Status = "TestValue826351452",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1010445654",
                        Department = new Department
                        {
                            Id = 256383826,
                            Name = "TestValue282039632",
                            RequestedCompanyId = 390428971,
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
                Id = 191528213,
                DeptId = 1902059992,
                MobileNumber = "TestValue739778469",
                FirstName = "TestValue347669721",
                MiddleName = "TestValue1615622810",
                LastName = "TestValue1310835476",
                PositionId = 633563823,
                NickName = "TestValue1348414080",
                Gender = "TestValue199935995",
                EmployeeCredentialId = 1498977235,
                Dept = new Department
                {
                    Id = 1619899507,
                    Name = "TestValue1167422890",
                    RequestedCompanyId = 1226015038,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1200902285,
                        Name = "TestValue484426472",
                        PhoneNumber = "TestValue1888966955",
                        DomainName = "TestValue629545679",
                        Status = "TestValue1206550063",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1693036568",
                        Department = default(Department),
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                },
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1794831495,
                    UserName = "TestValue4392656",
                    Password = "TestValue1444375231",
                    Status = (short)8746,
                    RequestedCompanyId = 551377650,
                    Email = "TestValue437931802",
                    DefaultPassword = true,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1329973264,
                        Name = "TestValue465790707",
                        PhoneNumber = "TestValue188353127",
                        DomainName = "TestValue1576370452",
                        Status = "TestValue1441783855",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1454605324",
                        Department = new Department
                        {
                            Id = 1564751297,
                            Name = "TestValue572130887",
                            RequestedCompanyId = 554830314,
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
                Position = new Position
                {
                    Id = 2072530616,
                    Name = "TestValue1681941070",
                    RequestedCompanyId = 529432549,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1593103332,
                        Name = "TestValue851482394",
                        PhoneNumber = "TestValue1293937812",
                        DomainName = "TestValue1073840930",
                        Status = "TestValue143555759",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue759609075",
                        Department = new Department
                        {
                            Id = 1573663939,
                            Name = "TestValue914095477",
                            RequestedCompanyId = 540421340,
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

            _empDetails.Setup(mock => mock.InsertEmployeeDetail(It.IsAny<EmployeeDetail>())).ReturnsAsync("TestValue1346767825");

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
            var id = 870620182;
            var depId = 1126164696;
            var mobilenumber = "TestValue2061263624";
            var fname = "TestValue1519990216";
            var mname = "TestValue702415695";
            var lname = "TestValue1408369756";
            var positionid = 1311423884;
            var nickname = "TestValue2034020836";
            var gender = "TestValue2143216672";
            var employeecredentialId = 1930029124;

            _empDetails.Setup(mock => mock.UpdateEmployeeDetail(It.IsAny<int>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int?>())).ReturnsAsync(new EmployeeDetail
            {
                Id = 641804996,
                DeptId = 341924980,
                MobileNumber = "TestValue1268962346",
                FirstName = "TestValue1774321794",
                MiddleName = "TestValue1222973216",
                LastName = "TestValue844876050",
                PositionId = 2061669195,
                NickName = "TestValue1342375169",
                Gender = "TestValue894636629",
                EmployeeCredentialId = 1328805723,
                Dept = new Department
                {
                    Id = 188400819,
                    Name = "TestValue2057221566",
                    RequestedCompanyId = 120471073,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 2128345859,
                        Name = "TestValue167773116",
                        PhoneNumber = "TestValue1160060953",
                        DomainName = "TestValue771049190",
                        Status = "TestValue57193380",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue165294183",
                        Department = default(Department),
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                },
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1750155240,
                    UserName = "TestValue653884151",
                    Password = "TestValue646071971",
                    Status = (short)8535,
                    RequestedCompanyId = 207025885,
                    Email = "TestValue100113130",
                    DefaultPassword = false,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 841554174,
                        Name = "TestValue500893683",
                        PhoneNumber = "TestValue1078035373",
                        DomainName = "TestValue1300819472",
                        Status = "TestValue1961128841",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1125197358",
                        Department = new Department
                        {
                            Id = 1671319972,
                            Name = "TestValue954730397",
                            RequestedCompanyId = 688168268,
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
                Position = new Position
                {
                    Id = 123865727,
                    Name = "TestValue1066874428",
                    RequestedCompanyId = 1949532305,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 218810639,
                        Name = "TestValue609729274",
                        PhoneNumber = "TestValue1650565749",
                        DomainName = "TestValue1377239365",
                        Status = "TestValue1807677332",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue743724893",
                        Department = new Department
                        {
                            Id = 1493540251,
                            Name = "TestValue619694630",
                            RequestedCompanyId = 1472632259,
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
            var id = 1674208664;

            _empDetails.Setup(mock => mock.DeleteEmployeeDetail(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _testClass.DeleteEmpDetails(id);

            // Assert
            _empDetails.Verify(mock => mock.DeleteEmployeeDetail(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}