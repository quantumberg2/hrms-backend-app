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
            var id = 1935000254;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(1717744205);

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
            var id = 1634276983;

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
                Id = 1074698133,
                EmployeeCredentialId = 1420729496,
                LeaveId = 423416701,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                Session = "TestValue937795176",
                TotalDays = 879126801,
                Contact = "TestValue2024572554",
                ReasonForLeave = "TestValue1336387697",
                Files = "TestValue837859207",
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1753123791,
                    UserName = "TestValue2115502757",
                    Password = "TestValue624739403",
                    Status = (short)22610,
                    RequestedCompanyId = 2021135137,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 2043360429,
                        Name = "TestValue1597338071",
                        PhoneNumber = "TestValue37287619",
                        DomainName = "TestValue1005450682",
                        Status = "TestValue612216472",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 1344673855,
                            Name = "TestValue1373502408",
                            RequestedCompanyId = 378568303,
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
                    Id = 216694397,
                    LeaveType1 = "TestValue1328286537",
                    Days = 260741425,
                    CompanyId = 1520826770,
                    Company = new CompanyDetail
                    {
                        Id = 1482029981,
                        Name = "TestValue184280719",
                        Address = "TestValue672878699",
                        Country = "TestValue79145883",
                        States = "TestValue1329424361",
                        Industry = "TestValue14517159",
                        TimeZone = "TestValue1279389081",
                        Currency = "TestValue1200859096",
                        PfNo = "TestValue657594846",
                        TanNo = "TestValue1318156052",
                        EsiNo = "TestValue1907164386",
                        PanNo = "TestValue2004682965",
                        GstNo = "TestValue1315160519",
                        RegistrationNo = "TestValue435842833",
                        Twitter = "TestValue1884649683",
                        Facebook = "TestValue1758913014",
                        LinkedIn = "TestValue1342941042",
                        CompanyLogo = "TestValue1317030258",
                        RequestedCompanyId = 776523578,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 116102742,
                            Name = "TestValue564875289",
                            PhoneNumber = "TestValue135270693",
                            DomainName = "TestValue2073047673",
                            Status = "TestValue1701207940",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Department = new Department
                            {
                                Id = 564082620,
                                Name = "TestValue1512362025",
                                RequestedCompanyId = 793789897,
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

            // Act
            var result = await _testClass.InsertEmployeeLeave(employeeLeave);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}