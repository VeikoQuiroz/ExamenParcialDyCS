using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EnterprisePatterns.Api.Common.Infrastructure.Persistence.NHibernate;
using AutoMapper;
using EnterprisePatterns.Api.BankAccounts.Application.Assembler;
using EnterprisePatterns.Api.Jugadores.Domain.Repository;
using EnterprisePatterns.Api.Jugadores.Infrastructure.Persistence.NHibernate.Repository;
using EnterprisePatterns.Api.Jugadores.Application.Assembler;
using EnterprisePatterns.Api.Common.Application;

namespace EnterprisePatterns.Api
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
            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton(new SessionFactory(Environment.GetEnvironmentVariable("MYSQL_STRCON_PATTERNS")));
            var serviceProvider = services.BuildServiceProvider();
            var mapper = serviceProvider.GetService<IMapper>();
            services.AddSingleton(new JugadorAssembler(mapper));
            services.AddScoped<IUnitOfWork, UnitOfWorkNHibernate>();
            services.AddTransient<IJugadorRepository, JugadorNHibernateRepository>((ctx) =>
            {
                IUnitOfWork unitOfWork = ctx.GetService<IUnitOfWork>();
                return new JugadorNHibernateRepository((UnitOfWorkNHibernate)unitOfWork);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
