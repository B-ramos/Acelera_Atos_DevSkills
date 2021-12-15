using Atos.DevSkills.Domain.Extension;
using Atos.DevSkills.Domain.InputModel;
using Atos.DevSkills.Domain.IRepository;
using Atos.DevSkills.Domain.IService;
using Atos.DevSkills.Domain.ViewModel;
using Atos.DevSkills.Service.Validators;

namespace Atos.DevSkills.Service.Service
{
    public class DesenvolvedorService : IDesenvolvedorService
    {
        private readonly IDesenvolvedorRepository _desenvolvedorRepository;
        private readonly ISkillRepository _skillRepository;

        //private readonly DesenvolvedorValidador _validator;

        public DesenvolvedorService(IDesenvolvedorRepository desenvolvedorRepository, ISkillRepository skillRepository)
        {
            _desenvolvedorRepository = desenvolvedorRepository;
            _skillRepository = skillRepository;
        }

        public async Task<List<DesenvolvedorViewModel>> ListAll()
        {
            var listaDevs = new List<DesenvolvedorViewModel>();

            var desenvolvedorList = await _desenvolvedorRepository.ListAllWithSkill();

            foreach (var dev in desenvolvedorList)
            {
                listaDevs.Add(dev.ToDesenvolvedorViewModel());
            }
            return listaDevs;
        }

        public async Task<List<DesenvolvedorViewModel>> ListAllBySkill(string skill)
        {
            var desenvolvedorList = await _desenvolvedorRepository.ListAllBySkill(skill);   
            
            return desenvolvedorList.Select(x => x.ToDesenvolvedorViewModel()).ToList();
        }

        public async Task<DesenvolvedorViewModel> FindById(int id)
        {
            var desenvolvedor = await _desenvolvedorRepository.FindByIdWithSkills(id);
            return desenvolvedor.ToDesenvolvedorViewModel();
        }

        public async Task<DesenvolvedorViewModel> AddAsync(DesenvolvedorInputModel model)
        {
            if (await _desenvolvedorRepository.ExistByEmail(model.Email))
                throw new Exception($"E-mail já existente.");

            var skills = await SkillValidator.CreateSkillNotExists(model.Skills, _skillRepository);

            var desenvolvedor = await _desenvolvedorRepository.Add(model.ToDesenvolvedor(skills));

            return desenvolvedor.ToDesenvolvedorViewModel();

        }             

        public async Task<DesenvolvedorViewModel> UpdateById(int id, DesenvolvedorUpdateInputModel model)
        {
            var desenvolvedor = await _desenvolvedorRepository.FindById(id);

            DesenvolvedorValidador.Validate(desenvolvedor);

            var dev = await DesenvolvedorValidador.Validate(model, desenvolvedor, _desenvolvedorRepository);

            var desenvolvedorUpdate = await _desenvolvedorRepository.Update(dev);

            return desenvolvedorUpdate.ToDesenvolvedorViewModel();
        }

        public async Task Delete(int id)
        {
            var buscaDesenvolvedor = await _desenvolvedorRepository.FindById(id);

            if (buscaDesenvolvedor != null)
                await _desenvolvedorRepository.Delete(buscaDesenvolvedor);
        }
    }
}
