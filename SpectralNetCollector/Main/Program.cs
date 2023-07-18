using AndersonImes.ServiceProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SpectralNetCollector
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //static void Main()
        //{
        //    ServiceBase[] ServicesToRun;
        //    ServicesToRun = new ServiceBase[]
        //    {
        //        new Service1()
        //    };
        //    ServiceBase.Run(ServicesToRun);
        //}
        static void Main()
        {
            ServiceBase[] ServicesToRun;

            // More than one user Service may run within the same process. To add
            // another service to this process, change the following line to
            // create a second service object. For example,
            //
            //   ServicesToRun = new ServiceBase[] {new Service1(), new MySecondUserService()};
            //
            ServicesToRun = new ServiceBase[] { new SNCollectorService() };

            //ServiceBase.Run(ServicesToRun);
#if (!DEBUG)
            ServiceBase.Run(ServicesToRun);
#else
            ServicesLoader.StartServices(ServicesToRun);
#endif

        }
    }
}
