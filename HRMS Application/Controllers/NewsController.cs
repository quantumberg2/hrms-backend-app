using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly ILogger<NewsController> _logger;
        private readonly INews _news;
        public NewsController(ILogger<NewsController> logger, INews news)
        {
            _logger = logger;
            _news = news;
        }

        [HttpGet]
        public List<News> GetAllNews()
        {
            _logger.LogInformation("Get all news from news method started");
            var res = _news.GetAllNews();
            return res;
        }

        [HttpPost]
        public string InsertNews(News newNews)
        {
            _logger.LogInformation("Insert news for news table method started");
            var res = _news.InsertNews(newNews);
            return res;

        }

        [HttpPut]
        public string UpdateNews(News newNews)
        {
            _logger.LogInformation("update news of news table method started");
            var res = _news.UpdateNews(newNews);
            return res;

        }

        [HttpDelete]
        public string DeleteNews(int id)
        {
            _logger.LogInformation("Delete news from news table method started");
            var res = _news.DeleteNews(id);
            return res;
        }


    }
}
