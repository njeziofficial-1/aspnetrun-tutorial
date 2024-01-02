using Discount.Api.Entities;
using Discount.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Discount.Api.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class DiscountController : ControllerBase
{
    IDiscountRepository _repository;

    public DiscountController(IDiscountRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{productName}", Name ="GetDiscount")]
    [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
    public async Task<IActionResult>GetDiscount(string productName)
        => Ok(await _repository.GetDiscount(productName));

    [HttpPost]
    [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateDiscount([FromBody]Coupon coupon)
    {
        await _repository.CreateDiscount(coupon);
        return CreatedAtRoute("GetDiscount", new {productName = coupon.ProductName}, coupon);
    }
}
