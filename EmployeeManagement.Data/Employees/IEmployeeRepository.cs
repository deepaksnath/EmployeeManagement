namespace EmployeeManagement.Data.Employees
{
    public interface IEmployeeRepository
    {
        Task<Employee?> Get(int id);
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> Add(Employee employee);
        Task<Employee> Update(Employee employee);
        Task<Employee?> Delete(int id);
    }
}
