using System.Linq.Expressions;
using Amazon.DynamoDBv2;
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
using SimpleInjector.Lifestyles;

namespace Boozio.Appify.App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private RecyclerView _wishListRecyclerView;
        private RecyclerView.LayoutManager _wishListRecyclerViewLayoutManger;
        private WishListAdapter _wishListAdapter;
        private Container _container;
        private IWishListWhiskeyUseCase _wishListWhiskeyUseCase;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            InitializeDependencies();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            _wishListRecyclerViewLayoutManger = new LinearLayoutManager(this);
            _wishListAdapter = new WishListAdapter(_wishListWhiskeyUseCase, 1);

            _wishListRecyclerView = FindViewById<RecyclerView>(Resource.Id.wishListRecyclerView);
            _wishListRecyclerView.SetLayoutManager(_wishListRecyclerViewLayoutManger);
            _wishListRecyclerView.SetAdapter(_wishListAdapter);
        }

        private void InitializeDependencies()
        {
            AmazonDynamoDBConfig config = new AmazonDynamoDBConfig { ServiceURL = "http://localhost:8000" };
            IAmazonDynamoDB amazonDynamoDb = new AmazonDynamoDBClient(config);
            _wishListWhiskeyUseCase = new WishListWhiskeyUseCase(new WhiskeyDataStore(amazonDynamoDb));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}