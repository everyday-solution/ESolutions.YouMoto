using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using ESolutions.Youmoto.Web.UI.Logic;
using ESolutions.Youmoto.Persistence;
using ESolutions.Youmoto.I18N;

namespace ESolutions.Youmoto.Web.UI.Models
{
	public class VehicleViewModel
	{
		public class Preview
		{
			//Properties
			#region Guid
			/// <summary>
			/// Gets or sets the unique identifier.
			/// </summary>
			/// <value>
			/// The unique identifier.
			/// </value>
			[JsonProperty(PropertyName = "guid")]
			public Guid Guid
			{
				get;
				set;
			} = Guid.Empty;
			#endregion

			#region Title
			/// <summary>
			/// Gets or sets the title.
			/// </summary>
			/// <value>
			/// The title.
			/// </value>
			[JsonProperty(PropertyName = "title")]
			public String Title
			{
				get;
				set;
			} = String.Empty;
			#endregion

			#region Date
			/// <summary>
			/// Gets or sets the date.
			/// </summary>
			/// <value>
			/// The date.
			/// </value>
			[JsonProperty(PropertyName = "date")]
			public DateTime Date
			{
				get;
				set;
			}
			#endregion

			#region TextTeaser
			/// <summary>
			/// Gets or sets the text.
			/// </summary>
			/// <value>
			/// The text.
			/// </value>
			[JsonProperty(PropertyName = "textTeaser")]
			public String TextTeaser
			{
				get;
				set;
			} = String.Empty;
			#endregion

			#region TeaserImageGuid
			/// <summary>
			/// Gets or sets the teaser image URL.
			/// </summary>
			/// <value>
			/// The teaser image URL.
			/// </value>
			[JsonProperty(PropertyName = "teaserImageGuid")]
			public Guid TeaserImageGuid
			{
				get;
				set;
			} = Guid.Empty;
			#endregion

			#region Author
			public String Author
			{
				get;
				set;
			} = String.Empty;
			#endregion

			//Constructor
			#region Preview
			public Preview(Persistence.Vehicle vehicle)
			{
				this.Guid = vehicle.Guid;
				this.Title = vehicle.BuildNames().FirstOrDefault()?.Name;
				this.Date = vehicle.CreateTimeStamp;

				var teaser = vehicle.VehiclePictures.OrderBy(runner => runner.SortOrder).FirstOrDefault();

				if (teaser != null)
				{
					this.TextTeaser = String.Concat(teaser.Text.Take(300).ToList()) + "...";
					this.TeaserImageGuid = teaser.PictureGuid;
				}
			}
			#endregion
		}

		public class Details
		{
			//Classes
			#region ManufacturerViewModel
			public class ManufacturerViewModel
			{
				//Properties
				#region Guid
				[JsonProperty(PropertyName = "guid")]
				public Guid Guid

				{
					get;
					set;
				}
				#endregion

				#region Name
				[JsonProperty(PropertyName = "name")]
				public String Name
				{
					get;
					set;
				}
				#endregion

				#region PictureGuid
				[JsonProperty(PropertyName = "pictureGuid")]
				public Guid? PictureGuid
				{
					get;
					set;
				}
				#endregion

				//Constructors
				#region ManufacturerViewModel
				public ManufacturerViewModel(Persistence.Manufacturer manufacturer)
				{
					this.Guid = manufacturer.Guid;
					this.Name = manufacturer.Name;
					this.PictureGuid = manufacturer.PictureGuid;
				}
				#endregion
			}
			#endregion

			#region SeriesVehicleViewModel
			public class SeriesVehicleViewModel
			{
				//Properties
				#region Guid
				[JsonProperty(PropertyName = "guid")]
				public Guid Guid

				{
					get;
					set;
				}
				#endregion

				#region Name
				[JsonProperty(PropertyName = "name")]
				public String Name
				{
					get;
					set;
				}
				#endregion

				#region PictureGuid
				[JsonProperty(PropertyName = "pictureGuid")]
				public Guid? PictureGuid
				{
					get;
					set;
				}
				#endregion

				//Constructors
				#region SeriesVehicleViewModel
				public SeriesVehicleViewModel(Persistence.Vehicle vehicle)
				{
					this.Guid = vehicle.Guid;
					this.Name = vehicle.Name;

					var teaser = vehicle.VehiclePictures.OrderBy(runner => runner.SortOrder).FirstOrDefault();
					this.PictureGuid = teaser?.PictureGuid;
				}
				#endregion
			}
			#endregion

