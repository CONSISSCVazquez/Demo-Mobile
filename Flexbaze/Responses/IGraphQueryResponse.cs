namespace Flexbaze.Responses
{
    public interface IGraphQueryResponse<T>
    {
        T Data { get; set; }
    }
}
