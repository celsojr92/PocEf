using PocEf;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddEntityFrameworkNpgsql();
builder.Services.AddApplicationBootstrapper(configuration);
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();