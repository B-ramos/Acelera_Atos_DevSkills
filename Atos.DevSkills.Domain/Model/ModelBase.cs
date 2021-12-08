using Atos.DevSkills.Domain.Enum;

namespace Atos.DevSkills.Domain.Model
{
    public abstract class ModelBase
    {
        public int Id { get; set; }
        public DateTime DtCriacao { get; set; }
        public DateTime? DtAtualizacao { get; set; }
        public EStatus Status { get; set; }

        public ModelBase()
        {
            DtCriacao = DateTime.Now;
            DtAtualizacao = null;
        }
    }
}