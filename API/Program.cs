using System.Configuration;
using API.Data;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(
    options =>
    {
        options.UseMySql(builder.Configuration.GetConnectionString("ContentCachingMechDB"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.1.0-mysql"));
    }
);

builder.Services.AddSingleton<IConnectionMultiplexer>(c =>
    {
        var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis")!, true);
        return ConnectionMultiplexer.Connect(configuration);
    });

builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", policy =>
            {
                policy
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithOrigins("http://localhost:3000");

            }
        );
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();
app.MapFallbackToController("Index", "Fallback");

// Creating Scope for automated DB creation ======================
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedData(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");
    // throw;
}
//================================================================
await app.RunAsync();
