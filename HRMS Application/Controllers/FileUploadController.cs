using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly ILogger<FileUploadController> _logger;
        private readonly IFileUpload _fileUpload;

        public FileUploadController( ILogger<FileUploadController> logger,IFileUpload fileUpload)
        {
            _logger = logger;
            _fileUpload = fileUpload;
        }

        [HttpPost]
        public string UploadFile([FromForm] FileUploadDTO files)
        {
            var res = _fileUpload.UploadFile(files);
            return res;
        }


    }
}
