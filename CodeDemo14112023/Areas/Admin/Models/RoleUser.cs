using DatabaseFirstDemo16112023.Models;

namespace CodeDemo14112023.Areas.Admin.Models
{
	public class RoleUser
	{
		internal ICollection<UsersDetail> UsersDetails;
		public ICollection<Role> Roles { get; set; }
		public ICollection<User> Users { get; set; }
		public ICollection<UsersDetail> UserDetails { get; set; }
	}
}
