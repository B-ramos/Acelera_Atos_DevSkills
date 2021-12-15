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
            var response = await _desenvolvedorService.ListAll();
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await _desenvolvedorService.FindById(id);
            return Ok(response);
        }

        [HttpGet("skill")]
        public async Task<IActionResult> GetBySkillAsync([FromQuery] string? skill)
        {
            var response = await _desenvolvedorService.ListAllBySkill(skill);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] DesenvolvedorInputModel model)
        {
            var response = await _desenvolvedorService.AddAsync(model);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] DesenvolvedorUpdateInputModel model)
        {
            var response = await _desenvolvedorService.UpdateById(id, model);
            return Ok(response);
        }        

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _desenvolvedorService.Delete(id);
            return Ok(response);
        }
    }
}
