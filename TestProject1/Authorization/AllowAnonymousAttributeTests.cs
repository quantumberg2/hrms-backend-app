namespace TestProject1.Authorization
{
    using System;
    using HRMS_Application.Authorization;
    using Xunit;

    public class AllowAnonymousAttributeTests
    {
        private AllowAnonymousAttribute _testClass;

        public AllowAnonymousAttributeTests()
        {
            _testClass = new AllowAnonymousAttribute();
        }
    }
}