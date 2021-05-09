using System;
using System.Runtime.CompilerServices;

namespace Lecture6
{
    public class Writer : IDisposable
    {
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~Writer()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

    public class DerivedWriter : Writer, IDisposable
    {
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        [SkipLocalsInit]
        public bool TryGetName(User user, out string result)
        {
            Unsafe.SkipInit(out result);

            string parameter = "444";

            if (user.Age > 18)
            {
                result = "User is adult";
                return true;
            }

            return false;
        }
    }

    public class User
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string GenerateContent()
        {
            throw new System.NotImplementedException();
        }
    }
}