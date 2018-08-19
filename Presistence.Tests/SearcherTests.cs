using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ESolutions.Youmoto.Persistence.Tests
{
	[TestClass]
	public class SearcherTests
	{
		#region SearchExact
		[TestMethod]
		public void SearchExact()
		{
			using (var context = new YoumotoDbContext(Effort.DbConnectionFactory.CreateTransient()))
			{
				//var guid = Guid.NewGuid();
				//context.Vehicles.Add(new Vehicle() { Guid = guid });
				//context.SearchMatrix.Add(new SearchMatrixView() { });
				//context.SaveChanges();
			}
		}
		#endregion
	}
}
