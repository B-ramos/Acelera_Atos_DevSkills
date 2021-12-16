using Atos.DevSkills.Domain.Enum;

namespace Atos.DevSkills.Domain.Model
{
    public class Desenvolvedor : ModelBase
    {
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public DateTime DtNascimento { get; set; }

        public virtual List<Skill> Skills { get; set; } = new();
    }
}
