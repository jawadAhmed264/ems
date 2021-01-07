using ems.DTO;
using ems.Service.ServiceImplimentation;
using ems.Service.ServiceInterface;
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
    [Authorize(Roles = "Admin")]
    public class DepartmentController : ApiController
    {
        private IDepartmentService DepartmentService = null;
        public DepartmentController(IDepartmentService departmentService)
        {
            this.DepartmentService = departmentService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            IEnumerable<DepartmentDto> departments = DepartmentService.getAllDepartment();
            return Ok(departments);
        }
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Get(int? Id)
        {
            if (Id == null || (int)Id == 0)
            {
                return NotFound();
            }
            DepartmentDto dep = DepartmentService.getDepartmentById(Id);
            if (dep == null)
            {
                return NotFound();
            }
            return Ok<DepartmentDto>(dep);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] DepartmentDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            int status = DepartmentService.addDepartment(model);
            if (status > 0)
            {
                return Ok("New Record Added");
            }
            return BadRequest("Invalid Request");

        }

        [HttpPut]
        public IHttpActionResult Put([FromUri] int Id, [FromBody] DepartmentUpdateDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            int status = DepartmentService.updateDepartment(model, Id);
            if (status > 0)
            {
                return Ok("Record Updated");
            }
            return BadRequest("Invalid Request");

        }

        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int Id)
        {
            var dep = DepartmentService.getDepartmentById(Id);
            if (dep == null)
            {
                return NotFound();
            }
            int status = DepartmentService.DeleteDepartment(Id);
            if (status > 0)
            {
                return Ok("Record Deleted");
            }
            return BadRequest("Invalid Request");
        }
    }
}
