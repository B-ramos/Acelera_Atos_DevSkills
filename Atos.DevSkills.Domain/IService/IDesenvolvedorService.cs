using Atos.DevSkills.Domain.InputModel;
using Atos.DevSkills.Domain.ViewModel;

namespace Atos.DevSkills.Domain.IService
{
    public interface IDesenvolvedorService
    {
        Task<DefaultViewModel<DesenvolvedorViewModel>> AddAsync(DesenvolvedorInputModel model);
        Task<DefaultViewModel<DesenvolvedorViewModel>> FindById(int id);
        Task<DefaultViewModel<List<DesenvolvedorViewModel>>> ListAll();
        Task<DefaultViewModel<string>> Delete(int id);
        Task<DefaultViewModel<List<DesenvolvedorViewModel>>> ListAllBySkill(string? skill);
        Task<DefaultViewModel<DesenvolvedorViewModel>> UpdateById(int id, DesenvolvedorUpdateInputModel model);        
    }
}
