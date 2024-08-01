namespace TestProject1.BusinessLogic.Implements
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HRMS_Application.Authorization;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.Models;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class PositionImpTests
    {
        private PositionImp _testClass;
        private HRMSContext _hrmsContext;
        private Mock<IHttpContextAccessor> _httpContextAccessor;
        private Mock<IJwtUtils> _jwtUtils;

        public PositionImpTests()
        {
            _hrmsContext = new HRMSContext();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _jwtUtils = new Mock<IJwtUtils>();
            _testClass = new PositionImp(_hrmsContext, _httpContextAccessor.Object, _jwtUtils.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new PositionImp(_hrmsContext, _httpContextAccessor.Object, _jwtUtils.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCalldeletePosition()
        {
            // Arrange
            var id = 790505248;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(2093569637);

            // Act
            var result = await _testClass.deletePosition(id);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetPositions()
        {
            // Act
            var result = _testClass.GetPositions();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertPositions()
        {
            // Arrange
            var position = new Position
            {
                Id = 1544776528,
                Name = "TestValue1788611805",
                RequestedCompanyId = 156183822,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 2138336862,
                    Name = "TestValue696053572",
                    PhoneNumber = "TestValue362477565",
                    DomainName = "TestValue1607580853",
                    Status = "TestValue1640983266",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = new Department
                    {
                        Id = 1662064648,
                        Name = "TestValue1826144520",
                        RequestedCompanyId = 1016331561,
                        RequestedCompany = default(RequestedCompanyForm),
                        EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                    },
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
            };

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(1913319038);

            // Act
            var result = await _testClass.InsertPositions(position);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallupdateposition()
        {
            // Arrange
            var id = 1892806952;
            var name = "TestValue643216780";
            var requestedcompanyId = 1855846665;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(627550997);

            // Act
            var result = await _testClass.updateposition(id, name, requestedcompanyId);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}