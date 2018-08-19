using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESolutions.Youmoto.Persistence.Persister
{
	public static class ManufacturerPersister
	{
		#region LoadSingle
		public static Manufacturer LoadSingle(YoumotoDbContext context, Guid guid)
		{
			return context.Manufacturers.FirstOrDefault(runner => runner.Guid == guid);
		}
		#endregion

		#region LoadPaged
		public static IEnumerable<Manufacturer> LoadPaged(YoumotoDbContext context, Int32 skip, Int32 take)
		{
			return context.Manufacturers
				.Where(runner => runner.PictureGuid.HasValue)
				.Where(runner =>
					runner.ManufacturerVehicles.Any(x=>x.Vehicle.VehiclePictures.Any()) ||
					runner.Series.Any(x => x.SeriesVehicles.Any(y => y.Vehicle.VehiclePictures.Any()))
				)
				.OrderBy(runner => runner.Name)
				.Skip(skip)
				.Take(take);
		}
		#endregion
	}
}
