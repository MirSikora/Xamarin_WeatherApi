using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shared {
    public class WeatherService {
        string apiKey = "b7f8526580da436b83a144144231312";
        IWeatherView weatherView;

        public WeatherService(IWeatherView weatherView) {
            this.weatherView = weatherView;
        }

        public async Task GetWeatherForCityAsync(string city) {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}&aqi=no");
            if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();
                var weatherModel = JsonConvert.DeserializeObject<WeatherModel>(content);
                weatherView.SetWeatherData(weatherModel);
            }
        }
    }
}
