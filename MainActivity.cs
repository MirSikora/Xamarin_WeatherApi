using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Shared;
using System;
using System.Threading.Tasks;

namespace Xamarin_WeatherApi
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IWeatherView {
        Button btnChangeCity;
        ImageView imgViewWeather;
        TextView tvCity;
        TextView tvWeather;
        TextView tvTemperature;
        TextView tvWind;
        TextView tvPrecipitation;
        WeatherService weatherService;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            SetupReferences();
            SubscribeEventHandlers();
            weatherService = new WeatherService(this);
        }

        private void SubscribeEventHandlers() {            
            btnChangeCity.Click += BtnChangeCity_Click;
        }

        private void BtnChangeCity_Click(object sender, EventArgs e) {
            var intent = new Intent(this, typeof(CitiesActivity));
            StartActivityForResult(intent, 1);
        }

        private void SetupReferences() {
            btnChangeCity = FindViewById<Button>(Resource.Id.buttonChangeCity);
            imgViewWeather = FindViewById<ImageView>(Resource.Id.imageViewWeatherPicture);
            tvCity = FindViewById<TextView>(Resource.Id.textViewCityName);
            tvPrecipitation = FindViewById<TextView>(Resource.Id.textViewPrecipitation);
            tvTemperature = FindViewById<TextView>(Resource.Id.textViewTemperature);
            tvWeather = FindViewById<TextView>(Resource.Id.textViewWeather);
            tvWind = FindViewById<TextView>(Resource.Id.textViewWind);
        }
        protected override async void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data) {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 1 && resultCode == Result.Ok) {
                string city = data.GetStringExtra("City");
                await weatherService.GetWeatherForCityAsync(city);
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public async void SetWeatherData(WeatherModel model) {
            tvCity.Text = model.Location.Name;
            tvPrecipitation.Text = $"{model.Current.Precip_mm} mm";
            tvTemperature.Text = $"{model.Current.Temp_c}°C";
            tvWeather.Text = model.Current.Condition.Text;
            tvWind.Text = $"{model.Current.Wind_dir} {model.Current.Wind_kph} km/h";
            imgViewWeather.SetImageBitmap(await GetImageBitmapFromUrlAsync(@$"https:{model.Current.Condition.Icon}"));
        }
        private async Task<Bitmap> GetImageBitmapFromUrlAsync(string url) {
            Bitmap bmp = null;
            using (var httpClient = new System.Net.Http.HttpClient()) {
                var imageBytes = await httpClient.GetByteArrayAsync(url);
                if (imageBytes != null && imageBytes.Length > 0) {
                    bmp = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }
            return bmp;
        }
    }
}