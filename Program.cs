using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace otel_dotnet
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main()
        {
            await GetResponse();
        }

        private static async Task GetResponse()
        {
            try
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("https://raw.githubusercontent.com/JamieDanielson/otel-glossary/main/endpoint.json");
                response.EnsureSuccessStatusCode();
                var streamTask = await response.Content.ReadAsStreamAsync();
                var vocabs = await JsonSerializer.DeserializeAsync<Vocab>(streamTask);

                Console.WriteLine($"Word: {vocabs.Word}");
                Console.WriteLine($"Description: {vocabs.Description}");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
