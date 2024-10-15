using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Data.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ILogger<EmployeeRepository> _logger;
        private readonly AppDbContext _dbContext;

        public EmployeeRepository(
                                  ILogger<EmployeeRepository> logger,
                                  AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public async Task<Employee> Add(Employee employee)
        {
            await _dbContext.Employees.AddAsync(employee);
            _dbContext.SaveChanges();
            return employee;
        }

        public async Task<Employee?> Delete(int id)
        {
            Employee? employee = await _dbContext.Employees.FindAsync(id);
            if(employee is not null)
            {
                _dbContext.Employees.Remove(employee);
                _dbContext.SaveChanges();
            }
            return employee;
        }

        public async Task<Employee?> Get(int id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return _dbContext.Employees;
        }

        public async Task<Employee> Update(Employee employee)
        {
            var modifiedEmployee = _dbContext.Employees.Attach(employee);
            modifiedEmployee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
            return employee;
        }
    }
}
