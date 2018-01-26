using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Exercise6.Models;

namespace Exercise6.Controllers.Adapters
{
    class CurrencyAdapter : RecyclerView.Adapter
    {
        private List<Exrate> exrates = new List<Exrate>();

        public List<Exrate> Exrates
        {
            get => exrates;
            set
            {
                exrates = value;
                NotifyDataSetChanged();
            }
        }

        public override int ItemCount => exrates.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ((CurrencyViewHolder) holder).Exrate = exrates[position];
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var inflater = LayoutInflater.From(parent.Context);
            var view = inflater.Inflate(Resource.Layout.CurrencyTradeViewLayout, parent, false);
            return new CurrencyViewHolder(view);
        }
    }
}