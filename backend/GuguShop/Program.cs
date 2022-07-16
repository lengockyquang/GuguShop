using GuguShop.Application.Extensions;
using GuguShop.GridFsApplication.Extensions;
using GuguShop.Infrastructure.Extensions;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

builder.Services.SetupInfrastructure(configuration);
builder.Services.SetupAuthentication();
builder.Services.SetupMiniProfiler();
builder.Services.SetupApplication();
builder.Services.SetupMongoGridFs(configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.SetupSerilogHostBuilder();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseLoggingMiddleware();
app.UseMiniProfiler();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();