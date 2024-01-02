﻿using Dapper;
using Discount.Api.Entities;
using Npgsql;
using System.Data;

namespace Discount.Api.Repositories;

public class DiscountRepository : IDiscountRepository
{
    NpgsqlConnection _connection;

    public DiscountRepository(IConfiguration configuration)
    {
        _connection = new(configuration.GetValue<string>("ConnectionString:ConnectionString"));
        _connection.Open();
    }

    public async Task<bool> CreateDiscount(Coupon coupon)
    {
        using var connection = _connection;
        var affected = await connection.ExecuteAsync("INSERT INTO Coupon(ProductName,Description,Amount) VALUES(@ProductName,@Description,@Amount)", new { coupon.ProductName, coupon.Description, coupon.Amount });
        return affected != 0;
    }

    public Task<bool> DeleteDiscount(string productName)
    {
        throw new NotImplementedException();
    }

    public async Task<Coupon> GetDiscount(string productName)
    {
        using var connection = _connection;

        var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
            ("SELECT * FROM Coupon WHERE ProductName=@ProductName",
            new { ProductName = productName });
        return coupon ?? new Coupon
        {
            ProductName = "No Discount",
            Amount = 0,
            Description = "No Discount Desc"
        };
    }

    public Task<bool> UpdateDiscount(Coupon coupon)
    {
        throw new NotImplementedException();
    }
}
