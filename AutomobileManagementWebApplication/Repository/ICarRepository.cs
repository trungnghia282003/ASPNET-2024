using AutomobileManagementWebApplication.DataAccess;

namespace AutomobileManagementWebApplication.Repository
{
	public interface ICarRepository
	{
		IEnumerable<Car> GetCars();
		Car GetCarByID(int carId);
		void DeleteCar(int carId);
		void UpdateCar(Car car);
		void InsertCar(Car car);
	}
}
