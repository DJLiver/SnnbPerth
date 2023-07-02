using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.ResponseCompression;
using Radzen;
using SnnbFailover.Server.Hubs;
using SnnbFailover.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData;
using ExceptionLog;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddSingleton<TimerService>();
builder.Services.AddHostedService(sp => sp.GetRequiredService<TimerService>());
builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]{"application/octet-stream"});
});
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddSingleton(sp =>
{
    // Get the address that the app is currently running at
    var server = sp.GetRequiredService<IServer>();
    var addressFeature = server.Features.Get<IServerAddressesFeature>();
    string baseAddress = addressFeature.Addresses.First();
    return new HttpClient{BaseAddress = new Uri(baseAddress)};
});
builder.Services.AddScoped<SnnbFailover.Server.FailoverService>();
builder.Services.AddDbContext<SnnbFailover.Server.Data.FailoverContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FailoverConnection"));
});
builder.Services.AddControllers().AddOData(opt =>
{
    var oDataBuilderFailover = new ODataConventionModelBuilder();
    oDataBuilderFailover.EntitySet<SnnbFailover.Server.Models.Failover.Control>("Controls");
    oDataBuilderFailover.EntitySet<SnnbFailover.Server.Models.Failover.EventLog>("EventLogs");
    opt.AddRouteComponents("odata/Failover", oDataBuilderFailover.GetEdmModel()).Count().Filter().OrderBy().Expand().Select().SetMaxTop(null).TimeZone = TimeZoneInfo.Utc;
});
builder.Services.AddScoped<SnnbFailover.Client.FailoverService>();
builder.Services.AddScoped<SnnbFailover.Server.SNNBStatusService>();
builder.Services.AddDbContext<SnnbFailover.Server.Data.SNNBStatusContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SNNBStatusConnection"));
});
builder.Services.AddScoped<SnnbFailover.Client.SNNBStatusService>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.MapControllers();
var t = app.MapHub<UpdateHub>("/UpdateHub");
app.MapFallbackToPage("/_Host");
ExLog.Log(new Exception( "Application starting" ));
app.Run();