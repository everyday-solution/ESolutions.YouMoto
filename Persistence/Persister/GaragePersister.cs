using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESolutions;

namespace ESolutions.Youmoto.Persistence.Persister
{
	public static class GaragePersister
	{
		#region LoadRandomPages
		public static IEnumerable<Garage> LoadRandomPaged(
			YoumotoDbContext context,
			GarageTypes garageType,
			Int32 skip,
			Int32 take)
		{
			var garages = context.Garages
				.Where(runner => garageType == GarageTypes.Any || runner.GarageType == garageType)
				.Where(runner => runner.GaragePictures.Any())
				.ToList();

			List<Garage> result = new List<Garage>();
			List<Int32> taken = new List<Int32>();
			Random randomizer = new Random();
			for (Int32 index = 0; index < take; index++)
			{
				Int32 randomIndex = 0;
				do
				{
					randomIndex = randomizer.Next(0, garages.Count);
				}
				while (taken.Contains(randomIndex));

				taken.Add(randomIndex);
				result.Add(garages[randomIndex]);
			}

			return result;
		}
		#endregion

		#region LoadSingle
		public static Garage LoadSingle(YoumotoDbContext context, Guid guid)
		{
			return context.Garages.FirstOrDefault(runner => runner.Guid == guid);
		}
		#endregion
	}
}
