using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Boozio.Appify.Core.Models;
using Boozio.Appify.Core.Ports;
using Type = Boozio.Appify.Core.Models.Type;

namespace Boozio.Appify.Data
{
    public class WhiskeyDataStore: IWhiskeyDataStore
    {
        private readonly IAmazonDynamoDB _client;

        public WhiskeyDataStore(AmazonDynamoDBClient client)
        {
            _client = client;
        }

        public IReadOnlyCollection<Whiskey> GetWishListWhiskey(ulong userId)
        {
            try
            {
                GetItemRequest request = new GetItemRequest
                {
                    TableName = "BoozlogStore",
                    Key = new Dictionary<string, AttributeValue>
                    {
                        {"PK", new AttributeValue("WKY#1")},
                        {"SK", new AttributeValue("WKY#1")}
                    }
                };

                var items = _client.GetItemAsync(request).GetAwaiter().GetResult();
            }
            catch (Exception exception)
            {
                throw;
            }

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
