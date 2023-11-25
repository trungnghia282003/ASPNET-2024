using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo16112023.Models.DataAccess
{
	public class NewsCategoryDAO
	{
		private static NewsCategoryDAO instance;
		private static readonly object instanceLock = new object();
		public static NewsCategoryDAO Instance
		{
			get
			{
				lock (instanceLock)
				{
					if (instance == null)
					{
						instance = new NewsCategoryDAO();
					}
					return instance;
				}
			}
		}

		public List<NewsCategory> GetAll()
		{
			List<NewsCategory> newsCategory;
			try
			{
				using ProductManagementContext stock = new ProductManagementContext();
				newsCategory = stock.NewsCategories.ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return newsCategory;
		}

		public NewsCategory GetById(int? id)
		{
			NewsCategory newsCategory;
			try
			{
				using ProductManagementContext stock = new ProductManagementContext();
				newsCategory = stock.NewsCategories.SingleOrDefault(r => r.Id == id);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return newsCategory;
		}

		public void Insert(NewsCategory newsCategory)
		{
			try
			{
				using ProductManagementContext stock = new ProductManagementContext();
				stock.Add(newsCategory);
				stock.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void Update(NewsCategory newsCategory)
		{
			try
			{
				using ProductManagementContext stock = new ProductManagementContext();
				stock.Entry<NewsCategory>(newsCategory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				stock.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void Delete(NewsCategory newsCategory)
		{
			try
			{
				using ProductManagementContext stock = new ProductManagementContext();
				var rl = stock.NewsCategories.SingleOrDefault(c => c.Id == newsCategory.Id);
				stock.Remove(rl);
				stock.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}

