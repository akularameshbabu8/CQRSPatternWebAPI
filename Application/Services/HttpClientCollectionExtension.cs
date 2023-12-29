using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System.Net;

namespace Application.Services
{
    public static class HttpClientCollectionExtension
    {
        public static void ConfigureHttpClientService(this IServiceCollection services, IConfiguration configuration)
        {
            var retryPolicy = CreateRetryPolicy();

            AddHttpClientWithRetryPolicy(services, "people", configuration.GetSection("UrlApiPeople").Value, retryPolicy);
            AddHttpClientWithRetryPolicy(services, "films", configuration.GetSection("UrlApiFilm").Value, retryPolicy);
        }

        private static IAsyncPolicy<HttpResponseMessage> CreateRetryPolicy()
        {
            return Policy
                .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode && r.StatusCode != HttpStatusCode.BadRequest)
                .WaitAndRetryAsync(new[]
                {
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(3),
            TimeSpan.FromSeconds(6)
                });
        }
        private static void AddHttpClientWithRetryPolicy(IServiceCollection services, string name, string baseUrl, IAsyncPolicy<HttpResponseMessage> retryPolicy)
        {
            services.AddHttpClient(name, c =>
            {
                c.BaseAddress = new Uri(baseUrl);
                ConfigureDefaultRequestHeaders(c);
            }).AddPolicyHandler(retryPolicy);
        }

        private static void ConfigureDefaultRequestHeaders(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
            httpClient.DefaultRequestHeaders.Add("Keep-Alive", "3600");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory");
        }
    }
}
