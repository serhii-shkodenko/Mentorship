using System;

namespace Lecture4.Generics
{
    public class BaseClient : IGenericClient<DerivedRequest, DerivedResponse>
    {
        public DerivedResponse GetResponse(DerivedRequest request)
        {
            throw new NotImplementedException();
        }
    }
}