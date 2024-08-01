namespace TestProject1.BusinessLogic.Implements
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
            var id = 1815626717;

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
            var id = 271286698;

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
                Id = 1198538981,
                Name = "TestValue1496355682",
                Address = "TestValue1580902077",
                Country = "TestValue1786928312",
                States = "TestValue794394691",
                Industry = "TestValue1355093335",
                TimeZone = "TestValue1254181097",
                Currency = "TestValue25749825",
                PfNo = "TestValue1518463909",
                TanNo = "TestValue1597250054",
                EsiNo = "TestValue2119487409",
                PanNo = "TestValue1552315850",
                GstNo = "TestValue533124194",
                RegistrationNo = "TestValue333438289",
                Twitter = "TestValue277121591",
                Facebook = "TestValue562886429",
                LinkedIn = "TestValue419367565",
                CompanyLogo = "TestValue298254889",
                RequestedCompanyId = 1088459038,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 178906030,
                    Name = "TestValue978395686",
                    PhoneNumber = "TestValue1463005065",
                    DomainName = "TestValue728335772",
                    Status = "TestValue1353725661",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = new Department
                    {
                        Id = 1558096891,
                        Name = "TestValue1715960940",
                        RequestedCompanyId = 1882981829,
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