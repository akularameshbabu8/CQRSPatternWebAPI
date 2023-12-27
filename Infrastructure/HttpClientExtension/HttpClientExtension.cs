using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System.Net;


namespace Infrastructure.HttpClientExtension
{
    public static class HttpClientCollectionExtension
    {
        public static void ConfigureHttpClientService(this IServiceCollection services, IConfiguration configuration)
        {
            var retryPolicy = Policy
                .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode && r.StatusCode != HttpStatusCode.BadRequest)
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(3),
                    TimeSpan.FromSeconds(6)
                });

            services.AddHttpClient("people", c =>
            {
                c.BaseAddress = new Uri($"{configuration.GetSection("UrlApiPeople").Value}");

                c.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
                c.DefaultRequestHeaders.Add("Keep-Alive", "3600");
                c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory");

            }).AddPolicyHandler(retryPolicy);
            services.AddHttpClient("films", c =>
            {
                c.BaseAddress = new Uri($"{configuration.GetSection("UrlApiFilm").Value}");

                c.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
                c.DefaultRequestHeaders.Add("Keep-Alive", "3600");
                c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory");

            }).AddPolicyHandler(retryPolicy);
        }
    }
}
