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
            policy.WithOrigins("http://localhost:3002") // Allowings React frontend
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Load MongoDB settings from `appsettings.json`
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDB"));

// Register UserService
builder.Services.AddSingleton<UserService>();

// Enable Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Apply CORS Policy
app.UseCors("AllowReactApp");

app.UseRouting();
app.MapControllers();
app.Run();
