﻿using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Com.Lilarcor.Cheeseknife;
using Exercise3.Controllers;
using Exercise3.Controllers.Adapters;
using SearchView = Android.Widget.SearchView;

namespace Exercise3
{
    [Activity(Label = "Photo Finder", MainLauncher = true, Theme = "@android:style/Theme.Holo.Light")]
    public class MainActivity : Activity
    {
        [InjectView(Resource.Id.rvPhotos)] private RecyclerView rvPhotos;

        private SearchView searchView;
        private readonly ImageAdapter adapter = new ImageAdapter();
        private GettyImageApiController apiController;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);
            rvPhotos.SetLayoutManager(new LinearLayoutManager(this));
            rvPhotos.SetAdapter(adapter);
            apiController = new GettyImageApiController();

            searchView = FindViewById<SearchView>(Resource.Id.searchView);
            searchView.QueryTextSubmit += (sender, e) =>
            {
                adapter.Images = apiController.SearchImage(searchView.Query);
            };
        }
    }
}
