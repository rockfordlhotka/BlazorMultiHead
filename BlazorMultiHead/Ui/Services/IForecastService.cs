using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorMultiHead.Shared;

namespace BlazorMultiHead.Ui.Services
{
  public interface IForecastService
  {
    Task<WeatherForecast[]> GetForecastAsync(DateTime time);
  }
}
