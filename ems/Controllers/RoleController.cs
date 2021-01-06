using ems.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ems.Controllers
{
    [EnableCors("*", "*", "*")]
    public class RoleController : ApiController
    {
        [HttpGet]
        [Route("api/GetAllRoles")]
        [AllowAnonymous]
        public IHttpActionResult GetRoles()
        {
            var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            var roleMngr = new RoleManager<IdentityRole>(roleStore);

            var roles = roleMngr.Roles
                .Select(x => new { x.Id, x.Name })
                .ToList();
            return Ok(roles);
        }
    }
}