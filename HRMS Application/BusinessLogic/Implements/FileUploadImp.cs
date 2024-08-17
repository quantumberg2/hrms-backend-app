using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class FileUploadImp : IFileUpload
    {
        private readonly IAzureOperations _azureOperations;
        private readonly ILocalStorageOperations _localStorageOperations;
        private readonly IConfiguration _configuration;

        public FileUploadImp(IAzureOperations azureOperations,ILocalStorageOperations localStorageOperations,IConfiguration configuration)
        {
            _azureOperations = azureOperations;
            _localStorageOperations = localStorageOperations;
            _configuration = configuration;
        }
        public string UploadFile(FileUploadDTO files)
        {
            bool UseLocalDatabase = _configuration.GetValue<bool>("DatabaseSettings:UseLocalDatabase");

            string url;

            if(UseLocalDatabase)
            {
                url = _localStorageOperations.StoreFiles(files.FileContent, "HRMS_Files");
            }
            else
            {
                url = _azureOperations.StoreFilesInAzure(files.FileContent, "hrmsfiles");
            }

            return url;
        }
    }
}
