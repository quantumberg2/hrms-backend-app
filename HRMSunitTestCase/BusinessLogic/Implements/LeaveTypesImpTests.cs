namespace HRMSunitTestCase.BusinessLogic.Implements
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public class LeaveTypesImpTests
    {
        private LeaveTypesImp _testClass;
        private HRMSContext _context;

        public LeaveTypesImpTests()
        {
            _context = new HRMSContext();
            _testClass = new LeaveTypesImp(_context);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new LeaveTypesImp(_context);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCalldeleteLeaveType()
        {
            // Arrange
            var id = 1961536249;

            // Act
            var result = _testClass.deleteLeaveType(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAllLeaveType()
        {
            // Act
            var result = _testClass.GetAllLeaveType();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetLeaveTypeById()
        {
            // Arrange
            var id = 1309487888;

            // Act
            var result = _testClass.GetLeaveTypeById(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetLeaveTypeByType()
        {
            // Arrange
            var Type = "TestValue681283440";

            // Act
            var result = _testClass.GetLeaveTypeByType(Type);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallInsertLeaveType()
        {
            // Arrange
            var leaveType = new LeaveType
            {
                Id = 1412808032,
                LeaveType1 = "TestValue893983145",
                Days = 666783505,
                CompanyId = 1352074158,
                EmployeecredentialId = 1913499483,
                Company = new CompanyDetail
                {
                    Id = 1080042987,
                    Name = "TestValue2061244422",
                    Address = "TestValue1032462569",
                    Country = "TestValue119933893",
                    States = "TestValue1491353484",
                    Industry = "TestValue862667794",
                    TimeZone = "TestValue794273631",
                    Currency = "TestValue705750110",
                    PfNo = "TestValue1811144004",
                    TanNo = "TestValue180063917",
                    EsiNo = "TestValue2016280688",
                    PanNo = "TestValue1774358090",
                    GstNo = "TestValue368685575",
                    RegistrationNo = "TestValue930276325",
                    Twitter = "TestValue1035546093",
                    Facebook = "TestValue291295504",
                    LinkedIn = "TestValue585330587",
                    CompanyLogo = "TestValue313637518",
                    RequestedCompanyId = 633294470,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 415019102,
                        Name = "TestValue1094287078",
                        PhoneNumber = "TestValue141197946",
                        DomainName = "TestValue1859675524",
                        Status = "TestValue1066654588",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue61371563",
                        Department = new Department
                        {
                            Id = 231205346,
                            Name = "TestValue1715880704",
                            RequestedCompanyId = 808396192,
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
                    Id = 1289290096,
                    UserName = "TestValue1202821013",
                    Password = "TestValue581096418",
                    Status = (short)7188,
                    RequestedCompanyId = 1325989062,
                    Email = "TestValue2016092238",
                    DefaultPassword = false,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 929660877,
                        Name = "TestValue1172469461",
                        PhoneNumber = "TestValue1866555551",
                        DomainName = "TestValue935059971",
                        Status = "TestValue1942423622",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue514903386",
                        Department = new Department
                        {
                            Id = 729466065,
                            Name = "TestValue888728065",
                            RequestedCompanyId = 671808322,
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
            };

            // Act
            var result = _testClass.InsertLeaveType(leaveType);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallUpdateLeaveType()
        {
            // Arrange
            var id = 1358147366;
            var name = "TestValue1972770505";
            var requestedcompanyId = 6072762;

            // Act
            var result = _testClass.UpdateLeaveType(id, name, requestedcompanyId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}