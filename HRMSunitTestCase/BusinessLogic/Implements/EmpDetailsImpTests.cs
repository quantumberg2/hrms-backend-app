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

    public class EmpDetailsImpTests
    {
        private EmpDetailsImp _testClass;
        private HRMSContext _hrmsContext;
        private Mock<IHttpContextAccessor> _httpContextAccessor;
        private Mock<IJwtUtils> _jwtUtils;

        public EmpDetailsImpTests()
        {
            _hrmsContext = new HRMSContext();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _jwtUtils = new Mock<IJwtUtils>();
            _testClass = new EmpDetailsImp(_hrmsContext, _httpContextAccessor.Object, _jwtUtils.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new EmpDetailsImp(_hrmsContext, _httpContextAccessor.Object, _jwtUtils.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallDeleteEmployeeDetail()
        {
            // Arrange
            var id = 785160422;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(19561857);

            // Act
            var result = await _testClass.DeleteEmployeeDetail(id);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAllUser()
        {
            // Act
            var result = _testClass.GetAllUser();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetById()
        {
            // Arrange
            var id = 1413844570;

            // Act
            var result = _testClass.GetById(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertEmployeeDetail()
        {
            // Arrange
            var employeeDetail = new EmployeeDetail
            {
                Id = 1454825110,
                DeptId = 594645805,
                FirstName = "TestValue1732315602",
                MiddleName = "TestValue229594932",
                LastName = "TestValue174734760",
                PositionId = 1297286957,
                
                EmployeeCredentialId = 25911671,
                Dept = new Department
                {
                    Id = 1173134487,
                    Name = "TestValue743895077",
                    RequestedCompanyId = 1899683034,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1465622802,
                        Name = "TestValue319367877",
                        PhoneNumber = "TestValue1843107906",
                        DomainName = "TestValue189650863",
                        Status = "TestValue972047620",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue626593994",
                        Department = default(Department),
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                },
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1113795210,
                    UserName = "TestValue1300134459",
                    Password = "TestValue1489994065",
                    Status = (short)2792,
                    RequestedCompanyId = 427936787,
                    Email = "TestValue1874609432",
                    DefaultPassword = false,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1017827042,
                        Name = "TestValue1405699812",
                        PhoneNumber = "TestValue1373226762",
                        DomainName = "TestValue1985738203",
                        Status = "TestValue1399634443",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1050787608",
                        Department = new Department
                        {
                            Id = 728849679,
                            Name = "TestValue946682824",
                            RequestedCompanyId = 676762061,
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
                    Id = 723654346,
                    Name = "TestValue1876318119",
                    RequestedCompanyId = 2078794412,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 531311466,
                        Name = "TestValue616717565",
                        PhoneNumber = "TestValue140765272",
                        DomainName = "TestValue1310228849",
                        Status = "TestValue1733760593",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1322464547",
                        Department = new Department
                        {
                            Id = 1478512974,
                            Name = "TestValue136301157",
                            RequestedCompanyId = 1022868433,
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

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(483901481);

            // Act
            var result = await _testClass.InsertEmployeeDetail(employeeDetail);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmployeeDetail()
        {
            // Arrange
            var id = 1897364269;
            var depId = 801073123;
            var mobilenumber = "TestValue1919080354";
            var fname = "TestValue1194997884";
            var mname = "TestValue158566428";
            var lname = "TestValue300049360";
            var positionid = 1331250669;
            var nickname = "TestValue2112314692";
            var gender = "TestValue411637272";
            var employeecredentialId = 471971789;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(565845319);

            // Act
            var result = await _testClass.UpdateEmployeeDetail(id, depId, mobilenumber, fname, mname, lname, positionid, nickname, gender, employeecredentialId);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}