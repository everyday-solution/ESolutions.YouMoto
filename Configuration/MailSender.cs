using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Xml;

namespace ESolutions.Youmoto.Configuration
{
	public class MailSender
	{
		//Properties
		#region For
		public MailSenderTypes For
		{
			get;
			set;
		}
		#endregion

		#region Address
		public MailAddress Address
		{
			get;
			set;
		}
		#endregion

		#region Password
		public String Password
		{
			get;
			set;
		}
		#endregion

		//Constructors
		#region MailSender
		public MailSender(XmlNode senderNode)
		{
			this.For = (MailSenderTypes)Enum.Parse(typeof(MailSenderTypes), senderNode.Attributes["for"].Value);
			this.Address = new MailAddress(senderNode.Attributes["address"].Value);
			String temp = senderNode.Attributes["password"].Value;
			this.Password = YoumotoSettings.Decrypt(temp);
		}
		#endregion

		//Methods
		#region ToString
		public override String ToString( )
		{
			return String.Format(
				"For: {0} - Sender: {1}",
				this.For.ToString(),
				this.Address.ToString());
		}
		#endregion
	}
}
