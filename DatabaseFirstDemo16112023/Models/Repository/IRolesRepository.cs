using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo16112023.Models.Repository
{
	public interface IRolesRepository
	{
		IEnumerable<Role> GetAll();
		void Insert(Role role);
		void Update(Role role);
		Role GetById(int id);
		void Delete(Role role);
	}
}
