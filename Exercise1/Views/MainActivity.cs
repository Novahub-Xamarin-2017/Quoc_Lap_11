using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Com.Lilarcor.Cheeseknife;
using Exercise1.Controllers;
using Exercise1.Controllers.Adapters;

namespace Exercise1.Views
{
    [Activity(Label = "My Twitter", Theme = "@android:style/Theme.Holo.Light")]
    public class MainActivity : Activity
    {
        [InjectView(Resource.Id.rvTweets)] private RecyclerView rvTweets;

        private TweetController tweetController;
        private TweetPostAdapter adapter;
        private DataProvider data;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);
            tweetController = TweetController.Instance;
            data = DataProvider.Instance;
            data.Posts = tweetController.GetPosts();
            adapter = new TweetPostAdapter(data.Posts);
            rvTweets.SetLayoutManager(new LinearLayoutManager(this));
            rvTweets.SetAdapter(adapter);
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            tweetController.Logout();
            Finish();
            return base.OnOptionsItemSelected(item);
        }
    }
}

