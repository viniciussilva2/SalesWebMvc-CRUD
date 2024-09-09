using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<SellerService>();
            // Outros serviços podem ser adicionados aqui
        }

        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        //Método para trazer todos os funcionários, ou lista de funcionários.
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }



    }
}
