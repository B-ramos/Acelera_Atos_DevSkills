using Atos.DevSkills.Domain.Model;

namespace Atos.DevSkills.Domain.IRepository
{
    public interface IDesenvolvedorRepository : IBaseRepository<Desenvolvedor>
    {
        Task<List<Desenvolvedor>> ListAllWithSkill();
    }
}
