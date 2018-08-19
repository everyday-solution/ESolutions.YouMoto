using ESolutions.Youmoto.Persistence;
using ESolutions.Youmoto.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESolutions.Youmoto.Console
{
	public class Program
	{
		#region Main
		public static void Main(string[] args)
		{
			var count = BlobHandler.Count();
			System.Console.WriteLine(count);
		}
		#endregion
	}
}
