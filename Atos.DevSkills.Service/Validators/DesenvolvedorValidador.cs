using Atos.DevSkills.Domain.InputModel;
using Atos.DevSkills.Domain.IRepository;
using Atos.DevSkills.Domain.Model;

namespace Atos.DevSkills.Service.Validators
{
    public static class DesenvolvedorValidador
    {
        public static void Validate(Desenvolvedor desenvolvedor) 
        {
            if (desenvolvedor == null) 
            {
                throw new Exception("O desenvolvedor não existe");
            }
        }

        public async static Task<Desenvolvedor> Validate(DesenvolvedorUpdateInputModel model, Desenvolvedor desenvolvedor, IDesenvolvedorRepository _desenvolvedorRepository) 
        {
            if (!string.IsNullOrEmpty(model.NomeCompleto))
                desenvolvedor.NomeCompleto = model.NomeCompleto;

            if (!string.IsNullOrEmpty(model.Telefone))
                desenvolvedor.Telefone = model.Telefone;

            if (!string.IsNullOrEmpty(model.Email) && model.Email != desenvolvedor.Email)
            {
                var dev = await _desenvolvedorRepository.ExistByEmail(model.Email);
                if (dev is false)
                    desenvolvedor.Email = model.Email;
                else
                    throw new Exception("E-mail já existente.");
            }

            return desenvolvedor;
        }
    }
}
