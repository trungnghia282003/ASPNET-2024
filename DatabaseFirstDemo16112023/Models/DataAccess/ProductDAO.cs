using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo16112023.Models.DataAccess
{
	public class ProductDAO
	{
		private static ProductDAO instance = null;
		private static readonly object instanceLock = new object();
		public static ProductDAO Instance
		{
			get
			{
				lock (instanceLock)
				{
					if (instance == null)
					{
						instance = new ProductDAO();
					}
				}
				return instance;
			}
		}

		public IEnumerable<Product> GetProducts()
		{
			var product = new List<Product>();
			try
			{
				using var context = new ProductManagementContext();
				product = context.Products.ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return product;
		}

		public Product GetProductByID(int productID)
		{
			Product product = null;
			try
			{
				using var context = new ProductManagementContext();
				product = context.Products.SingleOrDefault(r => r.Id == productID);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return product;
		}

		public void AddNew(Product product)
		{
			try
			{
				Product _product = GetProductByID(product.Id);
				if (_product == null)
				{
					using var context = new ProductManagementContext();
					context.Products.Add(product);
					context.SaveChanges();
				}
				else
				{
					throw new Exception("Product is already exist");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void Update(Product product)
		{
			try
			{
				Product _product = GetProductByID(product.Id);
				if (_product == null)
				{
					using var context = new ProductManagementContext();
					context.Products.Update(product);
					context.SaveChanges();
				}
				else
				{
					throw new Exception("Product does not already exist.");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void Remove(int productID)
		{
			try
			{
				Product product = GetProductByID(productID);
				if (product == null)
				{
					using var context = new ProductManagementContext();
					context.Products.Remove(product);
					context.SaveChanges();
				}
				else
				{
					throw new Exception("Product does not already exist.");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}

