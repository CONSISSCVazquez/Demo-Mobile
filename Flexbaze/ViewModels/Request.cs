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
            var token = await _graphQLService.Query<WebToken>(Baseurl, Query);
            return token;
        }

        public async Task<SendPasswordResetEmail> SendEmail(string email)
        {
            var request = new GraphQLRequest();

            var Query = "mutation {sendPasswordResetEmail(email: \"" + email + "\")" +
                        "{success, errors}}";
            var token = await _graphQLService.Query<SendPasswordResetEmail>(Baseurl, Query);
            return token;
        }
    }
}
