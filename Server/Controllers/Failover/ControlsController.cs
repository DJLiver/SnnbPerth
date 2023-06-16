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
    [Route("odata/Failover/Controls")]
    public partial class ControlsController : ODataController
    {
        private SnnbFailover.Server.Data.FailoverContext context;

        public ControlsController(SnnbFailover.Server.Data.FailoverContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<SnnbFailover.Server.Models.Failover.Control> GetControls()
        {
            var items = this.context.Controls.AsQueryable<SnnbFailover.Server.Models.Failover.Control>();
            this.OnControlsRead(ref items);

            return items;
        }

        partial void OnControlsRead(ref IQueryable<SnnbFailover.Server.Models.Failover.Control> items);

        partial void OnControlGet(ref SingleResult<SnnbFailover.Server.Models.Failover.Control> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Failover/Controls(Id={Id})")]
        public SingleResult<SnnbFailover.Server.Models.Failover.Control> GetControl(int key)
        {
            var items = this.context.Controls.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnControlGet(ref result);

            return result;
        }
        partial void OnControlDeleted(SnnbFailover.Server.Models.Failover.Control item);
        partial void OnAfterControlDeleted(SnnbFailover.Server.Models.Failover.Control item);

        [HttpDelete("/odata/Failover/Controls(Id={Id})")]
        public IActionResult DeleteControl(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.Controls
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnControlDeleted(item);
                this.context.Controls.Remove(item);
                this.context.SaveChanges();
                this.OnAfterControlDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnControlUpdated(SnnbFailover.Server.Models.Failover.Control item);
        partial void OnAfterControlUpdated(SnnbFailover.Server.Models.Failover.Control item);

        [HttpPut("/odata/Failover/Controls(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutControl(int key, [FromBody]SnnbFailover.Server.Models.Failover.Control item)
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
                this.OnControlUpdated(item);
                this.context.Controls.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Controls.Where(i => i.Id == key);
                ;
                this.OnAfterControlUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Failover/Controls(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchControl(int key, [FromBody]Delta<SnnbFailover.Server.Models.Failover.Control> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.Controls.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnControlUpdated(item);
                this.context.Controls.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Controls.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnControlCreated(SnnbFailover.Server.Models.Failover.Control item);
        partial void OnAfterControlCreated(SnnbFailover.Server.Models.Failover.Control item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] SnnbFailover.Server.Models.Failover.Control item)
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

                this.OnControlCreated(item);
                this.context.Controls.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Controls.Where(i => i.Id == item.Id);

                ;

                this.OnAfterControlCreated(item);

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
