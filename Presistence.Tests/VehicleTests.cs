using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ESolutions.Youmoto.Persistence.Tests
{
	[TestClass]
	public class VehicleTests
	{
		//Constants
		#region manufacturerName
		private const String manufacturerName = "TestManufacturer";
		#endregion

		#region seriesName
		private const String seriesName = "TestSeries";
		#endregion

		#region vehicleName
		private const String vehicleName = "TestVehicle";
		#endregion

		//Methods
		#region CreateAndSaveVehicle
		[TestMethod]
		public void CreateAndSaveVehicle()
		{
			using (var context = new YoumotoDbContext(Effort.DbConnectionFactory.CreateTransient()))
			{
				Vehicle vehicle = Vehicle.Create(VehicleTests.vehicleName);

				context.Vehicles.Add(vehicle);
				context.SaveChanges();

				Assert.AreEqual(VehicleTests.vehicleName, vehicle.Name);
			}
		}
		#endregion

		#region CreateAndSaveVehicleWithAssociationToManufacturer
		[TestMethod]
		public void CreateAndSaveVehicleWithAssociationToManufacturer()
		{
			using (var context = new YoumotoDbContext(Effort.DbConnectionFactory.CreateTransient()))
			{
				Manufacturer manufacturer = Manufacturer.Create(VehicleTests.manufacturerName);
				context.Manufacturers.Add(manufacturer);

				Vehicle vehicle = Vehicle.Create(VehicleTests.vehicleName);
				context.Vehicles.Add(vehicle);

				ManufacturerVehicle manufacturerVehicle = ManufacturerVehicle.Create(manufacturer, vehicle);
				context.ManufacturerVehicles.Add(manufacturerVehicle);

				context.SaveChanges();

				Assert.AreEqual(1, vehicle.ManufacturerVehicles.Count());
				Assert.AreEqual(manufacturer, vehicle.ManufacturerVehicles.First().Manufacturer);
			}
		}
		#endregion

		#region CreateAndSaveVehicleWithAssociationToSeries
		[TestMethod]
		public void CreateAndSaveVehicleWithAssociationToSeries()
		{
			using (var context = new YoumotoDbContext(Effort.DbConnectionFactory.CreateTransient()))
			{
				Manufacturer manufacturer = Manufacturer.Create(VehicleTests.manufacturerName);
				context.Manufacturers.Add(manufacturer);

				Series series = Series.Create(manufacturer, VehicleTests.seriesName);
				context.Series.Add(series);

				Vehicle vehicle = Vehicle.Create(VehicleTests.vehicleName);
				context.Vehicles.Add(vehicle);

				SeriesVehicle seriesVehicle = SeriesVehicle.Create(series, vehicle);
				context.SeriesVehicles.Add(seriesVehicle);

				context.SaveChanges();

				Assert.AreEqual(1, vehicle.SeriesVehicles.Count());
				Assert.AreEqual(series, vehicle.SeriesVehicles.First().Series);
			}
		}
		#endregion
	}
}
