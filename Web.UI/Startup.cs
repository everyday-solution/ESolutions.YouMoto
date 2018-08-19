using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ESolutions.Youmoto.Web.UI.Startup))]
namespace ESolutions.Youmoto.Web.UI
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);

			app.MapSignalR();
		}
	}
}
