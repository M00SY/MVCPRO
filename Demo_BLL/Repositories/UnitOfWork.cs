using Demo_BLL.Interfaces;
using Demo_Dal.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IEmployeeRepositories employeeRepositories, IDepartmentRepository departmentRepository)
        {
            DepartmentRepository = departmentRepository;
            EmployeeRepository = employeeRepositories;
        }

        public IDepartmentRepository DepartmentRepository { get; set; }
        public IEmployeeRepositories EmployeeRepository { get; set; }
    }
}
