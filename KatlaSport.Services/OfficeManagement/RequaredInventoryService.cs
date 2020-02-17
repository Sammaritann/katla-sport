using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.OfficeCatalogue;
using KatlaSport.Services.OfficeManagement;

namespace KatlaSport.Services.RequaredInventoryManagement
{
    public class RequaredInventoryService : IRequaredInventoryService
    {
        private readonly IOfficeCatalogueContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequaredInventoryService"/> class with specified <see cref="IRequaredInventoryCatalogueContext"/> and <see cref="IUserContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IRequaredInventoryCatalogueContext"/>.</param>
        public RequaredInventoryService(IOfficeCatalogueContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<List<RequiredInventoryItem>> GetRequaredInventorysAsync()
        {
            var dbRequaredInventorys = await _context.RequiredInventories.OrderBy(o => o.Id).ToArrayAsync();
            var requaredInventorys = dbRequaredInventorys.Select(e => Mapper.Map<RequiredInventoryItem>(e)).ToList();

            return requaredInventorys;
        }

        /// <inheritdoc/>
        public async Task<RequiredInventoryItem> GetRequaredInventoryAsync(int requaredInventoryId)
        {
            var dbRequaredInventorys = await _context.RequiredInventories.Where(o => o.Id == requaredInventoryId).ToArrayAsync();
            if (dbRequaredInventorys.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<RequiredInventoryItem>(dbRequaredInventorys[0]);
        }

        public async Task<List<RequiredInventoryItem>> GetRequiredInventoryItemDescendantAsync(int requaredInventoryId)
        {
            var dbRequaredInventorys = await _context.RequiredInventories.Where(o => o.Id == requaredInventoryId).ToArrayAsync();
            if (dbRequaredInventorys.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var path = dbRequaredInventorys[0].Path + '.';
            var dbRequaredInventoryDescendant = await _context.RequiredInventories
                .Where(r => r.Path.StartsWith(path))
                .ToArrayAsync();

            if (dbRequaredInventoryDescendant.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var requaredInventoryDescendant = dbRequaredInventoryDescendant.OrderBy(r => r.Path)
                .Select(e => Mapper.Map<RequiredInventoryItem>(e))
                .ToList();
            return requaredInventoryDescendant;
        }

        /// <inheritdoc/>
        public async Task<RequiredInventoryItem> CreateRequaredInventoryAsync(UpdateRequiredInventoryRequest createRequest)
        {
            var dbRequaredInventory = Mapper.Map<UpdateRequiredInventoryRequest, RequiredInventory>(createRequest);

            int chapterNumber = _context.RequiredInventories
                .Where(r => r.Path.Length == 3)
                .Max(r => r.Number) + 1;
            string path = chapterNumber.ToString().PadLeft(3, '0');

            dbRequaredInventory.Number = chapterNumber;
            dbRequaredInventory.Path = path;

            _context.RequiredInventories.Add(dbRequaredInventory);

            await _context.SaveChangesAsync();

            return Mapper.Map<RequiredInventoryItem>(dbRequaredInventory);
        }

        /// <inheritdoc/>
        public async Task<RequiredInventoryItem> CreateRequaredInventoryAsync(int parentId, UpdateRequiredInventoryRequest createRequest)
        {
            var dbRequaredInventory = Mapper.Map<UpdateRequiredInventoryRequest, RequiredInventory>(createRequest);

            var dbRequaredInventoryParent = await _context.RequiredInventories.Where(o => o.Id == parentId).ToArrayAsync();

            if (dbRequaredInventoryParent.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            string parentPath = dbRequaredInventoryParent[0].Path + '.';

            var dbRequaredInventoryChild = await _context.RequiredInventories
                .Where(r => r.Path.StartsWith(parentPath) && r.Path.Length == parentPath.Length + 3)
                .ToArrayAsync();

            int chapterNumber = dbRequaredInventoryChild.Length > 0 ? dbRequaredInventoryChild.Max(r => r.Number) + 1 : 1;
            string path = parentPath + chapterNumber.ToString().PadLeft(3, '0');

            dbRequaredInventory.Number = chapterNumber;
            dbRequaredInventory.Path = path;

            _context.RequiredInventories.Add(dbRequaredInventory);

            await _context.SaveChangesAsync();

            return Mapper.Map<RequiredInventoryItem>(dbRequaredInventory);
        }

        /// <inheritdoc/>
        public async Task<RequiredInventoryItem> UpdateRequaredInventoryAsync(int requaredInventoryId, UpdateRequiredInventoryRequest updateRequest)
        {

            var dbRequaredInventorys = await _context.RequiredInventories.Where(p => p.Id == requaredInventoryId).ToArrayAsync();

            if (dbRequaredInventorys.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbRequaredInventory = dbRequaredInventorys[0];

            Mapper.Map(updateRequest, dbRequaredInventory);

            await _context.SaveChangesAsync();

            return Mapper.Map<RequiredInventoryItem>(dbRequaredInventory);
        }

        /// <inheritdoc/>
        public async Task DeleteRequaredInventoryAsync(int requaredInventoryId)
        {
            var dbRequaredInventorys = await _context.RequiredInventories.Where(p => p.Id == requaredInventoryId).ToArrayAsync();
            if (dbRequaredInventorys.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbRequaredInventory = dbRequaredInventorys[0];

            _context.RequiredInventories.Remove(dbRequaredInventory);
            await _context.SaveChangesAsync();
        }
    }
}
