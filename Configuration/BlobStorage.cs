using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace ESolutions.Youmoto.Configuration
{
	public class BlobStorage
	{
		//Properties
		#region ConnectionString
		public String ConnectionString
		{
			get;
			private set;
		}
		#endregion

		#region Container
		public String Container
		{
			get;
			private set;
		}
		#endregion

		//Constructors
		#region BlobStorage
		public BlobStorage(XmlNode node)
		{
			this.ConnectionString = node["connectionString"].InnerText;
			this.Container = node["container"].InnerText;
		}
		#endregion
	}
}