			#region SeriesViewModel
			public class SeriesViewModel
			{
				//Properties
				#region Guid
				[JsonProperty(PropertyName = "guid")]
				public Guid Guid
				{
					get;
					set;
				}
				#endregion

				#region Name
				[JsonProperty(PropertyName = "name")]
				public String Name
				{
					get;
					set;
				}
				#endregion

				#region SeriesVehicles
				[JsonProperty(PropertyName = "seriesVehicles")]
				public IEnumerable<SeriesVehicleViewModel> SeriesVehicles
				{
					get;
					set;
				} = new List<SeriesVehicleViewModel>();
				#endregion

				//Constructors
				#region SeriesViewModel
				public SeriesViewModel(Persistence.Series series)
				{
					this.Guid = series.Guid;
					this.Name = $"{series.Manufacturer.Name} {series.Name}";
					this.SeriesVehicles = series.SeriesVehicles
						.OrderBy(runner => runner.Vehicle.BuiltFromYear)
						.Select(runner => new SeriesVehicleViewModel(runner.Vehicle));
				}
				#endregion
			}
			#endregion

			#region ArticalPartViewModel
			public class ArticalPartViewModel
			{
				//Properties
				#region Key
				[JsonProperty(PropertyName = "key")]
				public String Key
				{
					get;
					set;
				}
				#endregion

				#region Value
				[JsonProperty(PropertyName = "value")]
				public String Value
				{
					get;
					set;
				}
				#endregion
			}
			#endregion

			#region GarageViewModel
			public class GarageViewModel
			{
				//Properties
				#region Guid
				[JsonProperty(PropertyName = "guid")]
				public Guid Guid
				{
					get;
					set;
				}
				#endregion

				#region Name
				[JsonProperty(PropertyName = "name")]
				public String Title
				{
					get;
					set;
				}
				#endregion

				#region TeaserPictureGuid
				[JsonProperty(PropertyName = "teaserPictureGuid")]
				public Guid? TeaserPictureGuid
				{
					get;
					set;
				}
				#endregion

				//Constructors
				#region GarageViewModel
				public GarageViewModel(Persistence.Garage garage)
				{
					this.Guid = garage.Guid;
					this.Title = garage.Title;

					var teaser = garage.GaragePictures
						.OrderBy(runner => runner.SortOrder)
						.Select(runner=>runner.Picture)
						.FirstOrDefault();
					this.TeaserPictureGuid = teaser?.Guid;
				}
				#endregion
			}
			#endregion

			//Properties
			#region Guid
			/// <summary>
			/// Gets or sets the unique identifier.
			/// </summary>
			/// <value>
			/// The unique identifier.
			/// </value>
			[JsonProperty(PropertyName = "guid")]
			public Guid Guid
			{
				get;
				set;
			} = Guid.Empty;
			#endregion

			#region Title
			/// <summary>
			/// Gets or sets the title.
			/// </summary>
			/// <value>
			/// The title.
			/// </value>
			[JsonProperty(PropertyName = "title")]
			public String Title
			{
				get;
				set;
			} = String.Empty;
			#endregion

			#region Date
			/// <summary>
			/// Gets or sets the date.
			/// </summary>
			/// <value>
			/// The date.
			/// </value>
			[JsonProperty(PropertyName = "date")]
			public DateTime Date
			{
				get;
				set;
			}
			#endregion

			#region Manufacturers
			[JsonProperty(PropertyName = "manufacturers")]
			public IEnumerable<ManufacturerViewModel> Manufacturers
			{
				get;
				set;
			} = new List<ManufacturerViewModel>();
			#endregion

			#region Series
			[JsonProperty(PropertyName = "series")]
			public IEnumerable<SeriesViewModel> Series
			{
				get;
				set;
			} = new List<SeriesViewModel>();
			#endregion

			#region Garages
			[JsonProperty(PropertyName = "garages")]
			public IEnumerable<GarageViewModel> Garages
			{
				get;
				set;
			} = new List<GarageViewModel>();
			#endregion

			#region TechnicalData
			[JsonProperty(PropertyName = "technicalData")]
			public List<ArticalPartViewModel> TechnicalData
			{
				get;
				set;
			} = new List<ArticalPartViewModel>();
			#endregion

			#region ArticleParts
			[JsonProperty(PropertyName = "articleParts")]
			public List<ArticalPartViewModel> ArticleParts
			{
				get;
				set;
			} = new List<ArticalPartViewModel>();
			#endregion

