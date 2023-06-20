using System.Net.Http;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;

using Radzen;
using Radzen.Blazor;

using SnnbFailover.Client.Pages;
using SnnbFailover.Server.Models.SNNBStatus;
using SnnbFailover.Shared.Models;

namespace SnnbFailover.Client.Shared
{


    public partial class MainLayout 
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


        private bool sidebarExpanded = true;

        void SidebarToggleClick()
        {
            sidebarExpanded = !sidebarExpanded;
        }

        bool FlagToggle = false;

        #region Hub

        //static public List<MetricSite1Summary> data { get; set; } = null;
        private ButtonStyle buttonStyle = ButtonStyle.Success;
        private string buttonText = "Good";

        private HubConnection hubConnection = null;

        protected override async Task OnInitializedAsync()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/UpdateHub"))
                .Build();
            hubConnection.On<SNNBStatus>("UpdateSummary", recd);
            await hubConnection.StartAsync();
        }

        private async void recd(SNNBStatus arg1)
        {
            //int count1 = (from ms in arg1
            //              where (ms.RfoutmeasuredDelay < 1.9 || ms.RfoutmeasuredDelay > 2.1)
            //                  || (ms.RfoutmeasuredNetworkRate < 420 || ms.RfoutmeasuredNetworkRate > 500)
            //                  || ms.ExtCommError == true
            //              select ms).Count();

            //int count2 = (from ms in arg2
            //              where (ms.RfoutmeasuredDelay < 1.9 || ms.RfoutmeasuredDelay > 2.1)
            //                  || (ms.RfoutmeasuredNetworkRate < 420 || ms.RfoutmeasuredNetworkRate > 500)
            //                  || ms.ExtCommError == true
            //              select ms).Count();

            //if (count1 > 0 || count2 > 0)
            //{
            //    buttonStyle = ButtonStyle.Danger;
            //    buttonText = "Fault";
            //}
            //else
            //{
            //    buttonStyle = ButtonStyle.Success;
            //    buttonText = "Good";
            //}
            //FlagToggle = !FlagToggle;
            //await InvokeAsync(new Action(() => base.StateHasChanged() )) ;
        }
        public bool IsConnected => hubConnection?.State == HubConnectionState.Connected;
        public async ValueTask DisposeAsync()
        {
            if (hubConnection is not null)
            {
                await hubConnection.DisposeAsync();
            }
        }



        //    //int b1 = (from ms in arg1 where ms.RfoutmeasuredDelay < 1.9E6 || ms.RfoutmeasuredDelay > 2.1E6 select ms).Count();
        //    //int b2 = (from ms in arg1 where ms.RfoutmeasuredNetworkRate < 420E6 || ms.RfoutmeasuredDelay > 500E6 select ms).Count();

        //    //int b3 = (from ms in arg2 where ms.RfoutmeasuredDelay < 1.9E6 || ms.RfoutmeasuredDelay > 2.1E6 select ms).Count();
        //    //int b4 = (from ms in arg2 where ms.RfoutmeasuredNetworkRate < 420E6 || ms.RfoutmeasuredDelay > 500E6 select ms).Count();


        //    foreach (var item in arg1)
        //    {
        //        var v1 = item.RfoutmeasuredDelay;
        //        var v2 = item.RfoutmeasuredNetworkRate;

        //    }

        //    foreach (var item in arg2)
        //    {
        //        var v1 = item.RfoutmeasuredDelay;
        //        var v2 = item.RfoutmeasuredNetworkRate;

        //    }




        //}



        #endregion
    }
}