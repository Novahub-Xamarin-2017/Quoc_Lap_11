using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Com.Lilarcor.Cheeseknife;
using Exercise6.Controllers;
using Exercise6.Controllers.Adapters;
using Exercise6.Models;

namespace Exercise6
{
    [Activity(Label = "Currency Trade Market", MainLauncher = true, Theme = "@android:style/Theme.Holo.Light")]
    public class MainActivity : Activity
    {
        [InjectView(Resource.Id.rvCurrencies)] private RecyclerView rvCurrencies;

        [InjectView(Resource.Id.tvTitle)] private TextView tvTitle;

        private readonly VietcombankApiController apiController = new VietcombankApiController();

        private readonly CurrencyAdapter adapter = new CurrencyAdapter();

        private ExrateList exrateList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);
            exrateList = apiController.GetExrateData();
            SetWidgets();
        }

        private void SetWidgets()
        {
            tvTitle.Text = exrateList.Source;
            adapter.Exrates = exrateList.Exrates;
            rvCurrencies.SetLayoutManager(new LinearLayoutManager(this));
            rvCurrencies.SetAdapter(adapter);
        }
    }
}

