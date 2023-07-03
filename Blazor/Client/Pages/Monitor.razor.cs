using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;

using Radzen;

using SnnbDB.ModelExt;

namespace Failover.Client.Pages;

public partial class Monitor
{
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

    #region Hub

    private HubConnection hubConnection = null;
    protected override async Task OnInitializedAsync()
    {
        try
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/UpdateHub"))
                .Build();
            hubConnection.On<rtStatus>("RT Status", recd);
            await hubConnection.StartAsync();

        }
        catch (Exception ex)
        {
        }    
    }
    private async void recd(rtStatus rtStatus)
    {
//rtStatus.SpecNetGroups.
        await InvokeAsync(() => StateHasChanged());
    }


    #endregion

}