using Microsoft.AspNetCore.SignalR.Client;
using SnnbDB.ModelExt;

namespace Failover.Client.Shared;

public partial class MainLayout
{
    private string DataTimeStamp = DateTime.Now.ToString("ddMMMyyyy HH:mm:ss");
    private RadzenText dt;
    bool sidebarExpanded = true;
    private HubConnection hubConnection = null;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/UpdateHub"))
                .Build();
            hubConnection.On<RtMainLayout>("RT MainLayout", RecDataAsync);
            await hubConnection.StartAsync();

        }
        catch (Exception)
        {

        }
    }

    private async Task RecDataAsync(RtMainLayout rtMainLayout)
    {
        DataTimeStamp = rtMainLayout.DateTimeStamp.ToString("ddMMMyyyy HH:mm:ss");
       
        await InvokeAsync(() => StateHasChanged());
    }

    void SidebarToggleClick()
    {
        sidebarExpanded = !sidebarExpanded;
    }
}