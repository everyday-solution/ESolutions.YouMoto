using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ESolutions.Youmoto.Persistence.Tests
{
	[TestClass]
	public class SeriesTests
	{
		//Constants
		#region manufacturerName
		private const String manufacturerName = "TestManufacturer";
		#endregion

		#region seriesName
		private const String seriesName = "TestSeries";
		#endregion

		//Methods
		#region CreateAndSaveSeries
		[TestMethod]
		public void CreateAndSaveSeries()
		{
			using (var context = new YoumotoDbContext(Effort.DbConnectionFactory.CreateTransient()))
			{
				Manufacturer manufacturer = Manufacturer.Create(SeriesTests.manufacturerName);
				Series series = Series.Create(manufacturer, SeriesTests.seriesName);

				context.Manufacturers.Add(manufacturer);
				context.Series.Add(series);
				context.SaveChanges();

				Assert.AreEqual(SeriesTests.seriesName, series.Name);
			}
		}
		#endregion
	}
}
