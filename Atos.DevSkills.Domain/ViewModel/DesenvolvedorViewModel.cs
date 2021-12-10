using Atos.DevSkills.Domain.Model;

namespace Atos.DevSkills.Domain.ViewModel
{
    public class DesenvolvedorViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public DateTime DtNascimento { get; set; }

        public virtual List<Skill> Skills { get; set; } = new();
    }
}
