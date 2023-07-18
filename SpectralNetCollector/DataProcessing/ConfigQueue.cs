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
    class ConfigQueue : QueueThread<SNdata>
    {
        List<Target> targets = null;
        Dictionary<string, ConfigData> databank;


        public ConfigQueue(List<Target> targets)
        {
            this.targets = targets;
        }

        #region IStartStop Members

        public new void Start()
        {
            // Create dictionary entry for each unit
            databank = new Dictionary<string, ConfigData>(targets.Count);

            foreach (var item in targets)
            {
                databank.Add(item.Name, new ConfigData());
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
            ConfigData configData = databank[t.Name];
            configData.ProcessNewData(t);
            base.Next();
        }
    }
}
