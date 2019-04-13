using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Apresentacao.CrossCuting.Helpers.RegisterService;
using Apresentacao.Data;

namespace Apresentacao.ApplicationTests.Base
{
    public class TestClassBase
    {
        private DbContextOptionsBuilder<ApplicationDbContext> OptionsBuilder { get; set; } = new DbContextOptionsBuilder<ApplicationDbContext>();
        public ApplicationDbContext Context { get; set; }
        public IConfiguration Configuration { set; get; }
        public TestClassBase()
        {

            Configuration = InitConfiguration();
            this.OptionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            Context = new ApplicationDbContext(this.OptionsBuilder.Options);
        }

        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            //Obs caso o teste não execute os enpoints com precisão será necessario registrar nosso serviços de aplicação na camada de configuração IoC.

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<IoCMappingProfile>();
            });

            return config;
        }
    }
}
