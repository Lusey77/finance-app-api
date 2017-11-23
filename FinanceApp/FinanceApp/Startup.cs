using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FinanceApp.Infrastructure.Data;
using FinanceApp.Model;
using FinanceApp.ModelConverter;
using FinanceApp.Service.Class;
using FinanceApp.Core;
using FinanceApp.Domain.Entity;
using FinanceApp.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp
{
    public class Startup
    {
        private static IContainer Container { get; set; }

        private IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            ContainerBuilder builder = new ContainerBuilder();

//            Assembly[] assemblies = GetAssemblies.GetAllDirectoryAssemblies("FinanceApp");
//
//            builder.RegisterAssemblyTypes(assemblies)
//                .AsImplementedInterfaces();
//
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<DBContextUnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<AccountConverter>().As<IModelConverter<Account, AccountModel>>();
            builder.RegisterType<FinanceAppContextFactory>().As<IContextFactory>();
            
            // Add framework services.
            services.AddDbContext<FinanceAppContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));

            services.AddMvc();

            services.AddSingleton<IConfiguration>(Configuration);

            builder.Populate(services);

            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseMvc();
        }
    }
}