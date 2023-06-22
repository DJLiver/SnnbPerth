using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
using SnnbFailover.Server.Models.SNNBStatus;

namespace SnnbFailover.Server.Hubs;


public class UpdateHub : Hub
{

    public override Task OnConnectedAsync()
    {
        return base.OnConnectedAsync();
        //A comment for GIT
    }

    public void SendMessage(SNNBStatus sNNBStatus)
    {
        this.Clients.All.SendAsync("UpdateSummary", sNNBStatus);
    }

}
