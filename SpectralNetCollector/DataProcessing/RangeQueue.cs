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
    class RangeQueue : QueueThread<SNdata>
    {
        List<Target> targets = null;
        Dictionary<string, RangeData> databank;


        public RangeQueue(List<Target> targets)
        {
            this.targets = targets;
        }

        #region IStartStop Members

        public new void Start()
        {
            // Create dictionary entry for each unit
            databank = new Dictionary<string, RangeData>(targets.Count);

            foreach (var item in targets)
            {
                RangeConfig.CreateRow(item);
            }
            foreach (var item in targets)
            {
                var rc = RangeConfig.GetRangeConfigs(item.Name);
                databank.Add(item.Name, new RangeData(rc));
                RangeConfig.CreateRow(item);
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
            RangeData rangeData = databank[t.Name];
            rangeData.ProcessNewData(t);
            base.Next();
        }
    }
}
