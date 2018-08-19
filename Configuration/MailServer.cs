using ESolutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Security;
using System.Security.Cryptography;

namespace ESolutions.Youmoto.Configuration
{
	public class MailServer
	{
		#region Host
		/// <summary>
		/// Gets or sets the host.
		/// </summary>
		/// <value>The host.</value>
		public String Host
		{
			get;
			set;
		}
		#endregion

		#region Port
		/// <summary>
		/// Gets or sets the port.
		/// </summary>
		/// <value>The port.</value>
		public Int32 Port
		{
			get;
			set;
		}
		#endregion

		#region UseSsl
		/// <summary>
		/// Gets or sets a value indicating whether to use SSL encryption.
		/// </summary>
		/// <value><c>true</c> if [use SSL]; otherwise, <c>false</c>.</value>
		public Boolean UseSsl
		{
			get;
			set;
		}
		#endregion

		//Constructor
		#region MailServer
		/// <summary>
		/// Initializes a new instance of the <see cref="MailServer"/> class.
		/// </summary>
		/// <param name="serverNode">The server node.</param>
		public MailServer(XmlNode serverNode)
		{
			this.Host = serverNode["host"].InnerText;
			this.Port = serverNode["port"].InnerText.ToInt32();
			this.UseSsl = serverNode["useSSL"].InnerText.ToBoolean();
		}
		#endregion

		#region ToString
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public override String ToString( )
		{
			return String.Format(
				"{0}:{1}",
				this.Host,
				this.Port.ToString());
		}
		#endregion
	}
}
