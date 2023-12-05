using Api.Domain.Interfaces.Repositories;
using Api.Service.Services;

namespace Api.CrossCutting.DependencyInjection;

public class ConfigureService
{
    public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IStudentService, StudentService>();
    }
}