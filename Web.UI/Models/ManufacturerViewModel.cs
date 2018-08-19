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
	public class ManufacturerViewModel
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

			#region LogoImageGuid
			/// <summary>
			/// Gets or sets the teaser image URL.
			/// </summary>
			/// <value>
			/// The teaser image URL.
			/// </value>
			[JsonProperty(PropertyName = "logoImageGuid")]
			public Guid? LogoImageGuid
			{
				get;
				set;
			} = null;
			#endregion

			//Constructor
			#region Preview
			public Preview(Persistence.Manufacturer manufacturer)
			{
				this.Guid = manufacturer.Guid;
				this.Title = manufacturer.Name;
				this.LogoImageGuid = manufacturer.PictureGuid;
			}
			#endregion
		}

		public class Details
		{
			//Classes
			#region VehicleTeaserViewModel
			public class VehicleTeaserViewModel
			{
				//Properties
				#region Guid
				[JsonProperty(PropertyName = "guid")]
				public Guid Guid
				{
					get;
					set;
				} = Guid.Empty;
				#endregion

				#region Name
				[JsonProperty(PropertyName = "name")]
				public String Name
				{
					get;
					set;
				} = String.Empty;
				#endregion

				#region BuiltFromYear
				[JsonProperty(PropertyName = "builtFromYear")]
				public Int32 BuiltFromYear
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
				} = null;
				#endregion

				//Constructors
				#region VehicleTeaserViewModel
				public VehicleTeaserViewModel(Vehicle vehicle)
				{
					this.Guid = vehicle.Guid;
					this.Name = vehicle.Name;
					this.BuiltFromYear = vehicle.BuiltFromYear;
					this.PictureGuid = vehicle.VehiclePictures
						.OrderBy(runner => runner.SortOrder)
						.Select(runner => runner.PictureGuid)
						.FirstOrDefault();
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
				} = Guid.Empty;
				#endregion

				#region Name
				[JsonProperty(PropertyName = "name")]
				public String Name
				{
					get;
					set;
				}
				#endregion

				#region BuiltFromYear
				[JsonProperty(PropertyName = "builtFromYear")]
				public Int32 BuiltFromYear
				{
					get;
					set;
				}
				#endregion

				#region VehicleTeasers
				[JsonProperty(PropertyName = "vehicleTeasers")]
				public IEnumerable<VehicleTeaserViewModel> VehicleTeasers
				{
					get;
					set;
				} = new List<VehicleTeaserViewModel>();
				#endregion

				//Constructors
				#region SeriesViewModel
				public SeriesViewModel(Persistence.Series series)
				{
					this.Guid = series.Guid;
					this.Name = series.Name;
					this.BuiltFromYear = series.SeriesVehicles.Min(x => x.Vehicle.BuiltFromYear);
					this.VehicleTeasers = series.SeriesVehicles
						.OrderBy(runner => runner.Vehicle.BuiltFromYear)
						.Select(runner => new VehicleTeaserViewModel(runner.Vehicle));
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

			#region LogoImageGuid
			/// <summary>
			/// Gets or sets the teaser image URL.
			/// </summary>
			/// <value>
			/// The teaser image URL.
			/// </value>
			[JsonProperty(PropertyName = "logoImageGuid")]
			public Guid? LogoImageGuid
			{
				get;
				set;
			} = null;
			#endregion

			#region Series
			/// <summary>
			/// Gets or sets the teaser image URL.
			/// </summary>
			/// <value>
			/// The teaser image URL.
			/// </value>
			[JsonProperty(PropertyName = "series")]
			public IEnumerable<SeriesViewModel> Series
			{
				get;
				set;
			} = new List<SeriesViewModel>();
			#endregion

			#region Vehicles
			/// <summary>
			/// Gets or sets the teaser image URL.
			/// </summary>
			/// <value>
			/// The teaser image URL.
			/// </value>
			[JsonProperty(PropertyName = "vehicles")]
			public IEnumerable<VehicleTeaserViewModel> Vehicles
			{
				get;
				set;
			} = new List<VehicleTeaserViewModel>();
			#endregion

			//Constructor
			#region Details
			public Details(Persistence.Manufacturer manufacturer)
			{
				this.Guid = manufacturer.Guid;
				this.Title = manufacturer.Name;
				this.LogoImageGuid = manufacturer.PictureGuid;
				this.Series = manufacturer.Series
					.Where(runner => runner.SeriesVehicles.Any())
					.OrderBy(runner => runner.SeriesVehicles.Min(x => x.Vehicle.BuiltFromYear))
					.Select(runner => new SeriesViewModel(runner));
				this.Vehicles = manufacturer.ManufacturerVehicles
					.OrderBy(runner => runner.Vehicle.BuiltFromYear)
					.Select(runner => new VehicleTeaserViewModel(runner.Vehicle));
			}
			#endregion
		}
	}
}