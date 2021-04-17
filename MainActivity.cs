using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Boozio.Appify.App.Adapters;
using Boozio.Appify.Core.Ports;
using Boozio.Appify.Core.UseCases;
using Boozio.Appify.Data;
using SimpleInjector;

namespace Boozio.Appify.App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private RecyclerView _wishListRecyclerView;
        private RecyclerView.LayoutManager _wishListRecyclerViewLayoutManger;
        private WishListAdapter _wishListAdapter;
        private Container _container;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            InitializeContainer();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            _wishListRecyclerViewLayoutManger = new LinearLayoutManager(this);
            _wishListAdapter = new WishListAdapter(_container.GetInstance<IWishListWhiskeyUseCase>(), 1);

            _wishListRecyclerView = FindViewById<RecyclerView>(Resource.Id.wishListRecyclerView);
            _wishListRecyclerView.SetLayoutManager(_wishListRecyclerViewLayoutManger);
            _wishListRecyclerView.SetAdapter(_wishListAdapter);
        }

        private void InitializeContainer()
        {
            _container = new SimpleInjector.Container();
            _container.Register<IWishListWhiskeyUseCase, WishListWhiskeyUseCase>();
            _container.Register<IWhiskeyDataStore, WhiskeyDataStore>();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}