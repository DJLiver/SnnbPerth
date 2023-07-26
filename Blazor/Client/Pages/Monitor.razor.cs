using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;

using Radzen;
using Radzen.Blazor;

using SnnbDB.ModelExt;

namespace Failover.Client.Pages;

public partial class Monitor
{
    private string DataTimeStamp = DateTime.Now.ToString("ddMMMyyyy HH:mm:ss");
    //RadzenDataGrid<RtMonitorTable> grid1;
    //private List<MTT> MTTs { get; set;}
    private HubConnection hubConnection = null;
    private string PrimaryStatus = "bg-dark";
    private string SecondaryStatus = "bg-dark";
    private string PrimaryPath = "bg-dark";
    private string SecondaryPath = "bg-dark";
    private string PrimaryPathTxt = "Undetermined";
    private string SecondaryPathTxt = "Undetermined";
    private string DangerColor = "#8d2108";
    private string DangerStyle = "background-color: #8d2108; width: 20px; color: #8d2108";
    private string SuccessStyle = "background-color: #1e801d; width: 20px; color: #1e801d";
    private string CommsDangerStyle = "height: 22px; border-left: 4px solid #8d2108; width: 52px; text-align: left; padding-top: 3px; padding-left: 3px";
    private string CommsSuccessStyle = "height: 22px; border-left: 4px solid #1a7819; width: 52px; text-align: left; padding-top: 3px; padding-left: 3px";
    private string CommsAlertStyle = "height: 22px; border-left: 4px solid #8d2108; width: 52px; text-align: left; padding-top: 3px; padding-left: 3px";

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
       // MTTs.Add(new MTT() { Column = "Unit", Name = "Unit" });
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

    private IEnumerable<RtMonitorTable> MonitorTablePrimary { get; set;}
    private IEnumerable<RtMonitorTable> MonitorTableSecondary { get; set;}
  
    private async void RecData(RtStatus rtStatus)
    {
        DataTimeStamp= rtStatus.DateTimeStamp.ToString("ddMMMyyyy HH:mm:ss");
        MonitorTablePrimary = rtStatus.GetRtMonitor("Primary");
        MonitorTableSecondary = rtStatus.GetRtMonitor("Secondary");
        PrimaryStatus = GetSummaryStatus(MonitorTablePrimary);
        SecondaryStatus = GetSummaryStatus(MonitorTableSecondary);
        var v1 = GetPathStatus(MonitorTablePrimary);
        var v2 = GetPathStatus(MonitorTableSecondary);

        PrimaryPath = v1.bg;
        SecondaryPath = v2.bg;
        PrimaryPathTxt = v1.txt;
        SecondaryPathTxt = v2.txt;


        await InvokeAsync(() => StateHasChanged());
    }

    private string GetSummaryStatus(IEnumerable<RtMonitorTable> m)
    {
        string ret = "bg-dark";
        if (m.Any(x => x.CommsOkAlert || x.OnePpsPresentAlert || x.MeasuredDelayAlert || x.DateTimeStampAlert || x.MeasuredNetworkRateAlert  || x.TenMhzLockedAlert))
        {
            ret = "bg-danger";
        }
        else
        {
            ret = "bg-success";
        }
        return ret;
    }
    
    private (string bg, string txt) GetPathStatus(IEnumerable<RtMonitorTable> m)
    {
        string bg = "bg-dark";
        string txt = "None on this path";
        if (m.All(x => x.RfOutputEnableAlert || x.StreamEnableAlert))
        {
            bg = "bg-danger";
            txt = "None on this path";
        }
        else if (m.Any(x => x.RfOutputEnableAlert || x.StreamEnableAlert))
        {
            bg = "bg-warning"; //--rz-warning
            txt = "Some on this path";
        }
        else
        {
            bg = "bg-success";
            txt = "All on this path";
        }

        return (bg,txt);
    }


    //private string GetSummaryStatus(string v)
    //{
    //}

    #endregion

    #region DataGrid

    void CellRender(DataGridCellRenderEventArgs<RtMonitorTable> args)
    {
            //args.Attributes.Add("style", $"background-color: {(args.Data.CommsOkAlert ? "var(--rz-danger)" : "var(--rz-success)" )};");
//       if (args.Column.Property == "DateTimeStamp")
//        {
//            args.Attributes.Add("style", $"background-color: {(args.Data.DateTimeStampAlert ? DangerColor : "var(--rz-success)" )};");
//        }
            
        if (args.Column.Property == "CommsOk")
        {
            CommsAlertStyle = args.Data.CommsOkAlert ? CommsSuccessStyle : CommsDangerStyle;
            //args.Attributes.Add("style", $"background-color: {(args.Data.CommsOkAlert ? DangerColor : "var(--rz-success)" )};");
        }
        
        if (args.Column.Property == "OnePpsPresent")
        {
            if(args.Data.CommsOkAlert)
                args.Attributes.Add("style", $"background-color: {"var(--rz-secondary-dark)"};");
            else
                args.Attributes.Add("style", $"background-color: {(args.Data.OnePpsPresentAlert ? DangerColor : "var(--rz-success)" )};");       
        }
        if (args.Column.Property == "TenMhzLocked")
        {
            if(args.Data.CommsOkAlert)
                args.Attributes.Add("style", $"background-color: {"var(--rz-secondary-dark)"};");
            else
                args.Attributes.Add("style", $"background-color: {(args.Data.TenMhzLockedAlert ? DangerColor : "var(--rz-success)" )};");
        }
        if (args.Column.Property == "MeasuredDelay")
        {
            if(args.Data.CommsOkAlert)
                args.Attributes.Add("style", $"background-color: {"var(--rz-secondary-dark)"};");
            else
                args.Attributes.Add("style", $"background-color: {(args.Data.MeasuredDelayAlert ? DangerColor : "var(--rz-success)" )};");
        }
        if (args.Column.Property == "MeasuredNetworkRate")
        {
            if(args.Data.CommsOkAlert)
                args.Attributes.Add("style", $"background-color: {"var(--rz-secondary-dark)"};");
            else
                args.Attributes.Add("style", $"background-color: {(args.Data.MeasuredNetworkRateAlert ? DangerColor : "var(--rz-success)" )};");
        }
        if (args.Column.Property == "StreamEnable")
        {
            if(args.Data.CommsOkAlert)
                args.Attributes.Add("style", $"background-color: {"var(--rz-secondary-dark)"};");
            else
                args.Attributes.Add("style", $"background-color: {(args.Data.StreamEnableAlert ? DangerColor : "var(--rz-success)" )};");
        }
        if (args.Column.Property == "RfOutputEnable")
        {
            if(args.Data.CommsOkAlert)
                args.Attributes.Add("style", $"background-color: {"var(--rz-secondary-dark)"};");
            else
                args.Attributes.Add("style", $"background-color: {(args.Data.RfOutputEnableAlert ? DangerColor : "var(--rz-success)" )};");
        }
 
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

internal class MTT
{
    public string Column { get; set; }
    public string Name { get; set; }

}