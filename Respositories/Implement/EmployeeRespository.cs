using Microsoft.EntityFrameworkCore;
using SOLID_example_2.Model;
using SOLID_example_2.Model.DB_Setting;
using SOLID_example_2.Respositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID_example_2.Respositories.Implement
{
    public class EmployeeRespository : IEmployeeRespository
    {
        private readonly Employee_Solid_Context _context;
        public EmployeeRespository(Employee_Solid_Context context)
        {
            _context = context;
        }
        public bool CheckExist(long id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }

        public async Task<Employee> Create(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Employee> Delete(Employee employee)
        {
            try
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Employee> Get(long id)
        {
            try
            {
                return await _context.Employees.FindAsync(id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Employee>> GetAll()
        {
            try
            {
                return await _context.Employees.ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<Employee> Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return employee;
            }
            catch
            {
                return null;
            }
        }
    }
}
