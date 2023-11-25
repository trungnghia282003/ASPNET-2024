using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo16112023.Models.DataAccess
{
	public class NewsDAO
	{
		private static NewsDAO instance = null;
		private static readonly object instanceLock = new object();
		public static NewsDAO Instance
		{
			get
			{
				lock (instanceLock)
				{
					if (instance == null)
					{
						instance = new NewsDAO();
					}
				}
				return instance;
			}
		}

		public IEnumerable<News> GetNews()
		{
			var news = new List<News>();
			try
			{
				using var context = new ProductManagementContext();
				news = context.News.ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return news;
		}

		public News GetNewsByID(int newsID)
		{
			News news = null;
			try
			{
				using var context = new ProductManagementContext();
				news = context.News.SingleOrDefault(n => n.Id == newsID);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return news;
		}

		public void AddNew(News news)
		{
			try
			{
				News _news = GetNewsByID(news.Id);
				if (_news == null)
				{
					using var context = new ProductManagementContext();
					context.News.Add(news);
					context.SaveChanges();
				}
				else
				{
					throw new Exception("News is already exist");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void Update(News news)
		{
			try
			{
				News _news = GetNewsByID(news.Id);
				if (_news == null)
				{
					using var context = new ProductManagementContext();
					context.News.Update(news);
					context.SaveChanges();
				}
				else
				{
					throw new Exception("News does not already exist.");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void Remove(int newsID)
		{
			try
			{
				News news = GetNewsByID(newsID);
				if (news == null)
				{
					using var context = new ProductManagementContext();
					context.News.Remove(news);
					context.SaveChanges();
				}
				else
				{
					throw new Exception("News does not already exist.");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}

