using ESolutions.Youmoto.Configuration;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ESolutions.Youmoto.Persistence
{
	public static class BlobHandler
	{
		#region WriteImage
		public static Uri WriteImage(Byte[] imageData, Guid pictureGuid)
		{
			CloudBlockBlob newBlob = BlobHandler.Connect(pictureGuid);
			newBlob.UploadFromByteArray(imageData, 0, imageData.Length);
            return newBlob.Uri;
		}
		#endregion

		#region Connect
		private static CloudBlockBlob Connect(Guid pictureGuid)
		{
			CloudStorageAccount storageAccount = CloudStorageAccount.Parse(YoumotoSettings.Default.BlobStorage.ConnectionString);
			CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
			CloudBlobContainer blobContainer = blobClient.GetContainerReference(YoumotoSettings.Default.BlobStorage.Container);
			CloudBlockBlob newBlob = blobContainer.GetBlockBlobReference(pictureGuid.ToString() + ".jpg");
			return newBlob;
		}
		#endregion

		#region Count
		public static Int32 Count()
		{
			System.Net.ServicePointManager.DefaultConnectionLimit = 100;
			CloudStorageAccount storageAccount = CloudStorageAccount.Parse(YoumotoSettings.Default.BlobStorage.ConnectionString);
			CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
			CloudBlobContainer blobContainer = blobClient.GetContainerReference(YoumotoSettings.Default.BlobStorage.Container);
			return blobContainer.ListBlobs(null, true).Count();
		}
		#endregion

		#region DeleteImage
		public static void DeleteImage(Guid pictureGuid)
		{
			CloudBlockBlob blob = Connect(pictureGuid);
			blob.DeleteIfExists();
		}
		#endregion

		#region ReadImage
		public static Byte[] ReadImage(Guid pictureGuid)
		{
			CloudBlockBlob blob = BlobHandler.Connect(pictureGuid);
			blob.FetchAttributes();
			Byte[] result = new Byte[blob.Properties.Length];
			blob.DownloadToByteArray(result, 0);
			return result;
		}
		#endregion
	}
}