using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ESolutions.Youmoto.Web.UI.Logic
{
	public static class NameBuilder
	{
		public class VehicleName
		{
			#region VehicleGuid
			[JsonProperty(PropertyName = "vehicleGuid")]
			public Guid VehicleGuid
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

			#region PictureGuid
			[JsonProperty(PropertyName = "pictureGuid")]
			public Guid? PictureGuid
			{
				get;
				set;
			}
			#endregion
		}

		public static List<VehicleName> BuildNames(this Persistence.Vehicle vehicle)
		{
			List<VehicleName> vehicles = new List<VehicleName>();

			foreach (var seriesRunner in vehicle.SeriesVehicles.Select(x => x.Series))
			{
				var name = $"{seriesRunner.Manufacturer.Name} {seriesRunner.Name} {vehicle.Name}";
				var teaserPicture = vehicle.VehiclePictures
					.OrderBy(runner => runner.SortOrder)
					.FirstOrDefault();
				vehicles.Add(new VehicleName() { VehicleGuid = vehicle.Guid, Name = name, PictureGuid = teaserPicture?.PictureGuid });
			}

			foreach (var manufacturerRunner in vehicle.ManufacturerVehicles.Select(x => x.Manufacturer))
			{
				var name = $"{manufacturerRunner.Name} {vehicle.Name}";
				var teaserPicture = vehicle.VehiclePictures
					.OrderBy(runner => runner.SortOrder)
					.FirstOrDefault();
				vehicles.Add(new VehicleName() { VehicleGuid = vehicle.Guid, Name = name, PictureGuid = teaserPicture?.PictureGuid });
			}

			return vehicles;
		}
	}
}