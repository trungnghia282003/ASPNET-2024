using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo16112023.Models.Repository
{
	public interface IProductCategoryRepository
	{
		IEnumerable<ProductCategory> GetProductCategories();
		ProductCategory GetProductCategoryByID(int productCategoryId);
		void InsertProductCategory(ProductCategory productCategory);
		void UpdateProductCategory(ProductCategory productCategory);
		void DeleteProductCategory(int productCategoryId);
	}
}
