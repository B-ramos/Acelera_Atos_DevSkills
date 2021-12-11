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

        public async Task<DesenvolvedorViewModel> CadastrarDesenvolvedorAsync(DesenvolvedorInputModel model)
        {
            //Cria uma lista de skills
            var listaSkills = new List<Skill>();

            //Percorre as skills que vem do usuário(front/input) e adiciona uma nova skill
            //Falta validações, fica de exemplo
            foreach (var skill in model.Skills)
                listaSkills.Add(new Skill { Habilidade = skill });

            //O repositorio espera um objeto do tipo Desenvolvedor
            //Como recebemos um desenvolvedorInputModel, precisamos convertelo
            //Criei um metodo de extensao de exemplo, só pra ver como funciona
            //Esse metodo fica na camada Domain dentro da pasta extension
            //Vamos usar o exemplo que João passou no projeto, só fiz para deixar de referencia beleza
            //Eu explico como funciona e depois apagamos esses comentarios
            //model.ToDesenvolvedor(listaSkills) converte um DesenvolvedorInputModel para Desenvolvedor
            var desenvolvedor = await _desenvolvedorRepository.Add(model.ToDesenvolvedor(listaSkills));

            //desenvolvedor.ToDesenvolvedorViewModel() converte um Desenvolvedor para DesenvolvedorViewModel
            return desenvolvedor.ToDesenvolvedorViewModel();
        }

        public async Task<DesenvolvedorViewModel> FindById(long id)
        {
            var desenvolvedor = await _desenvolvedorRepository.FindById(id);
            return desenvolvedor.ToDesenvolvedorViewModel();
        }

        public async Task<List<DesenvolvedorViewModel>> ListAll()
        {
            var listaDevs = new List<DesenvolvedorViewModel>();

            var desenvolvedorList = await _desenvolvedorRepository.ListAllActive();
            foreach (var dev in desenvolvedorList) 
            {
                listaDevs.Add(dev.ToDesenvolvedorViewModel());
            }
            return listaDevs;
        }
        public async Task<DesenvolvedorViewModel> Delete(long id)
        {
            var buscaDesenvolvedor = await _desenvolvedorRepository.FindById(id);

            if (buscaDesenvolvedor != null)
            {
                var desenvolvedor = await _desenvolvedorRepository.Delete(buscaDesenvolvedor);
                return desenvolvedor.ToDesenvolvedorViewModel();
            }
            return null;


        }
    }
}
