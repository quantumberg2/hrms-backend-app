using HRMS_Application.DTO;
using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface INewsPreview
    {
        public List<NewsPreview> GetAllNews();    
        public string InsertNews(NewsDTO news);
        public string UpdateNews(int id, NewsDTO news);
        public bool SoftDelete(int id, short isActive);
    }
}
