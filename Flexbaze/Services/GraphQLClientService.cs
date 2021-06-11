using System.Threading.Tasks;

namespace Flexbaze.Services
{
    public class GraphQLClientService : IGraphQLService
    {
        private GraphQLHttpService _graphQLClient;

        public GraphQLClientService()
        {
        }

        public async Task<T> Query<T>(string endpointUrl, string q)
        {
            if (_graphQLClient == null)
            {
                _graphQLClient = new GraphQLHttpService();
            }

            var response = await _graphQLClient.Query<T>(endpointUrl, q);

            return response;
        }
    }
}
