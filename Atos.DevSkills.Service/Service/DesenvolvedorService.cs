using Atos.DevSkills.Domain.IRepository;
using Atos.DevSkills.Domain.IService;

namespace Atos.DevSkills.Service.Service
{
    public class DesenvolvedorService : IDesenvolvedorService
    {
        private readonly IDesenvolvedorRepository _desenvolvedorRepository;

        public DesenvolvedorService(IDesenvolvedorRepository desenvolvedorRepository)
        {
           _desenvolvedorRepository = desenvolvedorRepository;
        }
    }
}
