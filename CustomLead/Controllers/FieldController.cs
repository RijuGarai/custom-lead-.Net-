using CustomLead.DTOs;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomLead.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldController : ControllerBase
    {
        private readonly IFieldRepository _fieldRepository;

        public FieldController(IFieldRepository fieldRepository) { _fieldRepository = fieldRepository; }
        // GET: api/<FieldController>
        [HttpGet]
        public async Task<IEnumerable<Field>> Get()
        {
            return await _fieldRepository.GetAllAsync();
        }

        // GET api/<FieldController>/5
        [HttpGet("{id}")]
        public async Task<Field?> Get(Guid id)
        {
            return await _fieldRepository.GetByIdAsync(id);
        }

        // POST api/<FieldController>
        [HttpPost]
        public async void Post([FromBody] FieldDto dto)
        {
            var field = new Field(dto.Name, dto.Type, dto.MinLength, dto.MaxLength, dto.IsNullable, dto.Description);
            await _fieldRepository.CreateAsync(field);
        }

        // PUT api/<FieldController>/5
        [HttpPut("{id}")]
        public async void Put(Guid id, [FromBody] FieldUpdateDto dto)
        {
            var existingField = await _fieldRepository.GetByIdAsync(dto.Id);
            if (existingField != null)
            {
                var field = new Field(dto.Name, dto.Type, dto.MinLength, dto.MaxLength, dto.IsNullable, dto.Description)
                {
                    Id = dto.Id
                };
                await _fieldRepository.UpdateAsync(field);
            }
        }

        // DELETE api/<FieldController>/5
        [HttpDelete("{id}")]
        public async void Delete(Guid id)
        {
            await _fieldRepository.DeleteAsync(id);
        }
    }
}
