using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESolutions.Youmoto.Persistence.Persister
{
	public static class PicturePersister
	{
		#region Create
		public static Picture Create()
		{
			Picture result = new Picture();

			result.CreateTimeStamp = DateTime.UtcNow;
			result.Guid = Guid.NewGuid();
			result.TraumautoUrl = String.Empty;
			result.UpdateTimeStamp = DateTime.UtcNow;

			return result;
		}
		#endregion

		#region LoadSingle
		public static Picture LoadSingle(YoumotoDbContext context, Guid guid)
		{
			return context.Pictures.FirstOrDefault(runner => runner.Guid == guid);
		}
		#endregion
	}
}
