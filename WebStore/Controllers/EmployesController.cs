using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Interfaces;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployesController : Controller
    {
        private readonly IEmployeesData EmpList;

        public EmployesController(IEmployeesData IEmpData)
        {
            EmpList = IEmpData;
        }

        public IActionResult Index()
        {
            return View(EmpList.GetAll());
        }

        public IActionResult Details(int ID)
        {
            //var Employee = (from emp in EmpList
            //               where (emp.ID == ID)
            //               select emp).ToList();
            
            var Employee =  EmpList.GetById(ID);

            return View(Employee);
        }

        public IActionResult Edit(int? ID)
        {
            Employee E;
            if (ID != null)
            {
               E = EmpList.GetById((int)ID);
                if(E is null)
                {
                    return NotFound();
                }
            }
            else
            {
                E = new Employee();
            }
            return View();
        }
        
        [HttpPost]
        public IActionResult Edit(Employee Emp)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            else if(Emp.ID > 0)
            {
                var Employee = EmpList.GetById(Emp.ID);
                if(Employee is null)
                {
                    return NotFound();
                }
                Employee.FirstName = Emp.FirstName;
                Employee.LastName = Emp.LastName;
                Employee.Age = Emp.Age;
                Employee.Gender = Emp.Gender;
                Employee.Post = Emp.Post;
            }
            else
            {
                EmpList.AddNew(Emp);
            }
            EmpList.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}