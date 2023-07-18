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
    public class MonitorData
    {
        private SNdata current;
        private SNdata previous;
        internal static Action<object, ErrorData> ErrorEvent;
        private readonly List<SNdata> pool;

        public MonitorData()
        {
            current = null;
            previous = null;
            pool = new List<SNdata>();
               // InitMonitor();
        }

        #region ProcessMonitorData

        internal void ProcessNewData(SNdata t)
        {
            //first one exception
            if (previous == null)
            {
                previous = t;
                return;
            }
            current = t;

            if (t.Data != null)
                ProcessMonitorData();

            // make current the previous data
            previous = t;
        }
        internal void ProcessMonitorData()
        {
            pool.Add(current);
            if (current.DateStamp.Minute != previous.DateStamp.Minute)
            {
                AddToMonitorDatabase(current.DateStamp, current.Name);
                pool.Clear();
            }
        }

        private void AddToMonitorDatabase(DateTime dateStamp, string name)
        {
            try
            {
                MetricMonitor m = new MetricMonitor()
                {
                    DateStamp = dateStamp,
                    Target = name,
                    MaxInputRfPort1AdcSaturation = pool.Max(t => t.Data.inputRfPort1AdcSaturation.Value),
                    MaxInputRfPort1AdcSaturationPercent = pool.Max(t => t.Data.inputRfPort1AdcSaturationPercent.Value),
                    MaxInputRfPort1Power = pool.Max(t => t.Data.inputRfPort1Power.Value),
                    MaxOutputRfPort1AdcSaturation = pool.Max(t => t.Data.outputRfPort1DacSaturation.Value),
                    MaxOutputRfPort1AdcSaturationPercent = pool.Max(t => t.Data.outputRfPort1DacSaturationPercent.Value),
                    MaxOutputRfPort1Power = pool.Max(t => t.Data.outputRfPort1Power.Value),

                    MinInputRfPort1AdcSaturation = pool.Min(t => t.Data.inputRfPort1AdcSaturation.Value),
                    MinInputRfPort1AdcSaturationPercent = pool.Min(t => t.Data.inputRfPort1AdcSaturationPercent.Value),
                    MinInputRfPort1Power = pool.Min(t => t.Data.inputRfPort1Power.Value),
                    MinOutputRfPort1AdcSaturation = pool.Min(t => t.Data.outputRfPort1DacSaturation.Value),
                    MinOutputRfPort1AdcSaturationPercent = pool.Min(t => t.Data.outputRfPort1DacSaturationPercent.Value),
                    MinOutputRfPort1Power = pool.Min(t => t.Data.outputRfPort1Power.Value),
                };
                MetricMonitor.Add(m);

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
