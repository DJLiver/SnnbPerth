using Common;

using Newtonsoft.Json;

using RestSharp;

using SnnbDB.Models;
using SnnbDB.Rest;

using System.Diagnostics;

namespace SnnbFailover.Server.Services;

class CollectTimer : iStartStop
{
    public HSpectralNetGroup spectralNetGroup { get; set; }
    public HSystemParam hSystemParam { get; set; }


    private Timer pollTimer;
    private bool MeasurementInProgress = false;
    private bool MeasurementInProgressFirstMessage = true;
    internal Action<object, SnnbCommPack> SNDataEvent;
    //internal Action<object, HLog> ErrorEvent;
    RestClient client = null;
    RestRequest request = null;

    #region Start/Stop
    public void Start()
    {
        var options = new RestClientOptions(hSystemParam.PreIpAddress + spectralNetGroup.IpAddress)
        {
            BaseUrl = new Uri( hSystemParam.PreIpAddress + spectralNetGroup.IpAddress),
            ThrowOnAnyError = true,
            MaxTimeout = 500, 
        };
        client = new RestClient(options) /*{Timeout = hSystemParam.Timeout }*/;
        //client = new RestClient(options);

        request = new RestRequest(hSystemParam.RestQuery) { Timeout = 500 };

        pollTimer = new Timer(new TimerCallback(PollUnitNow));
        pollTimer.Change(0, hSystemParam.PollPeriod);
    }


    public void Stop()
    {
        pollTimer.Change(Timeout.Infinite, Timeout.Infinite);
    }

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
        scp.SpectralNetGroup = spectralNetGroup;
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
            Stopwatch sw = new Stopwatch();

        string content = String.Empty;
        try
        {
            sw.Start();
            content = GetResponse();
            sw.Stop();

            RestMain restMain = JsonConvert.DeserializeObject<RestMain>(content);
            scp.RestMain = restMain;
        }

        catch (Exception ex)
        {
            scp.Error = true;
            scp.ErrorText = ex.Message;
            sw.Stop();
  //          HLog.AddEntry(ex);
        }
        finally
        {
            scp.ResponseTime = (int)sw.Elapsed.TotalMilliseconds;
            OnSNData(scp);
            MeasurementInProgress = false;
        }
    }
    private string GetResponse()
    {

        RestResponse response = null;
        try
        {
            response = client.Get(request);
            if (response.IsSuccessful)
            {
                return response.Content;
            }
            throw new Exception("No response from " + spectralNetGroup.UnitName);

        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion

//    #region Get SNData And store In DB
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

    //private async Task GetSNDataAndStoreInDB()
    //{
    //    RestClient client;
    //    IRestResponse response = null!;
    //    SnnbCommPack scp = new SnnbCommPack();
    //    scp.SpectralNetGroup = target;
    //    scp.Error = false;
    //    scp.ErrorText = "No error";
    //    Stopwatch _stopwatch = new Stopwatch();

    //    try
    //    {
    //        _stopwatch.Start();
    //        client = new RestClient(hSystemParam.PreIpAddress + target.IpAddress);
    //        //response = client.Get(new RestRequest(hSystemParam.RestQuery) { Timeout = 300 });
    //        response = await client.ExecuteGetAsync(new RestRequest(hSystemParam.RestQuery) { Timeout = 500 });
    //        _stopwatch.Stop();
    //        scp.ResponseTime = (int)_stopwatch.ElapsedMilliseconds;
    //        if (response is null) throw new Exception($"Response is NULL: {target.UnitId} ");

    //        if (!response.IsSuccessful) throw new Exception($"Response is not successful - {target.UnitId}:{response.ResponseStatus}");

    //        if (response.Content is null) throw new Exception($"Content is NULL: {target.UnitId}");

    //        RestMain restMain = JsonConvert.DeserializeObject<RestMain>(response.Content);
    //        scp.RestMain = restMain;


    //    }
    //    catch (Exception ex)
    //    {
    //        scp.Error = true;
    //        scp.ErrorText = ex.Message;

    //        HLog.AddEntry(ex);
    //    }
    //    finally
    //    {
    //        OnSNData(scp);
    //        //scp.PopulateDB();
    //    }
    //}


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



}
