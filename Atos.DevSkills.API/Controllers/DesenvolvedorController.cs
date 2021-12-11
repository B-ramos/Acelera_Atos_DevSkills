using Atos.DevSkills.Domain.InputModel;
using Atos.DevSkills.Domain.IService;
using Microsoft.AspNetCore.Mvc;

namespace Atos.DevSkills.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesenvolvedorController : ControllerBase
    {
        private readonly IDesenvolvedorService _desenvolvedorService;

        public DesenvolvedorController(IDesenvolvedorService desenvolvedorService)
        {
            _desenvolvedorService = desenvolvedorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var desenvolvedorList = await _desenvolvedorService.ListAll();
            return Ok(desenvolvedorList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var desenvolvedor = await _desenvolvedorService.FindById(id);
            return Ok(desenvolvedor);
        }

        [HttpGet("skill")]
        public async Task<IActionResult> GetBySkillAsync([FromQuery] string? skill)
        {
            var desenvolvedorList = await _desenvolvedorService.ListAllBySkill(skill);
            return Ok(desenvolvedorList);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] DesenvolvedorInputModel model)
        {
            var response = await _desenvolvedorService.AddAsync(model);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] DesenvolvedorUpdateInputModel model)
        {
            var desenvolvedor = await _desenvolvedorService.UpdateById(id, model);
            return Ok(desenvolvedor);
        }        

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _desenvolvedorService.Delete(id);
            return NoContent();
        }
    }
}
