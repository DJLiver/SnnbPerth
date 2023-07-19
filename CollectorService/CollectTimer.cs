using Common;

using Newtonsoft.Json;

using RestSharp;

using SnnbDB.Models;
using SnnbDB.Rest;

namespace SnnbFailover.Server.Services;

class CollectTimer : iStartStop
{
    public HSpectralNetGroup target { get; set; }
    public HSystemParam hSystemParam { get; set; }


    private Timer pollTimer;
    private bool MeasurementInProgress = false;
    private bool MeasurementInProgressFirstMessage = true;
    internal Action<object, SnnbCommPack> SNDataEvent;
    //internal Action<object, HLog> ErrorEvent;

    #region Start/Stop
    public void Start()
    {
        pollTimer = new Timer(new TimerCallback(PollUnitNow));
        pollTimer.Change(0, hSystemParam.PollPeriod);
    }


    public void Stop()
    {
        pollTimer.Change(Timeout.Infinite, Timeout.Infinite);
    }

    #endregion

    #region Get SNData And store In DB
    //private void PollUnitNow(object? state)
    //{
    //    _ = GetSNDataAndStoreInDB(target, hSystemParam);
    //}

    //private async Task GetRestData(CancellationToken stoppingToken)
    //{
    //    SnnbFoContext sc = new SnnbFoContext();
    //    List<HSpectralNetGroup> t = sc.HSpectralNetGroups.ToList();
    //    HSystemParam hSystemParam = sc.HSystemParams.First();

    //    var TaskList = new List<Task>();

    //    foreach (HSpectralNetGroup specNetGroup in t)
    //    {
    //        if (specNetGroup.Enabled)
    //        {
    //            TaskList.Add(GetSNDataAndStoreInDB(specNetGroup, hSystemParam));
    //        }
    //    }
    //    Task.WaitAll(TaskList.ToArray());
    //}

    //private async Task GetSNDataAndStoreInDB(HSpectralNetGroup specNetGroup, HSystemParam hSystemParam)
    //{
    //    RestClient client;
    //    RestResponse response = null!;
    //    SnnbCommPack scp = new SnnbCommPack();
    //    scp.SpectralNetGroup = specNetGroup;
    //    scp.Error = false;
    //    scp.ErrorText = "No error";
    //    Stopwatch _stopwatch = new Stopwatch();

    //    try
    //    {
    //        _stopwatch.Start();
    //        client = new RestClient(hSystemParam.PreIpAddress + specNetGroup.IpAddress);
    //        //response = client.Get(new RestRequest(hSystemParam.RestQuery) { Timeout = 300 });
    //        response = await client.ExecuteGetAsync(new RestRequest(hSystemParam.RestQuery) { Timeout = 500 });
    //        _stopwatch.Stop();
    //        scp.ResponseTime = (int)_stopwatch.ElapsedMilliseconds;
    //        if (response is null) throw new Exception($"Response is NULL: {specNetGroup.UnitId} ");

    //        if (!response.IsSuccessful) throw new Exception($"Response is not successful - {specNetGroup.UnitId}:{response.ResponseStatus}");

    //        if (response.Content is null) throw new Exception($"Content is NULL: {specNetGroup.UnitId}");

    //        RestMain restMain = JsonConvert.DeserializeObject<RestMain>(response.Content);
    //        scp.RestMain = restMain;


    //    }
    //    catch (Exception ex)
    //    {
    //        scp.Error = true;
    //        scp.ErrorText = ex.Message;
            
    //        ExLog.Log(ex);
    //    }
    //    finally
    //    {
    //        OnSNData(scp);
    //        //scp.PopulateDB();
    //    }
    //}

    #endregion

    #region Actions
    protected void OnSNData(SnnbCommPack e)
    {
        SNDataEvent?.Invoke(this, e);
    }
    protected void OnError(Exception e)
    {
      //  ErrorEvent?.Invoke(this, HLog.FormEntry(e));
    }

    #endregion

    #region Poll unit
    private void PollUnitNow(object? state)
    {
        SnnbCommPack scp = new SnnbCommPack();
        scp.SpectralNetGroup = target;
        scp.Error = false;
        scp.ErrorText = "No error";

        //Prevent reentry
        if (MeasurementInProgress)
        {
            if (MeasurementInProgressFirstMessage)
            {
                //OnError( "Re-entry : " + target.Name);
                MeasurementInProgressFirstMessage = false;
            }
            return;
        }
        MeasurementInProgress = true;
        MeasurementInProgressFirstMessage = true;

        string content = String.Empty;
        try
        {
            content = GetResponse();
            RestMain restMain = JsonConvert.DeserializeObject<RestMain>(content);
            scp.RestMain = restMain;
            OnSNData(scp);
        }

        catch (Exception ex)
        {
            HLog.AddEntry(ex);
        }
        finally { MeasurementInProgress = false; }
    }
    private string GetResponse()
    {
        IRestResponse response = null;
        try
        {
            RestClient client = new RestClient(hSystemParam.PreIpAddress + target.IpAddress) { Timeout = hSystemParam.Timeout };
            
            RestRequest request = new RestRequest("/" + hSystemParam.RestQuery);
            response = client.Get(request) ;
            if (response.IsSuccessful)
            {
                return response.Content;
            }
            throw new Exception("No response from " + target.UnitName);

        }
        catch (Exception)
        {
            throw;
        }
    }

    //    private async Task<string> GetResponseAsync()
    //    {
    //        RestClient client = new RestClient(target.IpAddress);
    //        RestRequest request = new RestRequest("tttt");
    //        var response = await client.ExecuteAsync(request);
    //        if (response.IsSuccessful)
    //        {
    //            return response.Content;
    //        }
    //        else
    //            throw new Exception("No response from " + target.UnitName);
    //     }


    #endregion

}
