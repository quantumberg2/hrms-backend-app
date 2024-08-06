namespace HRMSunitTestCase.BusinessLogic.Implements
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public class CompanyDetailsImpTests
    {
        private CompanyDetailsImp _testClass;
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
            var id = 938202209;

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
            var id = 715966714;

            // Act
            var result = _testClass.GetCompanyDetailstById(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallInsertCompanyDetails()
        {
            // Arrange
            var companyDetail = new CompanyDetail
            {
                Id = 1636896025,
                Name = "TestValue1342768597",
                Address = "TestValue2041727479",
                Country = "TestValue1435821851",
                States = "TestValue216005235",
                Industry = "TestValue1672153242",
                TimeZone = "TestValue2099232318",
                Currency = "TestValue1317454663",
                PfNo = "TestValue447820494",
                TanNo = "TestValue2008933736",
                EsiNo = "TestValue1540889747",
                PanNo = "TestValue848355509",
                GstNo = "TestValue1361544252",
                RegistrationNo = "TestValue164015563",
                Twitter = "TestValue2105007583",
                Facebook = "TestValue206884759",
                LinkedIn = "TestValue519942149",
                CompanyLogo = "TestValue1722312464",
                RequestedCompanyId = 319464045,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 968178423,
                    Name = "TestValue1526640722",
                    PhoneNumber = "TestValue639140985",
                    DomainName = "TestValue1368323575",
                    Status = "TestValue2085727932",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1297252624",
                    Department = new Department
                    {
                        Id = 543377615,
                        Name = "TestValue291307730",
                        RequestedCompanyId = 97026558,
                        RequestedCompany = default(RequestedCompanyForm),
                        EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                    },
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                Holidays = new Mock<ICollection<Holiday>>().Object,
                LeaveTypes = new Mock<ICollection<LeaveType>>().Object
            };

            // Act
            var result = _testClass.InsertCompanyDetails(companyDetail);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}