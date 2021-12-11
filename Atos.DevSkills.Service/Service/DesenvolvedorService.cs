using Atos.DevSkills.Domain.Extension;
using Atos.DevSkills.Domain.InputModel;
using Atos.DevSkills.Domain.IRepository;
using Atos.DevSkills.Domain.IService;
using Atos.DevSkills.Domain.Model;
using Atos.DevSkills.Domain.ViewModel;

namespace Atos.DevSkills.Service.Service
{
    public class DesenvolvedorService : IDesenvolvedorService
    {
        private readonly IDesenvolvedorRepository _desenvolvedorRepository;

        public DesenvolvedorService(IDesenvolvedorRepository desenvolvedorRepository)
        {
            _desenvolvedorRepository = desenvolvedorRepository;
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

        public async Task<List<DesenvolvedorViewModel>> ListAllByskill(string skill)
        {
            var listaDevs = new List<DesenvolvedorViewModel>();

            var desenvolvedorList = await _desenvolvedorRepository.ListAllBySkill(skill);
            foreach (var dev in desenvolvedorList)
            {
                listaDevs.Add(dev.ToDesenvolvedorViewModel());
            }
            return listaDevs;
        }

        public async Task<DesenvolvedorViewModel> FindById(int id)
        {
            var desenvolvedor = await _desenvolvedorRepository.FindByIdWithSkills(id);
            return desenvolvedor.ToDesenvolvedorViewModel();
        }

        public async Task<DesenvolvedorViewModel> AddAsync(DesenvolvedorInputModel model)
        {
            var listaSkills = new List<Skill>();

            foreach (var skill in model.Skills)
                listaSkills.Add(new Skill { Habilidade = skill });

            var desenvolvedor = await _desenvolvedorRepository.Add(model.ToDesenvolvedor(listaSkills));

            return desenvolvedor.ToDesenvolvedorViewModel();
        }             

        public async Task<DesenvolvedorViewModel> UpdateById(int id, DesenvolvedorUpdateInputModel model)
        {
            var desenvolvedor = await _desenvolvedorRepository.FindById(id);
            if (desenvolvedor == null)
            {
                throw new Exception("Desenvolvedor não encontrado.");
            }

            var dev = await ToDesenvolvedorUpdate(model, desenvolvedor);

            var desenvolvedorUpdate = await _desenvolvedorRepository.Update(dev);

            return desenvolvedorUpdate.ToDesenvolvedorViewModel();
        }

        public async Task Delete(int id)
        {
            var buscaDesenvolvedor = await _desenvolvedorRepository.FindById(id);

            if (buscaDesenvolvedor != null)            
                await _desenvolvedorRepository.Delete(buscaDesenvolvedor);
        }

        private async Task<Desenvolvedor> ToDesenvolvedorUpdate(DesenvolvedorUpdateInputModel model, Desenvolvedor desenvolvedor)
        {
            if (!string.IsNullOrEmpty(model.NomeCompleto))
                desenvolvedor.NomeCompleto = model.NomeCompleto;

            if (!string.IsNullOrEmpty(model.Telefone))
                desenvolvedor.Telefone = model.Telefone;

            if (!string.IsNullOrEmpty(model.Email) && model.Email != desenvolvedor.Email)
            {
                var dev = await _desenvolvedorRepository.ExistByEmail(model.Email);
                if (dev is false)
                    desenvolvedor.Email = model.Email;
                else
                    throw new Exception("E-mail já existente.");
            }

            return desenvolvedor;
        }
    }
}
