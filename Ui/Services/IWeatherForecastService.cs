using BlazorMultiHead.Shared;
using System;
using System.Threading.Tasks;

namespace Ui.Services
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetForecastAsync(DateTime startDate);
    }
}
