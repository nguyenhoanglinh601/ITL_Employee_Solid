using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SOLID_example_2.Model;

namespace SOLID_example_2.Services.Interface
{
    interface IEmployeeCRUD
    {
        Task<List<Employee>> GetAll();
        Task<Employee> Get(long id);
        Task<Employee> Create(Employee employee);
        Task<Employee> Update(long id, Employee employee);
        Task<Employee> Delete(long id);
    }
}
