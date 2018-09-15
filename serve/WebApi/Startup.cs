using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApi.Unity;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using TradingService;

namespace WebApi
{
    public class Startup
    {
        private UnityServiceProvider _serviceProvider;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var unityServiceProvider = new UnityServiceProvider();
            _serviceProvider = unityServiceProvider;

            var container = unityServiceProvider.UnityContainer;

            services.AddSingleton<IControllerActivator>(new UnityControllerActivator(container));
            services.AddSingleton(fac => container);

            var defaultProvider = services.BuildServiceProvider();

            container.AddExtension(new UnityFallbackProviderExtension(defaultProvider));

            //container.RegisterType<IMyUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());

            //container.RegisterType<IMapper, Mapper>();
            //container.AddNewExtension<RepositoriesUnityExtension>();
            container.AddNewExtension<UnityExtension>();

            /*var eventLogFactory = new InjectionFactory((ctr, type, str) =>
            {
                var appLog = new EventLog("Application");
                appLog.Source = "Web Api.";

                return new CustomEventLog(appLog);
            });*/

            //container.RegisterType<IEventLog>(new TransientLifetimeManager(), eventLogFactory);
        }



        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
