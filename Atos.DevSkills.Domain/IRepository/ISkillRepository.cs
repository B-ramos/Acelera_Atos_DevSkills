using Atos.DevSkills.Domain.Model;

namespace Atos.DevSkills.Domain.IRepository
{
    public interface ISkillRepository : IBaseRepository<Skill>
    {
        Task<Skill> FindByNameAsync(string skill);
    }
}
