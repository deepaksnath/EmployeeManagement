using EmployeeManagement.Data;
using EmployeeManagement.Data.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmployeeManagement.Extensions
{
    public static class RegisterServiceDependencies
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            return services;
        }
    }
}
