using System.ComponentModel.DataAnnotations;

namespace MyCodeFirstApproachDemo1.Models
{
	public class Employee
	{
		[Display(Name = "Mã người dùng")]
		[Required(ErrorMessage = "Id không được để trống")]
		public int Id { get; set; }
		[Display(Name = "Họ tên")]
		[Required(ErrorMessage = "Họ tên không được để trống")]
		public string FullName { get; set; }
		[Display(Name = "Tuổi")]
		[Range(18, 60, ErrorMessage = "Tuổi phải từ 18 đến 60")]
		[Required(ErrorMessage = "Tuổi không được để trống")]
		public int Age { get; set; }
		[Required(ErrorMessage = "Số điện thoại không được để trống")]
		[Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
		public string PhoneNumber { get; set; }
		[Url(ErrorMessage = "Địa chỉ URL không hợp lệ")]
		public string? Website { get; set; }
		public string? Email { get; set; }
	}
}
