using HRMS_Application.DTO;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IFileStorage
    {
        public List<Models.File> GetFiles();
        public string UploadFile(FileStorageDTO file);
        public string UpdateFile(int id,FileStorageDTO files);
        public bool SoftDelete(int id, bool isActive);
    }
}
