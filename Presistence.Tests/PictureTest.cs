using System;
using ESolutions.Youmoto.Persistence.Persister;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ESolutions.Youmoto.Persistence.Tests
{
	[TestClass]
	public class PictureTest
	{
		[TestMethod]
		public void TestLoadSingleWithNonExistingGuid()
		{
			using (var context = new YoumotoDbContext(Effort.DbConnectionFactory.CreateTransient()))
			{
				var picture = PicturePersister.LoadSingle(context, new Guid("{633CEC22-87CF-4D27-9FA6-578322675617}"));
				Assert.IsNull(picture);
			}
		}

		#region TestLoadSingleWithExistingGuid
		[TestMethod]
		public void TestLoadSingleWithExistingGuid()
		{
			using (var context = new YoumotoDbContext(Effort.DbConnectionFactory.CreateTransient()))
			{
				Picture newPicture = PicturePersister.Create();
				context.Pictures.Add(newPicture);
				context.SaveChanges();

				var picture = PicturePersister.LoadSingle(context, newPicture.Guid);
				Assert.IsNotNull(picture);
				Assert.AreEqual(newPicture, picture);
			}
		}
		#endregion
	}
}
