using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Flexbaze.Responses;
using Newtonsoft.Json;

namespace Flexbaze.Services
{
    public class GraphQLHttpService : IGraphQLService
    {
        private readonly HttpClient _httpClient;

        public GraphQLHttpService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "GraphQL");
        }

        public async Task<T> Query<T>(string endpointUrl, string q)
        {
            try
            {
                var stringContent = new StringContent(q, Encoding.UTF8, "application/graphql");

                var response = await _httpClient.PostAsync(endpointUrl, stringContent);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                var queryResponse = JsonConvert.DeserializeObject<QueryResponse<TokenData<T>>>(json);

                return queryResponse.Data.WebToken;
            }
            catch (Exception ex)
            {
                Console.Write("Error al ejecutar query: " + ex.Message);
                return default;
            }
        }
    }
}
