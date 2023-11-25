using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo16112023.Models.DataAccess
{
	public class ProductCategoryDAO
	{
		private static ProductCategoryDAO instance = null;
		private static readonly object instanceLock = new object();
		public static ProductCategoryDAO Instance
		{
			get
			{
				lock (instanceLock)
				{
					if (instance == null)
					{
						instance = new ProductCategoryDAO();
					}
				}
				return instance;
			}
		}

		public IEnumerable<ProductCategory> GetProductCategories()
		{
			var productCategories = new List<ProductCategory>();
			try
			{
				using var context = new ProductManagementContext();
				productCategories = context.ProductCategories.ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return productCategories;
		}

		public ProductCategory GetProductCategoryByID(int productCategoryID)
		{
			ProductCategory productCategory = null;
			try
			{
				using var context = new ProductManagementContext();
				productCategory = context.ProductCategories.SingleOrDefault(p => p.Id == productCategoryID);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return productCategory;
		}

		public void AddNew(ProductCategory productCategory)
		{
			try
			{
				ProductCategory _productCategory = GetProductCategoryByID(productCategory.Id);
				if (_productCategory == null)
				{
					using var context = new ProductManagementContext();
					context.ProductCategories.Add(productCategory);
					context.SaveChanges();
				}
				else
				{
					throw new Exception("ProductCategory is already exist");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void Update(ProductCategory productCategory)
		{
			try
			{
				ProductCategory _productCategory = GetProductCategoryByID(productCategory.Id);
				if (_productCategory == null)
				{
					using var context = new ProductManagementContext();
					context.ProductCategories.Update(productCategory);
					context.SaveChanges();
				}
				else
				{
					throw new Exception("ProductCategory does not already exist.");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void Remove(int productCategoryID)
		{
			try
			{
				ProductCategory productCategory = GetProductCategoryByID(productCategoryID);
				if (productCategory == null)
				{
					using var context = new ProductManagementContext();
					context.ProductCategories.Remove(productCategory);
					context.SaveChanges();
				}
				else
				{
					throw new Exception("ProductCategory does not already exist.");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}

