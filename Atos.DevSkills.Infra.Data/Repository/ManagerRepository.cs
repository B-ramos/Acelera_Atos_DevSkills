using Atos.DevSkills.Domain.IRepository;
using Atos.DevSkills.Domain.Model;
using Atos.DevSkills.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Atos.DevSkills.Infra.Data.Repository
{
    public class ManagerRepository : BaseRepository<Manager>, IManagerRepository
    {
        public ManagerRepository(DevSkillsContext context) : base(context) { }

        public async Task<Manager> LoginAsync(string email, string senha)
        {
            return await _context.Managers
                .FirstOrDefaultAsync(x => x.Email == email && x.Senha == senha);
        }
    }
}
