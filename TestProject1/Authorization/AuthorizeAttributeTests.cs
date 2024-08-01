namespace TestProject1.Authorization
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
            _roles = new[] { "TestValue272016753", "TestValue1626317194", "TestValue406982908" };
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
                        Template = "TestValue1861047460",
                        Order = 789945459,
                        Name = "TestValue1967646394",
                        SuppressLinkGeneration = true,
                        SuppressPathMatching = true
                    },
                    ActionConstraints = new[] { new Mock<IActionConstraintMetadata>().Object, new Mock<IActionConstraintMetadata>().Object, new Mock<IActionConstraintMetadata>().Object },
                    EndpointMetadata = new[] { new object(), new object(), new object() },
                    Parameters = new[] {
                        new ParameterDescriptor
                        {
                            Name = "TestValue1681009923",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        },
                        new ParameterDescriptor
                        {
                            Name = "TestValue2007179008",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        },
                        new ParameterDescriptor
                        {
                            Name = "TestValue1166791539",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        }
                    },
                    BoundProperties = new[] {
                        new ParameterDescriptor
                        {
                            Name = "TestValue886602687",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        },
                        new ParameterDescriptor
                        {
                            Name = "TestValue853368236",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        },
                        new ParameterDescriptor
                        {
                            Name = "TestValue1041487792",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        }
                    },
                    FilterDescriptors = new[] { new FilterDescriptor(new Mock<IFilterMetadata>().Object, 179598507), new FilterDescriptor(new Mock<IFilterMetadata>().Object, 1925399253), new FilterDescriptor(new Mock<IFilterMetadata>().Object, 1111075125) },
                    DisplayName = "TestValue847630538",
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