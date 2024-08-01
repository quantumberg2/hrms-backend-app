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

    public class EmployeeLeaveControllerTests
    {
        private EmployeeLeaveController _testClass;
        private Mock<IEmployeeLeave> _employeeLeave;
        private Mock<ILogger<EmployeeLeaveController>> _logger;

        public EmployeeLeaveControllerTests()
        {
            _employeeLeave = new Mock<IEmployeeLeave>();
            _logger = new Mock<ILogger<EmployeeLeaveController>>();
            _testClass = new EmployeeLeaveController(_employeeLeave.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new EmployeeLeaveController(_employeeLeave.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllEmpleaves()
        {
            // Arrange
            _employeeLeave.Setup(mock => mock.GetAllEmpLeave()).Returns(new List<EmployeeLeave>());

            // Act
            var result = _testClass.GetAllEmpleaves();

            // Assert
            _employeeLeave.Verify(mock => mock.GetAllEmpLeave());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetById()
        {
            // Arrange
            var id = 1348591516;

            _employeeLeave.Setup(mock => mock.GetByEmpLeavebyId(It.IsAny<int>())).Returns(new EmployeeLeave
            {
                Id = 1595468537,
                EmployeeCredentialId = 1906930690,
                LeaveId = 625124123,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                Session = "TestValue1563998387",
                TotalDays = 1249270279,
                Contact = "TestValue2026021705",
                ReasonForLeave = "TestValue1623125114",
                Files = "TestValue1619110833",
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1722119330,
                    UserName = "TestValue101511993",
                    Password = "TestValue425234771",
                    Status = (short)8568,
                    RequestedCompanyId = 2147223077,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 952799472,
                        Name = "TestValue1745263756",
                        PhoneNumber = "TestValue1137737916",
                        DomainName = "TestValue1414614531",
                        Status = "TestValue113474509",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 1720025843,
                            Name = "TestValue1357595992",
                            RequestedCompanyId = 523125694,
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
                Leave = new LeaveType
                {
                    Id = 1580532218,
                    LeaveType1 = "TestValue92436370",
                    Days = 246443632,
                    CompanyId = 1254237556,
                    Company = new CompanyDetail
                    {
                        Id = 723218766,
                        Name = "TestValue1015256581",
                        Address = "TestValue176481123",
                        Country = "TestValue1745388365",
                        States = "TestValue2128125033",
                        Industry = "TestValue2077367955",
                        TimeZone = "TestValue1906514061",
                        Currency = "TestValue1334807317",
                        PfNo = "TestValue1241479605",
                        TanNo = "TestValue506471962",
                        EsiNo = "TestValue1840327063",
                        PanNo = "TestValue594702631",
                        GstNo = "TestValue1033403028",
                        RegistrationNo = "TestValue420077675",
                        Twitter = "TestValue1028717873",
                        Facebook = "TestValue716401546",
                        LinkedIn = "TestValue1773830631",
                        CompanyLogo = "TestValue278902",
                        RequestedCompanyId = 106983727,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 519510850,
                            Name = "TestValue1827432177",
                            PhoneNumber = "TestValue1441226975",
                            DomainName = "TestValue1276491541",
                            Status = "TestValue1938631582",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Department = new Department
                            {
                                Id = 1471995570,
                                Name = "TestValue212672639",
                                RequestedCompanyId = 1541242616,
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
                    EmployeeAttendances = new Mock<ICollection<EmployeeAttendance>>().Object,
                    EmployeeLeaves = new Mock<ICollection<EmployeeLeave>>().Object
                }
            });

            // Act
            var result = _testClass.GetById(id);

            // Assert
            _employeeLeave.Verify(mock => mock.GetByEmpLeavebyId(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertEmpLeaves()
        {
            // Arrange
            var employeeLeave = new EmployeeLeave
            {
                Id = 248925847,
                EmployeeCredentialId = 14936319,
                LeaveId = 1814494320,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                Session = "TestValue378680491",
                TotalDays = 309760831,
                Contact = "TestValue526051513",
                ReasonForLeave = "TestValue1010765124",
                Files = "TestValue1446643991",
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 2021206115,
                    UserName = "TestValue1741477944",
                    Password = "TestValue171627685",
                    Status = (short)10165,
                    RequestedCompanyId = 1374208460,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 905743472,
                        Name = "TestValue446327510",
                        PhoneNumber = "TestValue2052420340",
                        DomainName = "TestValue543035285",
                        Status = "TestValue381211503",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 1840880481,
                            Name = "TestValue691307970",
                            RequestedCompanyId = 641194446,
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
                Leave = new LeaveType
                {
                    Id = 896778710,
                    LeaveType1 = "TestValue1580253316",
                    Days = 2132936290,
                    CompanyId = 1874416429,
                    Company = new CompanyDetail
                    {
                        Id = 1574289026,
                        Name = "TestValue1429475438",
                        Address = "TestValue1886248687",
                        Country = "TestValue385333188",
                        States = "TestValue273392795",
                        Industry = "TestValue1915452394",
                        TimeZone = "TestValue536125339",
                        Currency = "TestValue557922545",
                        PfNo = "TestValue2043606917",
                        TanNo = "TestValue992553758",
                        EsiNo = "TestValue491535643",
                        PanNo = "TestValue25832743",
                        GstNo = "TestValue216022140",
                        RegistrationNo = "TestValue723642197",
                        Twitter = "TestValue2041509809",
                        Facebook = "TestValue17952749",
                        LinkedIn = "TestValue1417241202",
                        CompanyLogo = "TestValue1900108163",
                        RequestedCompanyId = 406284605,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 2082839689,
                            Name = "TestValue2000790140",
                            PhoneNumber = "TestValue453223717",
                            DomainName = "TestValue535483503",
                            Status = "TestValue830164031",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Department = new Department
                            {
                                Id = 2033694889,
                                Name = "TestValue928960285",
                                RequestedCompanyId = 1978944783,
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
                    EmployeeAttendances = new Mock<ICollection<EmployeeAttendance>>().Object,
                    EmployeeLeaves = new Mock<ICollection<EmployeeLeave>>().Object
                }
            };

            _employeeLeave.Setup(mock => mock.InsertEmployeeLeave(It.IsAny<EmployeeLeave>())).ReturnsAsync("TestValue1438684047");

            // Act
            var result = await _testClass.InsertEmpLeaves(employeeLeave);

            // Assert
            _employeeLeave.Verify(mock => mock.InsertEmployeeLeave(It.IsAny<EmployeeLeave>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallDeleteEmpDetails()
        {
            // Arrange
            var id = 657283546;

            _employeeLeave.Setup(mock => mock.DeleteEmployeeLeave(It.IsAny<int>())).ReturnsAsync(false);

            // Act
            var result = await _testClass.DeleteEmpDetails(id);

            // Assert
            _employeeLeave.Verify(mock => mock.DeleteEmployeeLeave(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}