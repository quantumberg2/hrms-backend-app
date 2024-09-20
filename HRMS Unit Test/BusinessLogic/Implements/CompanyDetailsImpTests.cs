namespace HRMS_Unit_Test.BusinessLogic.Implements
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public class CompanyDetailsImpTests
    {
        private readonly CompanyDetailsImp _testClass;
        private HRMSContext _context;

        public CompanyDetailsImpTests()
        {
            _context = new HRMSContext();
            _testClass = new CompanyDetailsImp(_context);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new CompanyDetailsImp(_context);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCalldeleteCompanyDetails()
        {
            // Arrange
            var id = 2135225435;

            // Act
            var result = _testClass.deleteCompanyDetails(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAllCompanyDetails()
        {
            // Act
            var result = _testClass.GetAllCompanyDetails();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetCompanyDetailstById()
        {
            // Arrange
            var id = 1415456953;

            // Act
            var result = _testClass.GetCompanyDetailstById(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetCompanyDetailstByName()
        {
            // Arrange
            var companyName = "TestValue566928608";

            // Act
            var result = _testClass.GetCompanyDetailstByName(companyName);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallInsertCompanyDetails()
        {
            // Arrange
            var companyDetail = new CompanyDetail
            {
                Id = 843301029,
                Name = "TestValue849453386",
                Address = "TestValue835783508",
                Country = "TestValue1370744713",
                States = "TestValue2088237923",
                Industry = "TestValue25205987",
                TimeZone = "TestValue947713085",
                Currency = "TestValue1827728215",
                PfNo = "TestValue1164806978",
                TanNo = "TestValue1558792427",
                EsiNo = "TestValue340143196",
                PanNo = "TestValue1184400570",
                GstNo = "TestValue1182386774",
                RegistrationNo = "TestValue1102214648",
                Twitter = "TestValue1188411501",
                Facebook = "TestValue404019633",
                LinkedIn = "TestValue1078755900",
                CompanyLogo = "TestValue391119822",
                RequestedCompanyId = 947311784,
                IsActive = (short)10638,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 760391035,
                    Name = "TestValue542607409",
                    PhoneNumber = "TestValue457093547",
                    DomainName = "TestValue1219862060",
                    Status = "TestValue251230889",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1753416085",
                    IsActive = (short)23089,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                }
            };

            // Act
            var result = _testClass.InsertCompanyDetails(companyDetail);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 341374462;
            var isActive = (short)20875;

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}