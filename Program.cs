using Jobs.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure SQL Server connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Bind to Render's dynamic PORT
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://*:{port}");

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // Render handles HTTPS externally — skip redirect inside container
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Optional: disable HTTPS redirection to prevent 308 redirect loops on Render
// Comment out if you face issues reaching the API
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Simple health-check endpoint for Render
app.MapGet("/", () => "✅ Jobs API is running successfully on Render!");

app.Run();
