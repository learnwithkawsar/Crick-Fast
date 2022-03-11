using EventBus.Messages.Common;
using MassTransit;
using Player.API.EventBusConsumer;
using Player.API.Infrastructure;
using Serilog;
using Utilities;

var builder = WebApplication.CreateBuilder(args);


//builder.Host.UseSerilog((ctx, lc) => lc
//    .WriteTo.Console());


var logger = CommonLogging.CreateSerilogLogger(builder.Configuration, "Players-API");
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
logger.Information(builder.Configuration.GetConnectionString("DefaultConnection"));
logger.Information("Player Service Starting....");
// Add services to the container.
builder.Services.AddInfrastructureServices(builder.Configuration);

// MassTransit-RabbitMQ Configuration
builder.Services.AddMassTransit(config => {

    config.AddConsumer<TeamAssignConsumer>();

    config.UsingRabbitMq((ctx, cfg) => {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        //cfg.UseHealthCheck(ctx);

        cfg.ReceiveEndpoint(EventBusConstants.TeamAssignQueue, c => {
            c.ConfigureConsumer<TeamAssignConsumer>(ctx);
        });
    });
});
builder.Services.AddMassTransitHostedService();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
