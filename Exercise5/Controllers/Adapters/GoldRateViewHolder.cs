using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;
using Exercise5.Models;

namespace Exercise5.Controllers.Adapters
{
    class GoldRateViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.tvBuy)] private TextView tvBuy;

        [InjectView(Resource.Id.tvSell)] private TextView tvSell;

        [InjectView(Resource.Id.tvGoldType)] private TextView tvGoldType;

        public GoldRate GoldRate
        {
            set
            {
                tvGoldType.Text = value.Type;
                tvBuy.Text = value.Buy;
                tvSell.Text = value.Sell;
            }
        }

        public GoldRateViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
        }
    }
}