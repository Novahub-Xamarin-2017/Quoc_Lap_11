using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Bumptech.Glide;
using Com.Lilarcor.Cheeseknife;
using Exercise1.Models;

namespace Exercise1.Controllers.Adapters
{
    class TweetPostViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.tvAuthor)] private TextView tvAuthor;

        [InjectView(Resource.Id.tvContent)] private TextView tvContent;

        [InjectView(Resource.Id.image)] private ImageView image;

        public TweetPost Post
        {
            set
            {
                tvAuthor.Text = value.Author;
                tvContent.Text = value.Content;
                if (value.Images != null)
                {
                    Glide.With(ItemView).Load(value.Images[0]).Into(image);
                }
            }
        }

        public TweetPostViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
        }
    }
}