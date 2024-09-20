namespace HRMS_Unit_Test.Controllers
{
    using System;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.Controllers;
    using HRMS_Application.DTO;
    using HRMS_Application.Models;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class EmpPersonalInfoControllerTests
    {
        private readonly EmpPersonalInfoController _testClass;
        private readonly Mock<ILogger<EmpPersonalInfoController>> _logger;
        private readonly Mock<IEmpPersonalInfo> _empPersonalInfo;
        private HRMSContext _context;

        public EmpPersonalInfoControllerTests()
        {
            _logger = new Mock<ILogger<EmpPersonalInfoController>>();
            _empPersonalInfo = new Mock<IEmpPersonalInfo>();
            _context = new HRMSContext();
            _testClass = new EmpPersonalInfoController(_logger.Object, _empPersonalInfo.Object, _context);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new EmpPersonalInfoController(_logger.Object, _empPersonalInfo.Object, _context);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallInsertEmpPersonalInfo()
        {
            // Arrange
            var empPersonalInfo = new EmpPersonalInfoDTO
            {
                FirstName = "TestValue1641686470",
                MiddleName = "TestValue954372434",
                LastName = "TestValue1759069150",
                EmployeeCredentialId = 2122078968,
                Dob = DateTime.UtcNow,
                DateOfJoining = DateTime.UtcNow,
                ConfirmDate = DateTime.UtcNow,
                EmpStatus = "TestValue329374128",
                EmailId = "TestValue549682469",
                PersonalEmail = "TestValue1779196550",
                MaritalStatus = "TestValue353481913",
                BloodGroup = "TestValue1492827010",
                SpouseName = "TestValue2131004432",
                PhysicallyChallenged = true,
                EmergencyContact = "TestValue460393806",
                PAN = "TestValue92419532",
                Gender = "TestValue1809320362",
                Contact = "TestValue2053998691"
            };
            var empCredentialId = 1629696420;

            _empPersonalInfo.Setup(mock => mock.InsertEmpPersonalInfo(It.IsAny<EmpPersonalInfoDTO>(), It.IsAny<int>())).Returns("TestValue791043422");

            // Act
            var result = _testClass.InsertEmpPersonalInfo(empPersonalInfo, empCredentialId);

            // Assert
            _empPersonalInfo.Verify(mock => mock.InsertEmpPersonalInfo(It.IsAny<EmpPersonalInfoDTO>(), It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 466704553;
            var isActive = (short)26262;

            _empPersonalInfo.Setup(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>())).Returns(false);

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            _empPersonalInfo.Verify(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}