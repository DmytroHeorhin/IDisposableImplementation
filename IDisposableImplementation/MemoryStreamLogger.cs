using System;
using System.IO;

namespace IDisposableImplementation
{
    public class MemoryStreamLogger : IDisposable
    {
        private readonly StreamWriter _streamWriter;
        private bool _isDisposed;

        public MemoryStreamLogger()
        {
            _streamWriter = new StreamWriter(@"\log.txt", append: true);
        }

        public void Log(string message)
        {
            if(_isDisposed)
                throw new ObjectDisposedException(nameof(MemoryStreamLogger));

            _streamWriter.WriteLine(message);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) return;

            if (disposing)
            {
                _streamWriter.Close();
            }

            _isDisposed = true;
        }
    }
}
