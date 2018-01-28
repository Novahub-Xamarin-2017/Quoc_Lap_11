using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;
using Exercise5.Models;

namespace Exercise5.Controllers.Adapters
{
    class CityNameViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.tvCityName)] private TextView tvCityName;

        public City City
        {
            set => tvCityName.Text = value.Name;
        }

        public CityNameViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
        }
    }
}