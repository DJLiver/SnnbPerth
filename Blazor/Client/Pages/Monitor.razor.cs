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
    private string[] StatusStyles = {
        "width: 112px; height: 31px; border-radius: 6px; vertical-align: bottom; padding-top: 4px; margin-top: 4px; border: 3px solid #278e26",
        "width: 112px; height: 31px; border-radius: 6px; vertical-align: bottom; padding-top: 4px; margin-top: 4px; border: 3px solid #8d2108",
        "width: 112px; height: 31px; border-radius: 6px; vertical-align: bottom; padding-top: 4px; margin-top: 4px; border: 3px solid #989594"
    };
    private int PrimaryStatusStylesIndex = 2;
    private int SecondaryStatusStylesIndex = 2;
    private string[] PathStyles = {
        "width: 170px; height: 31px; border-radius: 6px; padding-top: 4px; margin-top: 4px; margin-left: 20px; vertical-align: bottom; border: 3px solid #278e26",
        "width: 170px; height: 31px; border-radius: 6px; padding-top: 4px; margin-top: 4px; margin-left: 20px; vertical-align: bottom; border: 3px solid #8d2108",
        "width: 170px; height: 31px; border-radius: 6px; padding-top: 4px; margin-top: 4px; margin-left: 20px; vertical-align: bottom; border: 3px solid #989594",
        "width: 170px; height: 31px; border-radius: 6px; padding-top: 4px; margin-top: 4px; margin-left: 20px; vertical-align: bottom; border: 3px solid #f0aa4a"
    };
    private int PrimaryPathStylesIndex = 2;
    private int SecondaryPathStylesIndex = 2;
    enum Level
    {
        Good,
        Bad,
        Unknown,
        Caution
    }
private string CommsText = "NAAA";

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
        PrimaryStatusStylesIndex = GetSummaryStatus(MonitorTablePrimary);
        SecondaryStatusStylesIndex = GetSummaryStatus(MonitorTableSecondary);
        //SecondaryStatus = GetSummaryStatus(MonitorTableSecondary);
        (int index, string txt) v1 = GetPathStatus(MonitorTablePrimary);
        (int index, string txt) v2 = GetPathStatus(MonitorTableSecondary);

        PrimaryPathStylesIndex = v1.index;
        SecondaryPathStylesIndex = v2.index;
       //SecondaryPath = v2.bg;
        PrimaryPathTxt = v1.txt;
        SecondaryPathTxt = v2.txt;


        await InvokeAsync(() => StateHasChanged());
    }

    private int GetSummaryStatus(IEnumerable<RtMonitorTable> m)
    {
        int ret = 2;
        if (m.Any(x => x.CommsOkAlert || x.OnePpsPresentAlert || x.MeasuredDelayAlert || x.DateTimeStampAlert || x.MeasuredNetworkRateAlert  || x.TenMhzLockedAlert))
        {
            ret = (int)Level.Bad;
        }
        else
        {
            ret = (int)Level.Good;
        }
        return ret;
    }
    
    private (int index, string txt) GetPathStatus(IEnumerable<RtMonitorTable> m)
    {
        int index = 2;
        string txt = "None on this path";
        if (m.All(x => x.RfOutputEnableAlert || x.StreamEnableAlert))
        {
            index = (int)Level.Bad;
            txt = "None on this path";
        }
        else if (m.Any(x => x.RfOutputEnableAlert || x.StreamEnableAlert))
        {
            index = (int)Level.Caution; //--rz-warning
            txt = "Some on this path";
        }
        else
        {
            index = (int)Level.Good;
            txt = "All on this path";
        }

        return (index,txt);
    }


    //private string GetSummaryStatus(string v)
    //{
    //}

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

internal class MTT
{
    public string Column { get; set; }
    public string Name { get; set; }

}