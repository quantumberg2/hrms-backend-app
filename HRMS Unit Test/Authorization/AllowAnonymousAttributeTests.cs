namespace HRMS_Unit_Test.Authorization
{
    using System;
    using HRMS_Application.Authorization;
    using Xunit;

    public class AllowAnonymousAttributeTests
    {
        private readonly AllowAnonymousAttribute _testClass;

        public AllowAnonymousAttributeTests()
        {
            _testClass = new AllowAnonymousAttribute();
        }
    }
}