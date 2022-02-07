using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PlatformService.DTOs;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task SendPlatormToCommand(PlatformReadDto plat)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(plat),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            var responce = await _httpClient.PostAsync($"{_configuration["CommandService"]}/api/c/Platforms", httpContent);

            if(responce.IsSuccessStatusCode)
            {
                Console.WriteLine("-----> Sync POST was OK");
            }
            else
            {
                 Console.WriteLine("-----> Sync POST was NOT OK");

            }
        }
    }
}