using KatlaSport.DataAccess.OfficeCatalogue;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.OfficeManagement
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetStafAsync();

        Task<Employee> GetEmployeeAsync(int id);

        Task CreateAsync(Employee employee);

        Task<Employee> UpdateAsync(int id, Employee employee);

        Task DeleteAsync(int id);
    }
}
