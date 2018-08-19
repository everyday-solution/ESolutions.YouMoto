using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Xml;

namespace ESolutions.Youmoto.Configuration
{
	#region Mailer
	public class MailerSettings
	{
		//Properties
		#region Senders
		public SortedList<MailSenderTypes, MailSender> Senders
		{
			get;
			set;
		}
		#endregion

		#region Server
		public MailServer Server
		{
			get;
			set;
		}
		#endregion

		//Constructors
		#region MailerSettings
		public MailerSettings(XmlNode mailerNode)
		{
			this.Senders = new SortedList<MailSenderTypes, MailSender>();

			foreach (XmlNode current in mailerNode["senders"].ChildNodes)
			{
				MailSender sender = new MailSender(current);
				this.Senders.Add(sender.For, sender);
			}

			this.Server = new MailServer(mailerNode["server"]);
		}
		#endregion
	}
	#endregion
}
