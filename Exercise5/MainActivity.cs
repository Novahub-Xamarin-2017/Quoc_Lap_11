using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Com.Lilarcor.Cheeseknife;
using Exercise5.Controllers;
using Exercise5.Controllers.Adapters;
using Exercise5.Models;

namespace Exercise5
{
    [Activity(Label = "Exercise5", MainLauncher = true, Theme = "@android:style/Theme.Holo.Light")]
    public class MainActivity : Activity
    {
        [InjectView(Resource.Id.tvTitle)] private TextView tvTitle;

        [InjectView(Resource.Id.rvCityRates)] private RecyclerView rvCityRates;

        private readonly CityGoldRateAdapter adapter = new CityGoldRateAdapter();

        private List<object> objects;

        private readonly ApiController apiController = new ApiController();

        private ApiResponse apiResponse;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);

            apiResponse = apiController.GetGoldRates();
            objects = GenerateObjects(apiResponse.Ratelist.City);
            adapter.CityGoldRates = objects;
            rvCityRates.SetLayoutManager(new LinearLayoutManager(this));
            rvCityRates.SetAdapter(adapter);
        }

        private static List<object> GenerateObjects(List<City> cities)
        {
            var mList = new List<object>();
            foreach (var city in cities)
            {
                mList.Add(city);
                city.GoldRates.ForEach(mList.Add);
            }
            return mList;
        }
    }
}

