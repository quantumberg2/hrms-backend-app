namespace HRMS_Application.BusinessLogic.Interface
{
    public interface ILocalStorageOperations
    {
        public string StoreFiles(IFormFile file, string directory);
    }
}
