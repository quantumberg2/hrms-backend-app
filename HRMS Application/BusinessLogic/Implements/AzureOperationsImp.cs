using Azure.Storage.Blobs;
using HRMS_Application.BusinessLogic.Interface;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class AzureOperationsImp  : IAzureOperations
    {
        private readonly BlobServiceClient _blobServiceClient;

        public AzureOperationsImp(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }
        public string StoreFilesInAzure(IFormFile fileObj, string containerName)
        {
            var containerInstance = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobInstance = containerInstance.GetBlobClient(fileObj.FileName);
            blobInstance.Upload(fileObj.OpenReadStream(), true);
            string url = blobInstance.Uri.ToString();
            return url;
        }

    }
}
