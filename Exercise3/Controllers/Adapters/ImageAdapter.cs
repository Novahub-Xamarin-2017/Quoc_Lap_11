using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Exercise3.Models;

namespace Exercise3.Controllers.Adapters 
{
    class ImageAdapter : RecyclerView.Adapter
    {
        private readonly List<Image> images;

        public ImageAdapter(List<Image> images)
        {
            this.images = images;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ((ImageViewHolder) holder).Image = images[position];
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var inflater = LayoutInflater.From(parent.Context);
            var view = inflater.Inflate(Resource.Layout.ImageViewLayout, parent, false);
            return new ImageViewHolder(view);
        }

        public override int ItemCount => images.Count;
    }
}