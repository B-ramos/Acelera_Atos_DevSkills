using Atos.DevSkills.Domain.IRepository;
using Atos.DevSkills.Domain.Model;
using Atos.DevSkills.Infra.Data.Context;

namespace Atos.DevSkills.Infra.Data.Repository
{
    public class DesenvolvedorRepository : BaseRepository<Desenvolvedor>, IDesenvolvedorRepository
    {
        public DesenvolvedorRepository(DevSkillsContext context) : base(context)
        {
        }
    }
}
