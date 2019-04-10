using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Interfaces;
using WebStore.Models;

namespace WebStore.Services
{
    public class EmployeesDataService : IEmployeesData
    {
        private List<Employee> EmpList = new List<Employee>
        {
            new Employee(1, "Aron", "A", EmployesPostsEnum.Worker, 25, Gender.male),
            new Employee(2, "Bob", "B", EmployesPostsEnum.Manager, 35, Gender.male),
            new Employee(3, "Cindy", "C", EmployesPostsEnum.TopManager, 45, Gender.female)
        };

        public void AddNew(Employee Emp)
        {
            int num = EmpList.Count;
            Emp.ID = ++num;
            EmpList.Add(Emp);
        }

        public void Delete(Employee Emp)
        {
            if(EmpList.Contains(Emp))
            {
                EmpList.Remove(Emp);
            }
        }

        public IEnumerable<Employee> GetAll() => EmpList;

        public Employee GetById(int ID)
        {
            return EmpList.FirstOrDefault(e => e.ID == ID);
        }

        public void SaveChanges()
        {

        }
    }
}
