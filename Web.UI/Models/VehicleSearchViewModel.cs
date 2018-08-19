using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESolutions.Youmoto.Web.UI.Models
{
	public class VehicleSearchViewModel
	{
		#region Guid
		[JsonProperty("guid")]
		public Guid Guid
		{
			get;
			set;
		}
		#endregion

		#region Fullname
		[JsonProperty(PropertyName = "fullname")]
		public String Fullname
		{
			get;
			set;
		}
		#endregion
	}
}
