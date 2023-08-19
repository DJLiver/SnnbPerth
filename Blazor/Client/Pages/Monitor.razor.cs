using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;
using Failover.Client.Shared;
using SnnbDB.ModelExt;

namespace Failover.Client.Pages;

public partial class Monitor
{
    private GroupDG GroupDG201;
    private GroupDG GroupDG202;
    private GroupDG GroupDG203;
    private GroupDG GroupDG204;

    private HubConnection hubConnection = null;

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

    #region Initial

    protected override async Task OnInitializedAsync()
    {
        try
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/UpdateHub"))
                .Build();
            hubConnection.On<RtMonitor>("RT Monitor", RecData);
            await hubConnection.StartAsync();

        }
        catch (Exception ex)
        {
        }
    }
    #endregion

    #region RecData

    private async void RecData(RtMonitor rtMonitor)
    {
        GroupDG201.SetMonitorTable(rtMonitor.monitorTable201);
        GroupDG202.SetMonitorTable(rtMonitor.monitorTable202);
        GroupDG203.SetMonitorTable(rtMonitor.monitorTable203);
        GroupDG204.SetMonitorTable(rtMonitor.monitorTable204);

        //await InvokeAsync(() => StateHasChanged());
        await InvokeAsync(StateHasChanged);
    }

    #endregion

    #region DataGrid

    void CellRender(DataGridCellRenderEventArgs<RtMonitorTable> args)
    {
        //args.Attributes.Add("style", $"background-color: {(args.Data.CommsOkAlert ? "var(--rz-danger)" : "var(--rz-success)" )};");
        //if (args.Column.Property == "DateTimeStamp")
        //{
        //    //args.Column.Template.
        //    //args.Attributes.Add("style", $"background-color: {(args.Data.DateTimeStampAlert ? DangerColor : "var(--rz-success)")};");
        //}

        //if (args.Column.Property == "CommsOk")
        //{
        //    CommsAlertStyle = args.Data.CommsOkAlert ? CommsSuccessStyle : CommsDangerStyle;

        //    //args.Attributes.Add("style", $"background-color: {(args.Data.CommsOkAlert ? DangerColor : "var(--rz-success)" )};");
        //}

        //if (args.Column.Property == "OnePpsPresent")
        //{
        //    if(args.Data.CommsOkAlert)
        //        args.Attributes.Add("style", $"background-color: {"var(--rz-secondary-dark)"};");
        //    else
        //    {
        //        args.Attributes.Remove("style");    
        //        args.Attributes.Add("style", $"background-color: {(args.Data.OnePpsPresentAlert ? DangerColor : "var(--rz-success)" )};");       

        //    }
        //}
        //if (args.Column.Property == "TenMhzLocked")
        //{
        //    if(args.Data.CommsOkAlert)
        //        args.Attributes.Add("style", $"background-color: {"var(--rz-secondary-dark)"};");
        //    else
        //        args.Attributes.Add("style", $"background-color: {(args.Data.TenMhzLockedAlert ? DangerColor : "var(--rz-success)" )};");
        //}
        //if (args.Column.Property == "MeasuredDelay")
        //{
        //    if(args.Data.CommsOkAlert)
        //        args.Attributes.Add("style", $"background-color: {"var(--rz-secondary-dark)"};");
        //    else
        //        args.Attributes.Add("style", $"background-color: {(args.Data.MeasuredDelayAlert ? DangerColor : "var(--rz-success)" )};");
        //}
        //if (args.Column.Property == "MeasuredNetworkRate")
        //{
        //    if(args.Data.CommsOkAlert)
        //        args.Attributes.Add("style", $"background-color: {"var(--rz-secondary-dark)"};");
        //    else
        //        args.Attributes.Add("style", $"background-color: {(args.Data.MeasuredNetworkRateAlert ? DangerColor : "var(--rz-success)" )};");
        //}
        //if (args.Column.Property == "StreamEnable")
        //{
        //    if(args.Data.CommsOkAlert)
        //        args.Attributes.Add("style", $"background-color: {"var(--rz-secondary-dark)"};");
        //    else
        //        args.Attributes.Add("style", $"background-color: {(args.Data.StreamEnableAlert ? DangerColor : "var(--rz-success)" )};");
        //}
        //if (args.Column.Property == "RfOutputEnable")
        //{
        //    if(args.Data.CommsOkAlert)
        //        args.Attributes.Add("style", $"background-color: {"var(--rz-secondary-dark)"};");
        //    else
        //        args.Attributes.Add("style", $"background-color: {(args.Data.RfOutputEnableAlert ? DangerColor : "var(--rz-success)" )};");
        //}

    }

    void HeaderFooterCellRender(DataGridCellRenderEventArgs<RtMonitorTable> args)
    {
        //if (args.Column.Property == "MeasuredDelay")
        //{
        //    args.Attributes.Add("style", "background-color: var(--rz-danger)");
        //}
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

    #endregion

}

