using Autofac;
using SodukuSolver.Business.Factories;
using SodukuSolver.Business.Interfaces;
using SodukuSolver.Utility.Concrete;
using SodukuSolver.Utility.Interfaces;
using SudokuSolver.ViewModel.Concrete;

namespace SudokuSolver.ViewModel.Extensions;

public static class ContainerBuilderExtensions
{
    public static void RegisterDependencies(this ContainerBuilder builder, ISettings settings)
    {
        builder.RegisterInstance<ISettings>(settings);
        builder.RegisterType<Parser>().As<IParser>();
        builder.RegisterType<FileReader>().As<IFileReader>();
        builder.RegisterType<DataProvider>().As<IDataProvider>();
        builder.RegisterType<FieldFactory>().As<IFieldFactory>();
        builder.RegisterType<RowViewModel>();
        builder.RegisterType<SudokuSolverViewModel>();
    }
}
