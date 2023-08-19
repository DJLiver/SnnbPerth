using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.SignalR.Client;
using SnnbDB.ModelExt;
using SnnbDB.ModelHub;
using System.Net.Http.Headers;

namespace Failover.Client.Pages;


public partial class Experimental
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

    private HubConnection hubConnection = null;
    RtSpectrum Spectrum = new(true);

    //List<RtSpectrumChart> charts = new List<RtSpectrumChart>(); 

    protected override async Task OnInitializedAsync()
    {
        try
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/UpdateHub"))
                .Build();
            hubConnection.On<RtSpectrum>("RT Spectrum", RecDataAsync);
            await hubConnection.StartAsync();

        }
        catch (Exception ex)
        {
        }
       // await base.OnInitializedAsync();
    }

    private async Task RecDataAsync(RtSpectrum spectrum)
    {
        Spectrum = spectrum;
        //rtSpectrumChart = spectrum.Charts[0];
        //rtSpectrumChart.FillChartData();
        await InvokeAsync(StateHasChanged);

    }
}