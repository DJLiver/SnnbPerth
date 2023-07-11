using Common;

using RestSharp;

using SnnbDB.Models;


namespace SnnbFailover.Server.Services;

class CollectTimer : iStartStop
{
    public HSpectralNetGroup target { get; set; }

    private Timer pollTimer;
    private bool MeasurementInProgress = false;
    private bool MeasurementInProgressFirstMessage = true;
    internal Action<object, SnnbCommPack> SNDataEvent;
    //internal Action<object, ErrorData> ErrorEvent;

    #region Start/Stop
    public void Start()
    {
        pollTimer = new Timer(new TimerCallback(PollUnitNow));
        pollTimer.Change(0, /*target.Period*/2000);
    }
    public void Stop()
    {
        pollTimer.Change(Timeout.Infinite, Timeout.Infinite);
    }

    #endregion

    #region Poll unit
    private void PollUnitNow(object state)
    {
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
        //Task<string> content = null;
        string content = null;
        try
        {
            content = GetResponse();
            //content = GetResponseAsync();
        }
        catch (Exception ex)
        {
            MeasurementInProgress = false;
//               OnError( ex.Message);
            //OnSNData(new SNdata() { DateStamp = DateTime.UtcNow, Data = null, Name = target.Name });
            return;
        }

        try
        {
            //SNModule sNModule = JsonConvert.DeserializeObject<SNModule>(content);
            //OnSNData(new SNdata() { DateStamp = DateTime.UtcNow, Data = sNModule, Name = target.Name });

        }
        catch (Exception ex)
        {
          //  OnError(ex.Message);
        }
        MeasurementInProgress = false;
    }
    private string GetResponse()
    {
        RestResponse response = null;
        try
        {
            RestClient client = new RestClient(target.IpAddress);
            RestRequest request = new RestRequest("tttt");
            response = client.Get(request);
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

    private async Task<string> GetResponseAsync()
    {
        RestClient client = new RestClient(target.IpAddress);
        RestRequest request = new RestRequest("tttt");
        var response = await client.ExecuteAsync(request);
        if (response.IsSuccessful)
        {
            return response.Content;
        }
        else
            throw new Exception("No response from " + target.UnitName);
     }


    #endregion

    #region Actions
    //protected void OnSNData(SNdata e)
    //{
    //    SNDataEvent?.Invoke(this, e);
    //}
    //protected void OnError( string message)
    //{
    //    var e = new ErrorData()
    //    {
    //        DateTime = DateTime.UtcNow,
    //        Source = Utilities.NameOfCallingClass(),
    //        Message = message,
    //    };
    //    ErrorEvent?.Invoke(this, e);
    //}

    #endregion
}
