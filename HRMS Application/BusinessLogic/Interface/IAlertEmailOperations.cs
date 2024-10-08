namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IAlertEmailOperations
    {
        public Task SendEmailAsync(string emailTemplate, Dictionary<string, string> parameters);
    }
}
