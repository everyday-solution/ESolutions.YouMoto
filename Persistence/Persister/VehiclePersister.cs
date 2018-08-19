using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESolutions.Youmoto.Persistence.Persister
{
	public static class VehiclePersister
	{
		#region LoadRandomPaged
		public static IEnumerable<Vehicle> LoadRandomPaged(YoumotoDbContext context, Int32 take)
		{
			var vehicleQuery = context.Vehicles.Where(runner => runner.VehiclePictures.Any());
			var count = vehicleQuery.Count();
			var maxSkip = count - take;
			var randomSkip = new Random().Next(0, maxSkip);

			return vehicleQuery
				.OrderBy(runner => runner.Guid)
				.Skip(randomSkip)
				.Take(take);
		}
		#endregion

		#region LoadSingle
		public static Vehicle LoadSingle(YoumotoDbContext context, Guid guid)
		{
			return context.Vehicles.FirstOrDefault(runner => runner.Guid == guid);
		}
		#endregion

		#region LoadPaged
		public static IEnumerable<Vehicle> LoadPaged(YoumotoDbContext context, Int32 skip, Int32 take)
		{
			return context.Vehicles
				.Where(runner => runner.VehiclePictures.Any())
				.OrderBy(runner => runner.Guid)
				.Skip(skip)
				.Take(take);
		}
		#endregion
	}
}
