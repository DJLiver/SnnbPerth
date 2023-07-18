using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectralNetCollector.Logging
{
    class ErrorLog : QueueThread<ErrorData>
    {
        #region IStartStop Members

        public new void Start()
        {
            base.Start();
        }

        public new void Stop()
        {
            base.Stop();
        }
        #endregion

        #region Overrides

        public override void processItem(ErrorData t)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(@"c:\snnb\log\log" + DateTime.UtcNow.ToString("yyyyMMMdd") + ".txt"))
                {
                    writer.Write(t.DateTime.ToString() + "," + t.Source + "," + t.Message + "\r\n");
                }
            }
            catch (Exception )
            {

            }
            finally
            {
                base.Next();
            }
        }

        #endregion

    }
}
