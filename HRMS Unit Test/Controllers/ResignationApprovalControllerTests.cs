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

    public class ResignationApprovalControllerTests
    {
        private readonly ResignationApprovalController _testClass;
        private readonly Mock<ILogger<ResignationApprovalController>> _logger;
        private readonly Mock<IResignationApproval> _resignationApproval;

        public ResignationApprovalControllerTests()
        {
            _logger = new Mock<ILogger<ResignationApprovalController>>();
            _resignationApproval = new Mock<IResignationApproval>();
            _testClass = new ResignationApprovalController(_logger.Object, _resignationApproval.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new ResignationApprovalController(_logger.Object, _resignationApproval.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetData()
        {
            // Arrange
            _resignationApproval.Setup(mock => mock.GetData()).Returns(new List<ResignationApprovalStatus>());

            // Act
            var result = _testClass.GetData();

            // Assert
            _resignationApproval.Verify(mock => mock.GetData());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallInsertResignation()
        {
            // Arrange
            var resignation = new ResignationApprovalStatus
            {
                Id = 1804743024,
                ResignationId = 2075816479,
                ManagerApprovalStatus = "TestValue1560679135",
                AdminApprovalStatus = "TestValue1308848961",
                IsActive = (short)27697,
                Resignation = new Resignation
                {
                    Id = 1334744614,
                    EmpCredentialId = 2134763433,
                    Reason = "TestValue650747432",
                    StartDate = DateTime.UtcNow,
                    ExitDate = DateTime.UtcNow,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Status = "TestValue1947334021",
                    FinalSettlementDate = DateTime.UtcNow,
                    IsActive = (short)11250,
                    Comments = "TestValue737198424",
                    ResignationApprovalStatuses = new Mock<ICollection<ResignationApprovalStatus>>().Object
                }
            };

            _resignationApproval.Setup(mock => mock.InsertResignation(It.IsAny<ResignationApprovalStatus>())).Returns("TestValue325511821");

            // Act
            var result = _testClass.InsertResignation(resignation);

            // Assert
            _resignationApproval.Verify(mock => mock.InsertResignation(It.IsAny<ResignationApprovalStatus>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallUpdateResignation()
        {
            // Arrange
            var resignation = new ResignationApprovalStatus
            {
                Id = 942181951,
                ResignationId = 856644041,
                ManagerApprovalStatus = "TestValue1960066508",
                AdminApprovalStatus = "TestValue975779049",
                IsActive = (short)4443,
                Resignation = new Resignation
                {
                    Id = 2056619731,
                    EmpCredentialId = 1938312363,
                    Reason = "TestValue376005494",
                    StartDate = DateTime.UtcNow,
                    ExitDate = DateTime.UtcNow,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Status = "TestValue1372760664",
                    FinalSettlementDate = DateTime.UtcNow,
                    IsActive = (short)10284,
                    Comments = "TestValue130100892",
                    ResignationApprovalStatuses = new Mock<ICollection<ResignationApprovalStatus>>().Object
                }
            };

            _resignationApproval.Setup(mock => mock.UpdateResignation(It.IsAny<ResignationApprovalStatus>())).Returns("TestValue1738861310");

            // Act
            var result = _testClass.UpdateResignation(resignation);

            // Assert
            _resignationApproval.Verify(mock => mock.UpdateResignation(It.IsAny<ResignationApprovalStatus>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDeleteResignation()
        {
            // Arrange
            var id = 1073137731;
            var isActive = (short)30077;

            _resignationApproval.Setup(mock => mock.SoftDeleteResignation(It.IsAny<int>(), It.IsAny<short>())).Returns(false);

            // Act
            var result = _testClass.SoftDeleteResignation(id, isActive);

            // Assert
            _resignationApproval.Verify(mock => mock.SoftDeleteResignation(It.IsAny<int>(), It.IsAny<short>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateAdminApprovalStatus()
        {
            // Arrange
            var id = 1692027023;
            var adminApprovalStatus = "TestValue2062461421";

            _resignationApproval.Setup(mock => mock.UpdateAdminApprovalStatus(It.IsAny<int>(), It.IsAny<string>())).Returns("TestValue244108237");

            // Act
            var result = await _testClass.UpdateAdminApprovalStatus(id, adminApprovalStatus);

            // Assert
            _resignationApproval.Verify(mock => mock.UpdateAdminApprovalStatus(It.IsAny<int>(), It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateManagerApprovalStatus()
        {
            // Arrange
            var id = 884320129;
            var managerApprovalstatus = "TestValue1357423268";

            _resignationApproval.Setup(mock => mock.UpdateAdminApprovalStatus(It.IsAny<int>(), It.IsAny<string>())).Returns("TestValue577923151");

            // Act
            var result = await _testClass.UpdateManagerApprovalStatus(id, managerApprovalstatus);

            // Assert
            _resignationApproval.Verify(mock => mock.UpdateAdminApprovalStatus(It.IsAny<int>(), It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}