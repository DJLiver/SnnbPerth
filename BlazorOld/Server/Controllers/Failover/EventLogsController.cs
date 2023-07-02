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

namespace SnnbFailover.Server.Controllers.Failover
{
    [Route("odata/Failover/EventLogs")]
    public partial class EventLogsController : ODataController
    {
        private SnnbFailover.Server.Data.FailoverContext context;

        public EventLogsController(SnnbFailover.Server.Data.FailoverContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<SnnbFailover.Server.Models.Failover.EventLog> GetEventLogs()
        {
            var items = this.context.EventLogs.AsQueryable<SnnbFailover.Server.Models.Failover.EventLog>();
            this.OnEventLogsRead(ref items);

            return items;
        }

        partial void OnEventLogsRead(ref IQueryable<SnnbFailover.Server.Models.Failover.EventLog> items);

        partial void OnEventLogGet(ref SingleResult<SnnbFailover.Server.Models.Failover.EventLog> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Failover/EventLogs(Id={Id})")]
        public SingleResult<SnnbFailover.Server.Models.Failover.EventLog> GetEventLog(int key)
        {
            var items = this.context.EventLogs.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnEventLogGet(ref result);

            return result;
        }
        partial void OnEventLogDeleted(SnnbFailover.Server.Models.Failover.EventLog item);
        partial void OnAfterEventLogDeleted(SnnbFailover.Server.Models.Failover.EventLog item);

        [HttpDelete("/odata/Failover/EventLogs(Id={Id})")]
        public IActionResult DeleteEventLog(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.EventLogs
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnEventLogDeleted(item);
                this.context.EventLogs.Remove(item);
                this.context.SaveChanges();
                this.OnAfterEventLogDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnEventLogUpdated(SnnbFailover.Server.Models.Failover.EventLog item);
        partial void OnAfterEventLogUpdated(SnnbFailover.Server.Models.Failover.EventLog item);

        [HttpPut("/odata/Failover/EventLogs(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutEventLog(int key, [FromBody]SnnbFailover.Server.Models.Failover.EventLog item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null || (item.Id != key))
                {
                    return BadRequest();
                }
                this.OnEventLogUpdated(item);
                this.context.EventLogs.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.EventLogs.Where(i => i.Id == key);
                ;
                this.OnAfterEventLogUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Failover/EventLogs(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchEventLog(int key, [FromBody]Delta<SnnbFailover.Server.Models.Failover.EventLog> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.EventLogs.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnEventLogUpdated(item);
                this.context.EventLogs.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.EventLogs.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnEventLogCreated(SnnbFailover.Server.Models.Failover.EventLog item);
        partial void OnAfterEventLogCreated(SnnbFailover.Server.Models.Failover.EventLog item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] SnnbFailover.Server.Models.Failover.EventLog item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null)
                {
                    return BadRequest();
                }

                this.OnEventLogCreated(item);
                this.context.EventLogs.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.EventLogs.Where(i => i.Id == item.Id);

                ;

                this.OnAfterEventLogCreated(item);

                return new ObjectResult(SingleResult.Create(itemToReturn))
                {
                    StatusCode = 201
                };
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
