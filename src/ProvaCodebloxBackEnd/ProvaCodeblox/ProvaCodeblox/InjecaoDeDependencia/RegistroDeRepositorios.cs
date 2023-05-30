using Microsoft.EntityFrameworkCore;
using ProvaCodeblox.Dominio.Repositoiros;
using ProvaCodeblox.Repositorio.Contexto;
using ProvaCodeblox.Repositorio.Repositorios;

namespace ProvaCodeblox.UI.InjecaoDeDependencia
{
    public static class RegistroDeRepositorios
    {
        public static IServiceCollection RegistrarRepositorios(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("SqliteConnectionString"))
            );
            return services;
        }

        public static WebApplication CriarBancoDeDados(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Database.Migrate();
            }
            return app;
        }
    }
}
