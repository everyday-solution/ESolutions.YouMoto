using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ESolutions.Youmoto.Persistence
{
	public partial class SearchMatrixView
	{
		public class Configuration : EntityTypeConfiguration<SearchMatrixView>
		{
			public Configuration()
			{
				this.HasKey(t => t.Guid);
				this.ToTable("SearchMatrix");
			}
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public SearchMatrixView()
		{
		}

		[Key]
		[JsonProperty(PropertyName ="guid")]
		public Guid Guid { get; set; }

		[JsonProperty(PropertyName = "manufacturerName")]
		public string ManufacturerName { get; set; }

		[JsonProperty(PropertyName = "seriesName")]
		public string SeriesName { get; set; }

		[JsonProperty(PropertyName = "seriesNickname")]
		public string SeriesNickname { get; set; }

		[JsonProperty(PropertyName = "vehicleName")]
		public string VehicleName { get; set; }

		[JsonProperty(PropertyName = "fullname")]
		public string Fullname { get; set; }
	}
}
