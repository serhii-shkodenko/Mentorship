namespace Lecture4.Generics
{
    public interface IGenericClient<TRequest, TResponse>
        where TRequest : Request, new()
        where TResponse : Response, new()
    {
        TResponse GetResponse(TRequest request);
    }
}