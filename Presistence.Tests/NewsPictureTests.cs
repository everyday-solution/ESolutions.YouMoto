using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESolutions.Youmoto.Persistence.Persister;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ESolutions.Youmoto.Persistence.Tests
{
	[TestClass]
	public class NewsPictureTests
	{
		#region CreateNewsPicture
		[TestMethod]
		public void CreateNewsPicture()
		{
			using (var context = new YoumotoDbContext(Effort.DbConnectionFactory.CreateTransient()))
			{
				String url = "https://www.youmoto.com/test.jpg";
				News news = NewsPersister.Create("MyTitle");
				NewsPicture newsPicture = NewsPersister.CreatePicture(news, url);

				context.News.Add(news);
				context.SaveChanges();

				Assert.AreEqual(1, context.News.Count());
				Assert.AreEqual(1, context.NewsPictures.Count());
				Assert.AreEqual(1, context.News.First().NewsPictures.Count());
				Assert.AreEqual(url, context.News.First().NewsPictures.First().ImageLink);
			}
		}
		#endregion
	}
}
