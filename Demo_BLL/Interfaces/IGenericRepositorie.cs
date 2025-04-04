using Demo_BLL.Repositories;
using Demo_Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BLL.Interfaces
{
    public interface IGenericRepositorie<T> where T : Base
    {
        T GetById(int? id);
        IEnumerable<T> GetAll();
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
