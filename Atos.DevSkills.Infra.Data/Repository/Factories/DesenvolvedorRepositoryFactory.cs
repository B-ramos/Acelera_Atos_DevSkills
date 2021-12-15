using Atos.DevSkills.Domain.Config;
using Atos.DevSkills.Domain.IRepository;
using Atos.DevSkills.Infra.Data.Repository.Mocks;

namespace Atos.DevSkills.Infra.Data.Repository.Factories
{
    public class DesenvolvedorRepositoryFactory
    {
        private readonly IDesenvolvedorRepository _desenvolvedorRepository;

        public DesenvolvedorRepositoryFactory(IDesenvolvedorRepository desenvolvedorRepository)
        {
            _desenvolvedorRepository = desenvolvedorRepository;
        }

        public IDesenvolvedorRepository CreateFactory()
        {
            var flag = Config.Flag;

            if (flag)
                return new DesenvolvedorMockRepository();
            else
                return _desenvolvedorRepository;


        }
    }
}
