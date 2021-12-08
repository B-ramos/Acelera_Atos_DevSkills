using Atos.DevSkills.Domain.IService;
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
    }
}
