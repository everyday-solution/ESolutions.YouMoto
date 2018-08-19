using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Collections.Generic;
using ESolutions.Youmoto.Persistence;
using System.IO;
using ESolutions.Drawing;

namespace ESolutions.Youmoto.Web.UI.Logic
{
	/// <summary>
	/// Extender for the bitmap class.
	/// </summary>
	public static class PictureExtender
	{
		#region GetBitmap
		/// <summary>
		/// Gets the bitmap.
		/// </summary>
		/// <returns></returns>
		public static Bitmap GetBitmap(this Picture picture)
		{
			Bitmap result = null;

			try
			{
				MemoryStream stream = new MemoryStream(BlobHandler.ReadImage(picture.Guid));
				result = new Bitmap(stream);

				if (picture?.PictureSource?.WatermarkPicture != null)
				{
					using (Bitmap watermark = picture.PictureSource.WatermarkPicture.GetBitmap())
					{
						result.DrawWaterMark(watermark);
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Can't acquire bitmap", ex);
			}

			return result;
		}
		#endregion

		#region GetBitmap
		public static System.Drawing.Bitmap GetBitmap(this Picture picture, Int32? width, Int32? height)
		{
			Bitmap result = null;

			try
			{
				Bitmap original = picture.GetBitmap();

				if (width.HasValue && height.HasValue)
				{
					result = original.ResizeToWidth((Int32)width.Value);
				}
				else if (width.HasValue)
				{
					result = original.ResizeToWidth((Int32)width.Value);
				}
				else if (height.HasValue)
				{
					result = original.ResizeToHeight((Int32)height.Value);
				}
				else
				{
					result = original;
				}

				if (result != original)
				{
					original.Dispose();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Can't acquire bitmap", ex);
			}

			return result;
		}
		#endregion
	}
}