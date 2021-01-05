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
                    if (!roleMngr.RoleExists("SubAdmin"))
                    {
                        roleMngr.Create(new IdentityRole("SubAdmin"));
                        if (userMngr.FindByEmail("subadmin@gmail.com") == null)
                        {
                            ApplicationUser user = new ApplicationUser { UserName = "subadmin@gmail.com", Email = "subadmin@gmail.com" };
                            var result = userMngr.Create(user, "Aa@12345");
                            if (result.Succeeded)
                            {
                                userMngr.AddToRole(user.Id, "SubAdmin");
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
