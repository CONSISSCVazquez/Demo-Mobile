using System.Threading.Tasks;

namespace Flexbaze.Services
{
    public interface IGraphQLService
    {
        Task<T> Query<T>(string endpointUrl, string q);
    }
}
