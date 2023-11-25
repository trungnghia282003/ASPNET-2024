using DatabaseFirstDemo16112023.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo16112023.Models.Repository
{
	public class NewsRepository : INewsRepository
	{
		public IEnumerable<News> GetNews() => NewsDAO.Instance.GetNews();
		public News GetNewsByID(int newsId) => NewsDAO.Instance.GetNewsByID(newsId);
		public void InsertNews(News news) => NewsDAO.Instance.AddNew(news);
		public void UpdateNews(News news) => NewsDAO.Instance.Update(news);
		public void DeleteNews(int newsId) => NewsDAO.Instance.Remove(newsId);
	}
}
