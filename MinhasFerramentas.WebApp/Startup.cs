using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinhasFerramentasApp.BancoDados;
using MinhasFerramentasApp.Controller;
using MinhasFerramentasApp.Model;
using MinhasFerramentasApp.Model.Interface;
using MinhasFerramentasApp.Service;

namespace MinhasFerramentas.WebApp
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
      services.Configure<CookiePolicyOptions>(options =>
      {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      services.AddSingleton<IPersistenciaXML, PersistenciaXML>();
      services.AddSingleton<IBancoDados<Ferramenta>, BancoDadosXML>();
      services.AddSingleton<IFerramentaController, FerramentaController>();
      services.AddSingleton<IRelatorioService, RelatorioFerramentasService>();

      // -Transient : Criado a cada vez que são solicitados.
      // - Scoped: Criado uma vez por solicitação. 
      // - Singleton: Criado na primeira vez que são solicitados.Cada solicitação subseqüente usa a instância que foi criada na primeira vez.

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseCookiePolicy();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=Ferramenta}/{action=Index}/{id?}");
      });
    }
  }
}
