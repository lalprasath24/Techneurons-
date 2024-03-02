using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNeurons.Models;
using Unity;

namespace TechNeurons.IRepository
{
    public interface IEmployeeRepository<T>
    {
        void Create(T entity);

        void Delete(T entity);

        void Update(T entity);

        List<Employee> GetAll();

        Employee GetById(int? id);

        void Save();

        

    }
}
