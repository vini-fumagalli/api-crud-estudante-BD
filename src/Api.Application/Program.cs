using Api.CrossCutting.DependencyInjection;
using Api.CrossCutting.Mapping;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//Configurando Mapping
builder.Services.AddAutoMapper(typeof(DtoToEntityProfile));
builder.Services.AddAutoMapper(typeof(EntityToDtoResultProfile));

// Add services to the container.
//Cofigurando a Injeção de Dependência
ConfigureService.ConfigureDependenciesService(builder.Services);
ConfigureRepository.ConfigureDependenciesRepository(builder.Services, "DB_CONNECTION_ESTUDANTES");
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(s =>
        s.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Menu de Estudantes",
            Description = "Api de CRUD de Estudantes construído com arquitetura DDD e com Banco de Dados" +
            "\n\n feito através de migrações pelo EntityFramework",
            TermsOfService = new Uri("http://www.linkedin.com/in/vini-fumagalli"),
            Contact = new OpenApiContact
            {
                Name = "Vinícius Fumagalli",
                Email = "vinifumagalli_@hotmail.com",
            },
            License = new OpenApiLicense
            {
                Name = "Termo de Licença de Uso",
                Url = new Uri("http://www.linkedin.com/in/vini-fumagalli")
            }
        }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
