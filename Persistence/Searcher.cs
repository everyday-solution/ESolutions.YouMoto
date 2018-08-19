using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESolutions.Youmoto.Persistence
{
	public static class Searcher
	{
		//Methods
		#region PerformFreetextSearch
		/// <summary>
		/// Performs the freetext search.
		/// </summary>
		/// <param name="searchTerm">The search termn.</param>
		/// <returns></returns>
		/// <remarks>
		/// If the searchTerm is empty. No results are displayed. Otherwiese the searchterm in splitted into word
		/// and the database is search for a match of all words. If no match is found the last word is removed and the 
		/// search is restarted with the residual words.
		/// </remarks>
		public static SearchResult PerformFreetextSearch(YoumotoDbContext context, String searchTerm, Int32 skip, Int32 take)
		{
			SearchResult result = new SearchResult(searchTerm);

			if (String.IsNullOrEmpty(result.SearchTerm) || result.SearchTerm.Length < 2)
			{
				result.Quality = SearchResult.HitQualities.ToLow;
			}
			else
			{
				IEnumerable<SearchMatrixView> resultSet = Searcher.ExactSearch(context, searchTerm);

				if (resultSet.Any())
				{
					result.Quality = SearchResult.HitQualities.Exact;
				}
				else
				{
					resultSet = Searcher.SearchAnd(context, result.SearchWords);

					if (resultSet.Any())
					{
						result.Quality = SearchResult.HitQualities.And;
					}
					else
					{
						resultSet = Searcher.SearchOr(context, result.SearchWords);
						result.Quality = SearchResult.HitQualities.Or;
					}
				}

				var vehicleGuids = resultSet
					.Distinct()
					.OrderBy(runner => runner.Fullname)
					.Skip(skip)
					.Take(take)
					.Select(runner => runner.Guid);

				var vehicles = context.Vehicles
					.Where(runner => vehicleGuids.Contains(runner.Guid))
					.ToList();
				result.Vehicles = vehicles;

				result.Garages = context.Garages
					.Where(runner => runner.Title.ToLower().Contains(result.SearchTerm))
					.OrderBy(runner => runner.Title);
			}

			return result;
		}
		#endregion

		#region ExactSearch
		private static IEnumerable<SearchMatrixView> ExactSearch(YoumotoDbContext context, String searchTerm)
		{
			return context.SearchMatrix
				.Where(runner => runner.Fullname.Contains(searchTerm));
		}
		#endregion

		#region SearchAnd
		private static IEnumerable<SearchMatrixView> SearchAnd(YoumotoDbContext context, IEnumerable<String> words)
		{
			IEnumerable<SearchMatrixView> query = context.SearchMatrix;
			foreach (var wordRunner in words)
			{
				var temp = wordRunner;
				query = query.Where(runner => runner.Fullname.Contains(temp));
			}
			return query;
		}
		#endregion

		#region SearchOr
		private static IEnumerable<SearchMatrixView> SearchOr(YoumotoDbContext context, IEnumerable<String> words)
		{
			var word1 = words.First();
			IEnumerable<SearchMatrixView> query = context.SearchMatrix
				.Where(runner => runner.Fullname.Contains(word1));

			foreach (var wordRunner in words.Skip(1))
			{
				String temp = wordRunner;
				query = query.Concat(query.Where(runner => runner.Fullname.Contains(temp)));
			}

			return query;
		}
		#endregion

		#region PerformVehicleSearch
		public static IEnumerable<SearchMatrixView> PerformVehicleSearch(YoumotoDbContext context, String searchTerm)
		{
			String lowerSearchTerm = searchTerm.ToLower();
			return context.SearchMatrix
				.Where(runner => runner.Fullname.Contains(lowerSearchTerm));
		}
		#endregion
	}
}
