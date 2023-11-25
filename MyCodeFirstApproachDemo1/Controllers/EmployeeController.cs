using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCodeFirstApproachDemo1.Models;

namespace MyCodeFirstApproachDemo1.Controllers
{
	public class EmployeeController : Controller
	{
		// GET: EmployeeController
		public ActionResult Index()
		{
			return View();
		}

		// GET: EmployeeController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: EmployeeController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: EmployeeController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Employee em)
		{
			if (ModelState.IsValid)
			{
				ViewBag.alert = "alert-success";
				ViewBag.Message = "Success!";
			}
			return View();
		}

		// GET: EmployeeController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: EmployeeController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: EmployeeController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: EmployeeController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
