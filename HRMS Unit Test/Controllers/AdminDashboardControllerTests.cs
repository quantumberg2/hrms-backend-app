namespace HRMS_Unit_Test.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.Controllers;
    using HRMS_Application.DTO;
    using Moq;
    using Xunit;

    public class AdminDashboardControllerTests
    {
        private readonly AdminDashboardController _testClass;
        private readonly Mock<IAdminDashboard> _adminDashboard;

        public AdminDashboardControllerTests()
        {
            _adminDashboard = new Mock<IAdminDashboard>();
            _testClass = new AdminDashboardController(_adminDashboard.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new AdminDashboardController(_adminDashboard.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallGetDashboard()
        {
            // Arrange
            _adminDashboard.Setup(mock => mock.GetAdminDashboardAsync(It.IsAny<int>())).ReturnsAsync(new AdminDashboardDTO
            {
                TotalEmployees = 122344857,
                NewEmployees = 2017752684,
                EmployeesJoinedMonthWise = new List<MonthlyCountDTO>(),
                EmployeesResignedMonthWise = new List<MonthlyCountDTO>(),
                ExperienceCounts = new List<ExperienceCountDTO>()
            });

            // Act
            var result = await _testClass.GetDashboard();

            // Assert
            _adminDashboard.Verify(mock => mock.GetAdminDashboardAsync(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}