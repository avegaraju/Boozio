using System.Collections.Generic;
using Shoolin.Appify.Core.Models;
using Shoolin.Appify.Core.Ports;

namespace Shoolin.Appify.Core.UseCases
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
