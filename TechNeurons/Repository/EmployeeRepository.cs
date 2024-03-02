using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TechNeurons.IRepository;
using TechNeurons.Models;

namespace TechNeurons.Repository
{
    public class EmployeeRepository<T> : IEmployeeRepository<T> where T : Employee
    {
        DbEmployeeEntities db=new DbEmployeeEntities();
        public void Create(T entity)
        {
            db.Employees.Add(entity);
        }

        public void Delete(T entity)
        {
            db.Employees.Remove(entity);
        }

       

        public List<Employee> GetAll()
        {
            var employees = db.Employees.ToList();

            return employees;
        }

        public Employee GetById(int? id)
        {
            var entity = db.Employees.FirstOrDefault(x => x.Id == id);

            return entity;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(T entity)
        {
             var ObjFromDb=db.Employees.FirstOrDefault(x=>x.Id == entity.Id);

            if (ObjFromDb != null)
            {
                ObjFromDb.Id = entity.Id;
                ObjFromDb.name = entity.name;
                ObjFromDb.age = entity.age;
                ObjFromDb.experience = entity.experience;
                ObjFromDb.department = entity.department;
                ObjFromDb.gender = entity.gender;
                ObjFromDb.address = entity.address;

            }

              db.Employees.AddOrUpdate(ObjFromDb);
        }

       
    }
}