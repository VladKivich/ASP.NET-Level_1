using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Interfaces
{
    public interface IEmployeesData
    {
        IEnumerable<Employee> GetAll();

        Employee GetById(int ID);

        void AddNew(Employee Emp);

        void Delete(Employee Emp);

        void SaveChanges();
    }
}
