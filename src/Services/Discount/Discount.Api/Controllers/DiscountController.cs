using Discount.Api.Entities;
using Discount.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Discount.Api.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class DiscountController : ControllerBase
{
    readonly IDiscountRepository _repository;

    public DiscountController(IDiscountRepository repository)
    {
        _repository = repository;
    }

    [HttpGet(Name = "GetDiscounts")]
    [ProducesResponseType(typeof(IEnumerable<Coupon>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDiscounts()
        => Ok(await _repository.GetDiscounts());

    [HttpGet("{productName}", Name = "GetDiscount")]
    [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDiscount(string productName)
        => Ok(await _repository.GetDiscount(productName));

    [HttpPost]
    [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateDiscount([FromBody] Coupon coupon)
    {
        await _repository.CreateDiscount(coupon);
        return CreatedAtRoute("GetDiscount", new { productName = coupon.ProductName }, coupon);
    }

    [HttpPut]
    [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateDiscount([FromBody] Coupon coupon)
        => Ok(await _repository.UpdateDiscount(coupon));

    [HttpDelete("{productName}", Name = "DeleteDiscount")]
    [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteDiscount(string productName)
        => Ok(await _repository.DeleteDiscount(productName));
}
