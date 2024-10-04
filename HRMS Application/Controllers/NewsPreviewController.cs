using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsPreviewController : ControllerBase
    {
        private readonly ILogger<NewsPreviewController> _logger;
        private readonly INewsPreview _news;
        public NewsPreviewController(ILogger<NewsPreviewController> logger, INewsPreview news)
        {
            _logger = logger;
            _news = news;
        }

        [HttpGet]
        public List<NewsPreview> GetAllNews()
        {
            _logger.LogInformation("Get all News method started");
            var res = _news.GetAllNews();
            return res;
        }

        [HttpPost]
        public string InsertNews([FromForm] NewsDTO news)
        {
            _logger.LogInformation("Upload News method started");
             var res = _news.InsertNews(news);
            return res;
        }
        [HttpPut]
        public string UpdateNews(int id, NewsDTO news)
        {
            _logger.LogInformation("update News method started");
            var res= _news.UpdateNews(id, news);
            return res;

        }
        [HttpPut("SoftDelete")]
        public bool SoftDelete(int id, short isActive)
        {
            _logger.LogInformation("Delete News method started");
            var res = _news.SoftDelete(id, isActive);
            return res;
        }
    }
}
