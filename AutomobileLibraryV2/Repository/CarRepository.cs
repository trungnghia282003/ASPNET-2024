using AutomobileLibraryV2.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibraryV2.Repository
{
	public class CarRepository : ICarRepository
	{
		public Car GetCarByID(int carId) => CarDAO.Instance.GetCarByID(carId);
		public IEnumerable<Car> GetCars() => CarDAO.Instance.GetCarList();
		public void InsertCar(Car car) => CarDAO.Instance.AddNew(car);
		public void UpdateCar(Car car) => CarDAO.Instance.Update(car);
		public void DeleteCar(int carId) => CarDAO.Instance.Remove(carId);
	}
}
