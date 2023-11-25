using DatabaseFirstDemo16112023.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo16112023.Models.Repository
{
	public class UsersRepository : IUsersRepository
	{
		public IEnumerable<User> GetAll() => UsersDAO.Instance.GetAll();
		public void Insert(User user, UsersDetail UsersDetail) => UsersDAO.Instance.Insert(user, UsersDetail);
		public void Update(User user, UsersDetail UsersDetail) => UsersDAO.Instance.Update(user, UsersDetail);
		public User GetById(int id) => UsersDAO.Instance.GetById(id);
		public void Delete(User user) => UsersDAO.Instance.Delete(user);
		public IEnumerable<Role> GetAllRoles() => UsersDAO.Instance.GetAllRoles();
		public bool ChangeStatus(int id) => UsersDAO.Instance.ChangeStatus(id);
		public IEnumerable<UsersDetail> GetUsersDetailAll() => UsersDAO.Instance.GetUsersDetailAll();
		public void InsertUser(User user) => UsersDAO.Instance.InsertUser(user);
		public void InsertUsersDetail(UsersDetail UsersDetail) => UsersDAO.Instance.InsertUsersDetail(UsersDetail);
		public void UpdateUser(User user) => UsersDAO.Instance.UpdateUser(user);
		public void UpdateUsersDetail(UsersDetail UsersDetail) => UsersDAO.Instance.UpdateUsersDetail(UsersDetail);
	}
}
