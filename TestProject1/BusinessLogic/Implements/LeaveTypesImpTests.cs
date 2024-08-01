namespace TestProject1.BusinessLogic.Implements
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
            var id = 1114814983;

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
            var id = 1522963834;

            // Act
            var result = _testClass.GetLeaveTypeById(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetLeaveTypeByType()
        {
            // Arrange
            var Type = "TestValue1970014408";

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
                Id = 108266900,
                LeaveType1 = "TestValue1738478144",
                Days = 693129949,
                CompanyId = 620161487,
                Company = new CompanyDetail
                {
                    Id = 1467035540,
                    Name = "TestValue2091720225",
                    Address = "TestValue1236836897",
                    Country = "TestValue1085116362",
                    States = "TestValue1035602193",
                    Industry = "TestValue544496236",
                    TimeZone = "TestValue1164619826",
                    Currency = "TestValue362892696",
                    PfNo = "TestValue1937399415",
                    TanNo = "TestValue173444274",
                    EsiNo = "TestValue1454501249",
                    PanNo = "TestValue2054174190",
                    GstNo = "TestValue447774271",
                    RegistrationNo = "TestValue547652289",
                    Twitter = "TestValue1168728993",
                    Facebook = "TestValue732458586",
                    LinkedIn = "TestValue56695370",
                    CompanyLogo = "TestValue710974019",
                    RequestedCompanyId = 2097349986,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 536946127,
                        Name = "TestValue629308272",
                        PhoneNumber = "TestValue770981968",
                        DomainName = "TestValue1729242660",
                        Status = "TestValue1776739691",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 1591616743,
                            Name = "TestValue1521021192",
                            RequestedCompanyId = 865835363,
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

            // Act
            var result = _testClass.InsertLeaveType(leaveType);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallUpdateLeaveType()
        {
            // Arrange
            var id = 148288265;
            var name = "TestValue1882825346";
            var requestedcompanyId = 44592463;

            // Act
            var result = _testClass.UpdateLeaveType(id, name, requestedcompanyId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}