using Basket.Api.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Basket.Api.Repositories;

public class BasketRepository : IBasketRepository
{
    readonly IDistributedCache _redisCache;

    public BasketRepository(IDistributedCache redisCache)
    {
        _redisCache = redisCache;
    }

    public async Task DeleteBasket(string userName)
    => await _redisCache.RemoveAsync(userName);

    public async Task<ShoppingCart> GetBasket(string userName)
    {
        if (!string.IsNullOrEmpty(userName))
        {
            var basket = await _redisCache.GetStringAsync(userName);
            if(!string.IsNullOrEmpty(basket))
                return JsonConvert.DeserializeObject<ShoppingCart>(basket)!;
        }
        return null!;
    }

    public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
    {
        //Overwrites object if exists
        await _redisCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));
        return await GetBasket(basket.UserName);
    }
}
