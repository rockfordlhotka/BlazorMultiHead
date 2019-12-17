using System;
using System.Threading.Tasks;
using BlazorMultiHead.Shared;

namespace BlazorMultiHead.Ui.Services
{
  public interface IForecastService
  {
    Task<WeatherForecast[]> GetForecastAsync(DateTime time);
  }
}
