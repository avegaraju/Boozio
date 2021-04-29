using System.Collections.Generic;
using System.Threading.Tasks;
using Boozio.Appify.Core.Models;
using Boozio.Appify.Core.Ports;

namespace Boozio.Appify.Core.UseCases
{
    public interface IWishListWhiskeyUseCase
    {
        IReadOnlyCollection<Whiskey> Get(ulong userId);
    }

    public class WishListWhiskeyUseCase: IWishListWhiskeyUseCase
    {
        private readonly IWhiskeyDataStore _whiskeyDataStore;

        public WishListWhiskeyUseCase(IWhiskeyDataStore whiskeyDataStore)
        {
            _whiskeyDataStore = whiskeyDataStore;
        }
        public IReadOnlyCollection<Whiskey> Get(ulong userId)
        {
            return _whiskeyDataStore.GetWishListWhiskey(userId);
        }
    }
}
