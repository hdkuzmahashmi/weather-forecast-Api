using Newtonsoft.Json;

namespace Appsfactory.WeatherForecast.Api.Models
{

    public class Weather
    {
        [JsonProperty("cod")]
        public string cod { get; set; }

        [JsonProperty("message")]
        public int message { get; set; }

        [JsonProperty("cnt")]
        public int cnt { get; set; }

        [JsonProperty("list")]
        public List<lists> list { get; set; }

        [JsonProperty("city")]
        public city city { get; set; }
    }

    public class lists
    {
        [JsonProperty("dt")]
        public string? dt { get; set; }

        [JsonProperty("main")]
        public main main { get; set; }

        [JsonProperty("weather")]
        public List<weatherlist> weather { get; set; }

        [JsonProperty("clouds")]
        public cloud clouds { get; set; }

        [JsonProperty("wind")]
        public wind wind { get; set; }

        [JsonProperty("visibility")]
        public long visibility { get; set; }

        [JsonProperty("pop")]
        public float pop { get; set; }

        [JsonProperty("sys")]
        public sys sys { get; set; }

        [JsonProperty("dt_txt")]
        public string dt_txt { get; set; }
    }

    public class main
    {
        [JsonProperty("temp")]
        public float temp { get; set; }

        [JsonProperty("feels_like")]
        public float feels_like { get; set; }

        [JsonProperty("temp_min")]
        public float temp_min { get; set; }

        [JsonProperty("temp_max")]
        public float temp_max { get; set; }

        [JsonProperty("pressure")]
        public long pressure { get; set; }

        [JsonProperty("sea_level")]
        public long sea_level { get; set; }

        [JsonProperty("grnd_level")]
        public long grnd_level { get; set; }

        [JsonProperty("humidity")]
        public long humidity { get; set; }

        [JsonProperty("temp_kf")]
        public float temp_kf { get; set; }
    }

    public class coord
    {
        [JsonProperty("lat")]
        public double lat { get; set; }

        [JsonProperty("lon")]
        public double lon { get; set; }

    }

    public class city
    {
        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("coord")]
        public coord coord { get; set; }

        [JsonProperty("country")]
        public string  country { get; set; }

        [JsonProperty("population")]
        public double population { get; set; }

        [JsonProperty("timezone")]
        public long timezone { get; set; }

        [JsonProperty("sunrise")]
        public string sunrise { get; set; }

        [JsonProperty("sunset")]
        public string sunset { get; set; }
    }
   
    public class weatherlist
    {
        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("main")]
        public string main { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("icon")]
        public string icon { get; set; }
    }

    public class cloud
    {
        [JsonProperty("all")]
        public string all { get; set; }
    }

    public class wind
    {
        [JsonProperty("speed")]
        public float speed { get; set; }

        [JsonProperty("deg")]
        public float deg { get; set; }

        [JsonProperty("gust")]
        public float gust { get; set; }
    }

    public class sys
    {
        [JsonProperty("pod")]
        public string pod { get; set; }
    }

}
