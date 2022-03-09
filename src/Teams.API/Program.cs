using Serilog;
using Teams.API.Infrastructure.DBContext;
using Teams.API.Infrastructure.Interfaces;
using Teams.API.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .WriteTo.Console()
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddSerilog(logger);

logger.Information("Team Service Starting....");


// Add services to the container.
builder.Services.AddScoped<ITeamContext, TeamContext>();
builder.Services.AddScoped<ITeamsRepository, TeamsRepository>();


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
