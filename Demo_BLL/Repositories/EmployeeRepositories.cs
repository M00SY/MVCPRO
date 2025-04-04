using Demo_BLL.Interfaces;
using Demo_Dal.Context;
using Demo_Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BLL.Repositories
{
    public class EmployeeRepositories : GenericRepository<Employee>, IEmployeeRepositories
    {
        private readonly MVCDbContext context;

        public EmployeeRepositories(MVCDbContext _context) : base(_context)
        {
            context = _context;
        }

        //public IEnumerable<Employee> Search(string? Name, string? Email)
        //{
        //    if (string.IsNullOrEmpty(Name))
        //        return context.Employees.Where(emp => emp.Email.Trim().ToLower().Contains(Email.Trim().ToLower()));
        //    else if(string.IsNullOrEmpty(Email))
        //        return context.Employees.Where(emp => emp.Name.Trim().ToLower().Contains(Name.Trim().ToLower()));
        //    else
        //        return context.Employees.Where(emp => emp.Email.Trim().ToLower().Contains(Email.Trim().ToLower())
        //                                    && emp.Name.Trim().ToLower().Contains(Name.Trim().ToLower()));
        //}

        //public IEnumerable<Employee> Search(string? name, string? email)
        //{
        //    return context.Employees.Where(emp =>
        //        string.IsNullOrEmpty(name)
        //        ? emp.Email.Trim().ToLower().Contains(email.Trim().ToLower())
        //        : emp.Name.Trim().ToLower().Contains(name.Trim().ToLower())
        //        );
        //}
        //public IEnumerable<Employee> Search(string? name, string? email, int? deptId)
        //{
        //    return context.Employees.Where((emp => (((string.IsNullOrEmpty(name)) || emp.Name.Trim().ToLower().Contains(name.Trim().ToLower()) && (string.IsNullOrEmpty(email)) || emp.Email.Trim().ToLower().Contains(email.Trim().ToLower()) && (deptId == null)) | emp.DepartmentId == deptId))
        //        );
        //}

        public IEnumerable<Employee> Search(string? name, string? email, int? deptId)
        {
            //return context.Employees.Where(emp =>
            //    (string.IsNullOrEmpty(name) || emp.Name.Trim().ToLower().Contains(name.Trim().ToLower())) &&
            //    (string.IsNullOrEmpty(email) || emp.Email.Trim().ToLower().Contains(email.Trim().ToLower())) &&
            //    (deptId == null || emp.DepartmentId == deptId)
            //);

            IEnumerable<Employee> employees = Enumerable.Empty<Employee>() ;
            if(!string.IsNullOrEmpty(name))
                employees = employees.Concat(SearchByName(name));
            if(!string.IsNullOrEmpty(email))
                employees = employees.Concat(SearchByEmail(email));
            if(deptId != null || deptId != 0)
            employees = employees.Concat(SearchByDept(deptId));
            

            return employees;
            
        }

        private  IEnumerable<Employee> SearchByName(string? name)
        {
            return context.Employees.Where(emp => emp.Name.Trim().ToLower().Contains(name.Trim().ToLower()));

        }
        private IEnumerable<Employee> SearchByEmail(string? email)
        {
            return context.Employees.Where(emp => emp.Email.Trim().ToLower().Contains(email.Trim().ToLower()));
        }
        private IEnumerable<Employee> SearchByDept(int? deptId)
        {
            return context.Employees.Where(emp => emp.DepartmentId == deptId);

        }

    }
}