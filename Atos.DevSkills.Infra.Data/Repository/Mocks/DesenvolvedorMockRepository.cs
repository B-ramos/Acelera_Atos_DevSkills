using Atos.DevSkills.Domain.IRepository;
using Atos.DevSkills.Domain.Model;

namespace Atos.DevSkills.Infra.Data.Repository.Mocks
{
    public class DesenvolvedorMockRepository : IDesenvolvedorRepository
    {
        public async Task<Desenvolvedor> Add(Desenvolvedor model)
        {
            return new Desenvolvedor
            {
                Id = 100,
                Cpf = model.Cpf,
                NomeCompleto = model.NomeCompleto,
                Email = model.Email,
                Telefone = model.Telefone,                
            };
        }

        public Task Delete(Desenvolvedor model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistByEmail(string email)
        {
            return false;
        }

        public Task<Desenvolvedor> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Desenvolvedor?> FindByIdWithSkills(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Desenvolvedor>> ListAllActive()
        {
            throw new NotImplementedException();
        }

        public Task<List<Desenvolvedor>> ListAllBySkill(string skill)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Desenvolvedor>> ListAllWithSkill()
        {
            List<Desenvolvedor> list = new List<Desenvolvedor>();

            list.Add(new Desenvolvedor { Id = 1, Cpf = "111", NomeCompleto = "Mock1", Email = "m1@mail.com", Telefone = "1111-5555" });
            list.Add(new Desenvolvedor { Id = 2, Cpf = "222", NomeCompleto = "Mock2", Email = "m2@mail.com", Telefone = "2222-5555" });
            list.Add(new Desenvolvedor { Id = 3, Cpf = "333", NomeCompleto = "Mock3", Email = "m3@mail.com", Telefone = "3333-5555" });

            return list;
        }

        public Task<Desenvolvedor> Update(Desenvolvedor model)
        {
            throw new NotImplementedException();
        }
    }
}
