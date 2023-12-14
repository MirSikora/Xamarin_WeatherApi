using Shared;

namespace WeatherForms {
    public partial class FormWeather : System.Windows.Forms.Form ,IWeatherView {
        WeatherService weatherService; 
        public FormWeather() {
            InitializeComponent();
            weatherService = new WeatherService(this);
        }

        public void SetWeatherData(WeatherModel model) {
            lbCity.Text = model.Location.Name;
            lbPrecipitation.Text = $"Precipitation: {model.Current.Precip_mm} mm";
            lbTemperature.Text = $"Temperature: {model.Current.Temp_c}°C";
            lbWeather.Text =$"Weather: {model.Current.Condition.Text}";
            lbWind.Text = $"Wind: {model.Current.Wind_dir} {model.Current.Wind_kph} km/h";
            pbWeather.ImageLocation = @$"https:{model.Current.Condition.Icon}";

        }

        private async void cbCities_SelectedIndexChanged(object sender, EventArgs e) {
            string city = cbCities.SelectedItem.ToString();
            await weatherService.GetWeatherForCityAsync(city);
        }
        
    }
}
