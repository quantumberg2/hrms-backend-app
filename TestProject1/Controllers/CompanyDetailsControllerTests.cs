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
            var id = 1897990277;

            _companyDetails.Setup(mock => mock.GetCompanyDetailstById(It.IsAny<int>())).Returns(new CompanyDetail
            {
                Id = 856769247,
                Name = "TestValue2012441741",
                Address = "TestValue178450679",
                Country = "TestValue1121002923",
                States = "TestValue1418399767",
                Industry = "TestValue1421145224",
                TimeZone = "TestValue1719132623",
                Currency = "TestValue1326418654",
                PfNo = "TestValue1301478221",
                TanNo = "TestValue1087931827",
                EsiNo = "TestValue815494819",
                PanNo = "TestValue1713563353",
                GstNo = "TestValue1068341993",
                RegistrationNo = "TestValue147335785",
                Twitter = "TestValue572308419",
                Facebook = "TestValue299398347",
                LinkedIn = "TestValue175072431",
                CompanyLogo = "TestValue1822295577",
                RequestedCompanyId = 2138367620,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 501374937,
                    Name = "TestValue1520215375",
                    PhoneNumber = "TestValue1815557958",
                    DomainName = "TestValue461918400",
                    Status = "TestValue90670243",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = new Department
                    {
                        Id = 1951016605,
                        Name = "TestValue348415555",
                        RequestedCompanyId = 596653795,
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
                Id = 2049274658,
                Name = "TestValue175878998",
                Address = "TestValue1826216668",
                Country = "TestValue384927588",
                States = "TestValue356235461",
                Industry = "TestValue802931679",
                TimeZone = "TestValue893014376",
                Currency = "TestValue931677542",
                PfNo = "TestValue953814361",
                TanNo = "TestValue1259514311",
                EsiNo = "TestValue681556872",
                PanNo = "TestValue1509655094",
                GstNo = "TestValue1937902674",
                RegistrationNo = "TestValue1261114804",
                Twitter = "TestValue2146503550",
                Facebook = "TestValue1060215",
                LinkedIn = "TestValue2027690513",
                CompanyLogo = "TestValue2085313542",
                RequestedCompanyId = 1180518767,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1588583659,
                    Name = "TestValue2054635703",
                    PhoneNumber = "TestValue1894516915",
                    DomainName = "TestValue261644681",
                    Status = "TestValue621259335",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = new Department
                    {
                        Id = 262389548,
                        Name = "TestValue246156910",
                        RequestedCompanyId = 1188694936,
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

            _companyDetails.Setup(mock => mock.InsertCompanyDetails(It.IsAny<CompanyDetail>())).Returns(1841247270);

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
            var id = 87780436;

            _companyDetails.Setup(mock => mock.deleteCompanyDetails(It.IsAny<int>())).Returns(true);

            // Act
            var result = _testClass.DeletecompanyDetails(id);

            // Assert
            _companyDetails.Verify(mock => mock.deleteCompanyDetails(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}