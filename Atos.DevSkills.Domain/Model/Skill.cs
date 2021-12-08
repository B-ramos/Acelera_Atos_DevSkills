namespace Atos.DevSkills.Domain.Model
{
    public class Skill : ModelBase
    {
        public string Habilidade { get; set; }       

        public virtual List<Desenvolvedor> Desenvolvedores { get; set; }
    }
}
