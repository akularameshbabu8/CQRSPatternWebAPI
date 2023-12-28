using Application.Abstractions;
using Application.FilmCharacters.QueryHandlers;
using Infrastructure.FilmCharactersHttpClientFactory;
using Infrastructure.HttpClientExtension;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

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

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                                        .AllowAnyMethod()
                                        .AllowAnyHeader());
            });

            services.AddResponseCompression();
            services.AddResponseCaching();

            
            services.ConfigureHttpClientService(Configuration);

            services.AddTransient<IRepository, Repository>();
            services.AddTransient<IFilmCharactersHttpClientFactory, FilmCharactersHttpClientFactory>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "People", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            services.AddMvc()
               .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver())
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
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
