using SOLID_example_2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID_example_2.Respositories.Interface
{
    public interface IEmployeeRespository
    {
        Task<List<Employee>> GetAll();
        Task<Employee> Get(long id);
        Task<Employee> Create(Employee employee);
        Task<Employee> Update(Employee employee);
        Task<Employee> Delete(Employee employee);
        bool CheckExist(long id);
    }
}
