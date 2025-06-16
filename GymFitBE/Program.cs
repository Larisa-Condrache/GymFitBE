using System.Reflection;
using GymFitBE;
using GymFitBE.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// prepare edm model for postgresql database
builder.Services.AddDbContext<GymFitContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("gymFit")));

// Add OData support for the controllers
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Client>("Clients");

builder.Services.AddControllers()
    .AddOData(opt =>
        opt.Select().Filter().OrderBy().Expand().SetMaxTop(100).AddRouteComponents("odata", modelBuilder.GetEdmModel()));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Testare pentru database connection
Console.WriteLine($"🔧 Connection String: {builder.Configuration.GetConnectionString("gymFit")}");
Console.WriteLine($"📦 Environment: {app.Environment.EnvironmentName}");


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<GymFitContext>();
    try
    {
        var clientCount = db.Clients.Count();
        Console.WriteLine($"✅ Connected to database! Client count: {clientCount}");
    }
    catch (Exception ex)
    {
        Console.WriteLine("❌ Failed to connect to the database.");
        Console.WriteLine(ex.Message);
    }
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
