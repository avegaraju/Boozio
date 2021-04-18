using System.Collections.Generic;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Boozio.Appify.Core.Models;
using Boozio.Appify.Core.Ports;

namespace Boozio.Appify.Data
{
    public class WhiskeyDataStore: IWhiskeyDataStore
    {
        private readonly IAmazonDynamoDB _client;

        public WhiskeyDataStore(IAmazonDynamoDB client)
        {
            _client = client;
        }

        public IReadOnlyCollection<Whiskey> GetWishListWhiskey(ulong userId)
        {
            GetItemRequest request = new GetItemRequest
            {
                AttributesToGet = new List<string>
                {
                    "SPIRITNAME",
                    "DISTILLER"
                },
                TableName = "BoozlogStore"
            };

            var items = _client.GetItemAsync(request);

            var name = items.Result.Item["SPIRITNAME"];
            var distiller = items.Result.Item["DISTILLER"];

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
