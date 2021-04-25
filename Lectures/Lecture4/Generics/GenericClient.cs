using System;
using System.Collections;

namespace Lecture4.Generics
{
    public abstract class GenericClient<TRequest, TResponse> : IGenericClient<TRequest, TResponse>
        where TRequest : Request, IEnumerable, new()
        where TResponse : Response, new()
    {
        public TResponse GetResponse(TRequest request)
        {
            throw new NotImplementedException();
        }
    }
}