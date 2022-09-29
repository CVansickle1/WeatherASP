using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection.Metadata.Ecma335;
using WeatherASP.Models;
using static WeatherASP.Models.WeatherViewModels;

namespace WeatherASP.CallAPI
{
    public class CallApiNow : IMakeRootObject
    {
        public WeatherViewModels.RootObject GetWeather(string city)
        {
            string WeatherKey = ConstantsDoNotDistribute.Constants.CallKey;
            // Connection String
            var newClient = new HttpClient();
            var OpenURL = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=imperial&appid={WeatherKey}";

            try
            {
                var response = newClient.GetStringAsync(OpenURL).Result;

                var Information = JsonConvert.DeserializeObject<RootObject>(response);

                return Information;
            }
            catch { return null; }
        }
    }
}
