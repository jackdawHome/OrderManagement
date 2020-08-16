using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Repository;
using OrderManagement.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrderManagement
{
    class Program
    {
        static async Task Main(string[] args)
        {            
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken cancellationToken = source.Token;

            var serviceProvider = ConfigureServices();
            var orderService = serviceProvider.GetService<IOrderService>();
            var flightService = serviceProvider.GetService<IFlightService>();
            var orderManager = serviceProvider.GetService<IOrderManager>();


            await orderService.LoadOrders(cancellationToken);

            await flightService.LoadFlights(cancellationToken);

            await flightService.PrintFlights(cancellationToken);

            await orderManager.ScheduleOrders(cancellationToken);

            await orderService.PrintOrders(cancellationToken);


            while (true)
            {
                if (Console.ReadKey().Key != ConsoleKey.Escape) continue;

                Console.Clear();

                Console.WriteLine("Are you sure you want to close this application? (Y/N) ");
                var answer = Console.ReadLine();

                if (string.Compare(answer, "y", StringComparison.OrdinalIgnoreCase) == 0)
                    break;

                Console.Clear();
            }

            Console.WriteLine("Finishing tasks...");

            source.Cancel(true);
        }

        public static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IFlightRepository, FlightRepository>();

            services.AddTransient<IOrderService, OrderService>();            
            services.AddTransient<IFlightService, FlightService>();
            services.AddTransient<IOrderManager, OrderManager>();          

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
