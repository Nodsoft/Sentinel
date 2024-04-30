using System.Diagnostics;
using Nodsoft.Sentinel.Agent;
using Serilog;
using Serilog.Events;

Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));

// Serilog Logger
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console(applyThemeToRedirectedOutput: true)
    .CreateBootstrapLogger();

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSerilog(static (services, lc) => lc
    .ReadFrom.Configuration(services.GetRequiredService<IConfiguration>())
    .ReadFrom.Services(services)
);

builder.Services.AddHostedService<ETWMonitor>();

IHost host = builder.Build();



await host.RunAsync();