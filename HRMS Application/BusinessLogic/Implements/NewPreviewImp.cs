using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Models;
using System.Collections.Immutable;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class NewPreviewImp : INewsPreview
    {
        private readonly HRMSContext _hRMSContext;
        private readonly IAzureOperations _azureOperations;
        public NewPreviewImp( HRMSContext hRMSContext, IAzureOperations azureOperations)
        {
            _hRMSContext = hRMSContext;
            _azureOperations = azureOperations;

        }

        public List<NewsPreview> GetAllNews()
        {
             var newsInfo = (from row in _hRMSContext.NewsPreviews
                             select row).ToList();
            return newsInfo;
        }

        public string InsertNews(NewsDTO news)
        {
            string url;

            url = _azureOperations.StoreFilesInAzure(news.ImgUrl, "news");

            NewsPreview objNews = new NewsPreview
            {
                Desciption = news.Desciption,
                InsertedDate = news.InsertedDate,
                Heading = news.Heading,
                ImgUrl = url,
                IsActive = 1              
            };

            if (objNews != null)
            {
                _hRMSContext.NewsPreviews.Add(objNews);
                _hRMSContext.SaveChanges();
                return "New data inserted successfully";

            }
            return "Failed to insert new data";
          
        }

        public string UpdateNews(int id, NewsDTO news)
        {
            var res = (from row in _hRMSContext.NewsPreviews
                       where row.Id == id
                       select row).SingleOrDefault();
            if (res == null)
            {
                return "No data found";
            }

            string url = _azureOperations.StoreFilesInAzure(news.ImgUrl, "news");

            res.DisplayDate = news?.DisplayDate ?? res.DisplayDate;
            res.InsertedDate = news?.InsertedDate ?? res.DisplayDate;
            res.Heading = news?.Heading ?? res.Heading;
            res.Desciption = news?.Desciption ?? res.Desciption;
            res.ImgUrl = url;

            if(res!=null)
            {
                _hRMSContext.NewsPreviews.Update(res);
                _hRMSContext.SaveChanges();
                return "News updated successfully";
            }
            return "Failed to update news data";
        }

        public bool SoftDelete(int id, short isActive)
        {
            var res = (from row in _hRMSContext.NewsPreviews
                       where row.Id == id
                       select row).FirstOrDefault();
            if(res!=null)
            {
                res.IsActive = isActive;
                _hRMSContext.NewsPreviews.Update(res);
                _hRMSContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
