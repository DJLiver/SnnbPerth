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
    [Route("odata/SNNBStatus/Site1Statuses")]
    public partial class Site1StatusesController : ODataController
    {
        private SnnbFailover.Server.Data.SNNBStatusContext context;

        public Site1StatusesController(SnnbFailover.Server.Data.SNNBStatusContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<SnnbFailover.Server.Models.SNNBStatus.Site1Status> GetSite1Statuses()
        {
            var items = this.context.Site1Statuses.AsQueryable<SnnbFailover.Server.Models.SNNBStatus.Site1Status>();
            this.OnSite1StatusesRead(ref items);

            return items;
        }

        partial void OnSite1StatusesRead(ref IQueryable<SnnbFailover.Server.Models.SNNBStatus.Site1Status> items);
    }
}
