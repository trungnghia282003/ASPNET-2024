using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo16112023.Models.Repository
{
	public interface IUsersRepository
	{
		IEnumerable<User> GetAll();
		void Insert(User user, UsersDetail UsersDetail);
		void Update(User user, UsersDetail UsersDetail);
		User GetById(int id);
		void Delete(User user);
		IEnumerable<Role> GetAllRoles();
		bool ChangeStatus(int id);
		IEnumerable<UsersDetail> GetUsersDetailAll();
		void InsertUser(User user);
		void InsertUsersDetail(UsersDetail UsersDetail);
		void UpdateUser(User user);
		void UpdateUsersDetail(UsersDetail UsersDetail);
	}
}
