using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Radzen;

using SnnbFailover.Server.Data;

namespace SnnbFailover.Server
{
    public partial class FailoverService
    {
        FailoverContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly FailoverContext context;
        private readonly NavigationManager navigationManager;

        public FailoverService(FailoverContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);


        public async Task ExportControlsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/failover/controls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/failover/controls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportControlsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/failover/controls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/failover/controls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnControlsRead(ref IQueryable<SnnbFailover.Server.Models.Failover.Control> items);

        public async Task<IQueryable<SnnbFailover.Server.Models.Failover.Control>> GetControls(Query query = null)
        {
            var items = Context.Controls.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnControlsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnControlGet(SnnbFailover.Server.Models.Failover.Control item);

        public async Task<SnnbFailover.Server.Models.Failover.Control> GetControlById(int id)
        {
            var items = Context.Controls
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnControlGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnControlCreated(SnnbFailover.Server.Models.Failover.Control item);
        partial void OnAfterControlCreated(SnnbFailover.Server.Models.Failover.Control item);

        public async Task<SnnbFailover.Server.Models.Failover.Control> CreateControl(SnnbFailover.Server.Models.Failover.Control control)
        {
            OnControlCreated(control);

            var existingItem = Context.Controls
                              .Where(i => i.Id == control.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Controls.Add(control);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(control).State = EntityState.Detached;
                throw;
            }

            OnAfterControlCreated(control);

            return control;
        }

        public async Task<SnnbFailover.Server.Models.Failover.Control> CancelControlChanges(SnnbFailover.Server.Models.Failover.Control item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnControlUpdated(SnnbFailover.Server.Models.Failover.Control item);
        partial void OnAfterControlUpdated(SnnbFailover.Server.Models.Failover.Control item);

        public async Task<SnnbFailover.Server.Models.Failover.Control> UpdateControl(int id, SnnbFailover.Server.Models.Failover.Control control)
        {
            OnControlUpdated(control);

            var itemToUpdate = Context.Controls
                              .Where(i => i.Id == control.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(control);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterControlUpdated(control);

            return control;
        }

        partial void OnControlDeleted(SnnbFailover.Server.Models.Failover.Control item);
        partial void OnAfterControlDeleted(SnnbFailover.Server.Models.Failover.Control item);

        public async Task<SnnbFailover.Server.Models.Failover.Control> DeleteControl(int id)
        {
            var itemToDelete = Context.Controls
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnControlDeleted(itemToDelete);


            Context.Controls.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterControlDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportEventLogsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/failover/eventlogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/failover/eventlogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEventLogsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/failover/eventlogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/failover/eventlogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEventLogsRead(ref IQueryable<SnnbFailover.Server.Models.Failover.EventLog> items);

        public async Task<IQueryable<SnnbFailover.Server.Models.Failover.EventLog>> GetEventLogs(Query query = null)
        {
            var items = Context.EventLogs.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnEventLogsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEventLogGet(SnnbFailover.Server.Models.Failover.EventLog item);

        public async Task<SnnbFailover.Server.Models.Failover.EventLog> GetEventLogById(int id)
        {
            var items = Context.EventLogs
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnEventLogGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnEventLogCreated(SnnbFailover.Server.Models.Failover.EventLog item);
        partial void OnAfterEventLogCreated(SnnbFailover.Server.Models.Failover.EventLog item);

        public async Task<SnnbFailover.Server.Models.Failover.EventLog> CreateEventLog(SnnbFailover.Server.Models.Failover.EventLog eventlog)
        {
            OnEventLogCreated(eventlog);

            var existingItem = Context.EventLogs
                              .Where(i => i.Id == eventlog.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.EventLogs.Add(eventlog);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(eventlog).State = EntityState.Detached;
                throw;
            }

            OnAfterEventLogCreated(eventlog);

            return eventlog;
        }

        public async Task<SnnbFailover.Server.Models.Failover.EventLog> CancelEventLogChanges(SnnbFailover.Server.Models.Failover.EventLog item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnEventLogUpdated(SnnbFailover.Server.Models.Failover.EventLog item);
        partial void OnAfterEventLogUpdated(SnnbFailover.Server.Models.Failover.EventLog item);

        public async Task<SnnbFailover.Server.Models.Failover.EventLog> UpdateEventLog(int id, SnnbFailover.Server.Models.Failover.EventLog eventlog)
        {
            OnEventLogUpdated(eventlog);

            var itemToUpdate = Context.EventLogs
                              .Where(i => i.Id == eventlog.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(eventlog);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterEventLogUpdated(eventlog);

            return eventlog;
        }

        partial void OnEventLogDeleted(SnnbFailover.Server.Models.Failover.EventLog item);
        partial void OnAfterEventLogDeleted(SnnbFailover.Server.Models.Failover.EventLog item);

        public async Task<SnnbFailover.Server.Models.Failover.EventLog> DeleteEventLog(int id)
        {
            var itemToDelete = Context.EventLogs
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEventLogDeleted(itemToDelete);


            Context.EventLogs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEventLogDeleted(itemToDelete);

            return itemToDelete;
        }
        }
}