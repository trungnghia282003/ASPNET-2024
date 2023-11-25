using DatabaseFirstDemo16112023.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo16112023.Models.Repository
{
	public class RolesRepository : IRolesRepository
	{
		public IEnumerable<Role> GetAll() => RolesDAO.Instance.GetAll();
		public void Insert(Role role) => RolesDAO.Instance.Insert(role);
		public void Update(Role role) => RolesDAO.Instance.Update(role);
		public Role GetById(int id) => RolesDAO.Instance.GetById(id);
		public void Delete(Role role) => RolesDAO.Instance.Delete(role);
	}
}
