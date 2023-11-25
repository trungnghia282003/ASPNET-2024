using DatabaseFirstDemo16112023.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo16112023.Models.Repository
{
	public class ProductRepository : IProductRepository
	{
		public IEnumerable<Product> GetProducts() => ProductDAO.Instance.GetProducts();
		public Product GetProductByID(int productId) => ProductDAO.Instance.GetProductByID(productId);
		public void InsertProduct(Product product) => ProductDAO.Instance.AddNew(product);
		public void UpdateProduct(Product product) => ProductDAO.Instance.Update(product);
		public void DeleteProduct(int productId) => ProductDAO.Instance.Remove(productId);
	}
}
