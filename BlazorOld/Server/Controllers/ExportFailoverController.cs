using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using SnnbFailover.Server.Data;

namespace SnnbFailover.Server.Controllers
{
    public partial class ExportFailoverController : ExportController
    {
        private readonly FailoverContext context;
        private readonly FailoverService service;

        public ExportFailoverController(FailoverContext context, FailoverService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/Failover/controls/csv")]
        [HttpGet("/export/Failover/controls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportControlsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetControls(), Request.Query), fileName);
        }

        [HttpGet("/export/Failover/controls/excel")]
        [HttpGet("/export/Failover/controls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportControlsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetControls(), Request.Query), fileName);
        }

        [HttpGet("/export/Failover/eventlogs/csv")]
        [HttpGet("/export/Failover/eventlogs/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportEventLogsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetEventLogs(), Request.Query), fileName);
        }

        [HttpGet("/export/Failover/eventlogs/excel")]
        [HttpGet("/export/Failover/eventlogs/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportEventLogsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetEventLogs(), Request.Query), fileName);
        }
    }
}
