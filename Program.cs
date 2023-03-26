using CallCenterCoreAPI;
using CallCenterCoreAPI.Filters;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration().
    ReadFrom.Configuration(new ConfigurationBuilder()
   .AddJsonFile("seri-log.config.json").Build())
    .Enrich.FromLogContext().
    CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();
AppSettingsHelper.AppSettingsConfigure(configuration : app.Services.GetRequiredService<IConfiguration>());



// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
    app.UseSwagger();
    app.UseSwaggerUI();
//app.UseMiddleware<HttpLoggingMiddleware>();
app.UseAuthentication();

app.MapControllers();
app.Run();

