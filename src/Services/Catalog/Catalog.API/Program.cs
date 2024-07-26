var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config => { config.RegisterServicesFromAssembly(assembly); });

builder.Services.AddCarter();

var app = builder.Build();

app.MapCarter();

app.Run();