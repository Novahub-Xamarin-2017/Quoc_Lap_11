using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Com.Lilarcor.Cheeseknife;
using Exercise2.Controllers;
using Exercise2.Controllers.Adapters;
using SearchView = Android.Widget.SearchView;

namespace Exercise2.Views
{
    [Activity(Label = "Exercise2", MainLauncher = true, Theme = "@android:style/Theme.Holo.Light")]
    public class MainActivity : Activity
    {
        private UserAdapter adapter;
        private GithubApiController githubApiController;
        private SearchView searchView;

        [InjectView(Resource.Id.rvUsers)] private RecyclerView rvUsers;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);
            githubApiController = GithubApiController.Instance;
            rvUsers.SetLayoutManager(new LinearLayoutManager(this));

            searchView = FindViewById<SearchView>(Resource.Id.searchView);
            searchView.QueryTextSubmit += (sender, e) =>
            {
                adapter = new UserAdapter(githubApiController.SearchUser(searchView.Query));
                rvUsers.SetAdapter(adapter);
            };
        }
    }
}

