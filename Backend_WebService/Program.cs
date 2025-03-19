using Backend_WebService.Models;
using Backend_WebService.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Adding CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // Allowing React frontend
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Loading MongoDB settings from `appsettings.json`
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDB"));

// Registering UserService
builder.Services.AddSingleton<UserService>();

// Enabling Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Applying CORS Policy
app.UseCors("AllowReactApp");

app.UseRouting();
app.MapControllers();
app.Run();
