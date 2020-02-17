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
    /// Represents a office service.
    /// </summary>
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeCatalogueContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="OfficeService"/> class with specified <see cref="IOfficeCatalogueContext"/> and <see cref="IUserContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IOfficeCatalogueContext"/>.</param>
        public OfficeService(IOfficeCatalogueContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<List<OfficeItem>> GetOfficesAsync()
        {
            var dbOffices = await _context.Offices.OrderBy(o => o.OfficeId).ToArrayAsync();
            var offices = dbOffices.Select(e => Mapper.Map<OfficeItem>(e)).ToList();

            return offices;
        }

        /// <inheritdoc/>
        public async Task<OfficeItem> GetOfficeAsync(int officeId)
        {
            var dbOffices = await _context.Offices.Where(o => o.OfficeId == officeId).ToArrayAsync();
            if (dbOffices.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<OfficeItem>(dbOffices[0]);
        }

        /// <inheritdoc/>
        public async Task<OfficeItem> CreateOfficeAsync(UpdateOfficeRequest createRequest)
        {
            var dbOffice = Mapper.Map<UpdateOfficeRequest, Office>(createRequest);
            _context.Offices.Add(dbOffice);

            await _context.SaveChangesAsync();

            return Mapper.Map<OfficeItem>(dbOffice);
        }

        /// <inheritdoc/>
        public async Task<OfficeItem> UpdateOfficeAsync(int officeId, UpdateOfficeRequest updateRequest)
        {

            var dbOffices = await _context.Offices.Where(p => p.OfficeId == officeId).ToArrayAsync();

            if (dbOffices.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbOffice = dbOffices[0];

            Mapper.Map(updateRequest, dbOffice);

            await _context.SaveChangesAsync();

            return Mapper.Map<OfficeItem>(dbOffice);
        }

        /// <inheritdoc/>
        public async Task DeleteOfficeAsync(int officeId)
        {
            var dbOffices = await _context.Offices.Where(p => p.OfficeId == officeId).ToArrayAsync();
            if (dbOffices.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbOffice = dbOffices[0];

            _context.Offices.Remove(dbOffice);
            await _context.SaveChangesAsync();
        }
    }
}
