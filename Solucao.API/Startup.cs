using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Solucao.Domain.Interfaces;
using Solucao.InfraEstrutura.Contexto;
using Solucao.InfraEstrutura.Repositorios;
using Solucao.Servicos.Interfaces_Servicos;
using Solucao.Servicos.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucao.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Adicionando a classe contexto e obtendo a connection String
            services.AddDbContext<ContextoDB>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("BASE")));

            // adicionando o automapper para realizar o mapeamento entre os objetos de transferência de dados para entidade e de entidade pra dto.
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Solucao.API", Version = "v1" });
            });

            // Definindo as interfaces e quem as implementa
            services.AddScoped(typeof(ILocadorRepositorio), typeof(LocadorRepositorio));
            services.AddScoped(typeof(IFilmeRepositorio), typeof(FilmeRepositorio));
            services.AddScoped(typeof(ILocacaoRepositorio), typeof(LocacaoRepositorio));

            // Definindo as interfaces de serviços e quem as implemntam
            services.AddScoped(typeof(IFilmeServico), typeof(FilmeServicos));
            services.AddScoped(typeof(ILocadorServico), typeof(LocadorServico));
            services.AddScoped(typeof(ILocacaoServico), typeof(LocacaoServicos));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Solucao.API v1"));
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
