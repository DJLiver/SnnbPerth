using Common;
using SpectralNetCollector.Database;
using SpectralNetCollector.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectralNetCollector.Collect
{
    class CollectManager : iStartStop
    {
        internal Action<object, SNdata> SNDataEvent;
        internal Action<object, ErrorData> ErrorEvent;
        private readonly List<CollectTimer> collectTimers = new List<CollectTimer>();
        private readonly List<Target> targets;

        public CollectManager(List<Target> targets)
        {
            this.targets = targets;
        }

        public void Start()
        {
            foreach (var unit in targets)
            {
                CollectTimer collectTimer = new CollectTimer
                {
                    target = unit,
                };
                collectTimer.SNDataEvent += SNDataEvent;
                collectTimer.ErrorEvent += ErrorEvent;
                collectTimers.Add(collectTimer);
            }
            foreach (var t in collectTimers)
            {
                t.Start();
            }
        }

        public void Stop()
        {
            foreach (var t in collectTimers)
            {
                t.Stop();
            }
        }
    }
}
