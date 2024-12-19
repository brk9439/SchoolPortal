using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using SchoolPortal.Api.Extensions;
using SchoolPortal.Business.Extensions;
using SchoolPortal.Infrastruct.Domain.Context;
using SchoolPortal.Infrastruct.Extension;
using SchoolPortal.Shared.Common;

var builder = WebApplication.CreateBuilder(args);
#if DEBUG
Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
#endif
#if RELEASE
Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Production");
#endif

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: false, reloadOnChange: true)
    .Build();
// Add services to the container.
builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    //AddSwaggerXml(options);
    options.UseInlineDefinitionsForEnums();
    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SchoolPortal.Api",
        Version = "v1",
        Description = "SchoolPortal"
    });
});

#region PostgreSQL
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
BusinessExtension.Service(builder.Services, configuration);

#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations(); // Migration komutlarýný proje calýþmaya baþladýðýnda DB'de calýstýrýr.
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();
