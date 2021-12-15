using Atos.DevSkills.Domain.Config;
using Atos.DevSkills.Domain.IRepository;
using Atos.DevSkills.Infra.Data.Repository.Mocks;

namespace Atos.DevSkills.Infra.Data.Repository.Factories
{
    public class SkillRepositoryFactory
    {
        private readonly ISkillRepository _skillRepository;

        public SkillRepositoryFactory(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public ISkillRepository CreateFactory()
        {
            var flag = Config.Flag;

            if (flag)
                return new SkillMockRepository();
            else
                return _skillRepository;


        }
    }
}
