using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;

using SnnbDB.ModelExt;


namespace SnnbFailover.Server.Hubs;


public class UpdateHub : Hub
{

    public override Task OnConnectedAsync()
    {
        return base.OnConnectedAsync();
        //A comment for GIT
    }

    public void SendMessage(rtStatus rtStatus)
    {
        this.Clients.All.SendAsync("RT Status", rtStatus);
    }

}
