using Atos.DevSkills.Domain.Model;

namespace Atos.DevSkills.Domain.IRepository
{
    public interface IBaseRepository<T> where T : ModelBase
    {
        Task<List<T>> ListAllActive();
        Task<T> FindById(int id);
        Task<T> Add(T model);
        Task<T> Update(T model);
        Task Delete(T model);
    }
}
