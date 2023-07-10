
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Collections;

namespace Common
{
    public abstract class QueueThread<T> :IDisposable
    {
        private Queue<T> queue = new Queue<T>();
        private ManualResetEvent signalReady { get; set; }

        #region Initialisation
        public QueueThread()
        {
            signalReady = new ManualResetEvent(true);
        }
        internal void Start()
        {
            signalStopRequest.Reset();
            threadProcessQueue = new Thread(Run);
            threadProcessQueue.Name = this.ToString();
            threadProcessQueue.Start();
            signalReady.Set();
        }

        internal void Stop()
        {
            ProcessQueue();
            if (threadProcessQueue != null)
            {
                if (threadProcessQueue.IsAlive)
                {
                    signalStopRequest.Set();
                    threadProcessQueue.Join();
                }
                threadProcessQueue = null;
            }
        }

        internal void Next()
        {
            signalReady.Set();
        }

        #endregion

        #region Thread ProcessQueue
        private Thread threadProcessQueue;
        private ManualResetEvent signalStopRequest = new ManualResetEvent(false);
        private void Run()
        {
            while (!signalStopRequest.WaitOne(1))
            {
                if (signalReady.WaitOne())
                {
                    ProcessQueue();
                }
            }
        }

        private void ProcessQueue()
        {
            T t = default(T);
            lock (queue)
            {
                if (queue.Count != 0)
                {
                    t = queue.Dequeue();
                }
                else
                    t = default(T);
            }
            if (t != null)
            {
                signalReady.Reset();
                processItem(t);
            }
            //else
            //{
            //    if (SendDefault)
            //    {
            //        signalReady.Reset();
            //        processDefaultItem();
            //    }
            //}
        }

        #endregion

        #region Consumer
        public void Add(object sender, T t)
        {
            lock (queue)
            {
                queue.Enqueue(t);
            }
        }
        #endregion

        #region Abstract Members

        public abstract void processItem(T t);

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
                if (signalReady != null)
                {
                    signalReady.Dispose();
                    signalReady = null;
                }
            }
        }

        #endregion

    }
}

