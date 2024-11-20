namespace HRMS_Unit_Test.Controllers
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

    public class LeaveTypeControllerTests
    {
        private readonly LeaveTypeController _testClass;
        private readonly Mock<ILeaveTypes> _leavetype;
        private readonly Mock<ILogger<LeaveTypeController>> _logger;

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
        /*
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
        */
        [Fact]
        public void CanCallGetleavetypeById()
        {
            // Arrange
            var id = 1821261851;

            _leavetype.Setup(mock => mock.GetLeaveTypeById(It.IsAny<int>())).Returns(new LeaveType
            {
                Id = 1395323324,
                Type = "TestValue674460505",
                Days = 1215642833,
                CompanyId = 629105709,
                Year = 414337206,
                IsActive = (short)18871,
                Company = new RequestedCompanyForm
                {
                    Id = 2016197251,
                    Name = "TestValue273796879",
                    PhoneNumber = "TestValue1460808687",
                    DomainName = "TestValue2096704337",
                    Status = "TestValue2139442589",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1185119761",
                    IsActive = (short)5816,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object
            });

            // Act
            var result = _testClass.GetleavetypeById(id);

            // Assert
            _leavetype.Verify(mock => mock.GetLeaveTypeById(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertLeavetypes()
        {
            // Arrange
            var leaveType = new LeaveType
            {
                Id = 1475294470,
                Type = "TestValue33298652",
                Days = 2110422607,
                CompanyId = 2034176630,
                Year = 1332165955,
                IsActive = (short)27151,
                Company = new RequestedCompanyForm
                {
                    Id = 691750354,
                    Name = "TestValue863185759",
                    PhoneNumber = "TestValue1118031167",
                    DomainName = "TestValue619570784",
                    Status = "TestValue1267073417",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue657039475",
                    IsActive = (short)27168,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object
            };

            _leavetype.Setup(mock => mock.InsertLeaveType(It.IsAny<LeaveType>())).ReturnsAsync("TestValue1850644550");

            // Act
            var result = await _testClass.InsertLeavetypes(leaveType);

            // Assert
            _leavetype.Verify(mock => mock.InsertLeaveType(It.IsAny<LeaveType>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallDeleteLeavetype()
        {
            // Arrange
            var id = 963161364;

            _leavetype.Setup(mock => mock.deleteLeaveType(It.IsAny<int>())).Returns(true);

            // Act
            var result = _testClass.DeleteLeavetype(id);

            // Assert
            _leavetype.Verify(mock => mock.deleteLeaveType(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 1375537438;
            var isActive = (short)8988;

            _leavetype.Setup(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>())).Returns(false);

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            _leavetype.Verify(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAllLeavetype()
        {
            // Arrange
            _leavetype.Setup(mock => mock.GetAllLeaveType(It.IsAny<int>())).Returns(new List<LeaveType>());
            _leavetype.Setup(mock => mock.GetRegularizationLeaveType()).Returns(new List<LeaveType>());

            // Act
            var result = _testClass.GetAllLeavetype();

            // Assert
            _leavetype.Verify(mock => mock.GetAllLeaveType(It.IsAny<int>()));
            _leavetype.Verify(mock => mock.GetRegularizationLeaveType());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallUpdateLeaveType()
        {
            // Arrange
            var id = 446745759;
            var name = "TestValue468288645";
            var days = 1318389584;
            var year = 1339860116;
            var requestedcompanyId = 1011435910;

            _leavetype.Setup(mock => mock.UpdateLeaveType(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<int?>())).Returns(new LeaveType
            {
                Id = 727466783,
                Type = "TestValue1823886529",
                Days = 1923232911,
                CompanyId = 1328232896,
                Year = 1155582387,
                IsActive = (short)15030,
                CompanyConfiguredLeave = true,
                Company = new RequestedCompanyForm
                {
                    Id = 1584978202,
                    Name = "TestValue152714004",
                    PhoneNumber = "TestValue1041336752",
                    DomainName = "TestValue1704761795",
                    Status = "TestValue1426468639",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue106370522",
                    IsActive = (short)6024,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object
            });

            // Act
            var result = _testClass.UpdateLeaveType(id, name, days, year, requestedcompanyId);

            // Assert
            _leavetype.Verify(mock => mock.UpdateLeaveType(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<int?>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}