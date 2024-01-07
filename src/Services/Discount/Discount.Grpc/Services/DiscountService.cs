using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;
using Discount.Grpc.Repositories;
using Grpc.Core;

namespace Discount.Grpc.Services;

public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
{
    readonly ILogger<DiscountService> _logger;
    readonly IDiscountRepository _repository;
    readonly IMapper _mapper;

    public DiscountService(ILogger<DiscountService> logger, IDiscountRepository repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await _repository.GetDiscount(request.ProductName);
        return coupon == null
            ? throw new RpcException(new Status(StatusCode.NotFound, $"Could not find discount with product name = {request.ProductName}"))
            : _mapper.Map<CouponModel>(coupon);
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = _mapper.Map<Coupon>(request.Coupon);
        await _repository.CreateDiscount(coupon);
        string message = $"Discount is successfully created. ProductName:{coupon.ProductName}";
        _logger.LogInformation(message);
        return _mapper.Map<CouponModel>(coupon);
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupon = _mapper.Map<Coupon>(request.Coupon);
        await _repository.UpdateDiscount(coupon);
        _logger.LogInformation($"Discount is successfully updated. ProductName:{coupon.ProductName}");
        return _mapper.Map<CouponModel>(coupon);
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var deleted = await _repository.DeleteDiscount(request.ProductName);
        return new DeleteDiscountResponse
        {
            Success = deleted,
        };
    }
}
