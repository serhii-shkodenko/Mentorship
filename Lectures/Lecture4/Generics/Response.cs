using System;
using System.Collections;

namespace Lecture4.Generics
{
    public class Response
    {
    }

    public class Request
    {
    }

    public class DerivedResponse : Response { }

    public class DerivedRequest : Request, IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var order = new Order<UserType>
            {
                User = new User<UserType>(),
            };

            var orderAnother = new Order<UserTypeMore>
            {
                User = new User<UserTypeMore>(),
            };

            order.User.UserType = UserType.Business;

            throw new NotImplementedException();
        }
    }

    public class Order<TType>
        where TType : Enum
    {
        public User<TType> User { get; set; }
    }

    public class User<TType>
        where TType : Enum
    {
        public TType UserType { get; set; }
    }

    public class UserWithType
    {
        public UserType UserType { get; set; }
    }

    public class UserWithTypeAnother
    {
        public UserTypeMore UserType { get; set; }
    }

    public enum UserType
    {
        Undefined,
        Client,
        Business,
    }

    public enum UserTypeMore
    {
        Sea,
        Air
    }
}