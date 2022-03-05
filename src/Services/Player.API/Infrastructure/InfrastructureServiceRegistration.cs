using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace Player.API.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PlayerDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            //services.AddScoped<IOrderRepository, OrderRepository>();

            //services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            //services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
