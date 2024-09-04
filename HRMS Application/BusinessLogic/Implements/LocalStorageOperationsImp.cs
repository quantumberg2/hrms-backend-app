using HRMS_Application.BusinessLogic.Interface;
using System.Reflection.Metadata.Ecma335;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class LocalStorageOperationsImp : ILocalStorageOperations
    {
        public string StoreFiles(IFormFile file, string directory)
        {
            if(!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            string localFilePath = Path.Combine(directory, file.FileName);

            using (var stream = new FileStream(localFilePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return localFilePath;
        }
    }
}
