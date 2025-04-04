using Demo_BLL.Interfaces;
using Demo_Dal.Context;
using Demo_Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BLL.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository 
    {
        private readonly MVCDbContext context;

        public DepartmentRepository(MVCDbContext _context) : base(_context)
        {
            context = _context;
        }
        
    }
}
