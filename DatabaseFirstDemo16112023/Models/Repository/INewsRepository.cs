using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo16112023.Models.Repository
{
	public interface INewsRepository
	{
		IEnumerable<News> GetNews();
		News GetNewsByID(int newsId);
		void InsertNews(News news);
		void UpdateNews(News news);
		void DeleteNews(int newsId);
	}
}
