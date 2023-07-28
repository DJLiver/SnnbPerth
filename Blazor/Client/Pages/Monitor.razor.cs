using Failover.Client.Shared;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;

using Radzen;
using Radzen.Blazor;

using SnnbDB.ModelExt;

namespace Failover.Client.Pages;

public partial class Monitor
{
    private NetworkPathDG NPDGPrimary;
    private RadzenDataGrid<RtMonitorTable> gridPrimary;

    private NetworkPathDG NPDGSecondary;
    private RadzenDataGrid<RtMonitorTable> gridSecondary;

    private string DataTimeStamp = DateTime.Now.ToString("ddMMMyyyy HH:mm:ss");

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
            hubConnection.On<RtStatus>("RT Status", RecData);
            await hubConnection.StartAsync();

        }
        catch (Exception ex)
        {
        }
    }
    #endregion


    #region RecData


    private async void RecData(RtStatus rtStatus)
    {
        DataTimeStamp = rtStatus.DateTimeStamp.ToString("ddMMMyyyy HH:mm:ss");

        NPDGPrimary.SetMonitorTable(rtStatus.GetRtMonitor("Primary"));
        NPDGSecondary.SetMonitorTable(rtStatus.GetRtMonitor("Secondary"));

        await InvokeAsync(() => StateHasChanged());
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
    void SortCallback(DataGridCellRenderEventArgs<RtMonitorTable> args)
    {

    }

    #endregion

}

