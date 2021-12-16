using Atos.DevSkills.Domain.InputModel;

namespace Atos.DevSkills.Domain.IService
{
    public interface IManagerService
    {
        Task<string> LoginAsync(LoginInputModel model);
    }
}
