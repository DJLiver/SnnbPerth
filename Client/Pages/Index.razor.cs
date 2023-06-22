using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;

using Radzen;
using Radzen.Blazor;

using SnnbFailover.Server.Models.SNNBStatus;
using SnnbDB.Models;

namespace SnnbFailover.Client.Pages;

public partial class Index : ComponentBase
{
    #region Injects
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


    #endregion    
    
    protected RadzenDataGrid<Site1Status> grid1;
    protected RadzenDataGrid<Site2Status> grid2;

    private static IEnumerable<Site1Status> site1;
    private static IEnumerable<Site2Status> site2;
    public List<ActiveIssue> active = new();

   // SNNBStatus sNNBStatus

    bool AutoSwitch = false;

    #region Hub

    private HubConnection hubConnection = null;
    protected override async Task OnInitializedAsync()
    {
        hubConnection = new HubConnectionBuilder()
            .WithUrl(NavigationManager.ToAbsoluteUri("/UpdateHub"))
            .Build();
        hubConnection.On<SNNBStatus>("UpdateSummary", recd);
        await hubConnection.StartAsync();
    }
    private async void recd(SNNBStatus sNNBStatus )
    {
        site1 = sNNBStatus.Site1Status;
        site2 = sNNBStatus.Site2Status;


        active = new();
        foreach (var ms in site1)
        {
            if (ms.Measureddelay < 1.9 || ms.Measureddelay > 2.1)
            {
                active.Add(new ActiveIssue() { Site = ms.Site, Unit = ms.Source, Message = "Rfout measured Delay out of limits" });
            }
            if (ms.RFoutNetIn < 420 || ms.RFoutNetIn > 500)
            {
                active.Add(new ActiveIssue() { Site = ms.Site, Unit = ms.Source, Message = "Rfout measured NetworkRate out of limits" });

            }
            if (!(bool)ms.CommOk)
            {

            }
        }


        await InvokeAsync(() => StateHasChanged());
    }

    //private async Task Send()
    //{
    //    if (hubConnection is not null)
    //    {
    //        //           await hubConnection.SendAsync("SendMessage", userInput, messageInput);
    //    }
    //}

    //public bool IsConnected => hubConnection?.State == HubConnectionState.Connected;
    //public async ValueTask DisposeAsync()
    //{
    //    if (hubConnection is not null)
    //    {
    //        await hubConnection.DisposeAsync();
    //    }
    //}

#endregion

    #region DataGrid

    void CellRender(DataGridCellRenderEventArgs<Site1Status> args)
    {
        if (args.Column.Property == "RfOutEnable")
        {
            args.Attributes.Add("style", $"background-color: {(args.Data.RfOutEnable == true ? "var(--rz-success-light)" : "var(--rz-warning-light)")};");
        }

        if (args.Column.Property == "CommOk")
        {
            //if (args.Data.ExtCommError != false)
            //{   
            //    args.Attributes.Add("style", "background-color: var(--rz-warning-light)");
            //}
            args.Attributes.Add("style", $"background-color: {(args.Data.CommOk == true ? "var(--rz-success-light)" : "var(--rz-warning-light)")};");
        }
    }
    void HeaderFooterCellRender(DataGridCellRenderEventArgs<Site1Status> args)
    {
        args.Attributes.Add("style", "background-color: darkslategray ");
    }

    void CellRender(DataGridCellRenderEventArgs<Site2Status> args)
    {
        if (args.Column.Property == "RfOutEnable")
        {
            args.Attributes.Add("style", $"background-color: {(args.Data.RfOutEnable == true ? "var(--rz-success-light)" : "var(--rz-warning-light)")};");
        }

        if (args.Column.Property == "CommOk")
        {
            //if (args.Data.ExtCommError != false)
            //{   
            //    args.Attributes.Add("style", "background-color: var(--rz-warning-light)");
            //}
            args.Attributes.Add("style", $"background-color: {(args.Data.CommOk == true ? "var(--rz-success-light)" : "var(--rz-warning-light)")};");
        }
    }
    void HeaderFooterCellRender(DataGridCellRenderEventArgs<Site2Status > args)
    {
        args.Attributes.Add("style", "background-color: darkslategray ");
    }
    void SortCallback(DataGridCellRenderEventArgs<Site2Status> args)
    {

    }

    #endregion

}


public class ActiveIssue
{
    public string Site { get; set; }
    public string Unit { get; set; }
    public string Message { get; set; }
}

