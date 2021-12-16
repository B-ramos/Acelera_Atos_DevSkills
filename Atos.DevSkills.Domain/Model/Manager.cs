using Atos.DevSkills.Domain.Enum;

namespace Atos.DevSkills.Domain.Model
{
    public class Manager : ModelBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public ERole Role { get; set; }
    }
}