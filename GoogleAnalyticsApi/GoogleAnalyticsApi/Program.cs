using System;
using System.Threading.Tasks;
using Google.Apis.Analytics.v3.Data;
using GoogleAnalyticsApi.Application;

namespace GoogleAnalyticsApi
{
    internal class Program
    {
        private static IGoogleAnalyticsDataServiceV1 _analyticsDataService;

        private static void Main()
        {
            BootstrapApplication();

            WriteWelcomeMessageToConsole();

            try
            {
                Run().Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static async Task Run()
        {
            var readLine = Console.ReadLine();
            if (readLine == null)
                return;

            switch (readLine)
            {
                case "Active Users":
                    Console.WriteLine("Executing Active Users request...");
                    var task =  _analyticsDataService.GetCurrentActiveUsers();

                    if (task != null)
                    {
                        var activeUsers = task.Result;
                        Console.WriteLine($"The current number of active users is {activeUsers}");
                    }
                    else
                        Console.WriteLine($"Unable to obtain results for command {readLine}");

                    Console.Read();
                    break;

                default:
                    WriteUnknownCommandEnteredMessageToConsole(readLine);
                    Console.Read();
                    break;
            }
        }

        private static void WriteWelcomeMessageToConsole()
        {
            Console.WriteLine("Hello");
            Console.WriteLine("Please enter a command...");
        }

        private static void WriteUnknownCommandEnteredMessageToConsole(string command)
        {
            Console.WriteLine($"{command} is an unknown command.");
            Console.WriteLine("Press enter to close the application.");
        }

        private static void BootstrapApplication()
        {
            Bootstrap.Start();
            _analyticsDataService = Bootstrap.Container.GetInstance<IGoogleAnalyticsDataServiceV1>();
        }
    }
}
