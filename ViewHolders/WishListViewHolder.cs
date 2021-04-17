using System;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Boozio.Appify.App.ViewHolders
{
    public class WishListViewHolder: RecyclerView.ViewHolder
    {
        public ImageView WhiskeyImageView { get; set; }
        public TextView WhiskeyNameTextView { get; set; }
        public TextView DistilleryNameTextView { get; set; }
        public TextView AbvTextView { get; set; }

        public WishListViewHolder(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public WishListViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            WhiskeyImageView = itemView.FindViewById<ImageView>(Resource.Id.wishListWhiskeyImage);
            WhiskeyNameTextView = itemView.FindViewById<TextView>(Resource.Id.wishListWhiskeyNameTextView);
            DistilleryNameTextView = itemView.FindViewById<TextView>(Resource.Id.wishListDistilleryTextView);
            AbvTextView = itemView.FindViewById<TextView>(Resource.Id.wishListAbvTextView);

            itemView.Click += (_, __) => listener(base.LayoutPosition);
        }
    }
}