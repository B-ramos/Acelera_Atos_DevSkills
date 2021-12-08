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
    }
}
