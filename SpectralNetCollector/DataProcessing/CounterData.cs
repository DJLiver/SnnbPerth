using SpectralNetCollector.Collect;
using SpectralNetCollector.Common;
using SpectralNetCollector.Database;
using SpectralNetCollector.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace SpectralNetCollector.DataProcessing
{
    public class CounterData
    {
        SNdata current;
        private int lastMinute;
        internal static Action<object, ErrorData> ErrorEvent;

        //per min 60x24x14x16

        public CounterData()
        {
            current = null;
            lastMinute = 0;
        }

        #region ProcessCounterData

        internal void ProcessNewData(SNdata t)
        {
            current = t;
            if (current.DateStamp.Minute != lastMinute)
            {
                if (t.Data != null)
                { 
                    ProcessCounterData();
                    lastMinute = current.DateStamp.Minute;
                }
                    
            }

        }
        internal void ProcessCounterData()
        {
            try
            {
                MetricCount mc = new MetricCount()
                {
                    DateStamp = current.DateStamp,
                    Target = current.Name,
                    Com_discardedPackets = current.Data.discardedPackets.Value,
                    RfOut_droppedPackets = current.Data.RfOutputStream.array[0].structure.droppedPackets.Value,
                    RfOut_gapCount = current.Data.RfOutputStream.array[0].structure.gapCount.Value,
                    RfOut_pfecMissingSets = current.Data.RfOutputStream.array[0].structure.pfecMissingSets.Value,
                    RfOut_pfecRepairedPackets = current.Data.RfOutputStream.array[0].structure.pfecRepairedPackets.Value,
                    RfOut_pfecTotalPackets = current.Data.RfOutputStream.array[0].structure.pfecTotalPackets.Value,
                    RfOut_pfecUnrepairablePackets = current.Data.RfOutputStream.array[0].structure.pfecUnrepairablePackets.Value,
                    RfOut_preserveLatencyLatePackets = current.Data.RfOutputStream.array[0].structure.preserveLatencyLatePackets.Value,
                    RfOut_preserveLatencyMaxBurstLoss = current.Data.RfOutputStream.array[0].structure.preserveLatencyMaxBurstLoss.Value,
                    RfOut_preserveLatencyMissingPackets = current.Data.RfOutputStream.array[0].structure.preserveLatencyMissingPackets.Value,
                    RfOut_preserveLatencyOutOfOrderPackets = current.Data.RfOutputStream.array[0].structure.preserveLatencyOutOfOrderPackets.Value,
                    RfOut_underflowCount = current.Data.RfOutputStream.array[0].structure.underflowCount.Value
                };
                MetricCount.Add(mc);

            }
            catch (Exception ex)
            {
                OnError(ex.Message);
            }        
        }

        #endregion
        #region Actions
        protected void OnError(string message)
        {
            var e = new ErrorData()
            {
                DateTime = DateTime.UtcNow,
                Source = Utilities.NameOfCallingClass(),
                Message = message,
            };
            ErrorEvent?.Invoke(this, e);
        }

        #endregion

    }
}
