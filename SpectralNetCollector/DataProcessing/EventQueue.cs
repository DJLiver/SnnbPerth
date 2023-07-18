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
    class EventQueue : QueueThread<SNdata>
    {
        List<Target> targets = null;
        Dictionary<string, EventData> databank;


        public EventQueue(List<Target> targets)
        {
            this.targets = targets;
        }

        #region IStartStop Members

        public new void Start()
        {
            // Create dictionary entry for each unit
            databank = new Dictionary<string, EventData>(targets.Count);

            foreach (var item in targets)
            {
                databank.Add(item.Name, new EventData());
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
            EventData statusData = databank[t.Name];
            statusData.ProcessNewData(t);
            base.Next();
        }
    }
}
