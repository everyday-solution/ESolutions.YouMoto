using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESolutions.Youmoto.Persistence.Persister
{
	public static class NewsPersister
	{
		#region Create
		/// <summary>
		/// Creates a news article with the specified title
		/// </summary>
		/// <param name="title">The title.</param>
		/// <returns></returns>
		public static News Create(String title)
		{
			News result = new News();

			result.CreateTimeStamp = DateTime.UtcNow;
			result.Date = DateTime.UtcNow;
			result.Guid = Guid.NewGuid();
			result.SourceLink = String.Empty;
			result.Text = String.Empty;
			result.Title = title;
			result.UpdateTimeStamp = DateTime.UtcNow;

			return result;
		}
		#endregion

		#region LoadPaged
		/// <summary>
		/// Loads news articles paged.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="skipCount">The skip.</param>
		/// <param name="takeCount">The take.</param>
		/// <returns></returns>
		public static IEnumerable<News> LoadLatestPaged(YoumotoDbContext context, Int32 skipCount, Int32 takeCount)
		{
			return context.News
				.OrderByDescending(runner => runner.Date)
				.Skip(skipCount)
				.Take(takeCount)
				.ToList();
		}
		#endregion

		#region LoadSingle
		public static News LoadSingle(YoumotoDbContext context, Guid guid)
		{
			return context.News.FirstOrDefault(runner => runner.Guid == guid);
		}
		#endregion

		#region CreatePicture
		public static NewsPicture CreatePicture(News news, string url)
		{
			NewsPicture result = new NewsPicture();

			result.Guid = Guid.NewGuid();
			result.ImageLink = url;
			result.News = news;
			result.SortOrder = news.NewsPictures.Count;
			news.NewsPictures.Add(result);

			return result;
		}
		#endregion

		#region LoadSinglePicture
		public static NewsPicture LoadSinglePicture(YoumotoDbContext context, Guid guid)
		{
			return context.NewsPictures.FirstOrDefault(runner => runner.Guid == guid);
		}
		#endregion

		#region CreateVehicle
		public static NewsVehicle CreateVehicle(News news, Vehicle vehicle)
		{
			NewsVehicle result = new NewsVehicle();

			result.Guid = Guid.NewGuid();
			result.News = news;
			result.Vehicle = vehicle;
			result.SortOrder = news.NewsPictures.Count;
			news.NewsVehicles.Add(result);

			return result;
		}
		#endregion

		#region LoadSingleVehicle
		public static NewsVehicle LoadSingleVehicle(YoumotoDbContext context, Guid guid)
		{
			return context.NewsVehicles.FirstOrDefault(runner => runner.Guid == guid);
		}
		#endregion
	}
}
