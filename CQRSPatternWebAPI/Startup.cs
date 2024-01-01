using Application.QueryHandlers;
using Application.Services;
using Infrastructure.Middleware;
using MediatR;
using Microsoft.OpenApi.Models;

namespace CQRSPatternWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            BuildMediator(services);
            
            services.ConfigureHttpClientService(Configuration);

            services.AddTransient<IHttpClientService, HttpClientService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FilmCharacters", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
            services.AddResponseCompression();
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment() || env.IsStaging())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FilmCharacters");
                        c.RoutePrefix = "swagger";
                    });
                }
                else
                {
                    app.UseHsts();
                }

                app.UseCors("CorsPolicy");
                app.ConfigureCustomExceptionMiddleware();
                app.UseRouting();
                app.UseResponseCompression();
                app.UseResponseCaching();
                app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            }

            private static IMediator BuildMediator(IServiceCollection services)
            {
                services.AddScoped<ServiceFactory>(p => p.GetService);
                services.AddMediatR(typeof(GetCharacterByIdQueryHandler));
                services.AddMediatR(typeof(GetFilmByIdQueryHandler));
                var provider = services.BuildServiceProvider();

                return provider.GetRequiredService<IMediator>();
            }     
    }
}