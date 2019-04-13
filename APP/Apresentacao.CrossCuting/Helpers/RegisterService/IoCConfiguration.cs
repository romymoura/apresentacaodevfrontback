using Apresentacao.Business.Services;
using Apresentacao.Business.Services.Interfaces;
using Apresentacao.Data;
using Apresentacao.Data.EntityObjectsRepositorys;
using Apresentacao.Domain.Interfaces;
using Apresentacao.Domain.Interfaces.Repository;
using Apresentacao.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Apresentacao.CrossCuting.Helpers.RegisterService
{
    public static class IoCConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureDomain(services);
            ConfigureData(services, configuration);
            ConfigureApplication(services);
        }
        //BLL
        private static void ConfigureApplication(IServiceCollection services)
        {
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IAirplaneApplication, AirplaneApplication>();
        }

        //Data
        private static void ConfigureData(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                //aqui eu configuro o laziloading como false.
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUserApplicationRepository, UserApplicationRepository>();
            services.AddScoped<IAirplaneApplicationRepository, AirplaneApplicationRepository>();
        }
        //Domain
        private static void ConfigureDomain(IServiceCollection services)
        {
            services.AddScoped<IUserApplicationService, UserApplicationService>();
            services.AddScoped<IAirplaneApplicationService, AirplaneApplicationService>();
        }
    }
}
