using ESolutions.Youmoto.Persistence;
using ESolutions.Youmoto.Web.UI.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ESolutions.Youmoto.Persistence.Persister;

namespace ESolutions.Youmoto.Web.UI.Hubs
{
	[HubName("newsHub")]
	public class NewsHub : Hub
	{
		//Fields
		#region context
		private YoumotoDbContext context = null;
		#endregion

		//Constructor
		#region NewsHub
		public NewsHub() : base()
		{

		}
		#endregion

		#region NewsHub
		public NewsHub(YoumotoDbContext context)
		{
			this.context = context;
		}
		#endregion

		//Methods
		#region CreateNews
		[HubMethodName("createNews")]
		[Authorize(Users = "info@youmoto.de")]
		public NewsViewModel.Preview CreateNews(String title)
		{
			YoumotoDbContext context = this.context ?? new YoumotoDbContext();
			News newNews = NewsPersister.Create(title);
			context.News.Add(newNews);
			context.SaveChanges();

			return new NewsViewModel.Preview(newNews);
		}
		#endregion

		#region LoadNews
		[HubMethodName("loadNews")]
		public IEnumerable<NewsViewModel.Preview> LoadNews(Int32 skip = 0, Int32 take = 5)
		{
			YoumotoDbContext context = this.context ?? new YoumotoDbContext();
			return NewsPersister
				.LoadLatestPaged(context, skip, take)
				.Select(runner => new NewsViewModel.Preview(runner));
		}
		#endregion

		#region UpdateNews
		[HubMethodName("updateNews")]
		[Authorize(Users = "info@youmoto.de")]
		public void UpdateNews(Guid guid, String title, String text, String sourceLink)
		{
			YoumotoDbContext context = this.context ?? new YoumotoDbContext();
			var item = NewsPersister.LoadSingle(context, guid);
			item.Title = title ?? String.Empty;
			item.Text = text ?? String.Empty;
			item.SourceLink = sourceLink ?? String.Empty;
			item.UpdateTimeStamp = DateTime.UtcNow;
			context.SaveChangesAsync();
		}
		#endregion

		#region AddPicture
		[HubMethodName("addPicture")]
		[Authorize(Users = "info@youmoto.de")]
		public NewsViewModel.Details AddPicture(Guid newsGuid, String pictureUrl)
		{
			YoumotoDbContext context = this.context ?? new YoumotoDbContext();

			var result = NewsPersister.LoadSingle(context, newsGuid);

			var newPicture = NewsPersister.CreatePicture(result, pictureUrl);
			context.NewsPictures.Add(newPicture);
			context.SaveChanges();

			return new Models.NewsViewModel.Details(result);
		}
		#endregion

		#region DeletePicture
		[HubMethodName("deletePicture")]
		[Authorize(Users = "info@youmoto.de")]
		public NewsViewModel.Details DeletePicture(Guid newsPictureGuid)
		{
			YoumotoDbContext context = this.context ?? new YoumotoDbContext();

			var item = NewsPersister.LoadSinglePicture(context, newsPictureGuid);
			var news = item.News;

			context.NewsPictures.Remove(item);
			context.SaveChanges();

			var result = new Models.NewsViewModel.Details(news);
			return result;
		}
		#endregion

		#region AddVehicle
		[HubMethodName("addVehicle")]
		[Authorize(Users = "info@youmoto.de")]
		public NewsViewModel.Details AddVehicle(Guid newsGuid, Guid vehicleGuid)
		{
			YoumotoDbContext context = this.context ?? new YoumotoDbContext();

			var result = NewsPersister.LoadSingle(context, newsGuid);
			var vehicle = VehiclePersister.LoadSingle(context, vehicleGuid);

			var newPicture = NewsPersister.CreateVehicle(result, vehicle);
			context.NewsVehicles.Add(newPicture);
			context.SaveChanges();

			return new Models.NewsViewModel.Details(result);
		}
		#endregion

		#region DeleteVehicle
		[HubMethodName("deleteVehicle")]
		[Authorize(Users = "info@youmoto.de")]
		public NewsViewModel.Details DeleteVehicle(Guid newsVehicleGuid)
		{
			YoumotoDbContext context = this.context ?? new YoumotoDbContext();

			var item = NewsPersister.LoadSingleVehicle(context, newsVehicleGuid);
			var news = item.News;

			context.NewsVehicles.Remove(item);
			context.SaveChanges();

			var result = new Models.NewsViewModel.Details(news);
			return result;
		}
		#endregion

	}
}