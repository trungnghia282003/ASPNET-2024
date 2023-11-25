using DatabaseFirstDemo16112023.Models;
using DatabaseFirstDemo16112023.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CodeDemo14112023.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class NewsCategoryController : BaseController
	{
		INewsCategoryRepository newsCategoryRepository = null;
		public NewsCategoryController()
		{
			newsCategoryRepository = new NewsCategoryRepository();
		}
		public IActionResult Index()
		{
			var result = newsCategoryRepository.GetAll();
			return View(result);
		}

		// GET: Admin/Roles/Create
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public JsonResult Create(NewsCategory newCategory)
		{
			try
			{
				newsCategoryRepository.Insert(newCategory);
				SetAlert("Insert Data is success!", "success");
				return Json(new { success = true });
			}
			catch (Exception ex)
			{
				return Json(new { success = false, message = ex.Message });
			}
			return Json(new { success = false });
		}

		/*  public IActionResult Edit(int id)
		  {
			  NewsCategory newCategory = newsCategoryRepository.GetById(id);
			  return View(newCategory);
		  }*/

		[HttpGet]
		public IActionResult Edit(int id)
		{
			NewsCategory newsCategory = newsCategoryRepository.GetById(id);
			var data = new
			{
				Id = newsCategory.Id,
				Name = newsCategory.CategoryName
				// Các trường khác
			};

			return new JsonResult(new { success = true, data = data });
		}

		[HttpPost]
		public JsonResult Edit(NewsCategory newsCategory)
		{
			try
			{
				if (ModelState.IsValid)
				{
					newsCategoryRepository.Update(newsCategory);
					SetAlert("Update Data is success!", "success");
					return Json(new { success = true });
				}
			}
			catch (Exception ex)
			{
				return Json(new { success = false, message = ex.Message });
			}
			return Json(new { success = false });
		}

		[HttpPost]
		public JsonResult Delete(NewsCategory newCategory)
		{
			try
			{
				newsCategoryRepository.Delete(newCategory);
				SetAlert("Delete Data is success!", "success");
				return Json(new { success = true });
			}
			catch (Exception ex)
			{
				return Json(new { success = false, message = ex.Message });
			}
			return Json(new { success = false });
		}
	}
}
