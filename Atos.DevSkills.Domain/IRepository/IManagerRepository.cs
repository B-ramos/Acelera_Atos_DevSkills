using Atos.DevSkills.Domain.Model;

namespace Atos.DevSkills.Domain.IRepository
{
    public interface IManagerRepository : IBaseRepository<Manager>
    {
        Task<Manager> LoginAsync(string email, string senha);
    }
}
