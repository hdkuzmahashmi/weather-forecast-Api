using Appsfactory.WeatherForecast.Api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
//using System.Text.Json;


namespace Appsfactory.WeatherForecast.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[EnableCors]
	public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

		[EnableCors]

		[HttpGet("[action]")]
		public async Task<string> City(string name)
        {
			string jsonstr = "";
			WeatherResult result = new WeatherResult();
			// calling openweathermap api
			// not parametrizing url here because its a testing project 
			var uri = new Uri("https://api.openweathermap.org/data/2.5/forecast?q="+ name + ",DE&units=metric&appid=19718150ed7c355b8d5873b2311845ce");

			using (var cancellationTokenSource = new CancellationTokenSource())
			{
				var cancellationToken = cancellationTokenSource.Token;

				using (var client = new HttpClient())
				{
					try
					{
						var response = await client.GetAsync(uri, HttpCompletionOption.ResponseContentRead, cancellationToken);

						if (response.IsSuccessStatusCode)
						{
							var json = await response.Content.ReadAsStringAsync(cancellationToken);

							// Deserialize to an OpenWeather class.
							var weather = JsonConvert.DeserializeObject<Weather>(json);
							result = GetData(weather);
						}
					}
					catch (Exception exception)
					{
						// Log error.
						// Returm error to user.
					}
				}
			}

			jsonstr = JsonConvert.SerializeObject(result);
			return jsonstr;
		}


		[EnableCors]
		[HttpGet("[action]")]
		public async Task<string> Zipcodes(string code)
		{
			WeatherResult result = new WeatherResult();
			string jsonstr = "";

			// calling openweathermap api
			// not parametrizing url here, because its a testing project 

			var uri = new Uri("https://api.openweathermap.org/data/2.5/forecast?zip=" + code + ",DE&units=metric&appid=19718150ed7c355b8d5873b2311845ce");

			using (var cancellationTokenSource = new CancellationTokenSource())
			{
				var cancellationToken = cancellationTokenSource.Token;

				using (var client = new HttpClient())
				{
					try
					{
						var response = await client.GetAsync(uri, HttpCompletionOption.ResponseContentRead, cancellationToken);

						if (response.IsSuccessStatusCode)
						{
							var json = await response.Content.ReadAsStringAsync(cancellationToken);

							// Deserialize to an OpenWeather class.
							var weather = JsonConvert.DeserializeObject<Weather>(json);
							result = GetData(weather);
						}
					}

					catch (Exception exception) 
					{
						// Log error.
						// Return error to user.
					}
				}
			}
			jsonstr = JsonConvert.SerializeObject(result);
			return jsonstr;
		}
		/// <summary>
		/// Get data from openwebapi and apply calculation
		/// </summary>
		/// <param name="weather"></param>
		/// <returns></returns>
		public WeatherResult GetData(Weather weather)
        {
			WeatherResult weatherResult = new WeatherResult();

			// calculate average temprature 
			var now = DateTime.Now;
			DateTime datetimenow = now;
			DateTime datetimeday2 = DateTime.Now.AddDays(1);
			DateTime datetimeday3 = DateTime.Now.AddDays(2);
			DateTime datetimeday4 = DateTime.Now.AddDays(3);
			DateTime datetimeday5 = DateTime.Now.AddDays(4);

			//temprature
			List<double> atempday1 = new List<double>();
			List<double> atempday2 = new List<double>();
			List<double> atempday3 = new List<double>();
			List<double> atempday4 = new List<double>();
			List<double> atempday5 = new List<double>();

			//Wind speed
			List<double> windday1 = new List<double>();
			List<double> windday2 = new List<double>();
			List<double> windday3 = new List<double>();
			List<double> windday4 = new List<double>();
			List<double> windday5 = new List<double>();

			//Wind humidity
			List<double> humidityday1 = new List<double>();
			List<double> humidityday2 = new List<double>();
			List<double> humidityday3 = new List<double>();
			List<double> humidityday4 = new List<double>();
			List<double> humidityday5 = new List<double>();


			foreach (var obj in weather.list)
			{
				DateTime datetimecurr = Convert.ToDateTime(obj.dt_txt);

				if (datetimenow.Date == datetimecurr.Date)
				{
					atempday1.Add(obj.main.temp);
					windday1.Add(obj.wind.speed);
					humidityday1.Add(obj.main.humidity);
				}
				else if (datetimeday2.Date == datetimecurr.Date)
				{
					atempday2.Add(obj.main.temp);
					windday2.Add(obj.wind.speed);
					humidityday2.Add(obj.main.humidity);
				}
				else if (datetimeday3.Date == datetimecurr.Date)
				{
					atempday3.Add(obj.main.temp);
					windday3.Add(obj.wind.speed);
					humidityday3.Add(obj.main.humidity);
				}
				else if (datetimeday4.Date == datetimecurr.Date)
				{
					atempday4.Add(obj.main.temp);
					windday4.Add(obj.wind.speed);
					humidityday4.Add(obj.main.humidity);
				}
				else if (datetimeday5.Date == datetimecurr.Date)
				{
					atempday5.Add(obj.main.temp);
					windday5.Add(obj.wind.speed);
					humidityday5.Add(obj.main.humidity);
				}
			}

			// Serialize required data to your custom model class.
			if (atempday1.Count > 0)
			{
				//calculate average temprature, wind and humidity
				double sumtemp1 = atempday1.Sum(x => x);
				var avetemp1 = sumtemp1 / atempday1.Count();
				weatherResult.AverageTempDay1 = Math.Round(avetemp1);
				weatherResult.Day1 = now.DayOfWeek.ToString();

				double sumwind1 = windday1.Sum(x => x);
				var wind1 = sumwind1 / windday1.Count();
				weatherResult.WindDay1 = Math.Round(wind1);

				double sumhumidity1 = humidityday1.Sum(x => x);
				var humidity1 = sumhumidity1 / humidityday1.Count();
				weatherResult.HumidityDay1 = Math.Round(humidity1);

			}

			// Day2 temp , wind and humidity calculation
			double sumtemp2 = atempday2.Sum(x => x);
			var avetemp2 = sumtemp2 / atempday2.Count();
			weatherResult.AverageTempDay2 = Math.Round(avetemp2);
			weatherResult.Day2 = datetimeday2.DayOfWeek.ToString();

			double sumwind2 = windday2.Sum(x => x);
			var wind2 = sumwind2 / windday2.Count();
			weatherResult.WindDay2 = Math.Round(wind2);

			double sumhumidity2 = humidityday2.Sum(x => x);
			var humidity2 = sumhumidity2 / humidityday2.Count();
			weatherResult.HumidityDay2 = Math.Round(humidity2);

			// Day3 temp , wind and humidity calculation
			double sumtemp3 = atempday3.Sum(x => x);
			var avetemp3 = sumtemp3 / atempday3.Count();
			weatherResult.AverageTempDay3 = Math.Round(avetemp3);
			weatherResult.Day3 = datetimeday3.DayOfWeek.ToString();

			double sumwind3 = windday3.Sum(x => x);
			var wind3 = sumwind3 / windday3.Count();
			weatherResult.WindDay3 = Math.Round(wind3);

			double sumhumidity3 = humidityday3.Sum(x => x);
			var humidity3 = sumhumidity3 / humidityday3.Count();
			weatherResult.HumidityDay3 = Math.Round(humidity3);

			// Day4 temp , wind and humidity calculation
			double sumtemp4 = atempday4.Sum(x => x);
			var avetemp4 = sumtemp4 / atempday4.Count();
			weatherResult.AverageTempDay4 = Math.Round(avetemp4);
			weatherResult.Day4 = datetimeday4.DayOfWeek.ToString();

			double sumwind4 = windday4.Sum(x => x);
			var wind4 = sumwind4 / windday4.Count();
			weatherResult.WindDay4 = Math.Round(wind4);

			double sumhumidity4 = humidityday4.Sum(x => x);
			var humidity4 = sumhumidity4 / humidityday4.Count();
			weatherResult.HumidityDay4 = Math.Round(humidity4);

			// Day5 temp , wind and humidity calculation
			double sumtemp5 = atempday5.Sum(x => x);
			var avetemp5 = sumtemp5 / atempday5.Count();
			weatherResult.AverageTempDay5 = Math.Round(avetemp5);
			weatherResult.Day5 = datetimeday5.DayOfWeek.ToString();

			double sumwind5 = windday5.Sum(x => x);
			var wind5 = sumwind5 / windday5.Count();
			weatherResult.WindDay5 = Math.Round(wind5);

			double sumhumidity5 = humidityday5.Sum(x => x);
			var humidity5 = sumhumidity5 / humidityday5.Count();
			weatherResult.HumidityDay5 = Math.Round(humidity5);

			weatherResult.CityNamekuch = weather.city.name;
			weatherResult.CountryName = weather.city.country;

			
			return weatherResult;
		}
	}
}