using ProvaCodeblox.Dominio.Servicos;
using ProvaCodeblox.Servicos.Servicos;

namespace ProvaCodeblox.UI.InjecaoDeDependencia
{
    public static class RegistroDeServicos
    {
        public static IServiceCollection RegistrarServicos(this IServiceCollection services)
        {
            services.AddScoped<ICadastroDeProdutoServico, CadastroDeProdutoServico>();
            return services;
        }
    }
}
