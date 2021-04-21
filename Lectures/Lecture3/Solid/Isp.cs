using System;

namespace Lecture3.Solid
{
    public class Isp
    {
        public class Passenger : IPassenger, IPayablePassenger
        {
            public void Drive()
            {
                throw new NotImplementedException();
            }

            public void Pay()
            {
                throw new NotImplementedException();
            }
        }

        public class Babushka : IPassenger, INonPayablePassenger
        {
            public void Drive()
            {
                throw new NotImplementedException();
            }

            public void NoPayDrive()
            {
                throw new NotImplementedException();
            }
        }

        public interface IPassenger
        {
            void Drive();
        }

        public interface INonPayablePassenger
        {
            void NoPayDrive();
        }

        public interface IPayablePassenger
        {
            void Pay();
        }
    }
}