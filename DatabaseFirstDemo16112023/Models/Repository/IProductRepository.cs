using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo16112023.Models.Repository
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetProducts();
		Product GetProductByID(int productId);
		void InsertProduct(Product product);
		void UpdateProduct(Product product);
		void DeleteProduct(int productId);
	}
}
