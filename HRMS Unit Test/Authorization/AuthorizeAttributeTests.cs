namespace HRMS_Unit_Test.Authorization
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
        private readonly AuthorizeAttribute _testClass;
        private string[] _roles;

        public AuthorizeAttributeTests()
        {
            _roles = new[] { "TestValue307337822", "TestValue1589331138", "TestValue1455852817" };
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
                        Template = "TestValue544539662",
                        Order = 784310236,
                        Name = "TestValue842384596",
                        SuppressLinkGeneration = false,
                        SuppressPathMatching = true
                    },
                    ActionConstraints = new[] { new Mock<IActionConstraintMetadata>().Object, new Mock<IActionConstraintMetadata>().Object, new Mock<IActionConstraintMetadata>().Object },
                    EndpointMetadata = new[] { new object(), new object(), new object() },
                    Parameters = new[] {
                        new ParameterDescriptor
                        {
                            Name = "TestValue1249567415",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        },
                        new ParameterDescriptor
                        {
                            Name = "TestValue531683493",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        },
                        new ParameterDescriptor
                        {
                            Name = "TestValue1964333175",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        }
                    },
                    BoundProperties = new[] {
                        new ParameterDescriptor
                        {
                            Name = "TestValue560692243",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        },
                        new ParameterDescriptor
                        {
                            Name = "TestValue1630473598",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        },
                        new ParameterDescriptor
                        {
                            Name = "TestValue2017492749",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        }
                    },
                    FilterDescriptors = new[] { new FilterDescriptor(new Mock<IFilterMetadata>().Object, 1127721816), new FilterDescriptor(new Mock<IFilterMetadata>().Object, 1271480197), new FilterDescriptor(new Mock<IFilterMetadata>().Object, 1106528143) },
                    DisplayName = "TestValue758921232",
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