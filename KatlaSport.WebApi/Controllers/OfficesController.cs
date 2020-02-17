using KatlaSport.Services.OfficeManagement;
using KatlaSport.Services.RequaredInventoryManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/offices")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class OfficesController : ApiController
    {
        private readonly IOfficeService _officeService;

        private readonly IRequaredInventoryService _requaredInventoryService;
        public OfficesController(IOfficeService officeService, IRequaredInventoryService requaredInventory)
        {
            _officeService = officeService ?? throw new ArgumentNullException(nameof(officeService));
            _requaredInventoryService = requaredInventory ?? throw new  ArgumentNullException(nameof(requaredInventory));
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of office.", Type = typeof(UpdateOfficeRequest))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetOffices()
        {
            var offices = await _officeService.GetOfficesAsync();
            return Ok(offices);
        }

        [HttpGet]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a office.")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetOffice([FromUri] int id)
        {
            var office = await _officeService.GetOfficeAsync(id);
            return Ok(office);
        }

        [HttpGet]
        [Route("{id:int:min(1)}/inventorys")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of inventorys")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetInventoryAsync(int id)
        {
            var dbRequiredInventorys = await _requaredInventoryService.GetRequaredInventorysAsync();
            var requiredInventorys = dbRequiredInventorys.Where(i => i.OfficeId == id);
            return Ok(requiredInventorys);
        }


        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new office.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddOffice([FromBody] UpdateOfficeRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var office = await _officeService.CreateOfficeAsync(createRequest);
            var location = string.Format("/api/staf/{0}", office.OfficeId);
            return Created<OfficeItem>(location, office);
        }

        [HttpPut]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed office.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateOffice([FromUri] int id, [FromBody] UpdateOfficeRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _officeService.UpdateOfficeAsync(id, updateRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpDelete]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed office.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteOffice([FromUri] int id)
        {
            await _officeService.DeleteOfficeAsync(id);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
    }
}
