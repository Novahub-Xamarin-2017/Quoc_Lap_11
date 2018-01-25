using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Exercise1.Models;

namespace Exercise1.Controllers.Adapters
{
    class TweetPostAdapter : RecyclerView.Adapter
    {
        private readonly List<TweetPost> posts;

        public TweetPostAdapter(List<TweetPost> posts)
        {
            this.posts = posts;
        }

        public override int ItemCount => posts.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ((TweetPostViewHolder) holder).Post = posts[position];
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Tweet_Post_Layout, parent, false);
            return new TweetPostViewHolder(view);
        }
    }
}