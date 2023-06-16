using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SnnbFailover.Server.Controllers.SNNBStatus
{
    [Route("odata/SNNBStatus/SiteAttrLimits")]
    public partial class SiteAttrLimitsController : ODataController
    {
        private SnnbFailover.Server.Data.SNNBStatusContext context;

        public SiteAttrLimitsController(SnnbFailover.Server.Data.SNNBStatusContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<SnnbFailover.Server.Models.SNNBStatus.SiteAttrLimit> GetSiteAttrLimits()
        {
            var items = this.context.SiteAttrLimits.AsQueryable<SnnbFailover.Server.Models.SNNBStatus.SiteAttrLimit>();
            this.OnSiteAttrLimitsRead(ref items);

            return items;
        }

        partial void OnSiteAttrLimitsRead(ref IQueryable<SnnbFailover.Server.Models.SNNBStatus.SiteAttrLimit> items);
    }
}
