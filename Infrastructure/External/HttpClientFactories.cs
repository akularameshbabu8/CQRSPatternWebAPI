﻿using Domain.Models;
using System.Text.Json;

namespace Infrastructure.External
{
    public class HttpClientFactories : IHttpClientFactories
    {
        public readonly IHttpClientFactory _factory;
        
        public HttpClientFactories(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<Person> GetCharacterById(int Id)
        {
           
            var client = _factory.CreateClient("people");
            
            var result = await client.GetAsync($"{Id}");

            var resultContent = await result.Content.ReadAsStringAsync();

            var resultObject = JsonSerializer.Deserialize<Person>(resultContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return resultObject;

        }
        public async Task<Film> GetFilmById(int Id)
        {
            var client = _factory.CreateClient("films");

            var result = await client.GetAsync($"{Id}");

            var resultContent = await result.Content.ReadAsStringAsync();

            var resultObject = JsonSerializer.Deserialize<Film>(resultContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return resultObject;

        }
    }
}
