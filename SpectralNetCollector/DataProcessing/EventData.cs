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
    public class EventData
    {
        private SNdata current;
        private SNdata previous;
        List<FormatConfig> formatConfig = null;
        internal static Action<object, MetricEvent> AlarmEvent;
        internal static Action<object, ErrorData> ErrorEvent;

        public EventData()
        {
            current = null;
            previous = null;
            formatConfig = FormatConfig.GetFormatConfigs();
        }

        #region ProcessStatusData

        internal void ProcessNewData(SNdata t)
        {
            //first one exception
            //if (previous == null)
            //{
            //    previous = t;
            //    return;
            //}
            current = t;

            if (current.Data != null)
                ProcessEventData();
            ProcessComError();

            // make current the previous data
            previous = t;
        }


        #region ComError
        bool ComErrorActive = false;
        private void ProcessComError()
        {
            if (current.Data != null)
            {
                if (ComErrorActive)
                {
                    AddCommErrorToDB("ExtCommError", "True", "False", !ComErrorActive);
                    ComErrorActive = false;
                }
            }
            else
            {
                if (!ComErrorActive)
                {
                    AddCommErrorToDB("ExtCommError", "False", "True", !ComErrorActive);
                    ComErrorActive = true;
                }
            }
        }
        private void AddCommErrorToDB(string attr, string oldValue, string currentValue, bool ComErrorActive)
        {
            try
            {
                MetricEvent me = new MetricEvent()
                {
                    DateStamp = current.DateStamp,
                    Target = current.Name,
                    Attribute = attr,
                    Message = $"Status has changed from {oldValue} to {currentValue}",
                    Status = ComErrorActive
                };
                MetricEvent.Add(me);
                AlarmEvent?.Invoke(this, me);

            }
            catch (Exception) { throw; }
        }

        #endregion
        internal void ProcessEventData()
        {
            try
            {
                CompareValues("Com_CompositeStatus", current.Data.CompositeStatus.Value, previous?.Data.CompositeStatus.Value);
                CompareValues("Com_CompositeStatusMsg", current.Data.CompositeStatusMsg.Value, previous?.Data.CompositeStatusMsg.Value);
                CompareValues("Com_ContextPacketState", current.Data.ContextPacketState.Value, previous?.Data.ContextPacketState.Value);
                CompareValues("Com_healthStatus", current.Data.healthStatus.Value, previous?.Data.healthStatus.Value);
                CompareValues("Com_healthStatusMsg", current.Data.healthStatusMsg.Value, previous?.Data.healthStatusMsg.Value);
                CompareValues("Com_irigDcLocked", current.Data.irigDcLocked.Value.ToString(), previous?.Data.irigDcLocked.Value.ToString());
                CompareValues("Com_irigLocked", current.Data.irigLocked.Value.ToString(), previous?.Data.irigLocked.Value.ToString());
                CompareValues("Com_onePpsPresent", current.Data.onePpsPresent.Value.ToString(), previous?.Data.onePpsPresent.Value.ToString());
                CompareValues("Com_rebootRequired", current.Data.rebootRequired.Value.ToString(), previous?.Data.rebootRequired.Value.ToString());
                CompareValues("Com_TenMhzLocked", current.Data.TenMhzLocked.Value.ToString(), previous?.Data.TenMhzLocked.Value.ToString());
                CompareValues("RfOut_upstreamIrigLocked", current.Data.RfOutputStream.array[0].structure.upstreamIrigLocked.Value.ToString(), previous?.Data.RfOutputStream.array[0].structure.upstreamIrigLocked.Value.ToString());
                CompareValues("RfOut_upstreamOnePpsLocked", current.Data.RfOutputStream.array[0].structure.upstreamOnePpsLocked.Value.ToString(), previous?.Data.RfOutputStream.array[0].structure.upstreamOnePpsLocked.Value.ToString());
                CompareValues("RfOut_upstreamTenMhzLocked", current.Data.RfOutputStream.array[0].structure.upstreamTenMhzLocked.Value.ToString(), previous?.Data.RfOutputStream.array[0].structure.upstreamTenMhzLocked.Value.ToString());

            }
            catch (Exception ex)
            {
                OnError(ex.Message);
            }        
        }

        private void CompareValues(string attr, string currentValue, string previousValue)
        {
            try
            {
                if (previousValue == null)
                {
                    previousValue = GetDefaultValue(attr);

                }
                if (currentValue != previousValue)
                {
                    AddToDB(attr, currentValue, previousValue);
                }
            }
            catch (Exception)
            {
                throw;
            }        
        }

        private string GetDefaultValue(string attr)
        {
            string normal;
            var f2 = (from r in formatConfig
                      where r.Attr == attr
                      select r);
            if (f2.Count() > 0)
                normal = f2.First().Normal ?? "";
            else
                normal = "";
            return normal;
        }


        private void AddToDB(string attr, string currentValue, string oldValue)
        {
            try
            {
                string defaultValue =GetDefaultValue(attr);

                MetricEvent me = new MetricEvent()
                {
                    DateStamp = current.DateStamp,
                    Target = current.Name,
                    Attribute = attr,
                    Message = $"Status has changed from {oldValue} to {currentValue}",
                    Status = currentValue != defaultValue
                };
                MetricEvent.Add(me);
                AlarmEvent?.Invoke(this, me);

            }
            catch (Exception){throw;}
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
