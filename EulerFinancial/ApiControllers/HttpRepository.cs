using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EulerFinancial.ApiControllers
{
    public interface IHttpRepository
    {
        Task<T> GetAsync<T>(string requestUri);
    }
    public class HttpRepository : IHttpRepository
    {
        private readonly HttpClient client;
        private readonly JsonSerializerOptions options;
        public HttpRepository(HttpClient client)
        {
            this.client = client;
            options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
        }
        public async Task<T> GetAsync<T>(string requestUri)
        {
            var response = await client.GetAsync(requestUri);
            var content = await response.Content.ReadAsStringAsync();

            if(!response.IsSuccessStatusCode)
            {
                throw new ApplicationException();
            }

            var item = JsonSerializer.Deserialize<T>(content, options);
            return item;
        }
    }
}
