using Autofac;
using Microsoft.Extensions.Configuration;
using SudokuSolver.Utility.Configurations;
using SudokuSolver.ViewModel.Extensions;

namespace SudokuSolver.Presentation;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        var configuration = builder.Build();

        var settings = new SudokuSettings();
        configuration.Bind(nameof(SudokuSettings), settings);

        var containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterDependencies(settings);
        containerBuilder.RegisterType<MainWindow>();

        var container = containerBuilder.Build();

        ApplicationConfiguration.Initialize();
        Application.Run(container.Resolve<MainWindow>());
    }
}
