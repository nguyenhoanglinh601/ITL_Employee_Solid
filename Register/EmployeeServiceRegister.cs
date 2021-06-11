using Microsoft.Extensions.DependencyInjection;
using SOLID_example_2.Respositories.Implement;
using SOLID_example_2.Respositories.Interface;
using SOLID_example_2.Services.Implement;
using SOLID_example_2.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID_example_2.Register
{
    public static class EmployeeServiceRegister
    {
        public static IServiceCollection RegisterApiRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRespository, EmployeeRespository>();

            return services;
        }

        public static IServiceCollection RegisterApiService(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeCRUD, EmployeeService>();

            return services;
        }
    }
}
