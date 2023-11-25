using DatabaseFirstDemo16112023.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo16112023.Models.Repository
{
	public class NewsCategoryRepository : INewsCategoryRepository
	{
		public IEnumerable<NewsCategory> GetAll() => NewsCategoryDAO.Instance.GetAll();
		public void Insert(NewsCategory newsCategory) => NewsCategoryDAO.Instance.Insert(newsCategory);
		public void Update(NewsCategory newsCategory) => NewsCategoryDAO.Instance.Update(newsCategory);
		public NewsCategory GetById(int id) => NewsCategoryDAO.Instance.GetById(id);
		public void Delete(NewsCategory newsCategory) => NewsCategoryDAO.Instance.Delete(newsCategory);
	}
}
