//using Global_clg_App.BusinessLogics.Interface;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.AspNetCore.Mvc;
//using Global_clg_App.Models;

//namespace Global_clg_App.Helpers
//{
//    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
//    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
//    {
//        public void OnAuthorization(AuthorizationFilterContext context)
//        {
//            var user = (UserTable)context.HttpContext.Items["User"];
//            if (user == null)
//            {
//                // not logged in
//                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
//            }
//        }
//    }
//}
