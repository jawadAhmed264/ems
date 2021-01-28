using ems.Data.Models;
using ems.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ems.Data.Repository
{
    public interface IEmployeeRepo:IGenericRepository<Employee>
    {
        IEnumerable<Employee> getEmployeesByFilters(Root filter);
    }
}
