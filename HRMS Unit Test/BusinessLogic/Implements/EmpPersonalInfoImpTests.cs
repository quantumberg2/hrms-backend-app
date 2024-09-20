namespace HRMS_Unit_Test.BusinessLogic.Implements
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.DTO;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public class EmpPersonalInfoImpTests
    {
        private readonly EmpPersonalInfoImp _testClass;
        private HRMSContext _context;

        public EmpPersonalInfoImpTests()
        {
            _context = new HRMSContext();
            _testClass = new EmpPersonalInfoImp(_context);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new EmpPersonalInfoImp(_context);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAll()
        {
            // Act
            var result = _testClass.GetAll();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallInsertEmpPersonalInfo()
        {
            // Arrange
            var empPersonalInfo = new EmpPersonalInfoDTO
            {
                FirstName = "TestValue1005797542",
                MiddleName = "TestValue328283410",
                LastName = "TestValue315079101",
                EmployeeCredentialId = 930073859,
                Dob = DateTime.UtcNow,
                DateOfJoining = DateTime.UtcNow,
                ConfirmDate = DateTime.UtcNow,
                EmpStatus = "TestValue180452900",
                EmailId = "TestValue1931953823",
                PersonalEmail = "TestValue631949988",
                MaritalStatus = "TestValue1569124669",
                BloodGroup = "TestValue186725151",
                SpouseName = "TestValue2105467383",
                PhysicallyChallenged = true,
                EmergencyContact = "TestValue294672986",
                PAN = "TestValue1540564436",
                Gender = "TestValue1714977341",
                Contact = "TestValue2036314724"
            };
            var empCredentialId = 699897973;

            // Act
            var result = _testClass.InsertEmpPersonalInfo(empPersonalInfo, empCredentialId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallUpdateEmpPersonalInfo()
        {
            // Arrange
            var empPersonalInfo = new EmpPersonalInfo
            {
                Id = 2131315265,
                EmployeeCredentialId = 1896002214,
                Dob = DateTime.UtcNow,
                DateOfJoining = DateTime.UtcNow,
                ConfirmDate = DateTime.UtcNow,
                EmpStatus = "TestValue1159807234",
                EmailId = "TestValue1174299221",
                PersonalEmail = "TestValue1181548688",
                MaritalStatus = "TestValue348497800",
                BloodGroup = "TestValue1582878549",
                SpouseName = "TestValue244696415",
                PhysicallyChallenged = true,
                EmergencyContact = "TestValue1365390661",
                IsActive = (short)1386,
                Gender = "TestValue1633548824",
                Pan = "TestValue1989134172",
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 650952441,
                    UserName = "TestValue306776070",
                    Password = "TestValue652997189",
                    Status = (short)19377,
                    RequestedCompanyId = 708448729,
                    Email = "TestValue841772935",
                    DefaultPassword = false,
                    GenerateOtp = "TestValue1380733922",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)6191,
                    EmployeeLoginName = "TestValue910526531",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1293128948,
                        Name = "TestValue777249993",
                        PhoneNumber = "TestValue782469494",
                        DomainName = "TestValue1658648514",
                        Status = "TestValue1873615799",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue2060078357",
                        IsActive = (short)2676,
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        Departments = new Mock<ICollection<Department>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Holidays = new Mock<ICollection<Holiday>>().Object,
                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    AccountDetails = new Mock<ICollection<AccountDetail>>().Object,
                    AddressInfos = new Mock<ICollection<AddressInfo>>().Object,
                    Attendances = new Mock<ICollection<Attendance>>().Object,
                    DeviceTables = new Mock<ICollection<DeviceTable>>().Object,
                    EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                    EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
                    UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
                }
            };
            var name = new EmpPersonalInfoDTO
            {
                FirstName = "TestValue241758654",
                MiddleName = "TestValue885304994",
                LastName = "TestValue1953142291",
                EmployeeCredentialId = 1242389792,
                Dob = DateTime.UtcNow,
                DateOfJoining = DateTime.UtcNow,
                ConfirmDate = DateTime.UtcNow,
                EmpStatus = "TestValue750318840",
                EmailId = "TestValue1922456391",
                PersonalEmail = "TestValue1541718557",
                MaritalStatus = "TestValue159819591",
                BloodGroup = "TestValue1867590256",
                SpouseName = "TestValue657299742",
                PhysicallyChallenged = false,
                EmergencyContact = "TestValue70382686",
                PAN = "TestValue1855824253",
                Gender = "TestValue962545886",
                Contact = "TestValue1841103639"
            };

            // Act
            var result = _testClass.UpdateEmpPersonalInfo(empPersonalInfo, name);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallDeleteEmpPersonalInfo()
        {
            // Arrange
            var Id = 1145884811;

            // Act
            var result = _testClass.DeleteEmpPersonalInfo(Id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 1727474144;
            var isActive = (short)25683;

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}