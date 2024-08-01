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
            var id = 1934649226;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(326699599);

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
            var id = 363674553;

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
                Id = 333786396,
                DeptId = 293440243,
                MobileNumber = "TestValue785953538",
                FirstName = "TestValue225602999",
                MiddleName = "TestValue459890871",
                LastName = "TestValue1663997973",
                PositionId = 1413164363,
                NickName = "TestValue1856717448",
                Gender = "TestValue219994004",
                EmployeeCredentialId = 89306831,
                Dept = new Department
                {
                    Id = 780425244,
                    Name = "TestValue667075936",
                    RequestedCompanyId = 1342519133,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 481141032,
                        Name = "TestValue6025888",
                        PhoneNumber = "TestValue1774445019",
                        DomainName = "TestValue1467060029",
                        Status = "TestValue1950499830",
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
                    Id = 150885150,
                    UserName = "TestValue1023212174",
                    Password = "TestValue1474641951",
                    Status = (short)4541,
                    RequestedCompanyId = 964347018,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 423106655,
                        Name = "TestValue836054716",
                        PhoneNumber = "TestValue153641896",
                        DomainName = "TestValue1830839276",
                        Status = "TestValue1108653385",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 1781706531,
                            Name = "TestValue1229121593",
                            RequestedCompanyId = 2059247185,
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
                    Id = 172500048,
                    Name = "TestValue1124633689",
                    RequestedCompanyId = 1257041476,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1979430696,
                        Name = "TestValue720207817",
                        PhoneNumber = "TestValue721747363",
                        DomainName = "TestValue902542150",
                        Status = "TestValue1010616895",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 927485550,
                            Name = "TestValue1128454304",
                            RequestedCompanyId = 1929570806,
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

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(1129719801);

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
            var id = 1183545345;
            var depId = 1577725695;
            var mobilenumber = "TestValue1353518331";
            var fname = "TestValue167465915";
            var mname = "TestValue991113296";
            var lname = "TestValue1380469223";
            var positionid = 1767208435;
            var nickname = "TestValue746632533";
            var gender = "TestValue523683416";
            var employeecredentialId = 1783764076;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(460980710);

            // Act
            var result = await _testClass.UpdateEmployeeDetail(id, depId, mobilenumber, fname, mname, lname, positionid, nickname, gender, employeecredentialId);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}