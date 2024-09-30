using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface INews
    {
        public List<News> GetAllNews();
        public string InsertNews(News newNews);
        public string UpdateNews(News newNews);
        public string DeleteNews(int id);
    }
}
