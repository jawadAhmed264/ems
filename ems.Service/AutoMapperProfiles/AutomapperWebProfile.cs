using ems.Data.Models;
using ems.DTO;

namespace ems.Service.AutoMapperProfiles
{
    public class AutomapperWebProfile : AutoMapper.Profile
    {
        public AutomapperWebProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentDto, Department>();
            CreateMap<Department, DepartmentUpdateDto>();
            CreateMap<DepartmentUpdateDto, Department>();
            CreateMap<Employee, EmployeeUpdateDto>();
            CreateMap<EmployeeUpdateDto, Employee>();
        }
        
    }
}
