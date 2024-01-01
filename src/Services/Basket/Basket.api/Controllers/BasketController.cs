﻿using Basket.Api.Entities;
using Basket.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.Api.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class BasketController : ControllerBase
{
    readonly IBasketRepository _repository;

    public BasketController(IBasketRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{userName}", Name = "GetBasket")]
    [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBasket(string userName)
        => Ok(await _repository.GetBasket(userName) ?? new ShoppingCart(userName));

    [HttpPost]
    [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateBasket([FromBody] ShoppingCart basket)
    => Ok(await _repository.UpdateBasket(basket));

    [HttpDelete("{userName}", Name = "DeleteBasket")]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteBasket(string userName)
    {
        await _repository.DeleteBasket(userName);
        return Ok();
    }
}
