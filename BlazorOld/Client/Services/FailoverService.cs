
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Radzen;

namespace SnnbFailover.Client
{
    public partial class FailoverService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;

        public FailoverService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            this.baseUri = new Uri($"{navigationManager.BaseUri}odata/Failover/");
        }


        public async System.Threading.Tasks.Task ExportControlsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/failover/controls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/failover/controls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportControlsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/failover/controls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/failover/controls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetControls(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<SnnbFailover.Server.Models.Failover.Control>> GetControls(Query query)
        {
            return await GetControls(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<SnnbFailover.Server.Models.Failover.Control>> GetControls(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Controls");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetControls(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SnnbFailover.Server.Models.Failover.Control>>(response);
        }

        partial void OnCreateControl(HttpRequestMessage requestMessage);

        public async Task<SnnbFailover.Server.Models.Failover.Control> CreateControl(SnnbFailover.Server.Models.Failover.Control control = default(SnnbFailover.Server.Models.Failover.Control))
        {
            var uri = new Uri(baseUri, $"Controls");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(control), Encoding.UTF8, "application/json");

            OnCreateControl(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SnnbFailover.Server.Models.Failover.Control>(response);
        }

        partial void OnDeleteControl(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteControl(int id = default(int))
        {
            var uri = new Uri(baseUri, $"Controls({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteControl(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetControlById(HttpRequestMessage requestMessage);

        public async Task<SnnbFailover.Server.Models.Failover.Control> GetControlById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"Controls({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetControlById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SnnbFailover.Server.Models.Failover.Control>(response);
        }

        partial void OnUpdateControl(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateControl(int id = default(int), SnnbFailover.Server.Models.Failover.Control control = default(SnnbFailover.Server.Models.Failover.Control))
        {
            var uri = new Uri(baseUri, $"Controls({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(control), Encoding.UTF8, "application/json");

            OnUpdateControl(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportEventLogsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/failover/eventlogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/failover/eventlogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportEventLogsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/failover/eventlogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/failover/eventlogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetEventLogs(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<SnnbFailover.Server.Models.Failover.EventLog>> GetEventLogs(Query query)
        {
            return await GetEventLogs(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<SnnbFailover.Server.Models.Failover.EventLog>> GetEventLogs(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"EventLogs");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEventLogs(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SnnbFailover.Server.Models.Failover.EventLog>>(response);
        }

        partial void OnCreateEventLog(HttpRequestMessage requestMessage);

        public async Task<SnnbFailover.Server.Models.Failover.EventLog> CreateEventLog(SnnbFailover.Server.Models.Failover.EventLog eventLog = default(SnnbFailover.Server.Models.Failover.EventLog))
        {
            var uri = new Uri(baseUri, $"EventLogs");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(eventLog), Encoding.UTF8, "application/json");

            OnCreateEventLog(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SnnbFailover.Server.Models.Failover.EventLog>(response);
        }

        partial void OnDeleteEventLog(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteEventLog(int id = default(int))
        {
            var uri = new Uri(baseUri, $"EventLogs({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteEventLog(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetEventLogById(HttpRequestMessage requestMessage);

        public async Task<SnnbFailover.Server.Models.Failover.EventLog> GetEventLogById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"EventLogs({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEventLogById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SnnbFailover.Server.Models.Failover.EventLog>(response);
        }

        partial void OnUpdateEventLog(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateEventLog(int id = default(int), SnnbFailover.Server.Models.Failover.EventLog eventLog = default(SnnbFailover.Server.Models.Failover.EventLog))
        {
            var uri = new Uri(baseUri, $"EventLogs({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(eventLog), Encoding.UTF8, "application/json");

            OnUpdateEventLog(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
    }
}