using System.Collections.Generic;
using System.Threading.Tasks;
using Boozio.Appify.Core.Models;

namespace Boozio.Appify.Core.Ports
{
    public interface IWhiskeyDataStore
    {
        IReadOnlyCollection<Whiskey> GetWishListWhiskey(ulong userId);
    }
}
