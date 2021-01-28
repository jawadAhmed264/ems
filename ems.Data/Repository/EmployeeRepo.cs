using ems.Data.Models;
using ems.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ems.Data.Repository
{
    public class EmployeeRepo : GenericRepository<Employee>, IEmployeeRepo
    {
        private Root _filter;
        public IEnumerable<Employee> getEmployeesByFilters(Root filter)
        {
            _filter = filter;
            IQueryable<Employee> list = GetAll();
            list = Sort(list);
            list = Filter(list);
            list = list.Skip(filter.First).Take(filter.Rows);
            return list.ToList<Employee>();
        }

        private IQueryable<Employee> Filter(IQueryable<Employee> list)
        {
            if (_filter.GlobalFilter != null)
            {
                bool isNumber = int.TryParse(_filter.GlobalFilter.ToString(), out _);
                if (isNumber)
                {
                    int age = Convert.ToInt32(_filter.GlobalFilter);
                    Decimal salary = Convert.ToDecimal(_filter.GlobalFilter);
                    list = list.Where(m => m.Age == age || m.Salary == salary);
                }
                else
                {
                    list = list.Where(m => m.EmpName.Contains(_filter.GlobalFilter.ToString())
                    || m.Contact.Contains(_filter.GlobalFilter.ToString())
                    || m.Gender == _filter.GlobalFilter.ToString()
                    || m.Department.DepName.Contains(_filter.GlobalFilter.ToString())
                    );
                }
            }
            return list;
        }

        private IQueryable<Employee> Sort(IQueryable<Employee> list)
        {
            if (_filter.SortField == EmployeeProp.EmpName.ToString())
            {
                switch (_filter.SortOrder)
                {
                    case 1:
                        list = list.OrderBy(m => m.EmpName);
                        break;
                    case -1:
                        list = list.OrderByDescending(m => m.EmpName);
                        break;
                }
            }
            if (_filter.SortField == EmployeeProp.Contact.ToString())
            {
                switch (_filter.SortOrder)
                {
                    case 1:
                        list = list.OrderBy(m => m.Contact);
                        break;
                    case -1:
                        list = list.OrderByDescending(m => m.Contact);
                        break;
                }
            }
            if (_filter.SortField == EmployeeProp.Salary.ToString())
            {
                switch (_filter.SortOrder)
                {
                    case 1:
                        list = list.OrderBy(m => m.Salary);
                        break;
                    case -1:
                        list = list.OrderByDescending(m => m.Salary);
                        break;
                }
            }
            if (_filter.SortField == EmployeeProp.Age.ToString())
            {
                switch (_filter.SortOrder)
                {
                    case 1:
                        list = list.OrderBy(m => m.Age);
                        break;
                    case -1:
                        list = list.OrderByDescending(m => m.Age);
                        break;
                }
            }
            if (_filter.SortField == EmployeeProp.Gender.ToString())
            {
                switch (_filter.SortOrder)
                {
                    case 1:
                        list = list.OrderBy(m => m.Gender);
                        break;
                    case -1:
                        list = list.OrderByDescending(m => m.Gender);
                        break;
                }
            }
            if (_filter.SortField == "Department.DepName")
            {
                switch (_filter.SortOrder)
                {
                    case 1:
                        list = list.OrderBy(m => m.Department.DepName);
                        break;
                    case -1:
                        list = list.OrderByDescending(m => m.Department.DepName);
                        break;
                }
            }
            if (string.IsNullOrEmpty(_filter.SortField))
            {
                list = list.OrderBy(m => m.Id);
            }
            return list;
        }
    }
    enum EmployeeProp
    {
        EmpName,
        Contact,
        Salary,
        Age,
        DepId,
        Gender
    }
}