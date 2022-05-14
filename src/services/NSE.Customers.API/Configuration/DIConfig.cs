using FluentValidation.Results;
using MediatR;
using NSE.Core.Mediator;
using NSE.Customers.API.Application.Commands;
using NSE.Customers.API.Data;
using NSE.Customers.API.Data.Repositories;
using NSE.Customers.API.Models.Repositories;

namespace NSE.Customers.API.Configuration
{
    public static class DIConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // DataContext
            services.AddScoped<CustomerContext>();

            // Handlers
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<NewCustomerCommand, ValidationResult>, CustomerCommandHandler>();
            
            // Repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
