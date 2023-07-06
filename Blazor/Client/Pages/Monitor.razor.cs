using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;

using Radzen;

using SnnbDB.ModelExt;

namespace Failover.Client.Pages;

public partial class Monitor
{
    private string DataTimeStamp = DateTime.Now.ToString("ddMMMyyyy HH:MM:ss");
    
    
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

    #region Hub

    private HubConnection hubConnection = null;
    protected override async Task OnInitializedAsync()
    {
        try
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/UpdateHub"))
                .Build();
            hubConnection.On<rtStatus>("RT Status", recd);
            await hubConnection.StartAsync();

        }
        catch (Exception ex)
        {
        }    
    }
    //private IEnumerable<RtMonitor> GetRtMonitor()
    //{

    //}
    private IEnumerable<RtMonitor> MonitorTable { get; set;}
    private async void recd(rtStatus rtStatus)
    {
        DataTimeStamp= rtStatus.DateTime.ToString("ddMMMyyyy HH:MM:ss");
        MonitorTable = rtStatus.GetRtMonitor();
        await InvokeAsync(() => StateHasChanged());
    }

    #endregion
    #region DataGrid

    void CellRender(DataGridCellRenderEventArgs<RtMonitor> args)
    {
        if (args.Column.Property == "RfOutputEnable")
        {
            args.Attributes.Add("style", $"background-color: {(args.Data.RfOutputEnable == true ? "var(--rz-success)" : "var(--rz-danger)")};");
        }

        if (args.Column.Property == "CommsOk")
        {
            //if (args.Data.ExtCommError != false)
            //{   
            //    args.Attributes.Add("style", "background-color: var(--rz-warning-light)");
            //}
            args.Attributes.Add("style", $"background-color: {(args.Data.CommsOk == true ? "var(--rz-success)" : "var(--rz-danger)")};");
        }
    }

    void HeaderFooterCellRender(DataGridCellRenderEventArgs<RtMonitor> args)
    {
        if (args.Column.Property == "MeasuredDelay")
        {
            args.Attributes.Add("style", "background-color: var(--rz-danger)");
        }
    }

    //void CellRender(DataGridCellRenderEventArgs<Site2Status> args)
    //{
    //    if (args.Column.Property == "RfOutputEnable")
    //    {
    //        args.Attributes.Add("style", $"background-color: {(args.Data.RfOutEnable == true ? "var(--rz-success-light)" : "var(--rz-warning-light)")};");
    //    }

    //    if (args.Column.Property == "CommsOk")
    //    {
    //        //if (args.Data.ExtCommError != false)
    //        //{   
    //        //    args.Attributes.Add("style", "background-color: var(--rz-warning-light)");
    //        //}
    //        args.Attributes.Add("style", $"background-color: {(args.Data.CommOk == true ? "var(--rz-success-light)" : "var(--rz-warning-light)")};");
    //    }
    //}

    //void HeaderFooterCellRender(DataGridCellRenderEventArgs<Site2Status> args)
    //{
    //    args.Attributes.Add("style", "background-color: darkslategray ");
    //}
    void SortCallback(DataGridCellRenderEventArgs<RtMonitor> args)
    {

    }

    #endregion

}