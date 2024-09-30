using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class NewsImp : INews
    {
        private readonly HRMSContext _context;
        public NewsImp(HRMSContext context)
        {
            _context = context;
        }


        public List<News> GetAllNews()
        {
            var news = (from row in  _context.News
                        select row).ToList();
            return news;
        }


        public string InsertNews(News newNews)
        {
           var news =  _context.News.Add(newNews);

            if (news != null)
            {            
                _context.SaveChanges();
                return "Data inserted successfully";
            }

            return "Failed to insert news";
            
        }
        public string UpdateNews(News newNews)
        {
             var news = (from row in _context.News
                         where row.Id == newNews.Id
                         select row).FirstOrDefault();

            if(news != null)
            {
                _context.News.Update(news);
                _context.SaveChanges();
                return "News Updated Successfully";
            }

            return "Failed to Update News";
        }
        public string DeleteNews(int id)
        {
            var res = (from row in _context.News
                       where row.Id == id
                       select row).FirstOrDefault();

            if(res!= null)
            {
                _context.News.Remove(res);
                _context.SaveChanges();
                return "News deleted successfully";
            }
            return "Failed to delete news";
        }
    }
}
