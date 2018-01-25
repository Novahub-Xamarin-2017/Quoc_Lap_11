using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Widget;
using Com.Bumptech.Glide;
using Com.Lilarcor.Cheeseknife;
using Exercise2.Controllers;
using Exercise2.Models;

namespace Exercise2.Views
{
    [Activity(Label = "UserDetailActivity", Theme = "@android:style/Theme.Holo.Light")]
    public class UserDetailActivity : Activity
    {
        [InjectView(Resource.Id.imgAvatar)] private ImageView imgAvatar;

        [InjectView(Resource.Id.tvUserName)] private TextView tvUserName;

        [InjectView(Resource.Id.tvUserLogin)] private TextView tvUserLogin;

        [InjectView(Resource.Id.tvEmail)] private TextView tvEmail;

        [InjectView(Resource.Id.tvBio)] private TextView tvBio;

        [InjectView(Resource.Id.tvCompany)] private TextView tvCompany;

        [InjectView(Resource.Id.lvRepos)] private ListView lvRepos;

        private GithubApiController githubApiController;
        private User user;
        private List<Repository> repositories;
        private ArrayAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.UserDetail);
            Init();
            SetWidgets();
        }

        private void Init()
        {
            Cheeseknife.Inject(this);
            var userLogin = Intent.GetStringExtra("Login");
            githubApiController = GithubApiController.Instance;
            user = githubApiController.GetUserDetail(userLogin);
            repositories = githubApiController.GetUseRepositories(userLogin);
            adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, repositories.Select(r => r.name).ToList());
        }

        private void SetWidgets()
        {
            Glide.With(this).Load(user.AvatarUrl).Into(imgAvatar);
            tvUserName.Text = user.Name;
            tvUserLogin.Text = user.Login;
            tvEmail.Text = user.Email;
            tvBio.Text = user.Bio;
            tvCompany.Text = user.Company;
            lvRepos.Adapter = adapter;
        }
    }
}