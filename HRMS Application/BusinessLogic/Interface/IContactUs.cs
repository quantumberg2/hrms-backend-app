using HRMS_Application.DTO;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IContactUs
    {
        public Task SendMessageAsync(ContactUsDTO contact);
    }
}
