using Radzen;

using SnnbDB.ModelExt;

namespace Failover.Client.Pages;

public partial class NetworkPathDG
{
    public IEnumerable<RtMonitorTable> MonitorTable { get; set; }

    private string[] StatusStyles = {
        "width: 112px; height: 31px; border-radius: 6px; vertical-align: bottom; padding-top: 4px; margin-top: 4px; border: 3px solid #278e26",
        "width: 112px; height: 31px; border-radius: 6px; vertical-align: bottom; padding-top: 4px; margin-top: 4px; border: 3px solid #8d2108",
        "width: 112px; height: 31px; border-radius: 6px; vertical-align: bottom; padding-top: 4px; margin-top: 4px; border: 3px solid #989594"
    };
    private int StatusStylesIndex = 2;
    private string[] PathStyles = {
        "width: 170px; height: 31px; border-radius: 6px; padding-top: 4px; margin-top: 4px; margin-left: 20px; vertical-align: bottom; border: 3px solid #278e26",
        "width: 170px; height: 31px; border-radius: 6px; padding-top: 4px; margin-top: 4px; margin-left: 20px; vertical-align: bottom; border: 3px solid #8d2108",
        "width: 170px; height: 31px; border-radius: 6px; padding-top: 4px; margin-top: 4px; margin-left: 20px; vertical-align: bottom; border: 3px solid #989594",
        "width: 170px; height: 31px; border-radius: 6px; padding-top: 4px; margin-top: 4px; margin-left: 20px; vertical-align: bottom; border: 3px solid #f0aa4a"
    };
    private int PathStylesIndex = 2;
    enum Level
    {
        Good,
        Bad,
        Unknown,
        Caution
    }
    private string PathStyle = "bg-dark";
    private string PathText = "Undetermined";
 
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