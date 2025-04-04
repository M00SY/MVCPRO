using Demo_Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BLL.Interfaces
{
    public interface IEmployeeRepositories : IGenericRepositorie<Employee>
    {
        public IEnumerable<Employee> Search(string? Name, string? Email, int? DeptId);
    }
}
