using System;
using System.Collections.Generic;
using System.Linq;
using ems.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(ems.Startup))]

namespace ems
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            ConfigureAuth(app);
            CreateUserRoles();
        }
        private void CreateUserRoles()
        {
            try
            {
                using (ApplicationDbContext Db = new ApplicationDbContext())
                {
                    var roleStore = new RoleStore<IdentityRole>(Db);
                    var roleMngr = new RoleManager<IdentityRole>(roleStore);
                    var userStore = new UserStore<ApplicationUser>(Db);
                    var userMngr = new UserManager<ApplicationUser>(userStore);

                    if (!roleMngr.RoleExists("Admin"))
                    {
                        roleMngr.Create(new IdentityRole("Admin"));
                        if (userMngr.FindByEmail("admin@gmail.com") == null)
                        {
                            ApplicationUser user = new ApplicationUser { UserName = "admin@gmail.com", Email = "admin@gmail.com" };
                            var result = userMngr.Create(user, "Aa@12345");
                            if (result.Succeeded)
                            {
                                userMngr.AddToRole(user.Id, "Admin");
                            }
                        }
                    }
                    if (!roleMngr.RoleExists("User"))
                    {
                        roleMngr.Create(new IdentityRole("User"));
                        if (userMngr.FindByEmail("user@gmail.com") == null)
                        {
                            ApplicationUser user = new ApplicationUser { UserName = "user@gmail.com", Email = "user@gmail.com" };
                            var result = userMngr.Create(user, "Aa@12345");
                            if (result.Succeeded)
                            {
                                userMngr.AddToRole(user.Id, "User");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message + "/n" + ex.StackTrace);
            }
        }
    }

}
