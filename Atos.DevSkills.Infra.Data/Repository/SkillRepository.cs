using Atos.DevSkills.Domain.IRepository;
using Atos.DevSkills.Domain.Model;
using Atos.DevSkills.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Atos.DevSkills.Infra.Data.Repository
{
    public class SkillRepository : BaseRepository<Skill>, ISkillRepository
    {
        public SkillRepository(DevSkillsContext context) : base(context)
        {
        }

        public async Task<Skill> FindByNameAsync(string skill)
        {
            return await _context.Skills.FirstOrDefaultAsync(x => x.Habilidade == skill);
        }
    }
}
