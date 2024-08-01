namespace TestProject1.Controllers
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.Controllers;
    using HRMS_Application.Models;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class LeaveTypeControllerTests
    {
        private LeaveTypeController _testClass;
        private Mock<ILeaveTypes> _leavetype;
        private Mock<ILogger<LeaveTypeController>> _logger;

        public LeaveTypeControllerTests()
        {
            _leavetype = new Mock<ILeaveTypes>();
            _logger = new Mock<ILogger<LeaveTypeController>>();
            _testClass = new LeaveTypeController(_leavetype.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new LeaveTypeController(_leavetype.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllLeavetype()
        {
            // Arrange
            _leavetype.Setup(mock => mock.GetAllLeaveType()).Returns(new List<LeaveType>());

            // Act
            var result = _testClass.GetAllLeavetype();

            // Assert
            _leavetype.Verify(mock => mock.GetAllLeaveType());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetleavetypeById()
        {
            // Arrange
            var id = 75803891;

            _leavetype.Setup(mock => mock.GetLeaveTypeById(It.IsAny<int>())).Returns(new LeaveType
            {
                Id = 2037573533,
                LeaveType1 = "TestValue1592765275",
                Days = 1079388252,
                CompanyId = 1152084529,
                Company = new CompanyDetail
                {
                    Id = 575533061,
                    Name = "TestValue1885463551",
                    Address = "TestValue2122095891",
                    Country = "TestValue264525847",
                    States = "TestValue1940218875",
                    Industry = "TestValue1655026499",
                    TimeZone = "TestValue1055289220",
                    Currency = "TestValue774330200",
                    PfNo = "TestValue1512286713",
                    TanNo = "TestValue2075521992",
                    EsiNo = "TestValue1502079975",
                    PanNo = "TestValue1633471506",
                    GstNo = "TestValue139650275",
                    RegistrationNo = "TestValue645821351",
                    Twitter = "TestValue55414515",
                    Facebook = "TestValue1372815053",
                    LinkedIn = "TestValue996045128",
                    CompanyLogo = "TestValue1514849216",
                    RequestedCompanyId = 1701865142,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1903271459,
                        Name = "TestValue574957009",
                        PhoneNumber = "TestValue1145952724",
                        DomainName = "TestValue1433142001",
                        Status = "TestValue2038828162",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 1991845804,
                            Name = "TestValue307966722",
                            RequestedCompanyId = 1500956920,
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
            });

            // Act
            var result = _testClass.GetleavetypeById(id);

            // Assert
            _leavetype.Verify(mock => mock.GetLeaveTypeById(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallInsertLeavetypes()
        {
            // Arrange
            var leaveType = new LeaveType
            {
                Id = 331946192,
                LeaveType1 = "TestValue1989046837",
                Days = 1560436159,
                CompanyId = 1539985750,
                Company = new CompanyDetail
                {
                    Id = 528878578,
                    Name = "TestValue993947567",
                    Address = "TestValue49148893",
                    Country = "TestValue163486024",
                    States = "TestValue1702615167",
                    Industry = "TestValue1873814414",
                    TimeZone = "TestValue495774782",
                    Currency = "TestValue469567742",
                    PfNo = "TestValue163070053",
                    TanNo = "TestValue2101849017",
                    EsiNo = "TestValue1982490246",
                    PanNo = "TestValue618098830",
                    GstNo = "TestValue1163697651",
                    RegistrationNo = "TestValue1685417601",
                    Twitter = "TestValue1998836101",
                    Facebook = "TestValue1588655402",
                    LinkedIn = "TestValue321187412",
                    CompanyLogo = "TestValue1680506035",
                    RequestedCompanyId = 522724317,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 2038383780,
                        Name = "TestValue1323600440",
                        PhoneNumber = "TestValue577127520",
                        DomainName = "TestValue1577063984",
                        Status = "TestValue452321550",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 83267729,
                            Name = "TestValue420163690",
                            RequestedCompanyId = 1632252153,
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
            };

            _leavetype.Setup(mock => mock.InsertLeaveType(It.IsAny<LeaveType>())).Returns("TestValue1027139216");

            // Act
            var result = _testClass.InsertLeavetypes(leaveType);

            // Assert
            _leavetype.Verify(mock => mock.InsertLeaveType(It.IsAny<LeaveType>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallDeleteLeavetype()
        {
            // Arrange
            var id = 979485329;

            _leavetype.Setup(mock => mock.deleteLeaveType(It.IsAny<int>())).Returns(true);

            // Act
            var result = _testClass.DeleteLeavetype(id);

            // Assert
            _leavetype.Verify(mock => mock.deleteLeaveType(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}