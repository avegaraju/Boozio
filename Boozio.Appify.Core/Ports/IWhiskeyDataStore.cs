using System.Collections.Generic;
using Boozio.Appify.Core.Models;

namespace Boozio.Appify.Core.Ports
{
    public interface IWhiskeyDataStore
    {
        IReadOnlyCollection<Whiskey> GetWishListWhiskey(ulong userId);
    }
}
