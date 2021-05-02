using System;
using Xamarin.Auth;

namespace Boozio.Appify.App
{
    public class GoogleAuthHelper
    {

        public static OAuth2Authenticator Auth;

        internal OAuth2Authenticator Create(Settings settings)
        {
            var authenticator = new Xamarin.Auth.OAuth2Authenticator(
                clientId: settings.OAuth.Google.ClientId,
                clientSecret: "",
                scope: "email",
                authorizeUrl: new Uri("https://accounts.google.com/o/oauth2/v2/auth"),
                redirectUrl: new Uri("com.companyname.boozio.appify.app:/oauth2redirect"),
                accessTokenUrl: new Uri("https://oauth2.googleapis.com/token"),
                isUsingNativeUI: true);

            Xamarin.Auth.CustomTabsConfiguration.CustomTabsClosingMessage = null;

            return Auth = authenticator;
        }
    }
}