using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity.Core.EntityClient;
using System.Linq;

namespace ESolutions.Youmoto.Persistence.Tests
{
	[TestClass]
	public class ManufacturerTests
	{
		//Constants
		#region manufacturerName
		private const String manufacturerName = "TestManufacturer";
		#endregion

		//Methods
		#region CreateAndSaveManufacturer
		[TestMethod]
		public void CreateAndSaveManufacturer()
		{
			using (var context = new YoumotoDbContext(Effort.DbConnectionFactory.CreateTransient()))
			{
				Manufacturer manufacturer = Manufacturer.Create(ManufacturerTests.manufacturerName);

				context.Manufacturers.Add(manufacturer);
				context.SaveChanges();

				Assert.AreEqual(ManufacturerTests.manufacturerName, manufacturer.Name);
            }
		}
		#endregion
	}
}
