using NSE.Catalog.API.Data;
using NSE.Catalog.API.Data.Repositories;
using NSE.Catalog.API.Models;

namespace NSE.Catalog.API.Configuration
{
    public static class DIConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<CatalogContext>();            
        }
    }
}
