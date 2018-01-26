using System.Linq;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Com.Lilarcor.Cheeseknife;
using Exercise4.Controllers;
using Exercise4.Models;

namespace Exercise4
{
    [Activity(Label = "Exercise4", MainLauncher = true, Theme = "@android:style/Theme.Holo.Light")]
    public class MainActivity : Activity
    {
        [InjectView(Resource.Id.gridLayout)] private GridLayout gridLayout;

        [InjectView(Resource.Id.tvCityName)] private TextView tvCityName;

        [InjectView(Resource.Id.tvTemperature)] private TextView tvTemperature;

        [InjectView(Resource.Id.tvWeather)] private TextView tvWeather;

        [InjectView(Resource.Id.tvCloudliness)] private TextView tvCloudliness;

        [InjectView(Resource.Id.tvWindSpeed)] private TextView tvWindSpeed;

        private SearchView searchView;

        private WeatherApiController apiController;

        private Weather weather;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);
            gridLayout.Visibility = ViewStates.Invisible;
            apiController = new WeatherApiController();

            searchView = FindViewById<SearchView>(Resource.Id.searchView);
            searchView.QueryTextSubmit += (sender, e) =>
            {
                weather = apiController.GetWeatherInfo(searchView.Query);
                switch (weather.Cod)
                {
                    case 200:
                        ShowWeatherInfomations();
                        break;
                    case 404:
                        Toast.MakeText(this, weather.Message, ToastLength.Short).Show();
                        break;
                }
            };
        }

        private void ShowWeatherInfomations()
        {
            gridLayout.Visibility = ViewStates.Visible;
            tvCityName.Text = weather.Name;
            tvTemperature.Text = weather.Temperature.Temp + " Celcius";
            tvWeather.Text = weather.WeatherDetail.First().Description;
            tvCloudliness.Text = weather.Clouds.Cloudliness + " %";
            tvWindSpeed.Text = weather.Wind.Speed + " m/s";
        }
    }
}

