using Atos.DevSkills.Domain.Extension;
using Atos.DevSkills.Domain.InputModel;
using Atos.DevSkills.Domain.IRepository;
using Atos.DevSkills.Domain.IService;
using Atos.DevSkills.Service.Validators;

namespace Atos.DevSkills.Service.Service
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _managerRepository;

        public ManagerService(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        public async Task<string> LoginAsync(LoginInputModel model)
        {
            var manager = await _managerRepository.LoginAsync(model.Email, model.Senha.EncryptPassword());
            ManagerValidator.Validate(manager);

            var token = TokenService.GenerateToken(manager);
            return token;
        }
    }
}
