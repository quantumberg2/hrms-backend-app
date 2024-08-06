namespace HRMSunitTestCase.BusinessLogic.Implements
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HRMS_Application.Authorization;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.Models;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class EmployeeAttendanceImpTests
    {
        private EmployeeAttendanceImp _testClass;
        private HRMSContext _hrmscontext;
        private Mock<IHttpContextAccessor> _httpContextAccessor;
        private Mock<IJwtUtils> _jwtUtils;

        public EmployeeAttendanceImpTests()
        {
            _hrmscontext = new HRMSContext();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _jwtUtils = new Mock<IJwtUtils>();
            _testClass = new EmployeeAttendanceImp(_hrmscontext, _httpContextAccessor.Object, _jwtUtils.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new EmployeeAttendanceImp(_hrmscontext, _httpContextAccessor.Object, _jwtUtils.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallDeleteEmployeeAttendance()
        {
            // Arrange
            var id = 1039983779;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(2002962097);

            // Act
            var result = await _testClass.DeleteEmployeeAttendance(id);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAllEmpAttendence()
        {
            // Act
            var result = _testClass.GetAllEmpAttendence();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetById()
        {
            // Arrange
            var id = 479744605;

            // Act
            var result = _testClass.GetById(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertEmployeeAttendence()
        {
            // Arrange
            var employeeAttendence = new EmployeeAttendance
            {
                Id = 1082041836,
                EmployeeCredentialId = 1839064932,
                LeaveId = 974942292,
                HolidayId = 631181465,
                TimeIn = DateTime.UtcNow,
                TimeOut = DateTime.UtcNow,
                Remarks = "TestValue1760997718",
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1224880134,
                    UserName = "TestValue1465998257",
                    Password = "TestValue1292391411",
                    Status = (short)5357,
                    RequestedCompanyId = 1642608700,
                    Email = "TestValue1354840961",
                    DefaultPassword = true,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 247475390,
                        Name = "TestValue1156894027",
                        PhoneNumber = "TestValue246212743",
                        DomainName = "TestValue429987708",
                        Status = "TestValue984327022",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1281705900",
                        Department = new Department
                        {
                            Id = 1897515483,
                            Name = "TestValue1008313516",
                            RequestedCompanyId = 1491962231,
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
                Holiday = new Holiday
                {
                    Id = 2050546498,
                    Occasion = "TestValue2111270150",
                    Date = DateTime.UtcNow,
                    Day = "TestValue126458571",
                    RestrictedHoliday = true,
                    CompanyId = 1443711129,
                    EmployeecredentialId = 1097992303,
                    Company = new CompanyDetail
                    {
                        Id = 1403533498,
                        Name = "TestValue1508473393",
                        Address = "TestValue2040209619",
                        Country = "TestValue1070967240",
                        States = "TestValue255992350",
                        Industry = "TestValue612024720",
                        TimeZone = "TestValue2019621995",
                        Currency = "TestValue1862754484",
                        PfNo = "TestValue1956280762",
                        TanNo = "TestValue1349953852",
                        EsiNo = "TestValue397901685",
                        PanNo = "TestValue1811684595",
                        GstNo = "TestValue1192692989",
                        RegistrationNo = "TestValue1800234877",
                        Twitter = "TestValue1489170401",
                        Facebook = "TestValue280818190",
                        LinkedIn = "TestValue1420872259",
                        CompanyLogo = "TestValue366238968",
                        RequestedCompanyId = 706134559,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 580653360,
                            Name = "TestValue1368602070",
                            PhoneNumber = "TestValue629597625",
                            DomainName = "TestValue1807645963",
                            Status = "TestValue2021081911",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue721256197",
                            Department = new Department
                            {
                                Id = 1289951943,
                                Name = "TestValue1618914736",
                                RequestedCompanyId = 417706032,
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
                        Id = 1178978985,
                        UserName = "TestValue1875278429",
                        Password = "TestValue848483721",
                        Status = (short)4325,
                        RequestedCompanyId = 317286589,
                        Email = "TestValue126887831",
                        DefaultPassword = true,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 1931401665,
                            Name = "TestValue458403667",
                            PhoneNumber = "TestValue571641460",
                            DomainName = "TestValue1098848611",
                            Status = "TestValue1352097037",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue375337042",
                            Department = new Department
                            {
                                Id = 1441623190,
                                Name = "TestValue437415628",
                                RequestedCompanyId = 1227517503,
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
                    EmployeeAttendances = new Mock<ICollection<EmployeeAttendance>>().Object
                },
                Leave = new LeaveType
                {
                    Id = 586425337,
                    LeaveType1 = "TestValue1617504952",
                    Days = 704822494,
                    CompanyId = 1355562286,
                    EmployeecredentialId = 2791830,
                    Company = new CompanyDetail
                    {
                        Id = 1769728308,
                        Name = "TestValue690397891",
                        Address = "TestValue1907703250",
                        Country = "TestValue1789047053",
                        States = "TestValue863057769",
                        Industry = "TestValue1876873880",
                        TimeZone = "TestValue773935873",
                        Currency = "TestValue1848311077",
                        PfNo = "TestValue19127708",
                        TanNo = "TestValue349711043",
                        EsiNo = "TestValue1113524054",
                        PanNo = "TestValue1140593631",
                        GstNo = "TestValue1601915963",
                        RegistrationNo = "TestValue683775499",
                        Twitter = "TestValue81002333",
                        Facebook = "TestValue501470131",
                        LinkedIn = "TestValue114418185",
                        CompanyLogo = "TestValue1494398006",
                        RequestedCompanyId = 1065805158,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 1737770118,
                            Name = "TestValue1705252383",
                            PhoneNumber = "TestValue1969898170",
                            DomainName = "TestValue849230799",
                            Status = "TestValue1414874004",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue1501521169",
                            Department = new Department
                            {
                                Id = 205316318,
                                Name = "TestValue2074462527",
                                RequestedCompanyId = 192181997,
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
                        Id = 580128460,
                        UserName = "TestValue1434656574",
                        Password = "TestValue1251234892",
                        Status = (short)8928,
                        RequestedCompanyId = 263352450,
                        Email = "TestValue414914202",
                        DefaultPassword = false,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 1184880538,
                            Name = "TestValue1088264118",
                            PhoneNumber = "TestValue641920094",
                            DomainName = "TestValue1601712467",
                            Status = "TestValue397497598",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue1436012533",
                            Department = new Department
                            {
                                Id = 83090588,
                                Name = "TestValue439275959",
                                RequestedCompanyId = 221930417,
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
                }
            };

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(1909668263);

            // Act
            var result = await _testClass.InsertEmployeeAttendence(employeeAttendence);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmployeeAttendence()
        {
            // Arrange
            var id = 2132808204;
            var Timein = DateTime.UtcNow;
            var Timeout = DateTime.UtcNow;
            var Remark = "TestValue211503406";
            var empcredentialId = 920904726;

            // Act
            var result = await _testClass.UpdateEmployeeAttendence(id, Timein, Timeout, Remark, empcredentialId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}