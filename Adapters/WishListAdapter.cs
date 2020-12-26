using System.Collections.Generic;
using System.Linq;
using Android.Support.V7.Widget;
using Android.Views;
using Shoolin.Appify.App.ViewHolders;
using Shoolin.Appify.Core.Models;
using Shoolin.Appify.Core.UseCases;

namespace Shoolin.Appify.App.Adapters
{
    public class WishListAdapter: RecyclerView.Adapter
    {
        private readonly IReadOnlyCollection<Whiskey> _wishListWhiskeys;

        public WishListAdapter(IWishListWhiskeyUseCase wishListWhiskeyUseCase, ulong userId)
        {
            _wishListWhiskeys = wishListWhiskeyUseCase.Get(userId);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (!(holder is WishListViewHolder wishListViewHolder)) return;

            wishListViewHolder.WhiskeyImageView = null; //_wishListWhiskeyUseCase.GetImage();
            wishListViewHolder.WhiskeyTextView.Text = _wishListWhiskeys.ElementAt(position).Name;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView =
                LayoutInflater.From(parent.Context).Inflate(Resource.Layout.wishlist_viewholder, parent, false);

            WishListViewHolder wishListViewHolder = new WishListViewHolder(itemView);
            return wishListViewHolder;
        }

        public override int ItemCount => _wishListWhiskeys.Count;
    }
}