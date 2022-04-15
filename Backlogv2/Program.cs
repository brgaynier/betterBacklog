using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using IHost host = CreateHostBuilder(args).Build(); 
using var scope = host.Services.CreateScope();


var services = scope.ServiceProvider;

try
{
    services.GetRequiredService<App>().Run();

}

catch (Exception ex)
{
    Console.WriteLine("an error has occurred");
    Console.ReadLine();
    services.GetRequiredService<App>().Run(); //is this legal?
    
}

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
        {
            services
                .AddSingleton<ITechnician, Technician>()
                .AddTransient<ITicket, Ticket>()
                .AddTransient<IMenu, Menu>()
                .AddTransient<IList, List>()
                .AddTransient<App>();
        });

