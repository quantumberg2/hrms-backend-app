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


        public async Task<Stream> FetchBulkEmployeeDetailsFile(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                var stream = await response.Content.ReadAsStreamAsync();
                return stream;
            }
        }

    }
}
