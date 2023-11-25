using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo16112023.Models.Repository
{
	public interface INewsCategoryRepository
	{
		IEnumerable<NewsCategory> GetAll();
		void Insert(NewsCategory newsCategory);
		void Update(NewsCategory newsCategory);
		NewsCategory GetById(int newsCategory);
		void Delete(NewsCategory newsCategory);
	}
}
