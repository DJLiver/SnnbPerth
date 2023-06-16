using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace SnnbFailover.Client.Pages
{
    public partial class Events
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        public FailoverService FailoverService { get; set; }

        protected IEnumerable<SnnbFailover.Server.Models.Failover.EventLog> eventLogs;

        protected RadzenDataGrid<SnnbFailover.Server.Models.Failover.EventLog> grid0;


        protected async System.Threading.Tasks.Task DataGrid0LoadData(Radzen.LoadDataArgs args)
        {
            await RefreshData(args);
        }

        private async Task RefreshData(LoadDataArgs args)
        {
            try
            {
                var result = await FailoverService.GetEventLogs(filter: $"{args.Filter}", orderby: $"{args.OrderBy}", top: args.Top, skip: args.Skip, count: args.Top != null && args.Skip != null);
                eventLogs = result.Value.AsODataEnumerable();

            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load EventLogs" });
            }
        }

        protected async System.Threading.Tasks.Task RefreshClick(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
        {
            await RefreshData(new LoadDataArgs());
        }
    }
}