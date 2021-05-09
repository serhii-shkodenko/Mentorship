using System;
using System.Diagnostics;
using System.IO;

namespace Lecture6
{
    public class Logger : IDisposable
    {
        /// <summary>
        /// Implements IDisposable so we implement IDisposable, too!
        /// </summary>
        private StreamWriter _writer;

        /// <summary>
        /// Creates a new instance of Logger.
        /// </summary>
        /// <param name="filename">File to log to.</param>
        public Logger(string filename)
        {
            _writer = new StreamWriter(filename);
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~Logger()
        {
            Debug.WriteLine("Error - we forgot to dispose {0}", GetType().FullName);
            Dispose(false);
        }

        /// <summary>
        /// Dispose / close this instance.
        /// </summary>
        public void Dispose()
        {
            // Do a full dispose
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose / close this instance.
        /// </summary>
        public void Close()
        {
            Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            // Call base class
            //base.Dispose(disposing);

            if (disposing)
            {
                // Dispose managed stuff
                _writer?.Close();
            }

            // Dispose unmanaged stuff.
        }

        // Some usefull methods are required here to write log messages.
    }
}