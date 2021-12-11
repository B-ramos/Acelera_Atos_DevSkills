using Atos.DevSkills.Domain.Enum;
using Atos.DevSkills.Domain.IRepository;
using Atos.DevSkills.Domain.Model;
using Atos.DevSkills.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Atos.DevSkills.Infra.Data.Repository
{
    public class DesenvolvedorRepository : BaseRepository<Desenvolvedor>, IDesenvolvedorRepository
    {
        public DesenvolvedorRepository(DevSkillsContext context) : base(context)
        {
        }

        public async Task<bool> ExistByEmail(string email)
        {
            return await _context.Desenvolvedores
                        .AnyAsync(x => x.Email == email);
        }        

        public async Task<List<Desenvolvedor>> ListAllWithSkill()
        {
            return await _context.Desenvolvedores
                        .Where(x => x.Status == EStatus.Ativo)
                        .Include(x => x.Skills)
                        .ToListAsync();
        }

        public async Task<List<Desenvolvedor>> ListAllBySkill(string skill)
        {
            var query = from d in _context.Desenvolvedores
                        join s in _context.Skills on d.Id equals s.Id
                        where  s.Habilidade.Contains(skill)
                        select d;

            return await query
                .Include(x => x.Skills)
                .ToListAsync();

        }

        public async Task<Desenvolvedor?> FindByIdWithSkills(int id)
        {
            return await _context.Desenvolvedores
                .Include(x => x.Skills)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
