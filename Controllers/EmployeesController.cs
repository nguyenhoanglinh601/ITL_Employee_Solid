using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOLID_example_2.Model;
using SOLID_example_2.Model.DB_Setting;
using SOLID_example_2.Services.Implement;
using SOLID_example_2.Services.Interface;

namespace SOLID_example_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeCRUD _employeeService;
        public EmployeesController(IEmployeeCRUD employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            return await _employeeService.GetAll();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(long id)
        {
            return await _employeeService.Get(id);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> PutEmployee(long id, Employee employee)
        {
            return await _employeeService.Update(id, employee);
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
           return await _employeeService.Create(employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(long id)
        {
            return await _employeeService.Delete(id);
        }

        public bool EmployeeExist(long id)
        {
            return _employeeService.CheckIsExist(id);
        }
    }
}
