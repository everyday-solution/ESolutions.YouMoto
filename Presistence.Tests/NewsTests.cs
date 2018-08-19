using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using ESolutions;
using System.Collections.Generic;
using ESolutions.Youmoto.Persistence.Persister;

namespace ESolutions.Youmoto.Persistence.Tests
{
	[TestClass]
	public class NewsTests
	{
		//Constants
		#region newsTitle
		private const String newsTitle = "News";
		#endregion

		//Methods
		#region CreateTestNews
		private List<News> CreateTestNews(int newsCount, YoumotoDbContext context)
		{
			List<News> testNews = new List<News>();
			newsCount.Times(index =>
			{
				News news = NewsPersister.Create(NewsTests.newsTitle + index.ToString());
				news.Date = DateTime.UtcNow.AddDays(newsCount * -1).AddDays(index);
				testNews.Add(news);
				context.News.Add(news);
			});

			return testNews;
		}
		#endregion

		//Tests
		#region CreateAndSaveNews
		[TestMethod]
		public void CreateAndSaveNews()
		{
			using (var context = new YoumotoDbContext(Effort.DbConnectionFactory.CreateTransient()))
			{
				News news = NewsPersister.Create(NewsTests.newsTitle);

				context.News.Add(news);
				context.SaveChanges();

				Assert.AreEqual(NewsTests.newsTitle, news.Title);
			}
		}
		#endregion

		#region LoadNewsPagedFirstChunk
		[TestMethod]
		public void LoadNewsPagedFirstChunk()
		{
			Int32 newsCount = 5;
			using (var context = new YoumotoDbContext(Effort.DbConnectionFactory.CreateTransient()))
			{
				List<News> testNews = this.CreateTestNews(newsCount, context);

				context.SaveChanges();

				var paged = NewsPersister.LoadLatestPaged(context, 0, 2).ToList();

				Assert.AreEqual(2, paged.Count());
				Assert.AreEqual(testNews[newsCount - 1].Guid, paged[0].Guid);
				Assert.AreEqual(testNews[newsCount - 2].Guid, paged[1].Guid);
			}
		}
		#endregion

		#region LoadNewsPagedSecoundChunk
		[TestMethod]
		public void LoadNewsPagedSecoundChunk()
		{
			Int32 newsCount = 5;
			using (var context = new YoumotoDbContext(Effort.DbConnectionFactory.CreateTransient()))
			{
				List<News> testNews = this.CreateTestNews(newsCount, context);

				context.SaveChanges();

				var paged = NewsPersister.LoadLatestPaged(context, 2, 2).ToList();

				Assert.AreEqual(2, paged.Count());
				Assert.AreEqual(testNews[newsCount - 3].Guid, paged[0].Guid);
				Assert.AreEqual(testNews[newsCount - 4].Guid, paged[1].Guid);
			}
		}
		#endregion
	}
}
