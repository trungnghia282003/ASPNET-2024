using AutomobileManagementWebApplication.DataAccess;

namespace AutomobileManagementWebApplication.Repository
{
	public class CarRepository : ICarRepository
	{
		public Car GetCartByID(int carId) => CarDAO.Instance.GetCarByID(carId);
		public IEnumerable<Car> GetCars() => CarDAO.Instance.GetCarsList();
		public void InsertCart(Car car) => CarDAO.Instance.AddNew(car);
		public void DeleteCar(int carId) => CarDAO.Instance.Remove(carId);
		public void UpdateCar(Car car) => CarDAO.Instance.Update(car);
	}
}
