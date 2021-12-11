using Atos.DevSkills.Domain.InputModel;
using Atos.DevSkills.Domain.ViewModel;

namespace Atos.DevSkills.Domain.IService
{
    public interface IDesenvolvedorService
    {
        Task<DesenvolvedorViewModel> CadastrarDesenvolvedorAsync(DesenvolvedorInputModel model);
        Task<DesenvolvedorViewModel> FindById(long id);
        Task<List<DesenvolvedorViewModel>> ListAll();
        Task<List<DesenvolvedorViewModel>> ListAllByskill(string skill);
        Task<DesenvolvedorViewModel> UpdateById(int id, DesenvolvedorUpdateInputModel model);
    }
}
