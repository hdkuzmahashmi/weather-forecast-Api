using Newtonsoft.Json;

namespace Appsfactory.WeatherForecast.Api.Models
{
    public class WeatherResult
    {
        [JsonProperty(PropertyName = "cityname")]
        public string CityNamekuch { get; set; }

        [JsonProperty(PropertyName = "countryname")]
        public string CountryName { get; set; }

        [JsonProperty(PropertyName = "avgtempdayone")]
        public double AverageTempDay1 { get; set; }

        [JsonProperty(PropertyName = "dayone")]
        public string Day1 { get; set; }

        [JsonProperty(PropertyName = "avgtempdaytwo")]
        public double AverageTempDay2 { get; set; }

        [JsonProperty(PropertyName = "daytwo")]
        public string Day2 { get; set; }

        [JsonProperty(PropertyName = "avgtempdaythree")]
        public double AverageTempDay3 { get; set; }

        [JsonProperty(PropertyName = "daythree")]
        public string Day3 { get; set; }

        [JsonProperty(PropertyName = "avgtempdayfour")]
        public double AverageTempDay4 { get; set; }

        [JsonProperty(PropertyName = "dayfour")]
        public string Day4 { get; set; }

        [JsonProperty(PropertyName = "avgtempdayfive")]
        public double AverageTempDay5 { get; set; }

        [JsonProperty(PropertyName = "dayfive")]
        public string Day5 { get; set; }

        [JsonProperty(PropertyName = "humiditydayone")]
        public double HumidityDay1 { get; set; }

        [JsonProperty(PropertyName = "humiditydaytwo")]
        public double HumidityDay2 { get; set; }

        [JsonProperty(PropertyName = "humiditydaythree")]
        public double HumidityDay3 { get; set; }

        [JsonProperty(PropertyName = "humiditydayfour")]
        public double HumidityDay4 { get; set; }

        [JsonProperty(PropertyName = "humiditydayfive")]
        public double HumidityDay5 { get; set; }

        [JsonProperty(PropertyName = "winddayone")]
        public double WindDay1 { get; set; }

        [JsonProperty(PropertyName = "winddaytwo")]
        public double WindDay2 { get; set; }

        [JsonProperty(PropertyName = "winddaythree")]
        public double WindDay3 { get; set; }

        [JsonProperty(PropertyName = "winddayfour")]
        public double WindDay4 { get; set; }

        [JsonProperty(PropertyName = "winddayfive")]
        public double WindDay5 { get; set; }
    }
}
