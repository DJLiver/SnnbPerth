using Common;
using Newtonsoft.Json;
using RestSharp;
using SpectralNetCollector.Common;
using SpectralNetCollector.Database;
using SpectralNetCollector.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SpectralNetCollector.Database
{
    class DatabaseMaintTimer : iStartStop
    {
        private Timer maintTimer = null;
        internal static Action<object, ErrorData> ErrorEvent;

        private void MaintTicker(object state)
        {
            try
            {
                List<DatabaseMaint> databaseMaint = DatabaseMaint.GetDB_Maint();

                foreach (var item in databaseMaint)
                {
                    switch (item.dBTable)
                    {
                        case "MetricCounts":
                            if(item.Enabled)
                                MetricCount.DeleteOldRows(item.DaysToKeep);
                            break;
                        case "MetricMonitor":
                            if(item.Enabled)
                                MetricMonitor.DeleteOldRows(item.DaysToKeep);
                            break;
                        case "MetricConfig":
                            if(item.Enabled)
                                MetricConfig.DeleteOldRows(item.DaysToKeep);
                            break;
                        case "MetricEvents":
                            if(item.Enabled)
                                MetricEvent.DeleteOldRows(item.DaysToKeep);
                            break;

                        default:
                            break;
                    }
                }


            }
            catch (Exception )
            {

            }
        }


        public void Start()
        {

            maintTimer  = new Timer(new TimerCallback(MaintTicker));
#if TEST
            maintTimer.Change(10, dB_Maint.HoursTrimPeriod*60000);
#else
           maintTimer.Change(10000, 12*60*60*1000); //every 24 hours
#endif
        }
        public void Stop()
        {
            if (maintTimer != null)
                maintTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }

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