			#region PicturesGuid
			[JsonProperty(PropertyName = "name")]
			public IEnumerable<Guid> PicturesGuids
			{
				get;
				set;
			}
			#endregion

			#region WikipediaLink
			[JsonProperty(PropertyName = "wikipediaLink")]
			public String WikipediaLink
			{
				get;
				set;
			}
			#endregion

			//Constructor
			#region Details
			/// <summary>
			/// Initializes a new instance of the <see cref="Details"/> class.
			/// </summary>
			/// <param name="vehicle">The news.</param>
			public Details(Persistence.Vehicle vehicle)
			{
				this.Guid = vehicle.Guid;
				this.Title = vehicle.BuildNames().FirstOrDefault()?.Name;
				this.Date = vehicle.CreateTimeStamp;
				this.Manufacturers = vehicle.ManufacturerVehicles
					.Select(runner => runner.Manufacturer)
					.Union(vehicle.SeriesVehicles.Select(x => x.Series.Manufacturer))
					.Distinct()
					.Select(runner => new ManufacturerViewModel(runner));

				this.Series = vehicle.SeriesVehicles
					.Select(runner => new SeriesViewModel(runner.Series));

				this.Garages = vehicle.Garages
					.OrderByDescending(runner => runner.CreateTimeStamp)
					.Select(runner => new GarageViewModel(runner));

				this.TechnicalData.Add(new ArticalPartViewModel() { Key = StringTable.Code, Value = vehicle.Name });
				this.TechnicalData.Add(new ArticalPartViewModel() { Key = StringTable.VehicleType, Value = vehicle.VehicleTypeString });
				this.TechnicalData.Add(new ArticalPartViewModel() { Key = StringTable.BuiltFrom, Value = vehicle.BuiltFromYear.ToString() });
				this.TechnicalData.Add(new ArticalPartViewModel() { Key = StringTable.BuiltUntil, Value = vehicle.BuiltUntilYear.HasValue ? vehicle.BuiltUntilYear.Value.ToString() : StringTable.UntilToday });
				this.TechnicalData.Add(new ArticalPartViewModel() { Key = StringTable.SpeedMax, Value = vehicle.SpeedMaxKMH });
				this.TechnicalData.Add(new ArticalPartViewModel() { Key = StringTable.CylinderCount, Value = vehicle.CylinderCount });
				this.TechnicalData.Add(new ArticalPartViewModel() { Key = StringTable.CylinderCapacity, Value = vehicle.CylinderCapacityCCM });
				this.TechnicalData.Add(new ArticalPartViewModel() { Key = StringTable.EngineOutput, Value = vehicle.EngineOutputPS });
				this.TechnicalData.Add(new ArticalPartViewModel() { Key = StringTable.EngineRpm, Value = vehicle.EngineRPM });
				this.TechnicalData.Add(new ArticalPartViewModel() { Key = StringTable.Length, Value = vehicle.LengthCM });
				this.TechnicalData.Add(new ArticalPartViewModel() { Key = StringTable.Width, Value = vehicle.WidthCM });
				this.TechnicalData.Add(new ArticalPartViewModel() { Key = StringTable.Height, Value = vehicle.HeightCM });
				this.TechnicalData = this.TechnicalData
					.Where(runner => !String.IsNullOrWhiteSpace(runner.Value))
					.ToList();

				this.ArticleParts.Add(new ArticalPartViewModel() { Key = StringTable.Intro, Value = vehicle.Intro.ToHtml() });
				this.ArticleParts.Add(new ArticalPartViewModel() { Key = StringTable.Technic, Value = vehicle.Technic.ToHtml() });
				this.ArticleParts.Add(new ArticalPartViewModel() { Key = StringTable.History, Value = vehicle.GetHistory().ToHtml() });
				this.ArticleParts.Add(new ArticalPartViewModel() { Key = StringTable.PressComment, Value = vehicle.PressComment.ToHtml() });
				this.ArticleParts.Add(new ArticalPartViewModel() { Key = StringTable.Today, Value = vehicle.Today.ToHtml() });
				this.ArticleParts = this.ArticleParts
					.Where(runner => !String.IsNullOrWhiteSpace(runner.Value))
					.ToList();

				this.PicturesGuids = vehicle.VehiclePictures
					.OrderBy(runner => runner.SortOrder)
					.Select(runner => runner.PictureGuid);
				this.WikipediaLink = vehicle.WikipediaLink;
			}
			#endregion
		}
	}
}