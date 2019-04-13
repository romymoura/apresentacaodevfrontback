using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace Apresentacao.Business.Services.Integration.Bases
{
    public class BaseIDispose : IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
                handle.Dispose();
            disposed = true;
        }

        ~BaseIDispose()
        {
            Dispose(false);
        }
    }
}
