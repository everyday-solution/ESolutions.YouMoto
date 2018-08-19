using ESolutions.Youmoto.I18N;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESolutions.Youmoto.Persistence
{
	public class SearchResult
	{
		//Enums
		#region HitQualities
		public enum HitQualities
		{
			Exact,
			And,
			Or,
			ToLow
		}
		#endregion

		//Fields
		#region searchTerm
		private String searchTerm = String.Empty;
		#endregion

		//Properties
		#region Vehicles
		public IEnumerable<Vehicle> Vehicles
		{
			get;
			set;
		}
		#endregion

		#region Garages
		public IEnumerable<Garage> Garages
		{
			get;
			set;
		}
		#endregion

		#region SearchTerm
		/// <summary>
		/// Gets or sets the search term the user provided for the search.
		/// </summary>
		/// <value>The user search term.</value>
		public String SearchTerm
		{
			get
			{
				return this.searchTerm;
			}
			internal set
			{
				this.searchTerm = value;
				this.searchTerm = this.searchTerm.Replace("  ", " ").ToLower();
				this.searchTerm = this.searchTerm.Replace("  ", " ").ToLower();
			}
		}
		#endregion

		#region Quality
		public HitQualities Quality
		{
			get;
			internal set;
		}
		#endregion

		#region HasHits
		public Boolean HasHits
		{
			get
			{
				return this.Vehicles.Any();
			}
		}
		#endregion

		#region SearchWords
		public IEnumerable<String> SearchWords
		{
			get
			{
				return this.searchTerm.Split(' ');
			}
		}
		#endregion

		#region SearchTermParts
		public String SearchTermParts
		{
			get
			{
				String result = String.Empty;

				switch (this.Quality)
				{
					case HitQualities.Exact:
					case HitQualities.ToLow:
					{
						result = this.searchTerm;
						break;
					}

					case HitQualities.And:
					{
						result = String.Join($" {StringTable.And} ", this.SearchWords);
						break;
					}

					case HitQualities.Or:
					{
						result = String.Join($" {StringTable.Or} ", this.SearchWords);
						break;
					}
				}

				return result;
			}
		}
		#endregion

		//Constructors
		#region SearchResult
		public SearchResult(String searchTerm)
		{
			this.Vehicles = new List<Vehicle>();
			this.SearchTerm = searchTerm.ToLower();
		}
		#endregion
	}
}
