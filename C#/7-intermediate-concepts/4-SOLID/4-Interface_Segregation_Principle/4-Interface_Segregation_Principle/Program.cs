using _4_Interface_Segregation_Principle;
using _4_Interface_Segregation_Principle.DataBase;
using _4_Interface_Segregation_Principle.Repositories;
using _4_Interface_Segregation_Principle.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer("Server=localhost;DataBase=ActivityManager;Trusted_Connection=True;TrustServerCertificate=True"));

        services.AddScoped<UserRepository>();
        services.AddScoped<UserService>();
        services.AddScoped<ActivityRepository>();
        services.AddScoped<ActivityService>();

        var provider = services.BuildServiceProvider();

        var userService = provider.GetRequiredService<UserService>();
        var activityService = provider.GetRequiredService<ActivityService>();

        ActivityManagement am = new ActivityManagement(userService, activityService);

        await am.MainMenu();

        Console.ReadKey();
    }
}