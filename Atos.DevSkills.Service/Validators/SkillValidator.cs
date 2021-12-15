using Atos.DevSkills.Domain.IRepository;
using Atos.DevSkills.Domain.Model;

namespace Atos.DevSkills.Service.Validators
{
    public static class SkillValidator
    {
        public static async Task<List<Skill>> CreateSkillNotExists(List<string> skills, ISkillRepository _skillRepository)
        {
            var listSkills = new List<Skill>();

            foreach (var skill in skills)
            {
                var skillExists = await _skillRepository.FindByNameAsync(skill);

                if (skillExists is null)
                {
                    var newSkill = new Skill { Habilidade = skill };
                    listSkills.Add(await _skillRepository.Add(newSkill));
                }
                else
                {
                    listSkills.Add(skillExists);
                }
            }
            return listSkills;
        }
    }
}
