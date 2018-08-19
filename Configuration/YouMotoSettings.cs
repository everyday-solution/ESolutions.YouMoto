using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Xml;

namespace ESolutions.Youmoto.Configuration
{
	public class YoumotoSettings : IConfigurationSectionHandler
	{
		//Properties
		#region Default
		/// <summary>
		/// Returns the applications default settings object.
		/// </summary>
		/// <value>The default.</value>
		public static YoumotoSettings Default
		{
			get
			{
				return (YoumotoSettings)ConfigurationManager.GetSection("youmotoSettings");
			}
		}
		#endregion

		#region Mailer
		public MailerSettings Mailer
		{
			get;
			private set;
		}
		#endregion

		#region BlobStorage
		public BlobStorage BlobStorage
		{
			get;
			private set;
		}
		#endregion

		#region Admin
		public String Admin
		{
			get;
			private set;
		}
		#endregion

		#region AdminPassword
		public String AdminPassword
		{
			get;
			private set;
		}
		#endregion

		//Methods
		#region Create
		/// <summary>
		/// Creates a configuration section handler.
		/// </summary>
		/// <param name="parent">Parent object.</param>
		/// <param name="configContext">Configuration context object.</param>
		/// <param name="section">Section XML node.</param>
		/// <returns>The created section handler object.</returns>
		public Object Create(Object parent, Object configContext, XmlNode section)
		{
			YoumotoSettings result = new YoumotoSettings();

			result.Mailer = new MailerSettings(section["mailer"]);
			result.BlobStorage = new BlobStorage(section["blobstorage"]);
			result.Admin = YoumotoSettings.Decrypt(section["admin"].Attributes["user"].Value);
			result.AdminPassword = YoumotoSettings.Decrypt(section["admin"].Attributes["pass"].Value);

			return result;
		}
		#endregion

		#region Decrypt
		internal static String Decrypt(String encryptedString)
		{
			ESolutions.Security.Cryptography.Rijndael crypter = new ESolutions.Security.Cryptography.Rijndael();
			crypter.EncryptionSecret = "{12F79B90-10C9-4980-BDF8-E5D2BAA19561}";
			crypter.EncryptionIV = "{9637ABED-2F17-403D-8481-24DCABE9991D}";
			return crypter.Decrypt(encryptedString);
		}
		#endregion
	}
}