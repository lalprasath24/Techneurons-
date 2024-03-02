    using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TechNeurons.IRepository;
using TechNeurons.Models;
using TechNeurons.Repository;

namespace TechNeurons.Controllers
{
    
    public class HomeController : Controller
    {
         private IEmployeeRepository<Employee> _employee;

        public HomeController(IEmployeeRepository<Employee> employee)
        {
            _employee = employee;
        }

        public ActionResult Index()
        {
            List<Employee> employees = _employee.GetAll();
            

            return View(employees);
        }



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employee.Create(employee);
                _employee.Save();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee=_employee.GetById(id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employee.Update(employee);
                _employee.Save();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }
            Employee employee = _employee.GetById(id);

            return View(employee);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Employee employee= _employee.GetById(id);
            _employee.Delete(employee);
            _employee.Save();
            return RedirectToAction("Index");
        }


        [HttpGet]
       
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee=_employee.GetById(id);

            if(employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }



        
    }
}