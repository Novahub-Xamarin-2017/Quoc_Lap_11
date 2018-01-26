using System.Linq;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Bumptech.Glide;
using Com.Lilarcor.Cheeseknife;
using Exercise3.Models;

namespace Exercise3.Controllers.Adapters
{
    class ImageViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.image)] private ImageView image;

        [InjectView(Resource.Id.tvTitle)] private TextView tvTitle;

        public Image Image
        {
            set
            {
                Glide.With(ItemView).Load(value.DisplaySizes.First().Uri).Into(image);
                tvTitle.Text = value.Title;
            }
        }
        public ImageViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
        }
    }
}