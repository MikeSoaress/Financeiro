using Financeiro.Application.Interfaces;
using Financeiro.Application.Mappings;
using Financeiro.Application.Services;
using Financeiro.Domain.Interfaces;
using Financeiro.Infrastructure.Context;
using Financeiro.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Financeiro.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
           options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                 new MySqlServerVersion(new Version(8, 0, 29))));

        services.AddScoped<ICategoriaRespository, CategoriaRepository>();
        services.AddScoped<ITransacaoRepository, TransacaoRepository>();
        services.AddScoped<ITransacaoService, TransacaoService>();
        services.AddScoped<ICategoriaService, CategoriaService>();
        services.AddScoped<IResumoService, ResumoService>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        return services;
    }
}
