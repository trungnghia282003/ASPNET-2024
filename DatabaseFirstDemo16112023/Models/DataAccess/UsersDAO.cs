using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo16112023.Models.DataAccess
{
	public class UsersDAO
	{
		private static UsersDAO instance;
		private static readonly object instanceLock = new object();
		public static UsersDAO Instance
		{
			get
			{
				lock (instanceLock)
				{
					if (instance == null)
					{
						instance = new UsersDAO();
					}
					return instance;
				}
			}
		}

		public List<User> GetAll()
		{
			List<User> user;
			try
			{
				using ProductManagementContext stock = new ProductManagementContext();
				user = stock.Users.ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return user;
		}

		public User GetById(int? id)
		{
			User UsersDetail;
			try
			{
				using ProductManagementContext stock = new ProductManagementContext();
				UsersDetail = stock.Users.SingleOrDefault(r => r.UserId == id);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return UsersDetail;
		}

		public List<UsersDetail> GetUsersDetailAll()
		{
			List<UsersDetail> listUsersDetail;
			try
			{
				using ProductManagementContext stock = new ProductManagementContext();
				listUsersDetail = stock.UsersDetails.ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return listUsersDetail;
		}

		public void Insert(User user, UsersDetail UsersDetail)
		{
			using ProductManagementContext stock = new ProductManagementContext();
			using (var transaction = stock.Database.BeginTransaction())
			{
				try
				{

					stock.Add(user);
					stock.Add(UsersDetail);
					stock.SaveChanges();
					transaction.Commit();
				}
				catch (Exception ex)
				{
					transaction.Rollback();
					throw new Exception(ex.Message);
				}
			}
		}

		public void InsertUser(User user)
		{
			using ProductManagementContext stock = new ProductManagementContext();
			using (var transaction = stock.Database.BeginTransaction())
			{
				try
				{

					stock.Add(user);
					stock.SaveChanges();
					transaction.Commit();
				}
				catch (Exception ex)
				{
					transaction.Rollback();
					throw new Exception(ex.Message);
				}
			}
		}

		public void InsertUsersDetail(UsersDetail user)
		{
			using ProductManagementContext stock = new ProductManagementContext();
			using (var transaction = stock.Database.BeginTransaction())
			{
				try
				{

					stock.Add(user);
					stock.SaveChanges();
					transaction.Commit();
				}
				catch (Exception ex)
				{
					transaction.Rollback();
					throw new Exception(ex.Message);
				}
			}
		}

		public void Update(User user, UsersDetail UsersDetail)
		{
			using ProductManagementContext stock = new ProductManagementContext();
			using (var transaction = stock.Database.BeginTransaction())
			{
				try
				{
					stock.Entry<User>(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					stock.Entry<UsersDetail>(UsersDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					stock.SaveChanges();
					transaction.Commit();
				}
				catch (Exception ex)
				{
					transaction.Rollback();
					throw new Exception(ex.Message);
				}
			}
		}

		public void UpdateUser(User user)
		{
			using ProductManagementContext stock = new ProductManagementContext();
			using (var transaction = stock.Database.BeginTransaction())
			{
				try
				{
					stock.Entry<User>(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					stock.SaveChanges();
					transaction.Commit();
				}
				catch (Exception ex)
				{
					transaction.Rollback();
					throw new Exception(ex.Message);
				}
			}
		}

		public void UpdateUsersDetail(UsersDetail UsersDetail)
		{
			using ProductManagementContext stock = new ProductManagementContext();
			using (var transaction = stock.Database.BeginTransaction())
			{
				try
				{
					stock.Entry<UsersDetail>(UsersDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					stock.SaveChanges();
					transaction.Commit();
				}
				catch (Exception ex)
				{
					transaction.Rollback();
					throw new Exception(ex.Message);
				}
			}
		}

		public IEnumerable<Role> GetAllRoles()
		{
			using ProductManagementContext stock = new ProductManagementContext();
			return stock.Roles.ToList();
		}

		public void Delete(User user)
		{
			try
			{
				using ProductManagementContext stock = new ProductManagementContext();
				var rl = stock.Users.SingleOrDefault(c => c.UserId == user.UserId);
				stock.Remove(rl);
				stock.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool ChangeStatus(int id)
		{
			using ProductManagementContext stock = new ProductManagementContext();
			var user = stock.Users.Find(id);
			user.Status = !user.Status;
			stock.SaveChanges();
			return (bool)user.Status;
		}
	}
}
