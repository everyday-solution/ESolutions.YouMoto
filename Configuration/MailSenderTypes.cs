using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESolutions.Youmoto.Configuration
{
	#region MailSenderTypes
	/// <summary>
	/// The types of sender addresses in the config.
	/// </summary>
	public enum MailSenderTypes
	{
		/// <summary>
		/// Used for everything that has no special sender
		/// </summary>
		All,
		/// <summary>
		/// Used for message to which the recepient should not respond directly.
		/// </summary>
		DoNotRespond,
		/// <summary>
		/// Used for messages from the system.
		/// </summary>
		System
	}
	#endregion
}
