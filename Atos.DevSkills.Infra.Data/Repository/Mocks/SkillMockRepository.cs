using Atos.DevSkills.Domain.IRepository;
using Atos.DevSkills.Domain.Model;

namespace Atos.DevSkills.Infra.Data.Repository.Mocks
{
    public class SkillMockRepository : ISkillRepository
    {
        public Task<Skill> Add(Skill model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Skill model)
        {
            throw new NotImplementedException();
        }

        public Task<Skill> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Skill> FindByNameAsync(string skill)
        {
            throw new NotImplementedException();
        }

        public Task<List<Skill>> ListAllActive()
        {
            throw new NotImplementedException();
        }

        public Task<Skill> Update(Skill model)
        {
            throw new NotImplementedException();
        }
    }
}
