using Microsoft.Extensions.DependencyInjection;
using SalesWebMvc.Services;

namespace SalesWebMvc
{
    public static class ServiceConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<SellerService>(); // Registrar SellerService como Scoped

            // Outros serviços podem ser registrados aqui, se necessário
        }
    }
}
