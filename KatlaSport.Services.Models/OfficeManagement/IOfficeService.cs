using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.OfficeManagement
{
    /// <summary>
    /// Represents a office service.
    /// </summary>
    public interface IOfficeService
    {
        /// <summary>
        /// Gets a offices list.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{List{OfficeItem}}" />.
        /// </returns>
        Task<List<OfficeItem>> GetOfficesAsync();

        /// <summary>
        /// Gets a office with specified identifier.
        /// </summary>
        /// <param name="officeId">A office identifier.</param>
        /// <returns>
        /// A <see cref="Task{OfficeItem}" />.
        /// </returns>
        Task<OfficeItem> GetOfficeAsync(int officeId);

        /// <summary>
        /// Creates a new office.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateOfficeRequest" />.</param>
        /// <returns>
        /// A <see cref="Task{OfficeItem}" />.
        /// </returns>
        Task<OfficeItem> CreateOfficeAsync(UpdateOfficeRequest createRequest);

        /// <summary>
        /// Updates an existed office.
        /// </summary>
        /// <param name="officeId">A office identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateOfficeRequest" />.</param>
        /// <returns>
        /// A <see cref="Task{OfficeItem}" />.
        /// </returns>
        Task<OfficeItem> UpdateOfficeAsync(int officeId, UpdateOfficeRequest updateRequest);

        /// <summary>
        /// Deletes an existed office.
        /// </summary>
        /// <param name="officeId">A office identifier.</param>
        /// <returns><see cref="Task"/></returns>
        Task DeleteOfficeAsync(int officeId);
    }
}
