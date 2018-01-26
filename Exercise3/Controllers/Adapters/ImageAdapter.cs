using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Exercise3.Models;

namespace Exercise3.Controllers.Adapters 
{
    class ImageAdapter : RecyclerView.Adapter
    {
        private List<Image> images;

        public List<Image> Images
        {
            get => images;
            set
            {
                images = value; 
                NotifyDataSetChanged();
            }
        }

        public ImageAdapter()
        {
            images = new List<Image>();
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ((ImageViewHolder) holder).Image = Images[position];
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var inflater = LayoutInflater.From(parent.Context);
            var view = inflater.Inflate(Resource.Layout.ImageViewLayout, parent, false);
            return new ImageViewHolder(view);
        }

        public override int ItemCount => Images.Count;
    }
}