using DatabaseFirstDemo16112023.Models.Repository;
using DatabaseFirstDemo16112023.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Azure.Core.HttpHeader;
using CodeDemo14112023.Areas.Admin.Models;

namespace CodeDemo14112023.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UsersController : BaseController
	{	
		IUsersRepository userRepository = null;
		IRolesRepository roleRepository = null;
		public UsersController()
		{
			userRepository = new UsersRepository();
			roleRepository = new RolesRepository();
		}
		public IActionResult Index()
		{
			// Lấy danh sách quyền truy cập từ Repository hoặc Database
			IEnumerable<Role> roles = roleRepository.GetAll();

			// Tạo SelectList từ danh sách quyền truy cập
			SelectList selectList = new SelectList(roles, "Id", "Name");

			// Lưu SelectList vào ViewBag để sử dụng trong View
			ViewBag.Roles = selectList;

			IEnumerable<User> users = userRepository.GetAll();
			IEnumerable<UsersDetail> usersdetail = userRepository.GetUsersDetailAll();
			return View(new RoleUser
			{
				Roles = (ICollection<Role>)roles,
				Users = (ICollection<User>)users,
				UserDetails = (ICollection<UsersDetail>)usersdetail,
			});
			return View(users);
		}

		// GET: Admin/Roles/Create
		public IActionResult Create()
		{
			ViewBag.Roles = new SelectList(userRepository.GetAllRoles(), "Id", "Name");
			return View();
		}

		[HttpPost]
		public JsonResult Create(User users, UsersDetail UsersDetails)
		{
			try
			{
				// Lấy giá trị từ các trường thuộc tính của user trong form
				var user = new User
				{
					UserName = users.UserName,
					Password = users.Password,
					RoleId = users.RoleId,
					Status = users.Status
				};

				// Lấy giá trị từ các trường thuộc tính của UsersDetail trong form
				var UsersDetail = new UsersDetail
				{
					FullName = UsersDetails.FullName,
					Address = UsersDetails.Address,
					Email = UsersDetails.Email
				};
				/*  if (ModelState.IsValid)
                  {*/
				userRepository.InsertUser(user);
				// Gán giá trị UserId mới tạo cho thuộc tính UserId của UsersDetail
				UsersDetail.UserId = user.UserId;
				userRepository.InsertUsersDetail(UsersDetail);
				SetAlert("Insert Data is success!", "success");
				return Json(new { success = true });
				/* }*/
			}
			catch (Exception ex)
			{
				return Json(new { success = false, message = ex.Message });
			}
			return Json(new { success = false });
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			User user = userRepository.GetById(id);
			ViewBag.Roles = new SelectList(userRepository.GetAllRoles(), "Id", "Name", user.RoleId);
			var data = new
			{
				Id = user.UserId,
				Name = user.UserName,
				Password = user.Password,
				Status = user.Status,
				RoleId = user.RoleId,
				FullName = user.UsersDetail.FullName,
				Address = user.UsersDetail.Address,
				Email = user.UsersDetail.Email
				// Các trường khác
			};

			return new JsonResult(new { success = true, data = data });
		}

		[HttpPost]
		public JsonResult Edit(User users, UsersDetail UsersDetails)
		{
			try
			{
				// Lấy giá trị từ các trường thuộc tính của user trong form
				var user = new User
				{
					UserId = users.UserId,
					UserName = users.UserName,
					Password = users.Password,
					RoleId = users.RoleId,
					Status = users.Status
				};

				// Lấy giá trị từ các trường thuộc tính của UsersDetail trong form
				var UsersDetail = new UsersDetail
				{
					UserId = UsersDetails.UserId,
					FullName = UsersDetails.FullName,
					Address = UsersDetails.Address,
					Email = UsersDetails.Email
				};
				userRepository.UpdateUser(user);
				userRepository.UpdateUsersDetail(UsersDetail);
				SetAlert("Update Data is success!", "success");
				return Json(new { success = true });
			}
			catch (Exception ex)
			{
				return Json(new { success = false, message = ex.Message });
			}
			return Json(new { success = false });
		}

		[HttpPost]
		public JsonResult Delete(User user)
		{
			try
			{
				userRepository.Delete(user);
				SetAlert("Delete Data is success!", "success");
			}
			catch (Exception ex)
			{
				return Json(new { success = false, message = ex.Message });
			}
			return Json(new { success = true });
		}

		[HttpPost]
		public JsonResult ChangeStatus(int id)
		{
			var result = userRepository.ChangeStatus(id);
			return Json(new
			{
				status = result
			});
		}
	}
}
