using BeamlineX.Repositories.Abstraction;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeamlineX.Repositories
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddDbContextPool<BeamlineXDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetValue<string>("DbContextConnection"), b => b.MigrationsAssembly(typeof(BeamlineXDbContext).Assembly.FullName).MigrationsHistoryTable("EFMigrationHistory"));
                options.ConfigureWarnings(b => b.Ignore(CoreEventId.RowLimitingOperationWithoutOrderByWarning));
                options.EnableSensitiveDataLogging(true);
            });

            services.Scan(s => s
                .FromAssemblyOf<Repository>()
                .AddClasses(c => c.AssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .WithTransientLifetime());
        }

        public static void MigrateDb(this IServiceProvider serviceProvider)
        {
            BeamlineXDbContext db = serviceProvider.GetRequiredService<BeamlineXDbContext>();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // db.Database.EnsureDeleted();
            db.Database.Migrate();
            db.Database.EnsureCreated();
        }

    }
}
