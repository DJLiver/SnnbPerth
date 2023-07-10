using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common
{
    public abstract class ThreadHandler : IDisposable
    {
        public abstract void Run();

        private Thread recThread;
        private ManualResetEvent stopReading = new ManualResetEvent(false);

        #region Initialisation
        internal void Start()
        {
            stopReading.Reset();
            recThread = new Thread(recRun);
            recThread.Start();
        }
        internal void Stop()
        {
            if (recThread.IsAlive)
            {
                stopReading.Set();
                recThread.Join(2000);
            }
        }
        
        #endregion

        #region Run
        private void recRun()
        {
            while (!stopReading.WaitOne(1, false))
            {
                Run();
            }
        }

        #endregion    

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (stopReading != null)
                {
                    stopReading.Dispose();
                    stopReading = null;
                }
            }
        }

        #endregion

    }
}
