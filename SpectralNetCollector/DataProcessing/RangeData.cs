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
    public class RangeData
    {
        private SNdata current;
        private SNdata previous;
        List<RangeConfig> rangeConfig = null;
        List<FormatConfig> formatConfig = null;
        internal static Action<object, MetricEvent> AlarmEvent;
        internal static Action<object, ErrorData> ErrorEvent;

        public RangeData(List<RangeConfig> rangeConfig)
        {
            current = null;
            previous = null;
            this.rangeConfig = rangeConfig;
            formatConfig = FormatConfig.GetFormatConfigs();
        }

        #region ProcessRangeData

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
                ProcessRangeData();

            // make current the previous data
            previous = t;
        }
        internal void ProcessRangeData()
        {
            try
            {
                CompareValues("Com_fanSpeed", Convert.ToSingle(current.Data.fanSpeed.Value));
                CompareValues("Com_inputRfAdcSaturationPercent", Convert.ToSingle(current.Data.inputRfAdcSaturationPercent.Value));
                CompareValues("Com_SystemTemperature", Convert.ToSingle(current.Data.SystemTemperature.Value));
                CompareValues("RfIn_bitRate", Convert.ToSingle(current.Data.RfInputStream.array[0].structure.bitRate.Value));
                CompareValues("RfOut_measuredDelay", Convert.ToSingle(current.Data.RfOutputStream.array[0].structure.measuredDelay.Value));
                CompareValues("RfOut_measuredNetworkRate", Convert.ToSingle(current.Data.RfOutputStream.array[0].structure.measuredNetworkRate.Value));
                CompareValues("RfOut_networkDelay", Convert.ToSingle(current.Data.RfOutputStream.array[0].structure.networkDelay.Value));

            }
            catch (Exception ex)
            {
                OnError(ex.Message);
            }
        }

        private void CompareValues(string attr, float currentValue)
        {
            try
            {
                var range = (from r in rangeConfig
                             where r.Attr == attr
                             select r).First();
                if (range.Enabled)
                {
                    if (currentValue < range.Lower || currentValue > range.Upper) // it is out of range
                    {
                        if (range.InRange) // it was previously in range
                        {
                            //AddToDB(attr, "Attribute is out of range", currentValue, true);
                            AddToDB(attr, "Attribute is out of range", range, true);
                            range.InRange = false;
                        }
                        UpdateAlarmTable(attr, "Attribute is out of range", currentValue, true);

                    }
                    else  // it is in range
                    {
                        if (!range.InRange) // it was previously out of range
                        {
                            //AddToDB(attr, "Attribute is in range ", currentValue, false);
                            AddToDB(attr, "Attribute is in range ", range, false);
                            range.InRange = true;
                            UpdateAlarmTable(attr, "Attribute is in range ", currentValue, false);
                        }
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }        
        }

        private void AddToDB(string attr, string message, RangeConfig range, bool status)
        {
            try
            {
                var f = (from r in formatConfig
                         where r.Attr == attr
                         select r).First();

                MetricEvent me = new MetricEvent()
                {
                    DateStamp = this.current.DateStamp,
                    Target = this.current.Name,
                    Attribute = attr,
                    Message = $"{message} Lower:{(range.Lower / f.Scale ?? 1).ToString(f.Format)} {f.Units} Upper:{(range.Upper / f.Scale ?? 1).ToString(f.Format)} {f.Units}",
                    Status = status
                };
                MetricEvent.Add(me);

            }
            catch (Exception)
            {
                throw;
            }        
        }

        private void UpdateAlarmTable(string attr, string message, float currentValue, bool status)
        {
            try
            {
                var f = (from r in formatConfig
                         where r.Attr == attr
                         select r).First();

                MetricEvent me = new MetricEvent()
                {
                    DateStamp = this.current.DateStamp,
                    Target = this.current.Name,
                    Attribute = attr,
                    Message = $"{message} {(currentValue / (f.Scale ?? 1)).ToString(f.Format)} {f.Units}",
                    Status = status
                };
                AlarmEvent?.Invoke(this, me);

            }
            catch (Exception)
            {
                throw;
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
