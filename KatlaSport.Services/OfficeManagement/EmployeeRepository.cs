using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.OfficeCatalogue;

namespace KatlaSport.Services.OfficeManagement
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IOfficeCatalogueContext _context;

        public EmployeeRepository(IOfficeCatalogueContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateAsync(Employee employee)
        {
            _context.Staf.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dbEmployees = await _context.Staf.Where(p => p.Id == id).ToArrayAsync();
            if (dbEmployees.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbEmployee = dbEmployees[0];

            _context.Staf.Remove(dbEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            var dbEmployees = await _context.Staf.Where(e => e.Id == id).ToArrayAsync();

            if (dbEmployees.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return dbEmployees[0];
        }

        public async Task<IEnumerable<Employee>> GetStafAsync()
        {
            var dbEmployees = await _context.Staf.OrderBy(h => h.Id).ToArrayAsync();
            return dbEmployees;
        }

        public async Task<Employee> UpdateAsync(int id, Employee employee)
        {
            var dbEmployees = await _context.Staf.Where(p => p.Id == id).ToArrayAsync();

            var dbEmployee = dbEmployees[0];
            if (dbEmployees.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            Mapper.Map(employee, dbEmployee);

            await _context.SaveChangesAsync();

            return dbEmployee;
        }
    }
}
