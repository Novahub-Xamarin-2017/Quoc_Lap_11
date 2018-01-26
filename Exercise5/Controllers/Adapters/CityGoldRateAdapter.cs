using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Exercise5.Models;

namespace Exercise5.Controllers.Adapters
{
    class CityGoldRateAdapter : RecyclerView.Adapter
    {
        private const int TypeCityName = 1, TypeGoldRate = 2;

        private List<object> cityGoldRates = new List<object>();

        public List<object> CityGoldRates
        {
            set
            {
                cityGoldRates = value; 
                NotifyDataSetChanged();
            }
        }

        public override int ItemCount => cityGoldRates.Count;

        public override int GetItemViewType(int position)
        {
            if (cityGoldRates[position] is City)
                return TypeCityName;
            if (cityGoldRates[position] is GoldRate)
            {
                return TypeGoldRate;
            }
            return -1;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            switch (holder.ItemViewType)
            {
                case TypeCityName:
                    ((CityNameViewHolder) holder).City = (City)cityGoldRates[position];
                    break;
                case TypeGoldRate:
                    ((GoldRateViewHolder)holder).GoldRate = (GoldRate)cityGoldRates[position];
                    break;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var inflater = LayoutInflater.From(parent.Context);
            switch (viewType)
            {
                case TypeCityName:
                    return new CityNameViewHolder(inflater.Inflate(Resource.Layout.CityLayout, parent, false));
                case TypeGoldRate:
                    return new GoldRateViewHolder(inflater.Inflate(Resource.Layout.GoldRateLayout, parent, false));
                default:
                    return null;
            }
        }
    }
}