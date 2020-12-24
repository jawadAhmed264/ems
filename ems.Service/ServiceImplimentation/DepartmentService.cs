using ems.Service.AutoMapperInfrastructure;
using ems.Data.Models;
using ems.Data.Repository;
using ems.DTO;
using ems.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ems.Service.ServiceImplimentation
{
    public class DepartmentService : IDepartmentService
    {
        private IGenericRepository<Department> repository = null;

        public DepartmentService() {
            this.repository = new GenericRepository<Department>();
        }

        public DepartmentService(IGenericRepository<Department> repository)
        {
            this.repository = repository;
        }

        public int addDepartment(DepartmentDto departmentDto)
        {
            Department dep = ObjectMapper.Mapper.Map<Department>(departmentDto);
            repository.Insert(dep);
            int status=repository.Save();
            return status;
        }

        public int DeleteDepartment(object Id)
        {
            repository.Delete(Id);
            int Status=repository.Save();
            return Status;
        }

        public IEnumerable<DepartmentDto> getAllDepartment()
        {
            IEnumerable<DepartmentDto> DepartmentList = repository.GetAll().AsEnumerable().
                Select(dep => ObjectMapper.Mapper.Map<DepartmentDto>(dep)).ToList();
            return DepartmentList;
        }

        public DepartmentDto getDepartmentById(object Id)
        {
            Department dep = repository.GetById(Id);
            return ObjectMapper.Mapper.Map<DepartmentDto>(dep);
        }

        public int updateDepartment(DepartmentUpdateDto departmentDto, object Id)
        {
            Department dep = repository.GetById(Id);
            if (dep != null) {
                ObjectMapper.Mapper.Map(departmentDto, dep);
            }
            repository.Update(dep);
            int status = repository.Save();
            return status;
        }
    }
}
