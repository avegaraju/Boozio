namespace Boozio.Appify.App
{
    internal class Settings
    {
        public Aws Aws { get; set; }
    }

    internal class Aws
    {
        public RegionConfig RegionConfig { get; set; }
        public string IdentityPoolId { get; set; }
    }

    internal class RegionConfig
    {
        public string SystemName { get; set; }
    }
}