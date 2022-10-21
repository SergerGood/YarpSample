using Yarp.ReverseProxy.Configuration;
using YarpSample.Proxy.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IProxyConfigProvider, ProxyConfigProvider>();

var proxy = builder.Services.AddReverseProxy();
// proxy.LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.MapReverseProxy();
app.MapGet("/", () => "Hello World!");

app.Run();