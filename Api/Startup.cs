using AddressApplication;
using AddressApplication.Interface;
using AddressInfra.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using AutoMapper;
using AddressDomain.Services;
using CEPDomain;
using AddressInfra.RepositoryService;
using CEP.AddressInfra;
using CEP.AddressApplication.Interface;
using CEP.AddressApplication.Services;

namespace Api
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

            services.AddScoped<ICEPRepository, DadosCEPService>();
            services.AddScoped<IAddressRepository, AddressRepositoryService>();
            services.AddScoped<DadosCEPDomainService>();
            services.AddScoped<IValidationCepService, ValidationCepService>();

            CorreioConnections correioconnections = new();
            Configuration.GetSection("CorreioConnections").Bind(correioconnections);

            services.AddHttpClient<CorreiosServices>(opt => opt.BaseAddress = new Uri(correioconnections.BASE_URL));

            var config = new MapperConfiguration(cfg => {});

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();
       
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cep Manager", Version = "v1" });
            });    
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cep Manager"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
