using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Bumptech.Glide;
using Com.Lilarcor.Cheeseknife;
using Exercise2.Models;
using Exercise2.Views;

namespace Exercise2.Controllers.Adapters
{
    class UserViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.imgAvar)] private ImageView imgAvar;

        [InjectView(Resource.Id.tvLogin)] private TextView tvLogin;

        [InjectView(Resource.Id.tvEmail)] private TextView tvEmail;

        private User user;

        public User User
        {
            set
            {
                user = value;
                tvLogin.Text = value.Login;
                tvEmail.Text = value.Email;
                Glide.With(ItemView).Load(value.AvatarUrl).Into(imgAvar);
            }
        }

        public UserViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
            itemView.Click += (sender, e) =>
            {
                var intent = new Intent(itemView.Context, typeof(UserDetailActivity));
                intent.PutExtra("Login", user.Login);
                itemView.Context.StartActivity(intent);
            };
        }
    }
}