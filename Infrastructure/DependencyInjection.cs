using Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            
            services.AddScoped<IRepository<BaseEntity>, Repository<BaseEntity>> ();
            
            return services;


        }
    }
}
