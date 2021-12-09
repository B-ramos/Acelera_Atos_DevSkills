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

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] DesenvolvedorInputModel model)
        {
            var response = await _desenvolvedorService.CadastrarDesenvolvedorAsync(model);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id) 
        {
            var desenvolvedor = await _desenvolvedorService.FindById(id);
            return Ok(desenvolvedor);
        }
    }
}
