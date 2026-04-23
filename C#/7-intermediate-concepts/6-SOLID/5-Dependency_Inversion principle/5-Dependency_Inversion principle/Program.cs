using _5_Dependency_Inversion_principle;
using _5_Dependency_Inversion_principle.DataBase;
using _5_Dependency_Inversion_principle.Repositories;
using _5_Dependency_Inversion_principle.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer("Server=localhost;DataBase=CrudWithIlogger;Trusted_Connection=True;TrustServerCertificate=True"));

        services.AddScoped<UserRepository>();
        services.AddScoped<UserService>();
        services.AddScoped<LogRepository>();

        var option = "";
        while (option != "1" && option != "2")
        {
            Console.Write("Enter the form number to register and save the session logs (1.FILE - 2.DATABASE ): ");
            option = Console.ReadLine().Trim();
        }

        if (option == "1") { 
            services.AddScoped<IAppLogger, FileAppLoggerImpl>();
            services.AddScoped<IAppLogReader, FileAppLoggerImpl>();
        }
        else { 
            services.AddScoped<IAppLogger, DatabaseAppLoggerImpl>();
            services.AddScoped<IAppLogReader, DatabaseAppLoggerImpl>();
        }

        var provider = services.BuildServiceProvider();

        var userService = provider.GetRequiredService<UserService>();
        var iAppLogReader = provider.GetRequiredService<IAppLogReader>();

        Management m = new Management(userService, iAppLogReader);
        await m.MainMenu();
    }
}



