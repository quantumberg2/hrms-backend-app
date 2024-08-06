namespace HRMSunitTestCase.Authorization
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Abstractions;
    using Microsoft.AspNetCore.Mvc.ActionConstraints;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Microsoft.AspNetCore.Routing;
    using Moq;
    using Xunit;

    public class AuthorizeAttributeTests
    {
        private AuthorizeAttribute _testClass;
        private string[] _roles;

        public AuthorizeAttributeTests()
        {
            _roles = new[] { "TestValue1148970397", "TestValue1874453998", "TestValue1264803415" };
            _testClass = new AuthorizeAttribute(_roles);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new AuthorizeAttribute(_roles);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallOnAuthorization()
        {
            // Arrange
            var context = new AuthorizationFilterContext(new ActionContext
            {
                ActionDescriptor = new ActionDescriptor
                {
                    RouteValues = new Mock<IDictionary<string, string>>().Object,
                    AttributeRouteInfo = new AttributeRouteInfo
                    {
                        Template = "TestValue633567794",
                        Order = 1127595463,
                        Name = "TestValue647968400",
                        SuppressLinkGeneration = true,
                        SuppressPathMatching = true
                    },
                    ActionConstraints = new[] { new Mock<IActionConstraintMetadata>().Object, new Mock<IActionConstraintMetadata>().Object, new Mock<IActionConstraintMetadata>().Object },
                    EndpointMetadata = new[] { new object(), new object(), new object() },
                    Parameters = new[] {
                        new ParameterDescriptor
                        {
                            Name = "TestValue1159833655",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        },
                        new ParameterDescriptor
                        {
                            Name = "TestValue465327828",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        },
                        new ParameterDescriptor
                        {
                            Name = "TestValue636347032",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        }
                    },
                    BoundProperties = new[] {
                        new ParameterDescriptor
                        {
                            Name = "TestValue944848717",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        },
                        new ParameterDescriptor
                        {
                            Name = "TestValue1244881909",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        },
                        new ParameterDescriptor
                        {
                            Name = "TestValue1204486873",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        }
                    },
                    FilterDescriptors = new[] { new FilterDescriptor(new Mock<IFilterMetadata>().Object, 570573410), new FilterDescriptor(new Mock<IFilterMetadata>().Object, 1606514152), new FilterDescriptor(new Mock<IFilterMetadata>().Object, 908582574) },
                    DisplayName = "TestValue420257541",
                    Properties = new Mock<IDictionary<object, object>>().Object
                },
                HttpContext = new DefaultHttpContext(),
                RouteData = new RouteData()
            }, new[] { new Mock<IFilterMetadata>().Object, new Mock<IFilterMetadata>().Object, new Mock<IFilterMetadata>().Object });

            // Act
            _testClass.OnAuthorization(context);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}