using System.Collections.Generic;
using System.Threading.Tasks;
using KatlaSport.Services.OfficeManagement;

namespace KatlaSport.Services.RequaredInventoryManagement
{
    /// <summary>
    /// Represents a requiredInventory service.
    /// </summary>
    public interface IRequaredInventoryService
    {
        /// <summary>
        /// Gets a requiredInventorys list.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{List{RequiredInventoryItem}}" />.
        /// </returns>
        Task<List<RequiredInventoryItem>> GetRequaredInventorysAsync();

        /// <summary>
        /// Gets a requiredInventorys list.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{List{RequiredInventoryItem}}" />.
        /// </returns>
        Task<List<RequiredInventoryItem>> GetOfficeRequaredInventorysAsync(int officeId);

        /// <summary>
        /// Gets a requiredInventory with specified identifier.
        /// </summary>
        /// <param name="requiredInventoryId">A requiredInventory identifier.</param>
        /// <returns>
        /// A <see cref="Task{RequaredInventoryItem}" />.
        /// </returns>
        Task<RequiredInventoryItem> GetRequaredInventoryAsync(int requiredInventoryId);

        /// <summary>
        /// Gets the required inventory item descendant.
        /// </summary>
        /// <param name="requaredInventoryId">The requared inventory identifier.</param>
        /// <returns>
        /// A <see cref="Task{List{RequiredInventoryItem}}"/>
        /// </returns>
        Task<List<RequiredInventoryItem>> GetRequiredInventoryItemDescendantAsync(int requaredInventoryId);

        /// <summary>
        /// Creates a new requiredInventory.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateRequiredInventoryRequest" />.</param>
        /// <returns>
        /// A <see cref="Task{RequiredInventoryItem}" />.
        /// </returns>
        Task<RequiredInventoryItem> CreateRequaredInventoryAsync(UpdateRequiredInventoryRequest createRequest);

        /// <summary>
        /// Creates a new requiredInventory with parent.
        /// </summary>
        /// <param name="parentId">A <see cref="int"/></param>
        /// <param name="createRequest">A <see cref="UpdateRequiredInventoryRequest" />.</param>
        /// <returns>
        /// A <see cref="Task{RequiredInventoryItem}" />.
        /// </returns>
        Task<RequiredInventoryItem> CreateRequaredInventoryAsync( int parentId, UpdateRequiredInventoryRequest createRequest);

        /// <summary>
        /// Updates an existed requiredInventory.
        /// </summary>
        /// <param name="requiredInventoryId">A requiredInventory identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateRequiredInventoryRequest" />.</param>
        /// <returns>
        /// A <see cref="Task{RequaredInventoryItem}" />.
        /// </returns>
        Task<RequiredInventoryItem> UpdateRequaredInventoryAsync(int requiredInventoryId, UpdateRequiredInventoryRequest updateRequest);

        /// <summary>
        /// Deletes an existed requiredInventory.
        /// </summary>
        /// <param name="requiredInventoryId">A requiredInventory identifier.</param>
        /// <returns><see cref="Task"/></returns>
        Task DeleteRequaredInventoryAsync(int requiredInventoryId);
    }
}
