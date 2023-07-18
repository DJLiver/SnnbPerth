using Common;
using Newtonsoft.Json;
using RestSharp;
using SpectralNetCollector.Common;
using SpectralNetCollector.Database;
using SpectralNetCollector.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SpectralNetCollector.Collect
{
    class CollectTimer : iStartStop
    {
        public Target target { get; set; }
        private Timer pollTimer;
        private bool MeasurementInProgress = false;
        private bool MeasurementInProgressFirstMessage = true;
        internal Action<object, SNdata> SNDataEvent;
        internal Action<object, ErrorData> ErrorEvent;

        #region Start/Stop
        public void Start()
        {
            pollTimer = new Timer(new TimerCallback(PollUnitNow));
            pollTimer.Change(0, target.Period);
        }
        public void Stop()
        {
            pollTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        #endregion

        #region Poll unit
        private void PollUnitNow(object state)
        {
            //Prevent reentry
            if (MeasurementInProgress)
            {
                if (MeasurementInProgressFirstMessage)
                {
                    //OnError( "Re-entry : " + target.Name);
                    MeasurementInProgressFirstMessage = false;
                }
                return;
            }
            MeasurementInProgress = true;
            MeasurementInProgressFirstMessage = true;
            //Task<string> content = null;
            string content = null;
            try
            {
                content = GetResponse();
                //content = GetResponseAsync();
            }
            catch (Exception ex)
            {
                MeasurementInProgress = false;
 //               OnError( ex.Message);
                OnSNData(new SNdata() { DateStamp = DateTime.UtcNow, Data = null, Name = target.Name });
                return;
            }

            try
            {
                SNModule sNModule = JsonConvert.DeserializeObject<SNModule>(content);
                OnSNData(new SNdata() { DateStamp = DateTime.UtcNow, Data = sNModule, Name = target.Name });

            }
            catch (Exception ex)
            {
                OnError(ex.Message);
            }
            MeasurementInProgress = false;
        }
        private string GetResponse()
        {
            IRestResponse response = null;
            try
            {
                RestClient client = new RestClient(target.IpAddress);
                RestRequest request = new RestRequest(target.Query, DataFormat.Json);
                response = client.Get(request);
                if (response.IsSuccessful)
                {
                    return response.Content;
                }
                throw new Exception("No response from " + target.Name);

            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<string> GetResponseAsync()
        {
            RestClient client = new RestClient(target.IpAddress);
            RestRequest request = new RestRequest(target.Query, DataFormat.Json);
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return response.Content;
            }
            else
                throw new Exception("No response from " + target.Name);
         }


        #endregion

        #region Actions
        protected void OnSNData(SNdata e)
        {
            SNDataEvent?.Invoke(this, e);
        }
        protected void OnError( string message)
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
