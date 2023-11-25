﻿using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess
{
	public class CarDAO
	{
		private static CarDAO instance = null;
		private static readonly object instanceLock = new object();
		public static CarDAO Instance
		{
			get
			{
				lock (instanceLock)
				{
					if (instance == null)
					{
						instance = new CarDAO();
					}
				}
				return instance;
			}
		}

		public IEnumerable<Car> GetCarList()
		{
			var cars = new List<Car>();
			try
			{
				using var context = new MyStockContext();
				cars = context.Cars.ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return cars;
		}

		public Car GetCarByID(int carID)
		{
			Car car = null;
			try
			{
				using var context = new MyStockContext();
				car = context.Cars.FirstOrDefault(c => c.CarId == carID);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return car;
		}

		public void AddNew(Car car)
		{
			try
			{
					using var context = new MyStockContext();
					context.Cars.Add(car);
					context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

		}

		public void Update(Car car)
		{
			try
			{
				Car _car = GetCarByID(car.CarId);
				if (_car != null)
				{
					using var context = new MyStockContext();
					context.Cars.Update(car);
					context.SaveChanges();
				}
				else
				{
					throw new Exception("The car is already exist.");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void Remove(Car car)
		{
			try
			{
				Car _car = GetCarByID(car.CarId);
				if (car != null)
				{
					using var context = new MyStockContext();
					context.Cars.Remove(car);
					context.SaveChanges();
				}
				else
				{
					throw new Exception("The car is already exist.");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
