using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Google.Android.Material.TextField;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Xamarin_WeatherApi {
    [Activity(Label = "CitiesActivity")]
    public class CitiesActivity : Activity {
        TextView tvOstrava;
        TextView tvRovaniemi;
        TextView tvRome;
        TextView tvSydney;
        TextView tvReykjavik;
        TextInputEditText editTextSearch;
        Button btnSearch;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.cities_layout);
            SetupReferences();
            SubscribeEventHandlers();
        }

        private void SubscribeEventHandlers() {
            tvOstrava.Click += TvOstrava_Click;
            tvRovaniemi.Click += TvRovaniemi_Click;
            tvRome.Click += TvRome_Click;
            tvSydney.Click += TvSydney_Click;
            tvReykjavik.Click += TvReykjavik_Click;
            btnSearch.Click += BtnSearch_Click;
        }

        private void BtnSearch_Click(object sender, EventArgs e) {
            SendBackCityName(RemoveAccents(editTextSearch.Text));
        }

        private void TvReykjavik_Click(object sender, EventArgs e) {
            SendBackCityName("Reykjavik");
        }

        private void SendBackCityName(string city) {
            var intent = new Intent();
            intent.PutExtra("City", city);
            SetResult(Result.Ok, intent);
            Finish();
        }

        private void TvSydney_Click(object sender, EventArgs e) {
            SendBackCityName("Sydney");
        }

        private void TvRome_Click(object sender, EventArgs e) {
            SendBackCityName("Rome");
        }

        private void TvOstrava_Click(object sender, EventArgs e) {
            SendBackCityName("Ostrava");
        }

        private void TvRovaniemi_Click(object sender, EventArgs e) {
            SendBackCityName("Rovaniemi");
        }

        private void SetupReferences() {
            tvOstrava = FindViewById<TextView>(Resource.Id.textViewOstrava);
            tvRovaniemi = FindViewById<TextView>(Resource.Id.textViewRovaniemi);
            tvRome = FindViewById<TextView>(Resource.Id.textViewRome);
            tvSydney = FindViewById<TextView>(Resource.Id.textViewSydney);
            tvReykjavik = FindViewById<TextView>(Resource.Id.textViewReykjavik);
            editTextSearch = FindViewById<TextInputEditText>(Resource.Id.textInputSearch);
            btnSearch = FindViewById<Button>(Resource.Id.buttonSearch);
        }
        public string RemoveAccents(string text) {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText) {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark) {
                    sbReturn.Append(letter);
                }
            }
            return sbReturn.ToString();
        }
    }
}