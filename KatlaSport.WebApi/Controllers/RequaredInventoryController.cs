using KatlaSport.Services.OfficeManagement;
using KatlaSport.Services.RequaredInventoryManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;
using System;

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/items")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class RequaredInventoryController : ApiController
    {
        private readonly IRequaredInventoryService _requaredInventoryService;

        public RequaredInventoryController(IRequaredInventoryService requaredInventoryService)
        {
            _requaredInventoryService = requaredInventoryService ?? throw new ArgumentException(nameof(requaredInventoryService));
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of requaredInventory.", Type = typeof(UpdateRequiredInventoryRequest))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetRequaredInventorys()
        {
            var requaredInventorys = await _requaredInventoryService.GetRequaredInventorysAsync();
            return Ok(requaredInventorys);
        }


        [HttpGet]
        [Route("{id:int:min(1)}/office")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of inventorys")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetInventoryAsync(int id)
        {
            var dbRequiredInventorys = await _requaredInventoryService.GetOfficeRequaredInventorysAsync(id);

            return Ok(dbRequiredInventorys);
        }

        [HttpGet]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a requaredInventory.")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetRequaredInventory([FromUri] int id)
        {
            var requaredInventory = await _requaredInventoryService.GetRequaredInventoryAsync(id);
            return Ok(requaredInventory);
        }

        [HttpGet]
        [Route("{id:int:min(1)}/descendant")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a requaredInventory.")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetRequaredInventoryDescendant([FromUri] int id)
        {
            var requaredInventory = await _requaredInventoryService.GetRequiredInventoryItemDescendantAsync(id);
            return Ok(requaredInventory);
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new requaredInventory.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddRequaredInventory([FromBody] UpdateRequiredInventoryRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var requaredInventory = await _requaredInventoryService.CreateRequaredInventoryAsync(createRequest);
            var location = string.Format("/api/item/{0}", requaredInventory.Id);
            return Created<RequiredInventoryItem>(location, requaredInventory);
        }

        [HttpPost]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new requaredInventory.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddRequaredInventory([FromUri] int id, [FromBody] UpdateRequiredInventoryRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var requaredInventory = await _requaredInventoryService.CreateRequaredInventoryAsync(id,createRequest);
            var location = string.Format("/api/item/{0}", requaredInventory.Id);
            return Created<RequiredInventoryItem>(location, requaredInventory);
        }

        [HttpPut]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed requaredInventory.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateRequaredInventory([FromUri] int id, [FromBody] UpdateRequiredInventoryRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _requaredInventoryService.UpdateRequaredInventoryAsync(id, updateRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpDelete]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed requaredInventory.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteRequaredInventory([FromUri] int id)
        {
            await _requaredInventoryService.DeleteRequaredInventoryAsync(id);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
    }
}
