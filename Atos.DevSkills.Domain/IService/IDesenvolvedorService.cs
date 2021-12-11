using Atos.DevSkills.Domain.InputModel;
using Atos.DevSkills.Domain.Model;
using Atos.DevSkills.Domain.ViewModel;

namespace Atos.DevSkills.Domain.IService
{
    public interface IDesenvolvedorService
    {
        Task<DesenvolvedorViewModel> CadastrarDesenvolvedorAsync(DesenvolvedorInputModel model);
        Task<DesenvolvedorViewModel> FindById(long id);
        Task<List<DesenvolvedorViewModel>> ListAll();
        Task<DesenvolvedorViewModel> Delete(long id);
        Task<DesenvolvedorViewModel> UpdateById(int id, DesenvolvedorUpdateInputModel model);
    }
}
