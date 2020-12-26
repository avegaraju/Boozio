using System.Collections.Generic;
using Shoolin.Appify.Core.Models;
using Shoolin.Appify.Core.Ports;

namespace Shoolin.Appify.Data
{
    public class WhiskeyDataStore: IWhiskeyDataStore
    {
        public IReadOnlyCollection<Whiskey> GetWishListWhiskey(ulong userId)
        {
            return new List<Whiskey>
            {
                new Whiskey(1, "Lagavulin 16", "Lagavulin", 46, Type.SingleMalt, null),
                new Whiskey(2, "Glenlivet Nadura Cask strength", "Glenlivet", 63, Type.SingleMalt, null),
                new Whiskey(3, "Makers mark", "Makers maark", 46, Type.Bourbon, null),
                new Whiskey(3, "Makers mark", "Makers maark", 46, Type.Bourbon, null),
                new Whiskey(3, "Makers mark", "Makers maark", 46, Type.Bourbon, null),
                new Whiskey(3, "Makers mark", "Makers maark", 46, Type.Bourbon, null),
                new Whiskey(3, "Makers mark", "Makers maark", 46, Type.Bourbon, null),
                new Whiskey(3, "Makers mark", "Makers maark", 46, Type.Bourbon, null),
                new Whiskey(3, "Makers mark", "Makers maark", 46, Type.Bourbon, null),
                new Whiskey(3, "Makers mark", "Makers maark", 46, Type.Bourbon, null),
                new Whiskey(3, "Makers mark", "Makers maark", 46, Type.Bourbon, null),
                new Whiskey(3, "Makers mark", "Makers maark", 46, Type.Bourbon, null),
                new Whiskey(3, "Makers mark", "Makers maark", 46, Type.Bourbon, null),
                new Whiskey(3, "Makers mark", "Makers maark", 46, Type.Bourbon, null),
                new Whiskey(3, "Makers mark", "Makers maark", 46, Type.Bourbon, null),
                new Whiskey(3, "Makers mark", "Makers maark", 46, Type.Bourbon, null),
                new Whiskey(3, "Makers mark", "Makers maark", 46, Type.Bourbon, null),
                new Whiskey(3, "Makers mark", "Makers maark", 46, Type.Bourbon, null),
                new Whiskey(3, "Makers mark", "Makers maark", 46, Type.Bourbon, null),
            };
        }
    }
}
