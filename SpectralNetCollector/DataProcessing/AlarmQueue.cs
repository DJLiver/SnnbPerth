using Common;
using SpectralNetCollector.Collect;
using SpectralNetCollector.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectralNetCollector.DataProcessing
{
    class AlarmQueue : QueueThread<MetricEvent>
    {


        public AlarmQueue()
        {
        }

        #region IStartStop Members

        public new void Start()
        {
            MetricAlarm.DeleteAllAlarms();
            base.Start(); 
        }


        public new void Stop()
        {
            base.Stop();
        }
        #endregion

        public override void processItem(MetricEvent t)
        {
            MetricAlarm.ProcessAlarm(t);
            base.Next();
        }
    }
}
