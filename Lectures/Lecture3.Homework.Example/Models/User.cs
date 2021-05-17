using System;
using System.Collections.Generic;
using System.Threading;

namespace Lecture3.Homework.Example.Models
{
    public class User : IAuditable
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public UserAgeType UserAgeType { get; set; }

        public string GenerateContent()
        {
            var basket = new Basket(new CancellationTokenSource());

            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return $"Name {LastName}";
        }
    }

    public class Basket : IAuditable, IDisposable
    {
        private readonly IDisposable obj;
        private bool disposedValue;

        public Basket(IDisposable obj)
        {
            this.obj = obj;
        }

        public ICollection<Order> Orders { get; set; }

        public User User { get; set; }

        public string GenerateContent()
        {
            using var source = new CancellationTokenSource();

            throw new System.NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    obj.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

    public interface IAuditable
    {
        string GenerateContent();
    }

    public enum UserAgeType
    {
        Undefined,
        Infant,
        Child,
        Adult,
    }
}