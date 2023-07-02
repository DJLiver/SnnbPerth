using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using SnnbFailover.Server.Data;

namespace SnnbFailover.Server.Controllers
{
    public partial class ExportSNNBStatusController : ExportController
    {
        private readonly SNNBStatusContext context;
        private readonly SNNBStatusService service;

        public ExportSNNBStatusController(SNNBStatusContext context, SNNBStatusService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/SNNBStatus/site1statuses/csv")]
        [HttpGet("/export/SNNBStatus/site1statuses/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSite1StatusesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSite1Statuses(), Request.Query), fileName);
        }

        [HttpGet("/export/SNNBStatus/site1statuses/excel")]
        [HttpGet("/export/SNNBStatus/site1statuses/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSite1StatusesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSite1Statuses(), Request.Query), fileName);
        }

        [HttpGet("/export/SNNBStatus/site2statuses/csv")]
        [HttpGet("/export/SNNBStatus/site2statuses/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSite2StatusesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSite2Statuses(), Request.Query), fileName);
        }

        [HttpGet("/export/SNNBStatus/site2statuses/excel")]
        [HttpGet("/export/SNNBStatus/site2statuses/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSite2StatusesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSite2Statuses(), Request.Query), fileName);
        }

        [HttpGet("/export/SNNBStatus/siteattrlimits/csv")]
        [HttpGet("/export/SNNBStatus/siteattrlimits/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSiteAttrLimitsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSiteAttrLimits(), Request.Query), fileName);
        }

        [HttpGet("/export/SNNBStatus/siteattrlimits/excel")]
        [HttpGet("/export/SNNBStatus/siteattrlimits/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSiteAttrLimitsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSiteAttrLimits(), Request.Query), fileName);
        }
    }
}
