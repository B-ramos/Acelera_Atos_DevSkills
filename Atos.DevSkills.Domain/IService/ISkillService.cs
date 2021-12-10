using Atos.DevSkills.Domain.Model;

namespace Atos.DevSkills.Domain.IService
{
    public interface ISkillService
    {
        Task<List<Skill>> ListAll();
    }
}
