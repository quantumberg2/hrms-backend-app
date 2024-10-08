namespace HRMS_Unit_Test.Controllers
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
        private readonly CompanyDetailsController _testClass;
        private readonly Mock<ICompanyDetails> _companyDetails;
        private readonly Mock<ILogger<CompanyDetailsController>> _logger;

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
            var id = 1219040562;

            _companyDetails.Setup(mock => mock.GetCompanyDetailstById(It.IsAny<int>())).Returns(new List<CompanyDetail>());

            // Act
            var result = _testClass.GetCompanyDetail(id);

            // Assert
            _companyDetails.Verify(mock => mock.GetCompanyDetailstById(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetCompanyDetailstByName()
        {
            // Arrange
            var companyName = "TestValue1179821945";

            _companyDetails.Setup(mock => mock.GetCompanyDetailstByName(It.IsAny<string>())).Returns(new List<CompanyDetail>());

            // Act
            var result = _testClass.GetCompanyDetailstByName(companyName);

            // Assert
            _companyDetails.Verify(mock => mock.GetCompanyDetailstByName(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

       /* [Fact]
        public void CanCallInsertcompanyDetails()
        {
            // Arrange
            var companyDetail = new CompanyDetail
            {
                Id = 309145918,
                Name = "TestValue1157471599",
                Address = "TestValue1851747088",
                Country = "TestValue724213383",
                States = "TestValue1870053642",
                Industry = "TestValue719330310",
                TimeZone = "TestValue858197823",
                Currency = "TestValue1544395847",
                PfNo = "TestValue1033413874",
                TanNo = "TestValue969944425",
                EsiNo = "TestValue1504819985",
                PanNo = "TestValue777929445",
                GstNo = "TestValue592965103",
                RegistrationNo = "TestValue1594314947",
                Twitter = "TestValue274469434",
                Facebook = "TestValue423335407",
                LinkedIn = "TestValue192678419",
                CompanyLogo = "TestValue1494910042",
                RequestedCompanyId = 1469859788,
                IsActive = (short)21918,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 2127226664,
                    Name = "TestValue1822489063",
                    PhoneNumber = "TestValue764427471",
                    DomainName = "TestValue762041962",
                    Status = "TestValue1269652813",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1421668471",
                    IsActive = (short)18744,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                }
            };

            _companyDetails.Setup(mock => mock.InsertCompanyDetails(It.IsAny<CompanyDetail>())).Returns(1093375089);

            // Act
            var result = _testClass.InsertcompanyDetails(companyDetail);

            // Assert
            _companyDetails.Verify(mock => mock.InsertCompanyDetails(It.IsAny<CompanyDetail>()));

            throw new NotImplementedException("Create or modify test");
        }
*/
        [Fact]
        public void CanCallDeletecompanyDetails()
        {
            // Arrange
            var id = 634467298;

            _companyDetails.Setup(mock => mock.deleteCompanyDetails(It.IsAny<int>())).Returns(true);

            // Act
            var result = _testClass.DeletecompanyDetails(id);

            // Assert
            _companyDetails.Verify(mock => mock.deleteCompanyDetails(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 1969336633;
            var isActive = (short)23769;

            _companyDetails.Setup(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>())).Returns(true);

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            _companyDetails.Verify(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}