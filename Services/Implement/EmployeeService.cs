using SOLID_example_2.Model;
using SOLID_example_2.Respositories.Implement;
using SOLID_example_2.Respositories.Interface;
using SOLID_example_2.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID_example_2.Services.Implement
{
    public class EmployeeService : IEmployeeCRUD
    {
        private readonly IEmployeeRespository _employeeRespository;
        public EmployeeService(IEmployeeRespository employeeRespository)
        {
            _employeeRespository = employeeRespository;
        }
        public async Task<Employee> Create(Employee employee)
        {
            try
            {
                Employee emp = await _employeeRespository.Create(employee);
                return emp;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Employee> Delete(long id)
        {
            bool isExist = _employeeRespository.CheckExist(id);
            if (isExist == false)
            {
                return null;
            }

            Employee employee = await _employeeRespository.Get(id);
            Employee emp = await _employeeRespository.Delete(employee);
            return emp;
        }

        public async Task<Employee> Get(long id)
        {
            Employee employee = await _employeeRespository.Get(id);

            if (employee == null)
            {
                return null;
            }

            return employee;
        }

        public Task<List<Employee>> GetAll()
        {
            return _employeeRespository.GetAll();
        }

        public Task<Employee> Update(long id, Employee employee)
        {
            if (id != employee.Id)
            {
                return null;
            }

            return _employeeRespository.Update(employee);
        }

        public bool CheckIsExist(long id)
        {
            return _employeeRespository.CheckExist(id);
        }
    }
}
