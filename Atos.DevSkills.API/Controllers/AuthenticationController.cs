using Atos.DevSkills.Domain.InputModel;
using Atos.DevSkills.Domain.IService;
using Atos.DevSkills.Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Atos.DevSkills.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public AuthenticationController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        /// <summary>
        /// Retorna o token de autenticação do usuário.
        /// </summary>
        /// <remarks> 
        /// </remarks>
        /// <response code="200">Sucesso ao retornar token de autenticação.</response>
        /// <response code="400">Contém erros de validação.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [ProducesResponseType(typeof(ResponseViewModel<string>), 200)]
        [ProducesResponseType(typeof(ErrorsViewModel), 400)]
        [ProducesResponseType(500)]
        [HttpPost("login")]
        public async Task<IActionResult> PostAsync([FromBody] LoginInputModel model)
        {
            var token = await _managerService.LoginAsync(model);
            return Ok(new ResponseViewModel<string>(token));
        }
    }
}
