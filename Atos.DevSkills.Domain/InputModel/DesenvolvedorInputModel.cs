namespace Atos.DevSkills.Domain.InputModel
{
    public class DesenvolvedorInputModel
    {
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public DateTime DtNascimento { get; set; }

        public List<string> Skills { get; set; }
    }
}