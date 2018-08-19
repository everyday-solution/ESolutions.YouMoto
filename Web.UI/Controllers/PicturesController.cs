using ESolutions.Youmoto.Persistence;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ESolutions.Youmoto.Persistence.Persister;
using ESolutions.Youmoto.Web.UI.Logic;

namespace ESolutions.Youmoto.Web.UI.Controllers
{
	public class PicturesController : Controller
	{
		#region Render
		public ActionResult Render(Guid? guid, Int32? width = null, Int32? height = null)
		{
			this.Response.Clear();

			YoumotoDbContext context = new YoumotoDbContext();
			Picture picture = guid == null ? null : PicturePersister.LoadSingle(context, guid.Value);


			if (picture == null)
			{
				var bitmap = ESolutions.Youmoto.Web.UI.Properties.Resources.NoImage;
				this.Response.ContentType = "image/png";
				bitmap.Save(this.Response.OutputStream, ImageFormat.Png);
			}
			else
			{
				var bitmap = picture.GetBitmap(width, height);
				this.Response.ContentType = "image/jpg";

				Int64 compression = width.HasValue || height.HasValue ? 60L : 100L;
				EncoderParameters parameters = new EncoderParameters(1);
				parameters.Param[0] = new EncoderParameter(Encoder.Quality, compression);
				ImageCodecInfo codec = ImageCodecInfo.GetImageEncoders().FirstOrDefault(runner => runner.FormatID == ImageFormat.Jpeg.Guid);
				bitmap.Save(this.Response.OutputStream, codec, parameters);
			}

			this.Response.End();
			return null;
		}
		#endregion
	}
}