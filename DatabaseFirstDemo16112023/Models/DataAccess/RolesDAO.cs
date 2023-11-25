using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo16112023.Models.DataAccess
{
	public class RolesDAO
	{
		private static RolesDAO instance;
		private static readonly object instanceLock = new object();
		public static RolesDAO Instance
		{
			get
			{
				lock (instanceLock)
				{
					if (instance == null)
					{
						instance = new RolesDAO();
					}
					return instance;
				}
			}
		}

		public IEnumerable<Role> GetAll()
		{
			List<Role> roles;
			try
			{
				using ProductManagementContext stock = new ProductManagementContext();
				roles = stock.Roles.ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return roles;
		}

		public Role GetById(int? id)
		{
			Role role;
			try
			{
				using ProductManagementContext stock = new ProductManagementContext();
				role = stock.Roles.SingleOrDefault(r => r.Id == id);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return role;
		}

		public void Insert(Role role)
		{
			try
			{
				using ProductManagementContext stock = new ProductManagementContext();
				stock.Add(role);
				stock.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void Update(Role role)
		{
			try
			{
				using ProductManagementContext stock = new ProductManagementContext();
				stock.Entry<Role>(role).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				stock.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void Delete(Role role)
		{
			try
			{
				using ProductManagementContext stock = new ProductManagementContext();
				var rl = stock.Roles.SingleOrDefault(c => c.Id == role.Id);
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
