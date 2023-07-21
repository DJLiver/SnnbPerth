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

        await InvokeAsync(() => StateHasChanged());
    }

    private string GetSummaryStatus(IEnumerable<RtMonitorTable> m)
    {
        string ret = "bg-dark";
        if (m.Any(x => x.CommsOkAlert || x.OnePpsPresentAlert || x.MeasuredDelayAlert || x.DateTimeStampAlert || x.MeasuredNetworkRateAlert || x.RfOutputEnableAlert || x.StreamEnableAlert || x.TenMhzLockedAlert))
        {
            ret = "bg-danger";
        }
        else
        {
            ret = "bg-success";
        }
        return ret;
    }

    //private string GetSummaryStatus(string v)
    //{
    //}

    #endregion

    #region DataGrid

    void CellRender(DataGridCellRenderEventArgs<RtMonitorTable> args)
    {
        if (args.Column.Property == "DateTimeStamp")
        {
            args.Attributes.Add("style", $"background-color: {(args.Data.DateTimeStampAlert ? "var(--rz-danger)" : "var(--rz-success)" )};");
        }
            
        if (args.Column.Property == "CommsOk")
        {
            args.Attributes.Add("style", $"background-color: {(args.Data.CommsOkAlert ? "var(--rz-danger)" : "var(--rz-success)" )};");
        }
        
        if (args.Column.Property == "OnePpsPresent")
        {
            if(args.Data.CommsOkAlert)
                args.Attributes.Add("style", $"background-color: {"var(--rz-secondary-dark)"};");
            else
                args.Attributes.Add("style", $"background-color: {(args.Data.OnePpsPresentAlert ? "var(--rz-danger)" : "var(--rz-success)" )};");       
        }
        if (args.Column.Property == "TenMhzLocked")
        {
            if(args.Data.CommsOkAlert)
                args.Attributes.Add("style", $"background-color: {"var(--rz-secondary-dark)"};");
            else
                args.Attributes.Add("style", $"background-color: {(args.Data.TenMhzLockedAlert ? "var(--rz-danger)" : "var(--rz-success)" )};");
        }
        if (args.Column.Property == "MeasuredDelay")
        {
            if(args.Data.CommsOkAlert)
                args.Attributes.Add("style", $"background-color: {"var(--rz-secondary-dark)"};");
            else
                args.Attributes.Add("style", $"background-color: {(args.Data.MeasuredDelayAlert ? "var(--rz-danger)" : "var(--rz-success)" )};");
        }
        if (args.Column.Property == "MeasuredNetworkRate")
        {
            if(args.Data.CommsOkAlert)
                args.Attributes.Add("style", $"background-color: {"var(--rz-secondary-dark)"};");
            else
                args.Attributes.Add("style", $"background-color: {(args.Data.MeasuredNetworkRateAlert ? "var(--rz-danger)" : "var(--rz-success)" )};");
        }
        if (args.Column.Property == "StreamEnable")
        {
            if(args.Data.CommsOkAlert)
                args.Attributes.Add("style", $"background-color: {"var(--rz-secondary-dark)"};");
            else
                args.Attributes.Add("style", $"background-color: {(args.Data.StreamEnableAlert ? "var(--rz-danger)" : "var(--rz-success)" )};");
        }
        if (args.Column.Property == "RfOutputEnable")
        {
            if(args.Data.CommsOkAlert)
                args.Attributes.Add("style", $"background-color: {"var(--rz-secondary-dark)"};");
            else
                args.Attributes.Add("style", $"background-color: {(args.Data.RfOutputEnableAlert ? "var(--rz-danger)" : "var(--rz-success)" )};");
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