using HRMS_Application.DTO;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IFileUpload
    {
        public string UploadFile(FileUploadDTO files);
    }
}
