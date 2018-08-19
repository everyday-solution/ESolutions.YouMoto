using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WikiPlex;

namespace ESolutions.Youmoto.Web.UI
{
	public static class StringExtender
	{
		#region ToHtml
		/// <summary>
		/// Converts the input string into html using the creole parser.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		public static String ToHtml(this String input)
		{
			String temp = input;
			temp = new WikiEngine().Render(temp);
			return temp;
		}
		#endregion
	}
}