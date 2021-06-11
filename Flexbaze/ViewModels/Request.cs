using Flexbaze.Models;
using Flexbaze.Services;
using GraphQL;
using System.Threading.Tasks;

namespace Flexbaze.ViewModels
{
    public class Request
    {
        private string Baseurl;
        public GraphQLClientService _graphQLService;
        public Request()
        {
            Baseurl = FlexbazeSettings.APIRequest.FLEXBAZE_API;
            _graphQLService = new GraphQLClientService();
        }

        public async Task<WebToken> GetToken(string user, string pwd)
        {
            var request = new GraphQLRequest();

            var Query = "mutation {tokenAuth(username: \"" + user + "\", password: \"" + pwd + "\")" +
                        "{token, user {id, lastName, userPermissions {id, codename}, groups {" +
                        "id, name, permissions {id, codename}}}}}";
            var token = await _graphQLService.Query<WebToken>("https://rjve3dgjxh.execute-api.us-east-1.amazonaws.com/dev/api/graphql", Query);
            return token;
        }
    }
}
