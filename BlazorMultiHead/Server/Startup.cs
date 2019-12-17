using BlazorMultiHead.Server.Services;
using BlazorMultiHead.Ui.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace BlazorMultiHead.Server
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddResponseCompression(opts =>
      {
        opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                  new[] { "application/octet-stream" });
      });
      services.AddRazorPages();
#if !WASM
      services.AddServerSideBlazor();
      services.AddSingleton<IForecastService, ForecastService>();
      services.AddSingleton<IHostType, HostType>();
#endif
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseResponseCompression();

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseBlazorDebugging();
      }
#if !WASM
      else
      {
        app.UseExceptionHandler("/Error");
      }
#endif
      app.UseStaticFiles();

#if WASM
      app.UseClientSideBlazorFiles<Client.Startup>();
      app.UseRouting();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapDefaultControllerRoute();
        endpoints.MapFallbackToClientSideBlazor<Client.Startup>("index.html");
      });
#else
      app.UseRouting();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapBlazorHub();
        endpoints.MapFallbackToPage("/_Host");
      });
#endif
    }
  }
}
