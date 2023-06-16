using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
using SnnbFailover.Server.Models.SNNBStatus;
using SnnbFailover.Shared.Models;

namespace SnnbFailover.Server.Hubs;


public class UpdateHub : Hub
{

    public override Task OnConnectedAsync()
    {
        return base.OnConnectedAsync();
    }

    public void SendMessage(SNNBStatus sNNBStatus)
    {
        this.Clients.All.SendAsync("UpdateSummary", sNNBStatus);
    }

}
