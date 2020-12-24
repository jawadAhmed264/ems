using ems.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ems.Service.ServiceInterface
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> getAllEmployees();
        EmployeeDto getEmployeeById(object Id);
        int addEmployee(EmployeeDto employeeDto);
        int updateEmployee(EmployeeUpdateDto employeeUpdateDto, object Id);
        int DeleteEmployee(object Id);
    }
}
