#define TEST
//#undef TEST


using SpectralNetCollector.Collect;
using SpectralNetCollector.Database;
using SpectralNetCollector.DataProcessing;
using SpectralNetCollector.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;


namespace SpectralNetCollector
{
    public partial class SNCollectorService : ServiceBase
    {
        private CollectManager collectManager;
        private MonitorQueue monitorQueue;
        private AlarmQueue alarmQueue;
        private ConfigQueue configQueue;
        private EventQueue eventQueue;
        private RangeQueue rangeQueue;
        private CounterQueue counterQueue;
        private SummaryQueue summaryQueue;
        private DatabaseMaintTimer databaseTimer;
        private ErrorLog errorLog;
        public SNCollectorService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            List<Target> targets = Target.GetTargets();

            errorLog = new ErrorLog();
            errorLog.Start();
            errorLog.Add(null, new ErrorData() { DateTime = DateTime.UtcNow, Source = "Collector Service", Message = "Service Starting" });

            collectManager = new CollectManager(targets);


            monitorQueue = new MonitorQueue(targets);
            collectManager.SNDataEvent += monitorQueue.Add;
            MonitorData.ErrorEvent += errorLog.Add;
            monitorQueue.Start();
            
            alarmQueue = new AlarmQueue();
            alarmQueue.Start();

            configQueue = new ConfigQueue(targets);
            collectManager.SNDataEvent += configQueue.Add;
            ConfigData.ErrorEvent += errorLog.Add;
            configQueue.Start();

            eventQueue = new EventQueue(targets);
            collectManager.SNDataEvent += eventQueue.Add;
            EventData.AlarmEvent += alarmQueue.Add;
            EventData.ErrorEvent += errorLog.Add;
            eventQueue.Start();

            rangeQueue = new RangeQueue(targets);
            collectManager.SNDataEvent += rangeQueue.Add;
            RangeData.AlarmEvent += alarmQueue.Add;
            RangeData.ErrorEvent += errorLog.Add;
            rangeQueue.Start();

            counterQueue = new CounterQueue(targets);
            collectManager.SNDataEvent += counterQueue.Add;
            CounterData.ErrorEvent += errorLog.Add;
            counterQueue.Start();


            summaryQueue = new SummaryQueue(targets);
            collectManager.SNDataEvent += summaryQueue.Add;
            SummaryData.ErrorEvent += errorLog.Add;
            summaryQueue.Start();
                

            
            collectManager.ErrorEvent += errorLog.Add;
            collectManager.Start();

            databaseTimer = new DatabaseMaintTimer();
            DatabaseMaintTimer.ErrorEvent += errorLog.Add;
            databaseTimer.Start();
        }

        protected override void OnStop()
        {
            errorLog.Add(null, new ErrorData() { DateTime = DateTime.UtcNow, Source = "Collector Service", Message = "Service Stopping" });
            collectManager.Stop();
            monitorQueue.Stop();
            alarmQueue.Stop();
            configQueue.Stop();
            eventQueue.Stop();
            rangeQueue.Stop();
            counterQueue.Stop();
            summaryQueue.Stop();
            databaseTimer.Stop();
            errorLog.Stop();
        }
    }
}
