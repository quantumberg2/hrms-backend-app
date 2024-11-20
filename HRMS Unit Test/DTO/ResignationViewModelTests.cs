namespace HRMS_Unit_Test.DTO
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.DTO;
    using HRMS_Application.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Moq;
    using Xunit;

    public class ResignationViewModelTests
    {
        private readonly ResignationViewModel _testClass;

        public ResignationViewModelTests()
        {
            _testClass = new ResignationViewModel();
        }

        [Fact]
        public void CanSetAndGetResignation()
        {
            // Arrange
            var testValue = new Resignation
            {
                Id = 1153618822,
                EmpCredentialId = 665913959,
                Reason = "TestValue1715087555",
                StartDate = DateTime.UtcNow,
                ExitDate = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Status = "TestValue317607898",
                FinalSettlementDate = DateTime.UtcNow,
                IsActive = (short)14230,
                Comments = "TestValue1477653742",
                ResignationApprovalStatuses = new Mock<ICollection<ResignationApprovalStatus>>().Object
            };

            // Act
            _testClass.Resignation = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Resignation);
        }

        [Fact]
        public void CanSetAndGetReasons()
        {
            // Arrange
            var testValue = new[] {
                new SelectListItem
                {
                    Disabled = true,
                    Group = new SelectListGroup
                    {
                        Disabled = false,
                        Name = "TestValue396154325"
                    },
                    Selected = false,
                    Text = "TestValue1121478705",
                    Value = "TestValue1671289636"
                },
                new SelectListItem
                {
                    Disabled = true,
                    Group = new SelectListGroup
                    {
                        Disabled = true,
                        Name = "TestValue1234842275"
                    },
                    Selected = false,
                    Text = "TestValue1622135850",
                    Value = "TestValue1205795860"
                },
                new SelectListItem
                {
                    Disabled = false,
                    Group = new SelectListGroup
                    {
                        Disabled = true,
                        Name = "TestValue10333753"
                    },
                    Selected = false,
                    Text = "TestValue452760851",
                    Value = "TestValue141443539"
                }
            };

            // Act
            _testClass.Reasons = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Reasons);
        }
    }
}