using Basket.Api.Entities;

namespace Basket.Api.Repositories;

public interface IBasketRepository
{
    Task<ShoppingCart> GetBasket(string userName);
    Task<ShoppingCart> UpdateBasket(ShoppingCart basket); //Both adds and updates
    Task DeleteBasket(string userName);
}
