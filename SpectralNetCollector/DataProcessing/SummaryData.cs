using SpectralNetCollector.Collect;
using SpectralNetCollector.Common;
using SpectralNetCollector.Database;
using SpectralNetCollector.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectralNetCollector.DataProcessing
{
    public class SummaryData 
    {
        internal static Action<object, ErrorData> ErrorEvent;

        public string Site{ get; set; }
        internal void ProcessNewData(SNdata sNdata)
        {
            try
            {
                if (sNdata.Data != null)
                {
                    if (Site == "Site1")
                        MetricSite1Summary.UpdateSummary(sNdata);
                    else if (Site == "Site2")
                        MetricSite2Summary.UpdateSummary(sNdata);
                    else
                    {
                        OnError("No Site information");
                    }
                }

            }
            catch (Exception ex)
            {
                OnError(ex.Message);
            }        
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
