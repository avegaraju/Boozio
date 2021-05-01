using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Widget;
using Boozio.Appify.App.Adapters;
using Boozio.Appify.Core.Ports;
using Boozio.Appify.Core.UseCases;
using Boozio.Appify.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;

namespace Boozio.Appify.App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private const string DevConfigurationFileName = "Boozio.Appify.App.Configuration.appsettings.dev.json";
        private const string ProductionConfigurationFileName = "Boozio.Appify.App.Configuration.appsettings.dev.json";

        private Settings _settings;
        private RecyclerView _wishListRecyclerView;
        private RecyclerView.LayoutManager _wishListRecyclerViewLayoutManger;
        private WishListAdapter _wishListAdapter;
        private IWishListWhiskeyUseCase _wishListWhiskeyUseCase;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            InitializeDependencies();

            SetContentView(Resource.Layout.login);
            

            var googleLoginButton = FindViewById<Button>(Resource.Id.googleLoginButton);
            googleLoginButton.Click += GoogleLoginButton_Click;
        }

        private void ShowWishList()
        {
            SetContentView(Resource.Layout.activity_main);

            _wishListRecyclerViewLayoutManger = new LinearLayoutManager(this);
            _wishListAdapter = new WishListAdapter(_wishListWhiskeyUseCase, 1);

            _wishListRecyclerView = FindViewById<RecyclerView>(Resource.Id.wishListRecyclerView);
            _wishListRecyclerView.SetLayoutManager(_wishListRecyclerViewLayoutManger);
            _wishListRecyclerView.SetAdapter(_wishListAdapter);
        }

        private void GoogleLoginButton_Click(object sender, EventArgs e)
        {
           var googleAuthHelper = new GoogleAuthHelper();
           var authenticator = googleAuthHelper.Create(_settings);

           authenticator.Completed += Authenticator_Completed;
           authenticator.Error += Authenticator_Error;

            var intent = authenticator.GetUI(this);
            StartActivity(intent);
        }

        private void Authenticator_Error(object sender, Xamarin.Auth.AuthenticatorErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Authenticator_Completed(object sender, Xamarin.Auth.AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                var token = new
                {
                    TokenType = e.Account.Properties["token_type"],
                    AccessToken = e.Account.Properties["access_token"]
                };

                ShowWishList();

            }
            else
            {
                //do something
            }
        }



        private void InitializeDependencies()
        {
            _settings = new Settings();

#if DEBUG
            _settings = GetDevelopmentEnvironmentSettings();
#else
            settings = GetProductionEnvironmentSettings();
#endif


            var credentials = new CognitoAWSCredentials(
                _settings.Aws.IdentityPoolId,
                RegionEndpoint.GetBySystemName(_settings.Aws.RegionConfig.SystemName)
            );

            AmazonDynamoDBConfig config = new AmazonDynamoDBConfig
            {
                RegionEndpoint = RegionEndpoint.EUWest1,
            };
            
            AmazonDynamoDBClient client = new AmazonDynamoDBClient(credentials, config);
            _wishListWhiskeyUseCase = new WishListWhiskeyUseCase(new WhiskeyDataStore(client));
        }

        private Settings GetDevelopmentEnvironmentSettings()
        {
            var stream = Assembly.GetAssembly(typeof(Settings)).GetManifestResourceStream(DevConfigurationFileName);
            
            using var reader = new StreamReader(stream);
            var settingsJson = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<Settings>(settingsJson);
        }

        private Settings GetProductionEnvironmentSettings()
        {
            return new Settings();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}