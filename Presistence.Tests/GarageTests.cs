using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ESolutions.Youmoto.Persistence.Tests
{
	[TestClass]
	public class GarageTests
	{
		//Constants
		#region vehicleName
		private const String vehicleName = "TestVehicle";
		#endregion

		#region garageTitle
		private const String garageTitle = "GarageTitle";
		#endregion

		#region userEmail
		private const String userEmail = "ich@youmoto.de";
		#endregion

		#region userPassword
		private const String userPassword = "testPassword";
		#endregion

		//Methods
		#region CreateAndSaveGarage
		[TestMethod]
		public void CreateAndSaveGarage()
		{
			using (var context = new YoumotoDbContext(Effort.DbConnectionFactory.CreateTransient()))
			{
				//User user = User.Create(GarageTests.userEmail, GarageTests.userPassword, GarageTests.userPassword);
				//context.Users.Add(user);

				//Vehicle vehicle = Vehicle.Create(GarageTests.vehicleName);
				//context.Vehicles.Add(vehicle);

				//Garage garage = Garage.Create(user, vehicle, GarageTests.garageTitle);
				//context.Garages.Add(garage);

				//context.SaveChanges();
			}
		}
		#endregion
	}
}
