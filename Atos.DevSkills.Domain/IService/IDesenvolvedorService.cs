using Atos.DevSkills.Domain.InputModel;
using Atos.DevSkills.Domain.ViewModel;

namespace Atos.DevSkills.Domain.IService
{
    public interface IDesenvolvedorService
    {
        Task<ResponseViewModel<DesenvolvedorViewModel>> AddAsync(DesenvolvedorInputModel model);
        Task<ResponseViewModel<DesenvolvedorViewModel>> FindById(int id);
        Task<ResponseViewModel<List<DesenvolvedorViewModel>>> ListAll();
        Task<ResponseViewModel<string>> Delete(int id);
        Task<ResponseViewModel<List<DesenvolvedorViewModel>>> ListAllBySkill(string? skill);
        Task<ResponseViewModel<DesenvolvedorViewModel>> UpdateById(int id, DesenvolvedorUpdateInputModel model);        
    }
}
