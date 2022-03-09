using BeamlineX.Repositories.EntityConfigurations;

using Microsoft.EntityFrameworkCore;

namespace BeamlineX.Repositories
{
    public class BeamlineXDbContext : DbContext
    {
        public BeamlineXDbContext(DbContextOptions<BeamlineXDbContext> options)
            : base(options)
        {
            if (!Database.IsRelational())
            {
                return;
            }

            Database.SetCommandTimeout(TimeSpan.FromMinutes(15));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            _ = modelBuilder?.ApplyConfigurationsFromAssembly(typeof(IEntityConfiguration).Assembly) ?? throw new ArgumentNullException(nameof(modelBuilder), $"Argument darf nicht NULL sein!");
        }
    }
}
