var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy();

var app = builder.Build();

app.MapReverseProxy();
app.MapGet("/", () => "Hello World!");

app.Run();