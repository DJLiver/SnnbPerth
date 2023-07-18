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
    class SummaryQueue : QueueThread<SNdata>
    {
        List<Target> targets = null;
        Dictionary<string, SummaryData> databank;


        #region IStartStop Members

        public SummaryQueue(List<Target> targets)
        {
            this.targets = targets;
        }
        public new void Start()
        {
            // Create dictionary entry for each unit
            databank = new Dictionary<string, SummaryData>(targets.Count);

            foreach (var item in targets)
            {
                databank.Add(item.Name, new SummaryData() { Site = item.Site });
                if (item.Site == "Site1")
                {
                    MetricSite1Summary.CreateRow(item);
                }
                else if (item.Site == "Site2")
                {
                    MetricSite2Summary.CreateRow(item);

                }
            }

            base.Start();
        }


        public new void Stop()
        {
            base.Stop();
        }
        #endregion

        public override void processItem(SNdata sNdata)
        {
            // every 5/10 sec
            SummaryData summaryData = databank[sNdata.Name];
            summaryData.ProcessNewData(sNdata);
            base.Next();
        }
    }
}
