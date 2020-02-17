using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.OfficeManagement
{
    /// <summary>
    /// Represents a employee service.
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Gets a employees list.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{List{EmployeeItem}}" />.
        /// </returns>
        Task<List<EmployeeItem>> GetEmployeesAsync();

        /// <summary>
        /// Gets a employee with specified identifier.
        /// </summary>
        /// <param name="employeeId">A employee identifier.</param>
        /// <returns>
        /// A <see cref="Task{Employee}" />.
        /// </returns>
        Task<EmployeeItem> GetEmployeeAsync(int employeeId);

        /// <summary>
        /// Creates a new employee.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateEmployeeRequest" />.</param>
        /// <returns>
        /// A <see cref="Task{Employee}" />.
        /// </returns>
        Task<EmployeeItem> CreateEmployeeAsync(UpdateEmployeeRequest createRequest);

        /// <summary>
        /// Updates an existed employee.
        /// </summary>
        /// <param name="employeeId">A employee identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateEmployeeRequest" />.</param>
        /// <returns>
        /// A <see cref="Task{EmployeeItem}" />.
        /// </returns>
        Task<EmployeeItem> UpdateEmployeeAsync(int employeeId, UpdateEmployeeRequest updateRequest);

        /// <summary>
        /// Deletes an existed employee.
        /// </summary>
        /// <param name="employeeId">A employee identifier.</param>
        /// <returns><see cref="Task"/></returns>
        Task DeleteEmployeeAsync(int employeeId);
    }
}
