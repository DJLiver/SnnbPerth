using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using SnnbFailover.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
//builder.RootComponents.Add<App>("#app");
//builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddTransient(sp => new HttpClient{BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
builder.Services.AddScoped<SnnbFailover.Client.FailoverService>();
builder.Services.AddScoped<SnnbFailover.Client.SNNBStatusService>();
var host = builder.Build();
await host.RunAsync();