﻿using ems.Data.Models;
using ems.Data.Repository;
using ems.DTO;
using ems.Service.AutoMapperInfrastructure;
using ems.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ems.Service.ServiceImplimentation
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepo repository = null;
        public EmployeeService()
        {
            this.repository = new EmployeeRepo();
        }
        public EmployeeService(EmployeeRepo repository)
        {
            this.repository = repository;
        }

        public int addEmployee(EmployeeDto employeeDto)
        {
            Employee emp = ObjectMapper.Mapper.Map<Employee>(employeeDto);
            repository.Insert(emp);
            int status = repository.Save();
            return status;
        }

        public int DeleteEmployee(object Id)
        {
            repository.Delete(Id);
            return repository.Save();
        }

        public int EmployeeCount()
        {
            int count = repository.GetAll().Count();
            return count;
        }

        public IEnumerable<EmployeeDto> getAllEmployees()
        {
            IEnumerable<EmployeeDto> EmployeeList = repository.GetAll().AsEnumerable().
                Select(emp => ObjectMapper.Mapper.Map<EmployeeDto>(emp)
             ).ToList();

            return EmployeeList;
        }

        public IEnumerable<EmployeeDto> getEmployeesByFilter(Root root)
        {
            IEnumerable<EmployeeDto> list = repository.getEmployeesByFilters(root).
                           Select(emp => ObjectMapper.Mapper.Map<EmployeeDto>(emp)).ToList();
            return list;
        }

        public EmployeeDto getEmployeeById(object Id)
        {
            Employee emp = repository.GetById(Id);
            return ObjectMapper.Mapper.Map<EmployeeDto>(emp);
        }
        public int updateEmployee(EmployeeUpdateDto employeeUpdateDto, object Id)
        {
            Employee emp = repository.GetById(Id);
            if (emp != null)
            {
                emp = ObjectMapper.Mapper.Map(employeeUpdateDto, emp);
            }
            repository.Update(emp);
            return repository.Save();
        }
    }
}
