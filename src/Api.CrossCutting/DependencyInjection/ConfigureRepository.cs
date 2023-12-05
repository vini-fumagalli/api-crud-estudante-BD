using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.CrossCutting.DependencyInjection;

public class ConfigureRepository
{
    public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection, string chave)
    {
        serviceCollection.AddScoped(typeof(IStudentRepository), typeof(StudentRepository));

        string connectionStringMyContext = Environment.GetEnvironmentVariable(chave, EnvironmentVariableTarget.Machine)!;
        serviceCollection.AddDbContext<MyContext>(
            options => options.UseSqlServer(connectionStringMyContext));
    }
}