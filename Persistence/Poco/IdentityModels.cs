using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;

namespace ESolutions.Youmoto.Persistence
{
	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class ApplicationUser : IdentityUser
	{
		//Properties
		#region OldUserGuid
		public Guid? OldUserGuid
		{
			get;
			set;
		}
		#endregion

		#region DisplayName
		[Required(AllowEmptyStrings = true)]
		public String DisplayName
		{
			get;
			set;
		}
		#endregion

		#region PictureGuid
		public Guid? PictureGuid
		{
			get; set;
		}
		#endregion

		#region AboutMe
		[Required(AllowEmptyStrings = true)]
		public String AboutMe
		{
			get;
			set;
		}
		#endregion

		#region IsAdmin
		public Boolean IsAdmin
		{
			get
			{
				return this.UserName == "info@youmoto.de" || this.UserName == "admin@youmoto.de";
			}
		}
		#endregion

		//Methods
		#region GenerateUserIdentityAsync
		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			return userIdentity;
		}
		#endregion

		#region LoadSingle
		public static ApplicationUser LoadSingle(String id)
		{
			ApplicationDbContext context = new ApplicationDbContext();
			return context.Users.FirstOrDefault(runner => runner.Id == id);
		}
		#endregion
	}

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: base("youmotoDatabase", throwIfV1Schema: false)
		{
		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}