namespace TestProject1.BusinessLogic.Implements
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
            var id = 190983154;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(123338790);

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
            var id = 1491956921;

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
                Id = 1842823040,
                EmployeeCredentialId = 988918204,
                LeaveId = 1605981969,
                HolidayId = 384294926,
                TimeIn = DateTime.UtcNow,
                TimeOut = DateTime.UtcNow,
                Remarks = "TestValue2100894136",
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 247616510,
                    UserName = "TestValue1794047068",
                    Password = "TestValue814241301",
                    Status = (short)3304,
                    RequestedCompanyId = 898094922,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1905321500,
                        Name = "TestValue1598474227",
                        PhoneNumber = "TestValue1636023993",
                        DomainName = "TestValue2052464024",
                        Status = "TestValue20713603",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 1130590642,
                            Name = "TestValue1495769113",
                            RequestedCompanyId = 136324435,
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
                Holiday = new Holiday
                {
                    Id = 374889965,
                    Occasion = "TestValue272011802",
                    Date = DateTime.UtcNow,
                    Day = "TestValue1832893026",
                    RestrictedHoliday = false,
                    CompanyId = 1494401815,
                    Company = new CompanyDetail
                    {
                        Id = 88067950,
                        Name = "TestValue415885271",
                        Address = "TestValue643109697",
                        Country = "TestValue795310158",
                        States = "TestValue760525504",
                        Industry = "TestValue355492592",
                        TimeZone = "TestValue985183531",
                        Currency = "TestValue2095850434",
                        PfNo = "TestValue1862255077",
                        TanNo = "TestValue1286524404",
                        EsiNo = "TestValue1257022331",
                        PanNo = "TestValue346847734",
                        GstNo = "TestValue1852362619",
                        RegistrationNo = "TestValue1740509337",
                        Twitter = "TestValue1998703736",
                        Facebook = "TestValue323145905",
                        LinkedIn = "TestValue970681681",
                        CompanyLogo = "TestValue191431482",
                        RequestedCompanyId = 1847291347,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 705744390,
                            Name = "TestValue1272452833",
                            PhoneNumber = "TestValue61106095",
                            DomainName = "TestValue453197143",
                            Status = "TestValue1009266321",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Department = new Department
                            {
                                Id = 2023519928,
                                Name = "TestValue1426757361",
                                RequestedCompanyId = 1317267411,
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
                    EmployeeAttendances = new Mock<ICollection<EmployeeAttendance>>().Object
                },
                Leave = new LeaveType
                {
                    Id = 455994175,
                    LeaveType1 = "TestValue2134498002",
                    Days = 1963576836,
                    CompanyId = 1219945119,
                    Company = new CompanyDetail
                    {
                        Id = 2058430904,
                        Name = "TestValue1069331110",
                        Address = "TestValue1642000036",
                        Country = "TestValue1517914019",
                        States = "TestValue2115893302",
                        Industry = "TestValue1457784439",
                        TimeZone = "TestValue1599789999",
                        Currency = "TestValue1033521564",
                        PfNo = "TestValue458748709",
                        TanNo = "TestValue1378838995",
                        EsiNo = "TestValue949728135",
                        PanNo = "TestValue43066423",
                        GstNo = "TestValue311949823",
                        RegistrationNo = "TestValue379001662",
                        Twitter = "TestValue1705616290",
                        Facebook = "TestValue315834631",
                        LinkedIn = "TestValue1537564952",
                        CompanyLogo = "TestValue1644549024",
                        RequestedCompanyId = 1960662177,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 1551691931,
                            Name = "TestValue80580320",
                            PhoneNumber = "TestValue2133085326",
                            DomainName = "TestValue67747540",
                            Status = "TestValue221948982",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Department = new Department
                            {
                                Id = 26961855,
                                Name = "TestValue2110171775",
                                RequestedCompanyId = 1781327023,
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

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(1743840283);

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
            var id = 919273877;
            var Timein = DateTime.UtcNow;
            var Timeout = DateTime.UtcNow;
            var Remark = "TestValue1481251790";
            var empcredentialId = 1185708828;

            // Act
            var result = await _testClass.UpdateEmployeeAttendence(id, Timein, Timeout, Remark, empcredentialId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}