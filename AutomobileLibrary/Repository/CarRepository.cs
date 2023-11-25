using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository
{
	public class CarRepository : ICarRepository
	{
		public IEnumerable<Car> GetCars() => CarDAO.Instance.GetCarList();
		public Car GetCarByID(int id) => CarDAO.Instance.GetCarByID(id);
		public void Add(Car car) => CarDAO.Instance.AddNew(car);
		public void Update(Car car) => CarDAO.Instance.Update(car);
		public void Delete(Car car) => CarDAO.Instance.Remove(car);
	}
}
