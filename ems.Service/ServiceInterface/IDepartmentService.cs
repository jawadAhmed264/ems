using ems.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ems.Service.ServiceInterface
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentDto> getAllDepartment();
        DepartmentDto getDepartmentById(object Id);
        int addDepartment(DepartmentDto departmentDto);
        int updateDepartment(DepartmentUpdateDto departmentDto,object Id);
        int DeleteDepartment(object Id);

    }
}
