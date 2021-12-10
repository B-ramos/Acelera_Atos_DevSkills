using Atos.DevSkills.Domain.IRepository;
using Atos.DevSkills.Domain.IService;
using Atos.DevSkills.Domain.Model;

namespace Atos.DevSkills.Service.Service
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<List<Skill>> ListAll()
        {
            var skillList = await _skillRepository.ListAllActive();
            return skillList;
        }
    }
}
