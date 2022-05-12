using NSE.Customers.API.Data;

namespace NSE.Customers.API.Configuration
{
    public static class DIConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {            
            services.AddScoped<CustomerContext>();
        }
    }
}
