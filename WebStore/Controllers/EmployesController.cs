using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployesController : Controller
    {
        public static readonly List<Employee> EmpList = new List<Employee>
    {
        new Employee(1, "Aron", "A", EmployesPostsEnum.Worker, 25, Gender.male),
        new Employee(2, "Bob", "B", EmployesPostsEnum.Manager, 35, Gender.male),
        new Employee(3, "Cindy", "C", EmployesPostsEnum.TopManager, 45, Gender.female)
    };

        public IActionResult Index()
        {
            return View(EmpList);
        }

        public IActionResult Details(int ID)
        {
            //var Employee = EmpList.FirstOrDefault(emp => emp.ID == ID);
             var Employee = from emp in EmpList
                           where (emp.ID == ID)
                           select emp;

            return View(Employee);
        }
    }
}