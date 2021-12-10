using Atos.DevSkills.Domain.InputModel;
using Atos.DevSkills.Domain.Model;
using Atos.DevSkills.Domain.ViewModel;

namespace Atos.DevSkills.Domain.Extension
{
    public static class DesenvolvedorExtension
    {        
        public static Desenvolvedor ToDesenvolvedor(this DesenvolvedorInputModel model, List<Skill> skills)
        {
            return new Desenvolvedor
            {
                NomeCompleto = model.NomeCompleto,
                Cpf = model.Cpf,
                Telefone = model.Telefone,
                Email = model.Email,
                DtNascimento = model.DtNascimento,                
                Skills = skills
            };
        }

        public static DesenvolvedorViewModel ToDesenvolvedorViewModel(this Desenvolvedor model)
        {
            return new DesenvolvedorViewModel
            {
                Id = model.Id,
                Nome = model.NomeCompleto,
                Cpf = model.Cpf,
                Telefone = model.Telefone,
                Email = model.Email,
                DtNascimento = model.DtNascimento,
                Skills = model.Skills
            };
        }
    }
}
