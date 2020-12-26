using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Shoolin.Appify.App.ViewHolders
{
    public class WishListViewHolder: RecyclerView.ViewHolder
    {
        public ImageView WhiskeyImageView { get; set; }
        public TextView WhiskeyTextView { get; set; }

        public WishListViewHolder(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public WishListViewHolder(View itemView) : base(itemView)
        {
            WhiskeyImageView = itemView.FindViewById<ImageView>(Resource.Id.wishListWhiskeyImage);
            WhiskeyTextView = itemView.FindViewById<TextView>(Resource.Id.wishListWhiskeyTextView);
        }
    }
}