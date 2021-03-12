using ContosoUniversity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ContosoUniversity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //tinfo200:[2021-03-11-ex3po-dykstra1] - 
            var host = CreateHostBuilder(args).Build();
            //tinfo200:[2021-03-11-ex3po-dykstra1] - Creates a db if there are no entries in db 
            //tinfo200:[2021-03-11-ex3po-dykstra1] - Will not run if the db has content. Deleting every student in the browser will cause more students to be created but with different IDs
            //tinfo200:[2021-03-11-ex3po-dykstra1] - This is only visible in the SQL database for the IDs but wanted to point out that the ID numbers do not start at 1 if every student is deleted
            CreateDbIfNotExists(host);

            host.Run();
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SchoolContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
    //tinfo200:[2021-03-11-ex3po-dykstra1] - Note to Chuck and his team of graders :), Thank you for giving us the ability to do this course outside of campus.
    //this is really appreciated and I try to be as supportive as possible when it comes to zoom lectures. It absolutely sucks that the interaction level does
    //not compare to in person but I hope for next year being much more interactive! 2020 was hard and we are still dealing with the aftermath, but this class
    //was enjoyable. (I'm doing this note here since I usually do it during the final, but I do not have the confidence level to leave a note while being under
    // a time crunch.)
}
