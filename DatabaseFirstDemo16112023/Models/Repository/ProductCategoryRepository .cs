using DatabaseFirstDemo16112023.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo16112023.Models.Repository
{
	public class ProductCategoryRepository : IProductCategoryRepository
	{
		public IEnumerable<ProductCategory> GetProductCategories() => ProductCategoryDAO.Instance.GetProductCategories();
		public ProductCategory GetProductCategoryByID(int productCategoryId) => ProductCategoryDAO.Instance.GetProductCategoryByID(productCategoryId);
		public void InsertProductCategory(ProductCategory productCategory) => ProductCategoryDAO.Instance.AddNew(productCategory);
		public void UpdateProductCategory(ProductCategory productCategory) => ProductCategoryDAO.Instance.Update(productCategory);
		public void DeleteProductCategory(int productCategoryId) => ProductCategoryDAO.Instance.Remove(productCategoryId);
	}
}
