var builder = WebApplication.CreateBuilder(args);

var proxy = builder.Services.AddReverseProxy();
proxy.LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.MapReverseProxy();
app.MapGet("/", () => "Hello World!");

app.Run();