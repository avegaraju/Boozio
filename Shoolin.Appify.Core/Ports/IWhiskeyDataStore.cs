using System.Collections.Generic;
using Shoolin.Appify.Core.Models;

namespace Shoolin.Appify.Core.Ports
{
    public interface IWhiskeyDataStore
    {
        IReadOnlyCollection<Whiskey> GetWishListWhiskey(ulong userId);
    }
}
