using Atos.DevSkills.Domain.IService;
using Atos.DevSkills.Domain.Model;
using Atos.DevSkills.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Atos.DevSkills.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        /// <summary>
        /// Retorna uma lista de skills.
        /// </summary>
        /// <remarks> 
        /// </remarks>
        /// <response code="200">Sucesso ao retornar os a lista de skills.</response>
        /// <response code="400">Contém erros de validação.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [ProducesResponseType(typeof(List<Skill>), 200)]
        [ProducesResponseType(typeof(ErrorsViewModel), 400)]
        [ProducesResponseType(500)]
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var skillList = await _skillService.ListAll();
            return Ok(skillList);
        }
    }
}
