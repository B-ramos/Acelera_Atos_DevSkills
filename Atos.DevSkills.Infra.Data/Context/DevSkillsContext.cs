using Atos.DevSkills.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Atos.DevSkills.Infra.Data.Context
{
    public class DevSkillsContext : DbContext
    {
        public DevSkillsContext(DbContextOptions<DevSkillsContext> options) : base(options)  { }

        public DbSet<Desenvolvedor> Desenvolvedores { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
