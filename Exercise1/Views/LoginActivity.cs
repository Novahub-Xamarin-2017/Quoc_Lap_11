using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;
using Exercise1.Controllers;

namespace Exercise1.Views
{
    [Activity(Label = "LoginActivity", MainLauncher = true, Theme = "@android:style/Theme.Holo.Light")]
    public class LoginActivity : Activity
    {
        private TweetController tweetController;

        [InjectView(Resource.Id.edtUserName)] private TextView tvUsername;

        [InjectView(Resource.Id.edtPassword)] private TextView tvPassword;

        [InjectOnClick(Resource.Id.btnLogin)]
        void OnClickLoginButton(object sender, EventArgs e)
        {
            try
            {
                tweetController.Login(tvUsername.Text, tvPassword.Text);
                StartActivity(typeof(MainActivity));
            }
            catch (Exception exception)
            {
                Toast.MakeText(this, exception.Message, ToastLength.Short).Show();
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);
            Cheeseknife.Inject(this);
            tweetController = TweetController.Instance;
        }
    }
}