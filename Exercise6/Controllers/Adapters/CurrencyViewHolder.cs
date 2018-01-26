using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;
using Exercise6.Models;

namespace Exercise6.Controllers.Adapters
{
    class CurrencyViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.tvCurrencyCode)] private TextView tvCurrencyCode;
        [InjectView(Resource.Id.tvCurrencyName)] private TextView tvCurrencyName;
        [InjectView(Resource.Id.tvBuy)] private TextView tvBuy;
        [InjectView(Resource.Id.tvSell)] private TextView tvSell;
        [InjectView(Resource.Id.tvTransfer)] private TextView tvTransfer;

        private Exrate exrate;

        public Exrate Exrate
        {
            get => exrate;
            set
            {
                exrate = value;
                tvCurrencyCode.Text = value.CurrencyCode;
                tvCurrencyName.Text = value.CurrencyName;
                tvBuy.Text = value.Buy;
                tvSell.Text = value.Sell;
                tvTransfer.Text = value.Transfer;
            }
        }

        public CurrencyViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
        }

      
    }
}