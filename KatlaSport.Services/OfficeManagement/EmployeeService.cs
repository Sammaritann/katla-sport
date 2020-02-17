using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.OfficeCatalogue;

namespace KatlaSport.Services.OfficeManagement
{
    /// <summary>
    /// Represents a employee service.
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeService"/> class with specified <see cref="IOfficeCatalogueContext"/> and <see cref="IUserContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IOfficeCatalogueContext"/>.</param>
        public EmployeeService(IOfficeCatalogueContext context)
        {
            _repository = new EmployeeRepository(context) ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<List<EmployeeItem>> GetEmployeesAsync()
        {
            var dbEmployees = await _repository.GetStafAsync();
            var employees = dbEmployees.Select(e => Mapper.Map<EmployeeItem>(e)).ToList();

            return employees;
        }

        /// <inheritdoc/>
        public async Task<EmployeeItem> GetEmployeeAsync(int employeeId)
        {
            var dbEmployee = await _repository.GetEmployeeAsync(employeeId);

            return Mapper.Map<EmployeeItem>(dbEmployee);
        }

        /// <inheritdoc/>
        public async Task<EmployeeItem> CreateEmployeeAsync(UpdateEmployeeRequest createRequest)
        {
            var dbEmployee = Mapper.Map<UpdateEmployeeRequest, Employee>(createRequest);

            await _repository.CreateAsync(dbEmployee);

            return Mapper.Map<EmployeeItem>(dbEmployee);
        }

        /// <inheritdoc/>
        public async Task<EmployeeItem> UpdateEmployeeAsync(int employeeId, UpdateEmployeeRequest updateRequest)
        {
            var dbEmployee = await _repository.UpdateAsync(employeeId, Mapper.Map<Employee>(updateRequest));

            return Mapper.Map<EmployeeItem>(dbEmployee);
        }

        /// <inheritdoc/>
        public async Task DeleteEmployeeAsync(int employeeId)
        {
            await _repository.DeleteAsync(employeeId);
        }
    }
}
