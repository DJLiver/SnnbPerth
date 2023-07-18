using Common;
using SpectralNetCollector.Collect;
using SpectralNetCollector.Database;
using SpectralNetCollector.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectralNetCollector.DataProcessing
{
    class CounterQueue : QueueThread<SNdata>
    {
        List<Target> targets = null;
        Dictionary<string, CounterData> databank;

        public CounterQueue(List<Target> targets)
        {
            this.targets = targets;
        }

        #region IStartStop Members

        public new void Start()
        {
            // Create dictionary entry for each unit
            databank = new Dictionary<string, CounterData>(targets.Count);

            foreach (var item in targets)
            {
                databank.Add(item.Name, new CounterData());
            }

            base.Start(); 
        }


        public new void Stop()
        {
            base.Stop();
        }
        #endregion

        public override void processItem(SNdata t)
        {
            CounterData counterData = databank[t.Name];
            counterData.ProcessNewData(t);
            base.Next();
        }
    }
}
