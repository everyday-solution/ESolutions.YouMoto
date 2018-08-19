namespace ESolutions.Youmoto.Persistence
{
	using ESolutions.Youmoto.I18N;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;
	using System.Linq;

	public partial class Vehicle
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Vehicle()
		{
			this.FavoriteVehicles = new HashSet<FavoriteVehicle>();
			this.Garages = new HashSet<Garage>();
			this.ManufacturerVehicles = new HashSet<ManufacturerVehicle>();
			this.NewsVehicles = new HashSet<NewsVehicle>();
			this.SeriesVehicles = new HashSet<SeriesVehicle>();
			this.VehiclePictures = new HashSet<VehiclePicture>();
			this.VehicleVideos = new HashSet<VehicleVideo>();
		}

		[Key]
		public Guid Guid { get; set; }

		[Required]
		public String Name { get; set; }

		public Int32 BuiltFromYear { get; set; }

		public Int32? BuiltUntilYear { get; set; }

		public Guid? PredecessorVehicleGuid { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String Intro { get; set; }

		private String history;

		public String GetHistory()
		{
			return this.history;
		}

		public void SetHistory(String value)
		{
			this.history = value;
		}

		[Required(AllowEmptyStrings = true)]
		public String Today { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String PressComment { get; set; }

		public DateTime CreateTimeStamp { get; set; }

		public DateTime UpdateTimeStamp { get; set; }

		public Int32 VisitorCount { get; set; }

		public DateTime? VehicleOfTheWeekFrom { get; set; }

		public DateTime? VehicleOfTheWeekUntil { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String Technic { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String WikipediaLink { get; set; }

		public Int32? BuiltYear { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String SpeedMaxKMH { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String CylinderCount { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String CylinderCapacityCCM { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String EngineRPM { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String EngineOutputPS { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String KerbWeightKG { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String Acceleration0to100 { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String WheelBaseCM { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String FuelUsageLiterPer100KM { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String LengthCM { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String WidthCM { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String HeightCM { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String PurchaseYear { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String PurchasePrice { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String Literature { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String UnitsBuilt { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String SportiveAchievements { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String Debut { get; set; }

		public Guid? MarketSegment { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String TunedVariations { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String ExternalSources { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String TestReports { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String Records { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String RaceSeason { get; set; }

		[Required(AllowEmptyStrings = true)]
		public String Design { get; set; }

		public VehicleTypes VehicleType { get; set; }

		public String VehicleTypeString
		{
			get
			{
				String result = String.Empty;

				switch (this.VehicleType)
				{
					case VehicleTypes.Motorbike:
					{
						result = StringTable.Bike;
						break;
					}
					default:
					{
						result = StringTable.Car;
						break;
					}
				}

				return result;
			}
		}

		public String TraumautoUrl { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<FavoriteVehicle> FavoriteVehicles { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Garage> Garages { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<ManufacturerVehicle> ManufacturerVehicles { get; set; }

		public virtual MarketSegment MarketSegment1 { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<NewsVehicle> NewsVehicles { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<SeriesVehicle> SeriesVehicles { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<VehiclePicture> VehiclePictures { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<VehicleVideo> VehicleVideos { get; set; }

		//Methods
		#region Create
		public static Vehicle Create(String name)
		{
			Vehicle result = new Vehicle()
			{
				Acceleration0to100 = String.Empty,
				CreateTimeStamp = DateTime.UtcNow,
				CylinderCapacityCCM = String.Empty,
				CylinderCount = String.Empty,
				Debut = String.Empty,
				Design = String.Empty,
				EngineOutputPS = String.Empty,
				EngineRPM = String.Empty,
				ExternalSources = String.Empty,
				FuelUsageLiterPer100KM = String.Empty,
				Guid = Guid.NewGuid(),
				HeightCM = String.Empty
			};

			result.SetHistory(String.Empty);
			result.Intro = String.Empty;
			result.KerbWeightKG = String.Empty;
			result.LengthCM = String.Empty;
			result.Literature = String.Empty;
			result.Name = name;
			result.PressComment = String.Empty;
			result.PurchasePrice = String.Empty;
			result.PurchaseYear = String.Empty;
			result.RaceSeason = String.Empty;
			result.Records = String.Empty;
			result.SpeedMaxKMH = String.Empty;
			result.SportiveAchievements = String.Empty;
			result.Technic = String.Empty;
			result.TestReports = String.Empty;
			result.Today = String.Empty;
			result.TraumautoUrl = String.Empty;
			result.TunedVariations = String.Empty;
			result.UnitsBuilt = String.Empty;
			result.UpdateTimeStamp = DateTime.UtcNow;
			result.VehicleType = VehicleTypes.Car;
			result.WheelBaseCM = String.Empty;
			result.WidthCM = String.Empty;
			result.WikipediaLink = String.Empty;

			return result;
		}
		#endregion

		#region LoadSingle
		public static Vehicle LoadSingle(YoumotoDbContext context, Guid vehicleGuid)
		{
			return context.Vehicles.FirstOrDefault(runner => runner.Guid == vehicleGuid);
		}
		#endregion
	}
}
