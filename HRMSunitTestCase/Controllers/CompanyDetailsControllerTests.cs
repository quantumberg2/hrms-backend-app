namespace HRMSunitTestCase.Controllers
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.Controllers;
    using HRMS_Application.Models;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class CompanyDetailsControllerTests
    {
        private CompanyDetailsController _testClass;
        private Mock<ICompanyDetails> _companyDetails;
        private Mock<ILogger<CompanyDetailsController>> _logger;

        public CompanyDetailsControllerTests()
        {
            _companyDetails = new Mock<ICompanyDetails>();
            _logger = new Mock<ILogger<CompanyDetailsController>>();
            _testClass = new CompanyDetailsController(_companyDetails.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new CompanyDetailsController(_companyDetails.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllCompanyDetails()
        {
            // Arrange
            _companyDetails.Setup(mock => mock.GetAllCompanyDetails()).Returns(new List<CompanyDetail>());

            // Act
            var result = _testClass.GetAllCompanyDetails();

            // Assert
            _companyDetails.Verify(mock => mock.GetAllCompanyDetails());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetCompanyDetail()
        {
            // Arrange
            var id = 417902457;

            _companyDetails.Setup(mock => mock.GetCompanyDetailstById(It.IsAny<int>())).Returns(new CompanyDetail
            {
                Id = 31992526,
                Name = "TestValue177369969",
                Address = "TestValue1709645177",
                Country = "TestValue2004613090",
                States = "TestValue682690096",
                Industry = "TestValue1545536205",
                TimeZone = "TestValue1017388910",
                Currency = "TestValue1635722783",
                PfNo = "TestValue2137831186",
                TanNo = "TestValue9345400",
                EsiNo = "TestValue336534239",
                PanNo = "TestValue615999657",
                GstNo = "TestValue1103021389",
                RegistrationNo = "TestValue961693879",
                Twitter = "TestValue173639346",
                Facebook = "TestValue1096502711",
                LinkedIn = "TestValue835602918",
                CompanyLogo = "TestValue374665789",
                RequestedCompanyId = 1333523668,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1652810864,
                    Name = "TestValue609285116",
                    PhoneNumber = "TestValue1134307283",
                    DomainName = "TestValue1206639826",
                    Status = "TestValue934927226",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue98462774",
                    Department = new Department
                    {
                        Id = 1297600527,
                        Name = "TestValue1078840100",
                        RequestedCompanyId = 1397693008,
                        RequestedCompany = default(RequestedCompanyForm),
                        EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                    },
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                Holidays = new Mock<ICollection<Holiday>>().Object,
                LeaveTypes = new Mock<ICollection<LeaveType>>().Object
            });

            // Act
            var result = _testClass.GetCompanyDetail(id);

            // Assert
            _companyDetails.Verify(mock => mock.GetCompanyDetailstById(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallInsertcompanyDetails()
        {
            // Arrange
            var companyDetail = new CompanyDetail
            {
                Id = 462724814,
                Name = "TestValue1755618276",
                Address = "TestValue906379426",
                Country = "TestValue318400214",
                States = "TestValue341182334",
                Industry = "TestValue1716781980",
                TimeZone = "TestValue748874874",
                Currency = "TestValue1714424477",
                PfNo = "TestValue742242545",
                TanNo = "TestValue191087620",
                EsiNo = "TestValue265259553",
                PanNo = "TestValue1039139766",
                GstNo = "TestValue1923272308",
                RegistrationNo = "TestValue1679420759",
                Twitter = "TestValue556503171",
                Facebook = "TestValue340541139",
                LinkedIn = "TestValue1073678601",
                CompanyLogo = "TestValue1040644855",
                RequestedCompanyId = 1895601327,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1830425325,
                    Name = "TestValue1681210121",
                    PhoneNumber = "TestValue2033274703",
                    DomainName = "TestValue689931914",
                    Status = "TestValue1999958010",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1518595046",
                    Department = new Department
                    {
                        Id = 1045168890,
                        Name = "TestValue1118213790",
                        RequestedCompanyId = 774717951,
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

            _companyDetails.Setup(mock => mock.InsertCompanyDetails(It.IsAny<CompanyDetail>())).Returns(1905385001);

            // Act
            var result = _testClass.InsertcompanyDetails(companyDetail);

            // Assert
            _companyDetails.Verify(mock => mock.InsertCompanyDetails(It.IsAny<CompanyDetail>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallDeletecompanyDetails()
        {
            // Arrange
            var id = 1532573216;

            _companyDetails.Setup(mock => mock.deleteCompanyDetails(It.IsAny<int>())).Returns(false);

            // Act
            var result = _testClass.DeletecompanyDetails(id);

            // Assert
            _companyDetails.Verify(mock => mock.deleteCompanyDetails(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}