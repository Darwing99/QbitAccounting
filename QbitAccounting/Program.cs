using ClassLibraryBLL.Implementacion;
using ClassLibraryBLL.Interfaces;
using ClassLibraryDAL;
using ClassLibraryDAL.Implementacion;
using ClassLibraryDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace QbitAccounting
{
    internal static class Program
    {
        public static IConfigurationRoot configuration;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            using (var service=serviceCollection.BuildServiceProvider())
            {
                var form1=service.GetRequiredService<FrmLogin>();
                Application.Run(form1);
            }
         //   Application.Run(new Form1());
        }

        public  static void ConfigureServices(IServiceCollection Service)
        {
            // Add logging
            Service.AddDbContext<DbaccountingContext>(builderOptions =>
            {
                builderOptions.UseSqlServer(configuration.GetConnectionString("MyDBAccounting"));
            });
            Service.AddLogging();

            // Build configuration
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            // Add access to generic IConfigurationRoot
            Service.AddSingleton<IConfigurationRoot>(configuration);


            Service.AddScoped<FrmLogin>();
        }
    }
   
}