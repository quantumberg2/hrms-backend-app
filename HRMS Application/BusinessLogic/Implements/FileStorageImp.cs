using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Models;
using System.Linq.Expressions;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class FileStorageImp : IFileStorage
    {
        private readonly IAzureOperations _azureOperations;
        private readonly ILocalStorageOperations _localStorageOperations;   
        private readonly IConfiguration _configuration;
        private readonly HRMSContext _hRMSContext;

        public FileStorageImp(IAzureOperations azureOperations,ILocalStorageOperations localStorageOperations,IConfiguration configuration,HRMSContext hRMSContext)
        {
            _azureOperations = azureOperations;
            _localStorageOperations = localStorageOperations;
            _configuration = configuration;
            _hRMSContext = hRMSContext;
        }

        public List<Models.File> GetFiles()
        {
            var files = (from row in _hRMSContext.Files
                         where row.IsActive == true
                         select row).ToList();
            return files;
        }


        public string UploadFile(FileStorageDTO files)
        {
            bool UseLocalDatabase = _configuration.GetValue<bool>("DatabaseSettings:UseLocalDatabase");

            string url;

            if(UseLocalDatabase)
            {
                url = _localStorageOperations.StoreFiles(files.FileContent, "HRMS_Files");
            }
            else
            {
                url = _azureOperations.StoreFilesInAzure(files.FileContent, "hrms-files");
            }

            Models.File objnewFile = new Models.File
            {
                ObjectId = files.ObjectId,  
                ObjectName = files.ObjectName,
                Tags = files.Tags,
                IsActive = files.IsActive,
                FileUrl = url
            };

            _hRMSContext.Files.Add(objnewFile);
            var res = _hRMSContext.SaveChanges();

            if(res!=0)
            {
                return "File uploaded successfully";
            }
            return "Failed to upload file";
        }

        public string UpdateFile(int id, FileStorageDTO files)
        {
           var file = (from row in _hRMSContext.Files
                       where row.Id == id
                       select row).FirstOrDefault();
            if(file==null)
            {
                return "File not found";
            }

            bool UseLocalDatabase = _configuration.GetValue<bool>("DatabaseSettings:UseLocalDatabase");

            string url;

            if (UseLocalDatabase)
            {
                url = files.FileContent!=null? _localStorageOperations.StoreFiles(files.FileContent, "HRMS_Files") :file.FileUrl;
            }
            else
            {
                url = files.FileContent != null ? _azureOperations.StoreFilesInAzure(files.FileContent, "hrms-files") : file.FileUrl;
            }

            file.ObjectId = files?.ObjectId??file.ObjectId;
            file.ObjectName = files?.ObjectName ??file.ObjectName;
            file.Tags = files?.Tags??file.Tags;
            file.FileUrl = url;

            _hRMSContext.Files.Update(file);
            var res = _hRMSContext.SaveChanges();

            if(res !=  0 )
            {
                return "File updated successfully";
            }

            return "failed to update File";
        }

        public bool SoftDelete(int id, bool isActive)
        {
            var file = (from row in _hRMSContext.Files
                        where row.Id == id
                        select row).SingleOrDefault();

            if (file!=null)
            {
                file.IsActive = isActive;
                _hRMSContext.Files.Update(file);
                _hRMSContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
