using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID_example_2.Model.DB_Setting
{
    public class Employee_Solid_Context : DbContext
    {
        public Employee_Solid_Context(DbContextOptions<Employee_Solid_Context> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
