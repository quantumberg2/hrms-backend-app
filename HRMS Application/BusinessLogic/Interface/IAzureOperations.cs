namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IAzureOperations
    {
        public string StoreFilesInAzure(IFormFile fileObj, string containerName);
    }
}
