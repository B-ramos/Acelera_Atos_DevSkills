using Atos.DevSkills.Domain.Enum;
using Atos.DevSkills.Domain.IRepository;
using Atos.DevSkills.Domain.Model;
using Atos.DevSkills.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Atos.DevSkills.Infra.Data.Repository
{
    public class DesenvolvedorRepository : BaseRepository<Desenvolvedor>, IDesenvolvedorRepository
    {
        public DesenvolvedorRepository(DevSkillsContext context) : base(context) { }

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
            if (!string.IsNullOrEmpty(skill))
            {
                return await _context.Desenvolvedores
                    .Include(x => x.Skills)
                    .Where(x => x.Status == EStatus.Ativo)
                    .Where(x => x.Skills.Any(x => x.Habilidade.Contains(skill)))
                    .ToListAsync();
            }

            return await _context.Desenvolvedores
                .Include(x => x.Skills)
                .Where(x => x.Status == EStatus.Ativo)
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
