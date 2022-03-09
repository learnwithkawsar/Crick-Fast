using Player.API.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


//builder.Host.UseSerilog((ctx, lc) => lc
//    .WriteTo.Console());


var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddSerilog(logger);
logger.Information(builder.Configuration.GetConnectionString("DefaultConnection"));
logger.Information("Player Service Starting....");
// Add services to the container.
builder.Services.AddInfrastructureServices(builder.Configuration);



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
