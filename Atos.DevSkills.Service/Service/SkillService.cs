using Atos.DevSkills.Domain.IRepository;
using Atos.DevSkills.Domain.IService;

namespace Atos.DevSkills.Service.Service
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
    }
}
