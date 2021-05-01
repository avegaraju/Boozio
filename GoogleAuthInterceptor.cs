using System;
using Android.App;
using Android.Content;
using Android.OS;

namespace Boozio.Appify.App
{
    [Activity(Label = "GoogleAuthInterceptor")]
    [IntentFilter(actions: new[] { Intent.ActionView },
        Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
        DataSchemes = new[]
        {
            "com.companyname.boozio.appify.app"
        },
        DataPaths = new[]
        {
            "/oauth2redirect"
        })]
    public class GoogleAuthInterceptor : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            var intent = new Intent(this, typeof(MainActivity));
            intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.SingleTop);
            StartActivity(intent);
            SetContentView(Resource.Layout.activity_main);

            Finish();
        }
    }
}