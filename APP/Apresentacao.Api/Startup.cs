using Apresentacao.Api.Managers;
using Apresentacao.Api.Managers.Settings;
using Apresentacao.CrossCuting.Helpers.RegisterService;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Text;

namespace Apresentacao.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //Token
            var settings = Configuration.Get<JwtSettings>();
            services.AddSingleton(settings);
            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.IssuerKey));
                paramsValidation.ValidAudience = settings.TokenAudience;
                paramsValidation.ValidIssuer = settings.Issuer;

                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            IoCConfiguration.Configure(services, Configuration);
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<IoCMappingProfile>();
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.AddMvc(config =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //        .RequireAuthenticatedUser()
            //        .Build();

            //    config.Filters.Add(new AuthorizeFilter(policy));
            //}).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            LoadConfigSwagger(services);
            var provider = services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {

            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                //routes.MapSpaFallbackRoute(
                //    name: "spa-fallback",
                //    defaults: new { controller = "Home", action = "Index" });
            });


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //c.RoutePrefix = "http://localhost:501/swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Endpoints");
            });
            
            

            app.UseHttpsRedirection();
            app.UseSession();
            app.UseMvc();
        }

    


        private void LoadConfigSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<AddRequiredHeaderParameter>();
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Apresentação de desenvolvimento",
                        Version = "v1",
                        Description = "",
                        Contact = new Contact
                        {
                            Name = "Romy G. Moura Nunez",
                            Url = "http://localhost:501/swagger"
                        }
                    });

                string caminhoAplicacao = AppDomain.CurrentDomain.BaseDirectory;
                string nomeAplicacao = AppDomain.CurrentDomain.FriendlyName;
                string caminhoXmlDoc = Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });
        }
    }
}
