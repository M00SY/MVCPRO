using Demo_Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BLL.Interfaces
{
    public interface IDepartmentRepository : IGenericRepositorie<Department>
    {
        //Department GetDepartmentById(int? id);
        //IEnumerable<Department> GetAllDepartment();
        //int AddDepartment(Department department);
        //int UpdateDepartment(Department department);
        //int DeleteDepartment(Department department);
    }
}
