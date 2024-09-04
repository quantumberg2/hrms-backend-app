using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileStorageController : ControllerBase
    {
        private readonly ILogger<FileStorageController> _logger;
        private readonly IFileStorage _fileStorage;

        public FileStorageController( ILogger<FileStorageController> logger,IFileStorage fileStorage)
        {
            _logger = logger;
            _fileStorage = fileStorage;
        }

        [HttpGet("Get All Files")]
        public List<Models.File> GetFiles()
        {
            _logger.LogInformation("Get all files method started");
            var res = _fileStorage.GetFiles();
            return res;
        }

        [HttpPost]
        public string UploadFile([FromForm] FileStorageDTO file)
        {
            _logger.LogInformation("Upload file method started");
            var res = _fileStorage.UploadFile(file);
            return res;
        }


        [HttpPut]
        public string UpdateFile(int id,[FromForm] FileStorageDTO files)
        {       
            _logger.LogInformation("Update file method started");
            var res = _fileStorage.UpdateFile(id, files);
            return res;
        }

        [HttpPut("SoftDelete")]
        public bool SoftDelete(int id, bool isActive)
        {
            _logger.LogInformation("Soft delete method started");
            var res = _fileStorage.SoftDelete(id, isActive);
            return res;

        }

    }
}
