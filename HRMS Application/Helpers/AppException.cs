using System.Globalization;
using System.Security.AccessControl;

namespace HRMS_Application.Helpers
{
    public class AppException : Exception
    {
        public AppException()  :base() { }

        public AppException(string message) : base(message) { }

        public AppException(string message,params object[] args)
            :base(String.Format(CultureInfo.CurrentCulture, message, args)) { } 
    }
}
