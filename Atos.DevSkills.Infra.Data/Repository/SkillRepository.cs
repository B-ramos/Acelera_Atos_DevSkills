using Atos.DevSkills.Domain.IRepository;
using Atos.DevSkills.Domain.Model;
using Atos.DevSkills.Infra.Data.Context;

namespace Atos.DevSkills.Infra.Data.Repository
{
    public class SkillRepository : BaseRepository<Skill>, ISkillRepository
    {
        public SkillRepository(DevSkillsContext context) : base(context)
        {
        }
    }
}
