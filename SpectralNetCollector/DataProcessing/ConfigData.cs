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
    public class ConfigData
    {
        private SNdata current;
        private SNdata previous;
        List<FormatConfig> formatConfig = null;
        internal static Action<object, ErrorData> ErrorEvent;

        public ConfigData()
        {
            current = null;
            previous = null;
            formatConfig = FormatConfig.GetFormatConfigs();
        }

        #region ProcessConfigData

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
                ProcessConfigData();

            // make current the previous data
            previous = t;
        }
        internal void ProcessConfigData()
        {
            try
            {
                CompareValues("Com_currentGain", current.Data.currentGain.Value, previous.Data.currentGain.Value);
                CompareValues("Com_enableMulticastGroupSubscriptions", current.Data.enableMulticastGroupSubscriptions.Value, previous.Data.enableMulticastGroupSubscriptions.Value);
                CompareValues("Com_gainMode", current.Data.gainMode.Value, previous.Data.gainMode.Value);
                CompareValues("Com_gateway", current.Data.gateway.Value, previous.Data.gateway.Value);
                CompareValues("Com_inputRfBandwidth", current.Data.inputRfBandwidth.Value, previous.Data.inputRfBandwidth.Value);
                CompareValues("Com_inputRfCenterFrequency", current.Data.inputRfCenterFrequency.Value, previous.Data.inputRfCenterFrequency.Value);
                CompareValues("Com_inputRfPortSelect", current.Data.inputRfPortSelect.Value, previous.Data.inputRfPortSelect.Value);
                CompareValues("Com_invertRfOutputSpectrum", current.Data.invertRfOutputSpectrum.Value, previous.Data.invertRfOutputSpectrum.Value);
                CompareValues("Com_manualGain", current.Data.manualGain.Value, previous.Data.manualGain.Value);
                CompareValues("Com_minimumGain", current.Data.minimumGain.Value, previous.Data.minimumGain.Value);
                CompareValues("Com_outputAttenuation", current.Data.outputAttenuation.Value, previous.Data.outputAttenuation.Value);
                CompareValues("Com_outputRfCenterFrequency", current.Data.outputRfCenterFrequency.Value, previous.Data.outputRfCenterFrequency.Value);
                CompareValues("Com_outputRfPortSelect", current.Data.outputRfPortSelect.Value, previous.Data.outputRfPortSelect.Value);
                CompareValues("Com_overrideOutputFrequency", current.Data.overrideOutputFrequency.Value, previous.Data.overrideOutputFrequency.Value);
                CompareValues("Com_overrideOutputFrequencyEnable", current.Data.overrideOutputFrequencyEnable.Value, previous.Data.overrideOutputFrequencyEnable.Value);
                CompareValues("Com_RfOutputEnable", current.Data.RfOutputEnable.Value, previous.Data.RfOutputEnable.Value);
                CompareValues("Com_RfOutputSource", current.Data.RfOutputSource.Value, previous.Data.RfOutputSource.Value);
                CompareValues("RfIn_dataSampleWidth", current.Data.RfInputStream.array[0].structure.dataSampleWidth.Value, previous.Data.RfInputStream.array[0].structure.dataSampleWidth.Value);
                CompareValues("RfIn_destinationHost", current.Data.RfInputStream.array[0].structure.destinationHost.Value, previous.Data.RfInputStream.array[0].structure.destinationHost.Value);
                CompareValues("RfIn_destinationPort", current.Data.RfInputStream.array[0].structure.destinationPort.Value, previous.Data.RfInputStream.array[0].structure.destinationPort.Value);
                CompareValues("RfIn_frequencyOffset", current.Data.RfInputStream.array[0].structure.frequencyOffset.Value, previous.Data.RfInputStream.array[0].structure.frequencyOffset.Value);
                CompareValues("RfIn_maximumPacketSize", current.Data.RfInputStream.array[0].structure.maximumPacketSize.Value, previous.Data.RfInputStream.array[0].structure.maximumPacketSize.Value);
                CompareValues("RfIn_pfecEnable", current.Data.RfInputStream.array[0].structure.pfecEnable.Value, previous.Data.RfInputStream.array[0].structure.pfecEnable.Value);
                CompareValues("RfIn_sourcePort", current.Data.RfInputStream.array[0].structure.sourcePort.Value, previous.Data.RfInputStream.array[0].structure.sourcePort.Value);
                CompareValues("RfIn_streamBandwidth", current.Data.RfInputStream.array[0].structure.streamBandwidth.Value, previous.Data.RfInputStream.array[0].structure.streamBandwidth.Value);
                CompareValues("RfIn_streamEnable", current.Data.RfInputStream.array[0].structure.streamEnable.Value, previous.Data.RfInputStream.array[0].structure.streamEnable.Value);
                CompareValues("RfIn_streamId", current.Data.RfInputStream.array[0].structure.streamId.Value, previous.Data.RfInputStream.array[0].structure.streamId.Value);
                CompareValues("RfIn_streamSampleRate", current.Data.RfInputStream.array[0].structure.streamSampleRate.Value, previous.Data.RfInputStream.array[0].structure.streamSampleRate.Value);
                CompareValues("RfOut_dataSampleWidth", current.Data.RfOutputStream.array[0].structure.dataSampleWidth.Value, previous.Data.RfOutputStream.array[0].structure.dataSampleWidth.Value);
                CompareValues("RfOut_dataSource", current.Data.RfOutputStream.array[0].structure.dataSource.Value, previous.Data.RfOutputStream.array[0].structure.dataSource.Value);
                CompareValues("RfOut_frequencyOffset", current.Data.RfOutputStream.array[0].structure.frequencyOffset.Value, previous.Data.RfOutputStream.array[0].structure.frequencyOffset.Value);
                CompareValues("RfOut_preserveLatency", current.Data.RfOutputStream.array[0].structure.preserveLatency.Value, previous.Data.RfOutputStream.array[0].structure.preserveLatency.Value);
                CompareValues("RfOut_releaseMode", current.Data.RfOutputStream.array[0].structure.releaseMode.Value, previous.Data.RfOutputStream.array[0].structure.releaseMode.Value);
                CompareValues("RfOut_streamEnable", current.Data.RfOutputStream.array[0].structure.streamEnable.Value, previous.Data.RfOutputStream.array[0].structure.streamEnable.Value);
                CompareValues("RfOut_useLocalReference", current.Data.RfOutputStream.array[0].structure.useLocalReference.Value, previous.Data.RfOutputStream.array[0].structure.useLocalReference.Value);
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void CompareValues(string attr, double currentValue, double previousValue)
        {
            var f = (from r in formatConfig
                     where r.Attr == attr
                     select r).First();

            if (currentValue != previousValue)
            {
                AddToDB(attr, (currentValue / (f.Scale ?? 1)).ToString(f.Format), (previousValue / (f.Scale ?? 1)).ToString(f.Format), f.Units);
            }
        }


        private void CompareValues(string attr, uint currentValue, uint previousValue)
        {
            var f = (from r in formatConfig
                     where r.Attr == attr
                     select r).First();

            if (currentValue != previousValue)
            {
                AddToDB(attr, currentValue.ToString(f.Format), previousValue.ToString(f.Format), f.Units);
            }
        }

        private void CompareValues(string attr, int currentValue, int previousValue)
        {
            var f = (from r in formatConfig
                     where r.Attr == attr
                     select r).First();

            if (currentValue != previousValue)
            {
                AddToDB(attr, currentValue.ToString(f.Format), previousValue.ToString(f.Format), f.Units);
            }

        }


        private void CompareValues(string attr, bool currentValue, bool previousValue)
        {
            var f = (from r in formatConfig
                     where r.Attr == attr
                     select r).First();

            if (currentValue != previousValue)
            {
                AddToDB(attr, currentValue.ToString(), previousValue.ToString(), f.Units);
            }
        }

        private void CompareValues(string attr, string currentValue, string previousValue)
        {
            var f = (from r in formatConfig
                     where r.Attr == attr
                     select r).First();
            if (currentValue != previousValue)
            {
                AddToDB(attr, currentValue.ToString(), previousValue.ToString(), f.Units);
            }
        }

        private void AddToDB(string attr, string currentValue, string previousValue, object units)
        {
            MetricConfig mc = new MetricConfig()
            {
                DateStamp = current.DateStamp,
                Target = current.Name,
                Attribute = attr,
                Message = $"Configuration value has changed from {previousValue}{units} to {currentValue}{units}."
            };
            MetricConfig.Add(mc);
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
