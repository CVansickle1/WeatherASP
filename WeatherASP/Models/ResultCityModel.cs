using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WeatherASP.Models
{
    public class ResultCityModel
    {
        [Display(Name = "City:")]
        public string Name { get; set; }

        [Display(Name = "Temperature:")]
        public float Temp { get; set; }

        [Display(Name = "Humidity:")]
        public int Humidity { get; set; }

        [Display(Name = "Pressure:")]
        public int Pressure { get; set; }

        [Display(Name = "Wind Speed:")]
        public float Wind { get; set; }

        [Display(Name = "Weather Condition:")]
        public string Weather { get; set; }

        public string IconID { get; set; }

        public string IconImage { get { return $"http://openweathermap.org/img/wn/{IconID}@2x.png"; } }

        public string FavIcon
        {
            get
            {
                switch(IconID)
                {
                    case "01d":
                    case "01n":
                        return "../images/favicon.ico";
                    case "02d":
                    case "02n":
                        return "../images/PartlyCloudy.ico";
                    case "03d":
                    case "03n":
                    case "04d":
                    case "04n":
                        return "../images/Cloudy.ico";
                    case "09d":
                    case "09n":
                    case "10d":
                    case "10n":
                        return "../images/Rainy.ico";
                    case "50d":
                    case "50n":
                        return "../images/Foggy.ico";
                    default: return "../images/favicon.ico";
                }
            }
        }
    }
}
