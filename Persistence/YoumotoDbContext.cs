namespace ESolutions.Youmoto.Persistence
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	using System.Data.Common;

	public partial class YoumotoDbContext : DbContext
	{
		public YoumotoDbContext()
			: base("name=youmotoDatabase")
		{
		}

		public YoumotoDbContext(DbConnection connection)
			: base(connection, true)
		{
		}

		public virtual DbSet<Country> Countries { get; set; }
		public virtual DbSet<FavoriteVehicle> FavoriteVehicles { get; set; }
		public virtual DbSet<GaragePicture> GaragePictures { get; set; }
		public virtual DbSet<Garage> Garages { get; set; }
		public virtual DbSet<Manufacturer> Manufacturers { get; set; }
		public virtual DbSet<ManufacturerVehicle> ManufacturerVehicles { get; set; }
		public virtual DbSet<MarketSegment> MarketSegments { get; set; }
		public virtual DbSet<News> News { get; set; }
		public virtual DbSet<NewsPicture> NewsPictures { get; set; }
		public virtual DbSet<NewsVehicle> NewsVehicles { get; set; }
		public virtual DbSet<Picture> Pictures { get; set; }
		public virtual DbSet<PictureSource> PictureSources { get; set; }
		public virtual DbSet<Post> Posts { get; set; }
		public virtual DbSet<SearchMatrixView> SearchMatrix { get; set; }
		public virtual DbSet<SearchProtocol> SearchProtocols { get; set; }
		public virtual DbSet<Series> Series { get; set; }
		public virtual DbSet<SeriesVehicle> SeriesVehicles { get; set; }
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<VehiclePicture> VehiclePictures { get; set; }
		public virtual DbSet<Vehicle> Vehicles { get; set; }
		public virtual DbSet<VehicleVideo> VehicleVideos { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Garage>()
				.HasMany(e => e.GaragePictures)
				.WithRequired(e => e.Garage)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Manufacturer>()
				.HasMany(e => e.ManufacturerVehicles)
				.WithRequired(e => e.Manufacturer)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Manufacturer>()
				.HasMany(e => e.Series)
				.WithRequired(e => e.Manufacturer)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<MarketSegment>()
				.HasMany(e => e.Vehicles)
				.WithOptional(e => e.MarketSegment1)
				.HasForeignKey(e => e.MarketSegment);

			modelBuilder.Entity<News>()
				.HasMany(e => e.NewsPictures)
				.WithRequired(e => e.News)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<News>()
				.HasMany(e => e.NewsVehicles)
				.WithRequired(e => e.News)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Picture>()
				.HasMany(e => e.GaragePictures)
				.WithRequired(e => e.Picture)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Picture>()
				.HasMany(e => e.PictureSources)
				.WithRequired(e => e.WatermarkPicture)
				.HasForeignKey(e => e.PictureGuid)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Picture>()
				.HasMany(e => e.Users)
				.WithOptional(e => e.Picture)
				.HasForeignKey(e => e.ProfilePictureGuid);

			modelBuilder.Entity<Picture>()
				.HasMany(e => e.VehiclePictures)
				.WithRequired(e => e.Picture)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<PictureSource>()
				.HasMany(e => e.Pictures)
				.WithOptional(e => e.PictureSource)
				.HasForeignKey(e => e.PictureSourceGuid);

			modelBuilder.Entity<Post>()
				.HasMany(e => e.Posts1)
				.WithOptional(e => e.Post1)
				.HasForeignKey(e => e.ParentPostGuid);

			modelBuilder.Entity<Series>()
				.HasMany(e => e.SeriesVehicles)
				.WithRequired(e => e.Series)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<User>()
				.HasMany(e => e.FavoriteVehicles)
				.WithRequired(e => e.User)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<User>()
				.HasMany(e => e.Garages)
				.WithRequired(e => e.User)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<User>()
				.HasMany(e => e.Posts)
				.WithRequired(e => e.User)
				.HasForeignKey(e => e.SenderUserGuid)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<User>()
				.HasMany(e => e.Posts1)
				.WithOptional(e => e.User1)
				.HasForeignKey(e => e.ReceiverUserGuid);

			modelBuilder.Entity<Vehicle>()
				.HasMany(e => e.FavoriteVehicles)
				.WithRequired(e => e.Vehicle)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Vehicle>()
				.HasMany(e => e.Garages)
				.WithRequired(e => e.Vehicle)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Vehicle>()
				.HasMany(e => e.ManufacturerVehicles)
				.WithRequired(e => e.Vehicle)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Vehicle>()
				.HasMany(e => e.NewsVehicles)
				.WithRequired(e => e.Vehicle)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Vehicle>()
				.HasMany(e => e.SeriesVehicles)
				.WithRequired(e => e.Vehicle)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Vehicle>()
				.HasMany(e => e.VehiclePictures)
				.WithRequired(e => e.Vehicle)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Vehicle>()
				.HasMany(e => e.VehicleVideos)
				.WithRequired(e => e.Vehicle)
				.WillCascadeOnDelete(false);

			modelBuilder.Configurations.Add(new SearchMatrixView.Configuration());
		}
	}
}
