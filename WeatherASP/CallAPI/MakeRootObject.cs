using System;
using static WeatherASP.Models.WeatherViewModels;

namespace WeatherASP.CallAPI
{
    public interface IMakeRootObject
    {
        RootObject GetWeather(string city);
    }
}
