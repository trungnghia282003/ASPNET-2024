using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutomobileLibrary.Repository;
using AutomobileLibrary.DataAccess;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AutomobileWebApp.Controllers
{
	public class CarsController : Controller
	{
		ICarRepository carRepository;
		public CarsController() => carRepository = new CarRepository();
		// GET: CarsController
		public ActionResult Index()
		{
			var carList = carRepository.GetCars();

			return View(carList);
		}

		// GET: CarsController/Details/5
		public ActionResult Details(int id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var car = carRepository.GetCarByID(id);
			if (car == null)
			{
				return NotFound();
			}
			return View(car);
		}

		// GET: CarsController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: CarsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Car car)
		{
			try
			{
				if (ModelState.IsValid)
				{
					carRepository.Add(car);
				}
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				ViewBag.Message = ex.Message;
				return View(car);
			}
		}

		// GET: CarsController/Edit/5
		public ActionResult Edit(int id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var car = carRepository.GetCarByID(id);
			if (car == null)
			{
				return NotFound();
			}
			return View(car);
		}

		// POST: CarsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, Car car)
		{
			try
			{
				if (id != car.CarId)
				{
					return NotFound();
				}
				if (ModelState.IsValid)
				{
					carRepository.Update(car);
				}
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				ViewBag.Message = ex.Message;
				return View(car);
			}
		}

		// GET: CarsController/Delete/5
		public ActionResult Delete(int id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var car = carRepository.GetCarByID(id);
			if (car == null)
			{
				return NotFound();
			}
			return View(car);
		}

		// POST: CarsController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, Car c)
		{
			try
			{
				var car = carRepository.GetCarByID(id);
				carRepository.Delete(car);
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				ViewBag.Message = ex.Message;
				return View(c);
			}
		}
	}
}
