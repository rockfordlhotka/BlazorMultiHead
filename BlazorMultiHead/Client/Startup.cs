using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using BlazorMultiHead.Ui;
using BlazorMultiHead.Ui.Services;
using BlazorMultiHead.Client.Services;

namespace BlazorMultiHead.Client
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddSingleton<IForecastService, ForecastService>();
      services.AddSingleton<IHostType, HostType>();
    }

    public void Configure(IComponentsApplicationBuilder app)
    {
      app.AddComponent<App>("app");
    }
  }
}
