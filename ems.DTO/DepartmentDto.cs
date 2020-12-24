using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ems.DTO
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string DepName { get; set; }
    }
    public class DepartmentUpdateDto
    {
        public string DepName { get; set; }
    }

}
