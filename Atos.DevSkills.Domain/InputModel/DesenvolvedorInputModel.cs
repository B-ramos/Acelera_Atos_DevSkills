using System.ComponentModel.DataAnnotations;

namespace Atos.DevSkills.Domain.InputModel
{
    public class DesenvolvedorInputModel
    {
        [Required(ErrorMessage = "O campo NomeCompleto é obrigatório")]
        public string NomeCompleto { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Cpf é obrigatório")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo DtNascimento é obrigatório")]
        public DateTime DtNascimento { get; set; }

        public List<string> Skills { get; set; }
    }
}