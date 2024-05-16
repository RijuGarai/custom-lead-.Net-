using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repos.Contracts;

namespace CustomLead.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantFieldController : ControllerBase
    {
        private readonly ITenantFieldRepository _tenantFieldRepository;

        public TenantFieldController(ITenantFieldRepository tenantFieldRepository)
        {
            _tenantFieldRepository = tenantFieldRepository;
        }

        // GET: api/TenantField
        [HttpGet]
        public async Task<IEnumerable<TenantField>> Get()
        {
            return await _tenantFieldRepository.GetAllAsync();
        }

        // GET api/TenantField/5
        [HttpGet("{id}")]
        public async Task<TenantField?> Get(Guid id)
        {
            return await _tenantFieldRepository.GetByIdAsync(id);
        }

        // POST api/TenantField
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TenantField value)
        {
            await _tenantFieldRepository.CreateAsync(value);
            return Ok();
        }

        // PUT api/TenantField/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] TenantField value)
        {
            var existingTenantField = await _tenantFieldRepository.GetByIdAsync(id);
            if (existingTenantField != null)
            {
                value.Id = existingTenantField.Id;
                await _tenantFieldRepository.UpdateAsync(value);
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/TenantField/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _tenantFieldRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
