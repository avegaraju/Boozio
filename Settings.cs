using Xamarin.Auth;

namespace Boozio.Appify.App
{
    internal class Settings
    {
        public Aws Aws { get; set; }
        public OAuth OAuth { get; set; }
    }

    internal class Aws
    {
        public RegionConfig RegionConfig { get; set; }
        public string IdentityPoolId { get; set; }
    }

    internal class OAuth
    {
        public Google Google { get; set; }
    }

    internal class Google
    {
        public string ClientId { get; set; }
    }

    internal class RegionConfig
    {
        public string SystemName { get; set; }
    }
}