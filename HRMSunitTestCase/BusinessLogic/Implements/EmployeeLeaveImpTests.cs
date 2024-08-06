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

    public class EmployeeLeaveImpTests
    {
        private EmployeeLeaveImp _testClass;
        private HRMSContext _hrmscontext;
        private Mock<IHttpContextAccessor> _httpContextAccessor;
        private Mock<IJwtUtils> _jwtUtils;

        public EmployeeLeaveImpTests()
        {
            _hrmscontext = new HRMSContext();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _jwtUtils = new Mock<IJwtUtils>();
            _testClass = new EmployeeLeaveImp(_hrmscontext, _httpContextAccessor.Object, _jwtUtils.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new EmployeeLeaveImp(_hrmscontext, _httpContextAccessor.Object, _jwtUtils.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallDeleteEmployeeLeave()
        {
            // Arrange
            var id = 1847375643;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(1665104283);

            // Act
            var result = await _testClass.DeleteEmployeeLeave(id);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAllEmpLeave()
        {
            // Act
            var result = _testClass.GetAllEmpLeave();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetByEmpLeavebyId()
        {
            // Arrange
            var id = 965254788;

            // Act
            var result = _testClass.GetByEmpLeavebyId(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertEmployeeLeave()
        {
            // Arrange
            var employeeLeave = new EmployeeLeave
            {
                Id = 1265587528,
                EmployeeCredentialId = 1096198170,
                LeaveId = 73221315,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                Session = "TestValue1594982575",
                TotalDays = 659770177,
                Contact = "TestValue1823301033",
                ReasonForLeave = "TestValue1651329763",
                Files = "TestValue1972619495",
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1955755538,
                    UserName = "TestValue1697992274",
                    Password = "TestValue1833291967",
                    Status = (short)7979,
                    RequestedCompanyId = 688723376,
                    Email = "TestValue2110624008",
                    DefaultPassword = true,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1975402337,
                        Name = "TestValue1329525699",
                        PhoneNumber = "TestValue1147029809",
                        DomainName = "TestValue1340212612",
                        Status = "TestValue2129846736",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1532155073",
                        Department = new Department
                        {
                            Id = 1356886089,
                            Name = "TestValue1718124804",
                            RequestedCompanyId = 2109289727,
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
                Leave = new LeaveType
                {
                    Id = 108273483,
                    LeaveType1 = "TestValue1695773736",
                    Days = 2085499466,
                    CompanyId = 1005622414,
                    EmployeecredentialId = 2022131107,
                    Company = new CompanyDetail
                    {
                        Id = 1250064973,
                        Name = "TestValue664275959",
                        Address = "TestValue2113185880",
                        Country = "TestValue1760399504",
                        States = "TestValue347586571",
                        Industry = "TestValue1881405180",
                        TimeZone = "TestValue1281706884",
                        Currency = "TestValue1044972108",
                        PfNo = "TestValue2016019302",
                        TanNo = "TestValue310574769",
                        EsiNo = "TestValue740874188",
                        PanNo = "TestValue1857504241",
                        GstNo = "TestValue1385627598",
                        RegistrationNo = "TestValue1336719877",
                        Twitter = "TestValue1822821232",
                        Facebook = "TestValue947471844",
                        LinkedIn = "TestValue223024325",
                        CompanyLogo = "TestValue725378153",
                        RequestedCompanyId = 1953648645,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 1367608960,
                            Name = "TestValue1901847449",
                            PhoneNumber = "TestValue1049638847",
                            DomainName = "TestValue70080844",
                            Status = "TestValue324891671",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue1865012554",
                            Department = new Department
                            {
                                Id = 1580583362,
                                Name = "TestValue2056185086",
                                RequestedCompanyId = 1525557013,
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
                        Id = 111415234,
                        UserName = "TestValue1486709092",
                        Password = "TestValue1111480088",
                        Status = (short)28766,
                        RequestedCompanyId = 645707349,
                        Email = "TestValue2097972035",
                        DefaultPassword = true,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 1033716315,
                            Name = "TestValue1867589734",
                            PhoneNumber = "TestValue910044992",
                            DomainName = "TestValue341136805",
                            Status = "TestValue229218828",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue1763483302",
                            Department = new Department
                            {
                                Id = 930430229,
                                Name = "TestValue1460990044",
                                RequestedCompanyId = 836455039,
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

            // Act
            var result = await _testClass.InsertEmployeeLeave(employeeLeave);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}