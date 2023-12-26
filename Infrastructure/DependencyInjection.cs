using Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            
            //services.AddTransient<IRepository<BaseEntity>, Repository<BaseEntity>> ();
            services.AddTransient<IRepository<Film>, Repository<Film>>();
            services.AddTransient<IRepository<Person>, Repository<Person>>();
            services.AddTransient<IDataService, DefaultDataService>();           
            services.AddTransient<IWebHelper, WebHelper>();
            return services;


        }
    }
}
