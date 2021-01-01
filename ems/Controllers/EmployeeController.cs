using ems.DTO;
using ems.Service.ServiceImplimentation;
using ems.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ems.Controllers
{
    public class EmployeeController : ApiController
    {
        private IEmployeeService EmployeeService = null;

        public EmployeeController(IEmployeeService employeeService) {
            this.EmployeeService = employeeService;
        }

        [HttpGet]
        public IHttpActionResult Get() {
            IEnumerable<EmployeeDto> employeeDtos = EmployeeService.getAllEmployees();
            return Ok(employeeDtos);
        }

        [HttpGet]
        public IHttpActionResult Get(int? Id)
        {
            if (Id == null || (int)Id == 0)
            {
                return NotFound();
            }
            EmployeeDto emp = EmployeeService.getEmployeeById(Id);
            if (emp == null)
            {
                return NotFound();
            }
            return Ok<EmployeeDto>(emp);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] EmployeeDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            int status = EmployeeService.addEmployee(model);
            if (status > 0)
            {
                return Ok("New Record Added");
            }
            return BadRequest("Invalid Request");

        }

        [HttpPut]
        public IHttpActionResult Put([FromUri] int Id, [FromBody] EmployeeUpdateDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            int status = EmployeeService.updateEmployee(model, Id);
            if (status > 0)
            {
                return Ok("Record Updated");
            }
            return BadRequest("Invalid Request");

        }

        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int Id)
        {
            var dep = EmployeeService.getEmployeeById(Id);
            if (dep == null)
            {
                return NotFound();
            }
            int status = EmployeeService.DeleteEmployee(Id);
            if (status > 0)
            {
                return Ok("Record Deleted");
            }
            return BadRequest("Invalid Request");
        }
    }
}
