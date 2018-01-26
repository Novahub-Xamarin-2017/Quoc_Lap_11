using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Exercise2.Models;

namespace Exercise2.Controllers.Adapters
{
    class UserAdapter : RecyclerView.Adapter
    {
        private readonly List<User> users;

        public UserAdapter(List<User> users)
        {
            this.users = users;
        }

        public override int ItemCount => users.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ((UserViewHolder) holder).User = users[position];
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var inflater = LayoutInflater.From(parent.Context);
            var view = inflater.Inflate(Resource.Layout.SampleUserLayout, parent, false);
            return new UserViewHolder(view);
        }
    }
}