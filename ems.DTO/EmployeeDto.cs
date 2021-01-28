using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ems.DTO
{
    public class EmployeeDto
    {
        public long Id { get; set; }
        public string EmpName { get; set; }
        public string Contact { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> DepId { get; set; }
        public DepartmentDto Department { get; set; }
        public string Gender { get; set; }
    }

    public class EmployeeUpdateDto
    {
        public string EmpName { get; set; }
        public string Contact { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> DepId { get; set; }
        public string Gender { get; set; }
    }
    public class EmployeeListDto
    {
        public IList<EmployeeDto> Employees { get; set; }
        public int TotalEmployees { get; set; }
    }

}
