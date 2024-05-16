using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repos;

namespace CustomLead.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantRepository _tenantRepository;

        public TenantController(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        // GET: api/<TenantController>
        [HttpGet]
        public async Task<IEnumerable<Tenant>> Get()
        {
            return await _tenantRepository.GetAllAsync();
        }

        // GET api/<TenantController>/5
        [HttpGet("{id}")]
        public async Task<Tenant?> Get(string id)
        {
            return await _tenantRepository.GetByIdAsync(id);
        }

        // POST api/<TenantController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tenant value)
        {
            await _tenantRepository.CreateAsync(value);
            return Ok();
        }

        // PUT api/<TenantController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Tenant value)
        {
            var existingTenant = await _tenantRepository.GetByIdAsync(id);
            if (existingTenant != null)
            {
                value.Id = existingTenant.Id;
                await _tenantRepository.UpdateAsync(value);
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/<TenantController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _tenantRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
