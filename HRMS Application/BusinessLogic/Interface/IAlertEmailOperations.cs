namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IAlertEmailOperations
    {
        void SendEmail(string emailTemplate, Dictionary<string, string> parameters);
    }
}
