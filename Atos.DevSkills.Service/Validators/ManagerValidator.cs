using Atos.DevSkills.Domain.Model;

namespace Atos.DevSkills.Service.Validators
{
    public static class ManagerValidator
    {
        public static void Validate(Manager manager)
        {
            if (manager == null)
            {
                throw new Exception("O gestor não existe");
            }
        }
    }
}
